using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alguamcoisa.Utils;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class EstoqueForm : alguamcoisa.Utils.ThemedForm
    {

        private readonly RepositorioProdutos _repositorioProdutos = new RepositorioProdutos();
        private readonly RepositorioCategorias _repositorioCategorias = new RepositorioCategorias();
        private readonly RepositorioMovimentos _repositorioMovimentos = new RepositorioMovimentos();

        private List<Produto> _todosProdutos = new List<Produto>();
        private List<Produto> _produtosFiltrados = new List<Produto>();
        private bool _carregando = false;

        // Timer para "debounce" da busca (evita travar a cada tecla)
        private readonly System.Windows.Forms.Timer _filtroTimer;

        // Painel de edição embutido no pnlGrid
        private Panel? _painelEditor;

        public EstoqueForm()
        {
            InitializeComponent();
            GridHelper.ConfigurarGridCompleto(dgvEstoque);

            _filtroTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _filtroTimer.Tick += (s, e) =>
            {
                _filtroTimer.Stop();
                AplicarFiltros();
            };

            Load += EstoqueForm_Load;

            cboFiltro.SelectedIndexChanged += cboFiltro_SelectedIndexChanged;
            txtBuscarProduto.TextChanged += txtBuscarProduto_TextChanged;

            // >>> CORREÇÃO DO PROBLEMA <<<
            cboCategoriaFiltro.SelectedIndexChanged += cboCategoriaFiltro_SelectedIndexChanged;

            btnEditar.Click += btnEditar_Click;
            btnExcluir.Click += btnExcluir_Click;
            btnQuantidade.Click += btnQuantidade_Click;
            btnImprimir.Click += btnImprimir_Click;
            btnImportardadosSql.Click += btnImportardadosSql_Click;

            dgvEstoque.SelectionChanged += (s, e) => AtualizarEstadoBotoes();

            dgvEstoque.DataBindingComplete += (s, e) =>
            {
                AplicarCorValidade();
                AtualizarEstadoBotoes();
            };
        }


        #region LOAD / CARREGAMENTO

        private async void EstoqueForm_Load(object? sender, EventArgs e)
        {
            try
            {
                ConfigurarGrid();
                ConfigurarFiltro();
                await RecarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o estoque:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
           
            dgvEstoque.AutoGenerateColumns = false;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.MultiSelect = false;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dgvEstoque.RowHeadersVisible = false;

            dgvEstoque.Columns.Clear();

            // Produto
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Produto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 250
            });

            // Categoria
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoria",
                Width = 120
            });

            // Quantidade
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantidade",
                HeaderText = "Qtd",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2"
                }
            });

            // Unidade
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unidade",
                HeaderText = "Unid.",
                Width = 60
            });

            // Local depósito
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LocalDeposito",
                HeaderText = "Local",
                Width = 120
            });

            // Validade
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Validade",             
                DataPropertyName = "Validade",
                HeaderText = "Validade",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "dd/MM/yyyy"
                }
            });


            // Estoque mínimo
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstoqueMinimo",
                HeaderText = "Est. Mín.",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2"
                }
            });

            // Fabricante
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fabricante",
                HeaderText = "Fabricante",
                Width = 160
            });

            // Estado físico
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstadoFisico",
                HeaderText = "Estado Físico",
                Width = 120
            });

            // Recipiente
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Recipiente",
                HeaderText = "Recipiente",
                Width = 120
            });

            // Local específico
            dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LocalEspecifico",
                HeaderText = "Local Específico",
                Width = 160
            });

            HabilitarDoubleBuffering(dgvEstoque);
        }

        private void txtBuscarProduto_TextChanged(object sender, EventArgs e)
        {
            if (_carregando) return;
            AplicarFiltros();
        }

        private void ConfigurarFiltro()
        {
            cboFiltro.Items.Clear();
            cboFiltro.Items.Add("Todos");
            cboFiltro.Items.Add("Sem validade");
            cboFiltro.Items.Add("Vencidos");
            cboFiltro.Items.Add("Vencem em até 30 dias");
            cboFiltro.SelectedIndex = 0;
        }

        private void PreencherCategoriasNoFiltro()
        {
            // Guardar item selecionado atual da COMBO DE CATEGORIA
            string? selecionado = cboCategoriaFiltro.SelectedItem as string;

            // Item padrão
            cboCategoriaFiltro.Items.Clear();
            cboCategoriaFiltro.Items.Add("Todas");

            // Buscar categorias distintas a partir dos produtos carregados
            var categorias = _todosProdutos
                .Select(p => p.Categoria)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(c => c)
                .ToList();

            foreach (var cat in categorias)
            {
                cboCategoriaFiltro.Items.Add(cat);
            }

            // Tentar restaurar a seleção anterior
            if (!string.IsNullOrEmpty(selecionado) &&
                cboCategoriaFiltro.Items.Cast<object>().Any(i =>
                    string.Equals(i.ToString(), selecionado, StringComparison.OrdinalIgnoreCase)))
            {
                cboCategoriaFiltro.SelectedItem = selecionado;
            }
            else
            {
                cboCategoriaFiltro.SelectedIndex = 0; // "Todas"
            }
        }


        private async Task RecarregarDadosAsync()
        {
            _carregando = true;
            try
            {
                // Carrega todos os produtos de uma vez para não ficar indo e voltando no banco
                _todosProdutos = _repositorioProdutos.Listar();
                _produtosFiltrados = _todosProdutos.ToList();

                dgvEstoque.DataSource = null;
                dgvEstoque.DataSource = _produtosFiltrados;

                AplicarCorValidade();
                dgvEstoque.ClearSelection();
                PreencherCategoriasNoFiltro();
                AtualizarEstadoBotoes();
            }
            finally
            {
                _carregando = false;
            }
        }

        #endregion

        #region FILTROS / BUSCA

        private void cboFiltro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_carregando) return;
            AplicarFiltros();
        }

        private void cboCategoriaFiltro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_carregando) return;
            AplicarFiltros();
        }


        private void AplicarFiltros()
        {
            if (_carregando) return;

            IEnumerable<Produto> query = _todosProdutos;

            // Texto de busca
            string textoBusca = txtBuscarProduto.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(textoBusca))
            {
                var termos = textoBusca
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                query = query.Where(p =>
                {
                    string nome = p.Nome ?? string.Empty;
                    string categoria = p.Categoria ?? string.Empty;
                    string fabricante = p.Fabricante ?? string.Empty;
                    string local = p.LocalDeposito ?? string.Empty;
                    string recipiente = p.Recipiente ?? string.Empty;
                    string localEspecifico = p.LocalEspecifico ?? string.Empty;

                    foreach (var termo in termos)
                    {
                        if (!nome.Contains(termo, StringComparison.OrdinalIgnoreCase) &&
                            !categoria.Contains(termo, StringComparison.OrdinalIgnoreCase) &&
                            !fabricante.Contains(termo, StringComparison.OrdinalIgnoreCase) &&
                            !local.Contains(termo, StringComparison.OrdinalIgnoreCase) &&
                            !recipiente.Contains(termo, StringComparison.OrdinalIgnoreCase) &&
                            !localEspecifico.Contains(termo, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }

                    return true;
                });
            }

            // Filtro de validade e categoria
            string filtroValidade = cboFiltro.SelectedItem as string ?? "Todos";
            DateTime hoje = DateTime.Today;

            if (filtroValidade.Equals("Sem validade", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(p => !p.Validade.HasValue);
            }
            else if (filtroValidade.Equals("Vencidos", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(p =>
                    p.Validade.HasValue && p.Validade.Value.Date < hoje);
            }
            else if (filtroValidade.Equals("Vencem em até 30 dias", StringComparison.OrdinalIgnoreCase))
            {
                DateTime limite = hoje.AddDays(30);
                query = query.Where(p =>
                    p.Validade.HasValue &&
                    p.Validade.Value.Date >= hoje &&
                    p.Validade.Value.Date <= limite);
            }

            // Filtro de categoria (combo cboCategoriaFiltro)
            string categoriaFiltro = cboCategoriaFiltro.SelectedItem as string ?? "Todas";
            if (!string.IsNullOrWhiteSpace(categoriaFiltro) &&
                !categoriaFiltro.Equals("Todas", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(p =>
                    string.Equals(p.Categoria ?? string.Empty,
                                  categoriaFiltro,
                                  StringComparison.OrdinalIgnoreCase));
            }


            _produtosFiltrados = query
                .OrderBy(p => p.Nome)
                .ThenBy(p => p.Categoria)
                .ToList();

            dgvEstoque.DataSource = null;
            dgvEstoque.DataSource = _produtosFiltrados;

            AplicarCorValidade();
            AtualizarEstadoBotoes();
        }

        private void AplicarCorValidade()
        {
            if (dgvEstoque.Columns["Validade"] == null)
                return;

            int colIndex = dgvEstoque.Columns["Validade"].Index;
            DateTime hoje = DateTime.Today;

            foreach (DataGridViewRow row in dgvEstoque.Rows)
            {
                var cell = row.Cells[colIndex];
                if (cell.Value == null || cell.Value == DBNull.Value)
                {
                    // Sem validade -> cor padrão
                    cell.Style.BackColor = dgvEstoque.DefaultCellStyle.BackColor;
                    cell.Style.ForeColor = dgvEstoque.DefaultCellStyle.ForeColor;
                    continue;
                }

                if (cell.Value is DateTime dt)
                {
                    if (dt.Date < hoje)
                    {
                        // Vencido
                        cell.Style.BackColor = Color.LightCoral;
                        cell.Style.ForeColor = Color.Black;
                    }
                    else if (dt.Date <= hoje.AddDays(30))
                    {
                        // Prestes a vencer
                        cell.Style.BackColor = Color.Khaki;
                        cell.Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        cell.Style.BackColor = dgvEstoque.DefaultCellStyle.BackColor;
                        cell.Style.ForeColor = dgvEstoque.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }

        #endregion

        #region AÇÕES (EDITAR / EXCLUIR / QUANTIDADE / IMPRIMIR / IMPORTAR)

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            var produto = ObterProdutoSelecionado();
            if (produto == null)
            {
                MessageBox.Show("Selecione um produto para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AbrirCadastroProdutoNoPainel(produto);
        }

        private async void btnExcluir_Click(object? sender, EventArgs e)
        {
            var produto = ObterProdutoSelecionado();
            if (produto == null)
            {
                MessageBox.Show("Selecione um produto para excluir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resp = MessageBox.Show(
                $"Deseja realmente excluir o produto:\n\n{produto.Nome}?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            // Se já existir movimento vinculado a este produto,
            // não permitimos a exclusão para não quebrar a FK.
            if (_repositorioMovimentos.ExisteMovimentoParaProduto(produto.Id))
            {
                MessageBox.Show(
                    "Não é possível excluir este produto porque já existem movimentos de estoque registrados para ele.\n\n" +
                    "Para retirá-lo do estoque, utilize o ajuste de quantidade (zerar estoque) em vez de excluir.",
                    "Exclusão não permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Se tinha estoque, registra movimento de SAÍDA para o relatório,
                // mas sem vincular ao ProdutoId (para não bloquear a exclusão).
                if (produto.Quantidade > 0)
                {
                    RegistrarMovimento(
                        produto,
                        TipoMovimento.Saida,
                        produto.Quantidade,
                        "Exclusão do cadastro de produto no EstoqueForm (estoque zerado).",
                        false);
                }

                _repositorioProdutos.Excluir(produto.Id);

                await RecarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnQuantidade_Click(object? sender, EventArgs e)
        {
            var produto = ObterProdutoSelecionado();
            if (produto == null)
            {
                MessageBox.Show("Selecione um produto para ajustar a quantidade.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new AjusteQuantidadeDialog(produto);
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            decimal quantidade = dlg.Quantidade;
            if (quantidade <= 0)
            {
                MessageBox.Show("Informe uma quantidade maior que zero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal quantidadeOriginal = produto.Quantidade;
            decimal novaQuantidade;

            if (dlg.TipoMovimento == TipoMovimento.Entrada)
            {
                novaQuantidade = quantidadeOriginal + quantidade;
            }
            else
            {
                if (quantidade > quantidadeOriginal)
                {
                    var resp = MessageBox.Show(
                        "A quantidade informada é maior que o estoque atual.\n\n" +
                        "Deseja zerar o estoque deste produto?",
                        "Confirmar saída",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resp != DialogResult.Yes)
                        return;

                    // Se o usuário optou por zerar, usamos o total atual como quantidade de saída
                    quantidade = quantidadeOriginal;
                }

                novaQuantidade = quantidadeOriginal - quantidade;
            }

            produto.Quantidade = novaQuantidade;

            try
            {
                _repositorioProdutos.Atualizar(produto);

                // Registra movimento (entrada ou saída)
                RegistrarMovimento(
                    produto,
                    dlg.TipoMovimento,
                    quantidade,
                    dlg.Observacao);

                MessageBox.Show("Quantidade ajustada com sucesso.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await RecarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ajustar quantidade:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            if (_produtosFiltrados == null || _produtosFiltrados.Count == 0)
            {
                MessageBox.Show("Não há produtos para imprimir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using PrintDocument doc = new PrintDocument();
            doc.DocumentName = "Relatório de Estoque";
            doc.DefaultPageSettings.Landscape = true;

            int linhaAtual = 0;

            doc.PrintPage += (s, ev) =>
            {
                float y = ev.MarginBounds.Top;
                float x = ev.MarginBounds.Left;
                var fonteTitulo = new Font("Segoe UI", 12, FontStyle.Bold);
                var fonteCabecalho = new Font("Segoe UI", 9, FontStyle.Bold);
                var fonteTexto = new Font("Segoe UI", 9);

                ev.Graphics.DrawString("Relatório de Estoque", fonteTitulo, Brushes.Black, x, y);
                y += 30;

                ev.Graphics.DrawString("Produto", fonteCabecalho, Brushes.Black, x, y);
                ev.Graphics.DrawString("Categoria", fonteCabecalho, Brushes.Black, x + 300, y);
                ev.Graphics.DrawString("Qtd", fonteCabecalho, Brushes.Black, x + 480, y);
                ev.Graphics.DrawString("Unid.", fonteCabecalho, Brushes.Black, x + 520, y);
                ev.Graphics.DrawString("Validade", fonteCabecalho, Brushes.Black, x + 580, y);
                y += 20;

                while (linhaAtual < _produtosFiltrados.Count)
                {
                    var p = _produtosFiltrados[linhaAtual];

                    ev.Graphics.DrawString(p.Nome, fonteTexto, Brushes.Black, x, y);
                    ev.Graphics.DrawString(p.Categoria, fonteTexto, Brushes.Black, x + 300, y);
                    ev.Graphics.DrawString(p.Quantidade.ToString("N2"), fonteTexto, Brushes.Black, x + 480, y);
                    ev.Graphics.DrawString(p.Unidade, fonteTexto, Brushes.Black, x + 520, y);
                    ev.Graphics.DrawString(p.Validade?.ToString("dd/MM/yyyy") ?? "-", fonteTexto, Brushes.Black, x + 580, y);

                    y += 18;

                    if (y > ev.MarginBounds.Bottom - 20)
                    {
                        linhaAtual++;
                        ev.HasMorePages = linhaAtual < _produtosFiltrados.Count;
                        return;
                    }

                    linhaAtual++;
                }

                ev.HasMorePages = false;
            };

            using PrintDialog dlg = new PrintDialog
            {
                Document = doc,
                UseEXDialog = true
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private async void btnImportardadosSql_Click(object? sender, EventArgs e)
        {
            try
            {
                // Garante que temos a lista de produtos carregada
                if (_todosProdutos == null || _todosProdutos.Count == 0)
                {
                    await RecarregarDadosAsync();
                }

                var resp = MessageBox.Show(
                    "Esta ação irá registrar uma ENTRADA de estoque (para fins de histórico) " +
                    "para todos os produtos que já possuem quantidade em estoque e ainda não possuem " +
                    "movimentos registrados.\n\n" +
                    "Os saldos atuais NÃO serão alterados, apenas será gerado o registro no relatório " +
                    "de movimentos com a quantidade atual.\n\n" +
                    "Deseja continuar?",
                    "Importar dados para movimentos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp != DialogResult.Yes)
                    return;

                int movimentosCriados = 0;

                foreach (var produto in _todosProdutos)
                {
                    // Só interessa quem tem estoque > 0
                    if (produto.Quantidade <= 0)
                        continue;

                    // Se já existe qualquer movimento para este produto, não criamos de novo
                    if (_repositorioMovimentos.ExisteMovimentoParaProduto(produto.Id))
                        continue;

                    // Cria um movimento de ENTRADA com a quantidade atual
                    RegistrarMovimento(
                        produto,
                        TipoMovimento.Entrada,
                        produto.Quantidade,
                        "Importação inicial de estoque via botão 'Importar Dados'.");

                    movimentosCriados++;
                }

                // Recarrega dados na tela
                await RecarregarDadosAsync();

                // Feedback para o usuário
                string mensagem;
                if (movimentosCriados == 0)
                {
                    mensagem = "Nenhum movimento foi criado.\n\n" +
                               "Todos os produtos já possuíam histórico de movimentos " +
                               "ou estão com quantidade zerada.";
                }
                else
                {
                    mensagem = $"Importação concluída.\n\n" +
                               $"Movimentos de ENTRADA criados para {movimentosCriados} produto(s).";
                }

                MessageBox.Show(mensagem,
                    "Importar Dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar dados:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region HELPERS

        private void AtualizarEstadoBotoes()
        {
            bool temSelecao = dgvEstoque.CurrentRow?.DataBoundItem is Produto;
            bool temItens = _produtosFiltrados != null && _produtosFiltrados.Count > 0;

            btnEditar.Enabled = temSelecao;
            btnExcluir.Enabled = temSelecao;
            btnQuantidade.Enabled = temSelecao;
            btnImprimir.Enabled = temItens;
        }

        private static void HabilitarDoubleBuffering(DataGridView grid)
        {
            // Truque clássico pra remover flicker do DataGridView
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, grid, new object[] { true });
        }

        private Produto? ObterProdutoSelecionado()
        {
            if (dgvEstoque.CurrentRow?.DataBoundItem is Produto produto)
                return produto;

            return null;
        }

        private void AbrirCadastroProdutoNoPainel(Produto produto)
        {
            // Largura base do CadastroProduto no designer (em 96 DPI)
            const int larguraCadastroProdutoBase = 1294;

            // Cria (ou recria) o painel de edição usando o helper global
            _painelEditor = PainelEditorHelper.CriarOuSubstituirPainelEditor(
                container: pnlGrid,               // onde ficará o painel (pai do grid)
                painelEditor: ref _painelEditor,
                backColor: AppTheme.BackPanel,
                dock: DockStyle.Right,
                padding: new Padding(8),
                percentual: null,                 // usa o padrão (45%) se couber
                minEditor: null,                  // usa MinEditorPadrao
                minGrid: null,                    // usa MinGridPadrao
                larguraFormBase96Dpi: larguraCadastroProdutoBase
            );

            // Form de edição hospedado dentro do painel
            var frm = new CadastroProduto(produto)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Quando o form for fechado, limpamos o painel e recarregamos o grid
            frm.Disposed += async (_, __) => await FecharPainelEditorAsync(true);

            _painelEditor.Controls.Add(frm);
            frm.Show();
        }





        private async Task FecharPainelEditorAsync(bool recarregar)
        {
            if (_painelEditor != null)
            {
                if (pnlGrid.Controls.Contains(_painelEditor))
                    pnlGrid.Controls.Remove(_painelEditor);

                _painelEditor.Dispose();
                _painelEditor = null;
            }

            if (recarregar)
                await RecarregarDadosAsync();
        }

        private void RegistrarMovimento(
            Produto produto,
            TipoMovimento tipoMovimento,
            decimal quantidade,
            string? observacao,
            bool vincularAoProduto = true)
        {
            if (quantidade <= 0)
                return;

            var movimento = new Movimento
            {
                Tipo = tipoMovimento == TipoMovimento.Entrada ? "Entrada" : "Saída",
                Data = DateTime.Now,
                ProdutoId = vincularAoProduto ? produto.Id : (Guid?)null,
                CategoriaId = produto.CategoriaId,
                UnidadeId = produto.UnidadeId,
                LocalId = produto.LocalId,
                ProdutoNome = produto.Nome,
                Categoria = produto.Categoria,
                Quantidade = quantidade,
                Unidade = produto.Unidade,
                Local = produto.LocalDeposito,
                Observacao = observacao
            };

            _repositorioMovimentos.Inserir(movimento);
        }

        #endregion
    }

    /// <summary>
    /// Tipo de movimento para o ajuste de quantidade (Entrada / Saída).
    /// </summary>
    public enum TipoMovimento
    {
        Entrada,
        Saida
    }

    /// <summary>
    /// Diálogo simples para adicionar/remover quantidade (Entrada/Saída).
    /// </summary>
    public class AjusteQuantidadeDialog : Form
    {
        private readonly Produto _produto;

        private NumericUpDown nudQuantidade;
        private RadioButton rbEntrada;
        private RadioButton rbSaida;
        private TextBox txtObs;
        private Button btnOk;
        private Button btnCancelar;

        public decimal Quantidade => nudQuantidade.Value;

        public TipoMovimento TipoMovimento =>
            rbEntrada.Checked ? TipoMovimento.Entrada : TipoMovimento.Saida;

        public string Observacao => txtObs.Text?.Trim() ?? string.Empty;

        public AjusteQuantidadeDialog(Produto produto)
        {
            _produto = produto;

            Text = "Ajustar quantidade - " + produto.Nome;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;
            ShowInTaskbar = false;
            Width = 520;
            Height = 300;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            var lblProduto = new Label
            {
                Text = _produto.Nome,
                Dock = DockStyle.Top,
                AutoSize = false,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 10, 10, 0)
            };

            var pnlTipo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(10, 0, 10, 0)
            };

            rbEntrada = new RadioButton
            {
                Text = "Entrada (adicionar)",
                Checked = true,
                AutoSize = true,
                Location = new Point(0, 10)
            };

            rbSaida = new RadioButton
            {
                Text = "Saída (remover)",
                AutoSize = true,
                Location = new Point(180, 10)
            };

            pnlTipo.Controls.Add(rbEntrada);
            pnlTipo.Controls.Add(rbSaida);

            var pnlQuantidade = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(10, 0, 10, 0)
            };

            var lblQtd = new Label
            {
                Text = "Quantidade:",
                AutoSize = true,
                Location = new Point(0, 10)
            };

            nudQuantidade = new NumericUpDown
            {
                DecimalPlaces = 3,
                Minimum = 0,
                Maximum = 1000000,
                Increment = 0.1M,
                Width = 120,
                Location = new Point(100, 8)
            };

            pnlQuantidade.Controls.Add(lblQtd);
            pnlQuantidade.Controls.Add(nudQuantidade);

            var pnlObs = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 0, 10, 0)
            };

            var lblObs = new Label
            {
                Text = "Observação:",
                AutoSize = true,
                Location = new Point(0, 5)
            };

            txtObs = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Bottom,
                Height = 120
            };

            pnlObs.Controls.Add(txtObs);
            pnlObs.Controls.Add(lblObs);

            var pnlBotoes = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(10)
            };

            btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Width = 100,
                Height = 30,
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Location = new Point(Width - 240, 10)
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Width = 100,
                Height = 30,
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Location = new Point(Width - 130, 10)
            };

            pnlBotoes.Controls.Add(btnOk);
            pnlBotoes.Controls.Add(btnCancelar);

            Controls.Add(pnlBotoes);
            Controls.Add(pnlObs);
            Controls.Add(pnlQuantidade);
            Controls.Add(pnlTipo);
            Controls.Add(lblProduto);

            AcceptButton = btnOk;
            CancelButton = btnCancelar;
        }
    }
}
