using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa.Telas
{
    public partial class EditarAulasForm : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioProdutos _repositorioProdutos = new RepositorioProdutos();
        private readonly RepositorioMovimentos _repositorioMovimentos = new RepositorioMovimentos();

        private readonly BindingList<ItemAula> _itensAula = new BindingList<ItemAula>();
        private string? _aulaId;

        /// <summary>
        /// Item exibido no grid de edição da aula.
        /// </summary>
        private class ItemAula
        {
            public int MovimentoId { get; set; }
            public Guid? ProdutoId { get; set; }
            public string ProdutoNome { get; set; } = string.Empty;
            public string? Categoria { get; set; }
            public decimal Quantidade { get; set; }
            public string? Unidade { get; set; }
            public string? Local { get; set; }
        }

        public EditarAulasForm() : this(null)
        {
        }

        /// <summary>
        /// Construtor principal, recebe opcionalmente o AulaId para carregar a aula.
        /// </summary>
        public EditarAulasForm(string? aulaId)
        {
            InitializeComponent();

            btnAdicionarItem.Click += btnAdicionarItem_Click;
            cboProduto.SelectedIndexChanged += cboProduto_SelectedIndexChanged;
            dgvItensAula.SelectionChanged += dgvItensAula_SelectionChanged;
            btnRemoverItemSelecionado.Click += btnRemoverItemSelecionado_Click;
            btnLimpar.Click += btnLimpar_Click;
            btnSalvarAula.Click += btnSalvarAula_Click;
            btnFechar.Click += btnFechar_Click;
            btnExcluirAulaCompleta.Click += btnExcluirAulaCompleta_Click;

            ConfigurarGrid();
            VincularFonteGrid();
            ConfigurarControles();
            CarregarProdutos();

            if (!string.IsNullOrWhiteSpace(aulaId))
            {
                _aulaId = aulaId;
                CarregarAula(aulaId);
            }

            AtualizarResumo();
        }

        #region Configuração

        private void ConfigurarGrid()
        {
            dgvItensAula.ReadOnly = true;
            dgvItensAula.AllowUserToAddRows = false;
            dgvItensAula.AllowUserToDeleteRows = false;
            dgvItensAula.MultiSelect = false;
            dgvItensAula.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensAula.RowHeadersVisible = false;
            dgvItensAula.AutoGenerateColumns = false;
            dgvItensAula.Columns.Clear();

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProdutoNome",
                HeaderText = "Produto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoria",
                Width = 130
            });

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantidade",
                HeaderText = "Qtd",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unidade",
                HeaderText = "Un.",
                Width = 60
            });

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Local",
                HeaderText = "Local",
                Width = 150
            });
        }

        private void VincularFonteGrid()
        {
            dgvItensAula.DataSource = _itensAula;
        }

        private void ConfigurarControles()
        {
            // No editor, esses dados são apenas informativos por enquanto
            dateTimePicker1.Format = DateTimePickerFormat.Short;

            nudQuantidade.Minimum = 0.01M;
            nudQuantidade.Maximum = 1_000_000M;
            nudQuantidade.DecimalPlaces = 2;
            nudQuantidade.ThousandsSeparator = true;

            lblUnidade.Text = "Unidade: ---";
            lblLocal.Text = "Local: (nenhum)";
            lblDisponivel.Text = "Disponível: 0,00 unid.";

            btnRemoverItemSelecionado.Enabled = false;
        }

        private void CarregarProdutos()
        {
            try
            {
                var produtos = _repositorioProdutos.Listar()
                    .OrderBy(p => p.Nome)
                    .ToList();

                cboProduto.DataSource = produtos;
                cboProduto.DisplayMember = "Nome";
                cboProduto.ValueMember = "Id";

                if (produtos.Count > 0)
                    cboProduto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Carregar Aula

        private void CarregarAula(string aulaId)
        {
            try
            {
                _itensAula.Clear();

                var movimentosSaida = _repositorioMovimentos.ListarSaidas();

                var movimentosAula = movimentosSaida
                    .Where(m =>
                        !string.IsNullOrWhiteSpace(m.Observacao) &&
                        m.Observacao!.IndexOf("AulaId=" + aulaId, StringComparison.OrdinalIgnoreCase) >= 0 &&
                        m.Observacao.IndexOf("[AULA CANCELADA]", StringComparison.OrdinalIgnoreCase) < 0 &&
                        m.Observacao.IndexOf("[ITEM REMOVIDO DA AULA]", StringComparison.OrdinalIgnoreCase) < 0)
                    .ToList();

                if (movimentosAula.Count == 0)
                    return;

                // Usa o primeiro movimento para preencher cabeçalho
                var primeiro = movimentosAula[0];
                PreencherCabecalhoAPartirDaObservacao(primeiro.Observacao ?? string.Empty);

                foreach (var mov in movimentosAula)
                {
                    var item = new ItemAula
                    {
                        MovimentoId = mov.Id,
                        ProdutoId = mov.ProdutoId,
                        ProdutoNome = mov.ProdutoNome,
                        Categoria = mov.Categoria,
                        Quantidade = mov.Quantidade,
                        Unidade = mov.Unidade,
                        Local = mov.Local
                    };

                    _itensAula.Add(item);
                }

                AtualizarResumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar aula:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCabecalhoAPartirDaObservacao(string observacao)
        {
            // Padrão gerado no MontarAulaForm:
            // AulaId=...; Aula: {titulo}; Professor: {professor}; DataAula: {yyyy-MM-dd}; ...

            string titulo = ExtrairTrecho(observacao, "Aula:");
            string professor = ExtrairTrecho(observacao, "Professor:");
            string dataStr = ExtrairTrecho(observacao, "DataAula:");

            txtTituloAula.Text = titulo;
            cboProfessor.Text = professor;

            if (DateTime.TryParse(dataStr, out var data))
                dateTimePicker1.Value = data;
        }

        private string ExtrairTrecho(string texto, string chave)
        {
            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrWhiteSpace(chave))
                return string.Empty;

            int idx = texto.IndexOf(chave, StringComparison.OrdinalIgnoreCase);
            if (idx < 0)
                return string.Empty;

            idx += chave.Length;
            // pula espaço e dois pontos se houver
            while (idx < texto.Length && (texto[idx] == ' ' || texto[idx] == ':'))
                idx++;

            int fim = texto.IndexOf(';', idx);
            if (fim < 0) fim = texto.Length;

            return texto.Substring(idx, fim - idx).Trim();
        }

        #endregion

        #region Eventos de Controles

        private void cboProduto_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var produto = ObterProdutoSelecionado();
            if (produto == null)
            {
                lblUnidade.Text = "Unidade: ---";
                lblLocal.Text = "Local: (nenhum)";
                lblDisponivel.Text = "Disponível: 0,00 unid.";
                return;
            }

            lblUnidade.Text = $"Unidade: {produto.Unidade ?? "---"}";
            lblLocal.Text = $"Local: {produto.LocalDeposito ?? "(nenhum)"}";
            lblDisponivel.Text = $"Disponível: {produto.Quantidade:N2}";
        }

        private Produto? ObterProdutoSelecionado()
        {
            if (cboProduto.SelectedItem is Produto p)
                return p;

            if (cboProduto.SelectedValue is Guid idGuid)
                return _repositorioProdutos.BuscarPorId(idGuid);

            return null;
        }

        private void btnAdicionarItem_Click(object? sender, EventArgs e)
        {
            // Para não bagunçar o histórico, neste primeiro momento
            // o EditarAulasForm não altera quantidade dos movimentos existentes,
            // apenas permite remover itens com ou sem devolução.
            MessageBox.Show(
                "Por enquanto, a edição de quantidade ainda não está liberada.\n" +
                "Você já pode remover itens com devolução ao estoque.",
                "Em desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void dgvItensAula_SelectionChanged(object? sender, EventArgs e)
        {
            btnRemoverItemSelecionado.Enabled = dgvItensAula.SelectedRows.Count > 0;
        }

        private void btnRemoverItemSelecionado_Click(object? sender, EventArgs e)
        {
            if (dgvItensAula.SelectedRows.Count == 0)
                return;

            var row = dgvItensAula.SelectedRows[0];
            if (row.DataBoundItem is not ItemAula item)
                return;

            string mensagem =
                $"O produto \"{item.ProdutoNome}\" com {item.Quantidade:N2} unidades será removido desta aula.\n\n" +
                "Deseja devolver esta quantidade ao estoque?";

            var resp = MessageBox.Show(
                mensagem,
                "Confirmar Remoção de Produto",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);

            if (resp == DialogResult.Cancel)
                return;

            try
            {
                var movimentoOriginal = _repositorioMovimentos.BuscarPorId(item.MovimentoId);
                if (movimentoOriginal == null)
                {
                    // Se por algum motivo não achar o movimento, remove só da tela
                    _itensAula.Remove(item);
                    AtualizarResumo();
                    return;
                }

                // Marca movimento original como removido da aula
                movimentoOriginal.Observacao =
                    (movimentoOriginal.Observacao ?? string.Empty) + " [ITEM REMOVIDO DA AULA]";
                _repositorioMovimentos.Atualizar(movimentoOriginal);

                if (resp == DialogResult.Yes)
                {
                    // Devolver ao estoque: cria movimento de Entrada e soma no produto
                    if (item.ProdutoId.HasValue)
                    {
                        var produto = _repositorioProdutos.BuscarPorId(item.ProdutoId.Value);
                        if (produto != null)
                        {
                            produto.Quantidade += item.Quantidade;
                            _repositorioProdutos.Atualizar(produto);
                        }
                    }

                    var movimentoEntrada = new Movimento
                    {
                        Tipo = "Entrada",
                        Data = DateTime.Now,
                        ProdutoId = movimentoOriginal.ProdutoId,
                        CategoriaId = movimentoOriginal.CategoriaId,
                        UnidadeId = movimentoOriginal.UnidadeId,
                        LocalId = movimentoOriginal.LocalId,
                        ProdutoNome = movimentoOriginal.ProdutoNome,
                        Categoria = movimentoOriginal.Categoria,
                        Quantidade = item.Quantidade,
                        Unidade = movimentoOriginal.Unidade,
                        Local = movimentoOriginal.Local,
                        Observacao = (movimentoOriginal.Observacao ?? string.Empty) + " [DEVOLUÇÃO ITEM EDITADO]"
                    };

                    _repositorioMovimentos.Inserir(movimentoEntrada);
                }
                else
                {
                    // Não devolve: apenas deixa o estoque como está
                    // (o movimento de saída continua valendo para o estoque)
                }

                _itensAula.Remove(item);
                AtualizarResumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao remover o item da aula:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_aulaId))
                return;

            var resp = MessageBox.Show(
                "Deseja recarregar os dados da aula a partir do banco?\n" +
                "Alterações ainda não aplicadas serão perdidas.",
                "Recarregar aula",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            CarregarAula(_aulaId);
        }

        private void btnSalvarAula_Click(object? sender, EventArgs e)
        {
            // As alterações já foram aplicadas em tempo real (remoção/devolução).
            MessageBox.Show(
                "Edição concluída.\nOs itens removidos já foram atualizados no estoque.",
                "Edição de aula",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }

        private void btnFechar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void btnExcluirAulaCompleta_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_aulaId))
            {
                MessageBox.Show(
                    "Nenhuma aula carregada para exclusão.",
                    "Excluir Aula",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var resp = MessageBox.Show(
                "Você deseja CANCELAR a aula e devolver todo o estoque?\n\n" +
                "Sim  = Aula Cancelada (devolve todos os itens ao estoque)\n" +
                "Não  = Aula Ocorrida (mantém as saídas, não devolve)\n" +
                "Cancelar = Voltar sem alterar nada",
                "Excluir Aula",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);

            if (resp == DialogResult.Cancel)
                return;

            bool devolverEstoque = resp == DialogResult.Yes;

            try
            {
                ExcluirAulaCompleta(devolverEstoque);

                MessageBox.Show(
                    devolverEstoque
                        ? "Aula cancelada e estoque devolvido com sucesso."
                        : "Aula marcada como ocorrida. Estoque mantido.",
                    "Excluir Aula",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir a aula:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Exclusão global da aula

        private void ExcluirAulaCompleta(bool devolverEstoque)
        {
            if (string.IsNullOrWhiteSpace(_aulaId))
                return;

            var movimentosSaida = _repositorioMovimentos.ListarSaidas();

            var movimentosAula = movimentosSaida
                .Where(m =>
                    !string.IsNullOrWhiteSpace(m.Observacao) &&
                    m.Observacao!.IndexOf("AulaId=" + _aulaId, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    m.Observacao.IndexOf("[AULA CANCELADA]", StringComparison.OrdinalIgnoreCase) < 0 &&
                    m.Observacao.IndexOf("[ITEM REMOVIDO DA AULA]", StringComparison.OrdinalIgnoreCase) < 0)
                .ToList();

            if (movimentosAula.Count == 0)
                return;

            foreach (var mov in movimentosAula)
            {
                // Marca aula como cancelada ou ocorrida no movimento de saída
                mov.Observacao = (mov.Observacao ?? string.Empty) +
                                 (devolverEstoque ? " [AULA CANCELADA]" : " [AULA OCORRIDA]");

                _repositorioMovimentos.Atualizar(mov);

                if (!devolverEstoque)
                    continue;

                // Devolver ao estoque: soma no produto e cria movimento de Entrada
                if (mov.ProdutoId.HasValue)
                {
                    var produto = _repositorioProdutos.BuscarPorId(mov.ProdutoId.Value);
                    if (produto != null)
                    {
                        produto.Quantidade += mov.Quantidade;
                        _repositorioProdutos.Atualizar(produto);
                    }
                }

                var movimentoEntrada = new Movimento
                {
                    Tipo = "Entrada",
                    Data = DateTime.Now,
                    ProdutoId = mov.ProdutoId,
                    CategoriaId = mov.CategoriaId,
                    UnidadeId = mov.UnidadeId,
                    LocalId = mov.LocalId,
                    ProdutoNome = mov.ProdutoNome,
                    Categoria = mov.Categoria,
                    Quantidade = mov.Quantidade,
                    Unidade = mov.Unidade,
                    Local = mov.Local,
                    Observacao = (mov.Observacao ?? string.Empty) + " [DEVOLUÇÃO AULA CANCELADA]"
                };

                _repositorioMovimentos.Inserir(movimentoEntrada);
            }

            _itensAula.Clear();
            AtualizarResumo();
        }

        #endregion

        #region Auxiliares

        private void AtualizarResumo()
        {
            int itens = _itensAula.Count;
            decimal totalQtd = _itensAula.Sum(i => i.Quantidade);

            lblResumoItens.Text = $"Itens na aula: {itens} | Quantidade total: {totalQtd:N2}";
        }

        #endregion
    }
}
