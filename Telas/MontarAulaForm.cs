using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EstoqueQuimico.Data;
using Microsoft.VisualBasic; // Interaction.InputBox
using EstoqueQuimico.Models;
using alguamcoisa.Data; // RepositorioProfessores

namespace alguamcoisa.Telas
{
    public partial class MontarAulaForm : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioProdutos _repositorioProdutos = new RepositorioProdutos();
        private readonly RepositorioMovimentos _repositorioMovimentos = new RepositorioMovimentos();
        private readonly RepositorioProfessores _repositorioProfessores = new RepositorioProfessores();

        private List<Produto> _produtos = new List<Produto>();
        private readonly BindingList<ItemAula> _itensAula = new BindingList<ItemAula>();

        // Controle de turmas dinâmicas
        private readonly List<string> _turmas = new List<string>();
        private readonly string _arquivoTurmas =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "turmas_aula.txt");

        /// <summary>
        /// Item da aula que será exibido no grid.
        /// </summary>
        private class ItemAula
        {
            public Guid ProdutoId { get; set; }
            public string ProdutoNome { get; set; } = string.Empty;
            public string? Categoria { get; set; }
            public decimal QuantidadeUsar { get; set; }
            public string? Unidade { get; set; }
            public string? Local { get; set; }
            /// <summary>Quantidade disponível antes de usar na aula.</summary>
            public decimal DisponivelAntes { get; set; }
            /// <summary>Quantidade restante depois da aula (somente exibido).</summary>
            public decimal DisponivelDepois => DisponivelAntes - QuantidadeUsar;
        }

        public MontarAulaForm()
        {
            InitializeComponent();

            // Liga eventos
            btnAdicionarItem.Click += btnAdicionarItem_Click;
            cboProduto.SelectedIndexChanged += cboProduto_SelectedIndexChanged;
            txtFiltroProduto.TextChanged += txtFiltroProduto_TextChanged;
            dgvItensAula.SelectionChanged += dgvItensAula_SelectionChanged;
            btnRemoverItemSelecionado.Click += btnRemoverItemSelecionado_Click;
            btnLimpar.Click += btnLimpar_Click;
            btnSalvarAula.Click += btnSalvarAula_Click;
            btnFechar.Click += btnFechar_Click;

            // Exibir matrícula + nome do professor
            cboProfessor.Format += cboProfessor_Format;

            ConfigurarGrid();
            VincularFonteGrid();
            ConfigurarControles();
            CarregarProdutos();
            CarregarCombosAula();
            AtualizarResumo();
        }

        #region Configuração inicial

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

            // Estilização extra via código (backup ao Designer)
            dgvItensAula.EnableHeadersVisualStyles = false;
            dgvItensAula.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dgvItensAula.BorderStyle = BorderStyle.None;

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
                DataPropertyName = "QuantidadeUsar",
                HeaderText = "Qtd usar",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    BackColor = System.Drawing.Color.FromArgb(45, 45, 48),
                    ForeColor = System.Drawing.Color.White
                }
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

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DisponivelAntes",
                HeaderText = "Disponível",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    BackColor = System.Drawing.Color.FromArgb(45, 45, 48),
                    ForeColor = System.Drawing.Color.White
                }
            });

            dgvItensAula.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DisponivelDepois",
                HeaderText = "Após uso",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    BackColor = System.Drawing.Color.FromArgb(45, 45, 48),
                    ForeColor = System.Drawing.Color.White
                }
            });
        }

        private void VincularFonteGrid()
        {
            dgvItensAula.DataSource = _itensAula;
        }

        private void ConfigurarControles()
        {
            // Data da aula – só data
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;

            // Quantidade padrão
            nudQuantidade.Minimum = 0.01M;
            nudQuantidade.Maximum = 1_000_000M;
            nudQuantidade.DecimalPlaces = 2;
            nudQuantidade.ThousandsSeparator = true;

            // Labels padrão
            lblUnidade.Text = "-";
            lblLocal.Text = "-";
            lblDisponivel.Text = "0,00";

            // Checkbox: por padrão, desconta estoque
            chkDescontarEstoqueAoSalvar.Checked = true;

            btnRemoverItemSelecionado.Enabled = false;

            // AutoComplete para combos principais
            ConfigurarComboAutoComplete(cboProfessor);
            ConfigurarComboAutoComplete(cboMateriaAula);
            ConfigurarComboAutoComplete(cboTurma);
            ConfigurarComboAutoComplete(cboTipoAula);
            ConfigurarComboAutoComplete(cboStatusAula);
            ConfigurarComboAutoComplete(cboProduto);
        }

        private void ConfigurarComboAutoComplete(ComboBox combo)
        {
            if (combo == null) return;

            // Se o estilo NÃO for DropDownList -> Autocomplete funciona
            if (combo.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                combo.AutoCompleteMode = AutoCompleteMode.None;
                combo.AutoCompleteSource = AutoCompleteSource.None;
            }
        }


        private void CarregarProdutos()
        {
            try
            {
                _produtos = _repositorioProdutos.Listar()
                    .OrderBy(p => p.Nome)
                    .ToList();

                AtualizarListaProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar produtos:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Povoa combos de Matéria, Turma, Tipo, Status e Professor.
        /// Matéria/Tipo/Status ainda são listas em memória.
        /// Turma é carregada/salva em arquivo de texto.
        /// Professor vem do banco (dbo.Professores).
        /// </summary>
        private void CarregarCombosAula()
        {
            // Matéria – lista fixa por enquanto
            cboMateriaAula.Items.Clear();
            cboMateriaAula.Items.Add(""); // opcional
            cboMateriaAula.Items.Add("Química Geral");
            cboMateriaAula.Items.Add("Química Orgânica");
            cboMateriaAula.Items.Add("Físico-Química");
            cboMateriaAula.Items.Add("Laboratório Básico");

            // Turmas dinâmicas (arquivo texto)
            CarregarTurmas();

            // Tipo de aula
            cboTipoAula.Items.Clear();
            cboTipoAula.Items.Add("");
            cboTipoAula.Items.Add("Teórica");
            cboTipoAula.Items.Add("Prática");
            cboTipoAula.Items.Add("Revisão");

            // Status
            cboStatusAula.Items.Clear();
            cboStatusAula.Items.Add("Montada");
            cboStatusAula.Items.Add("Concluída");
            cboStatusAula.Items.Add("Cancelada");
            cboStatusAula.SelectedIndex = 0;

            // Professores – agora vindo do banco
            try
            {
                var professores = _repositorioProfessores.Listar();

                cboProfessor.DataSource = null;
                cboProfessor.DisplayMember = "NomeProfessor"; // texto final é formatado no evento Format
                cboProfessor.ValueMember = "IdProfessor";
                cboProfessor.DataSource = professores;

                if (professores.Count > 0)
                    cboProfessor.SelectedIndex = 0;
                else
                    cboProfessor.Text = string.Empty;
            }
            catch (Exception ex)
            {
                // Se der erro no banco, não trava o form; só avisa.
                MessageBox.Show(
                    "Erro ao carregar lista de professores:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                cboProfessor.DataSource = null;
                cboProfessor.Items.Clear();
                cboProfessor.Text = string.Empty;
            }
        }

        /// <summary>
        /// Lê as turmas do arquivo turmas_aula.txt, ou cria uma lista padrão
        /// se o arquivo ainda não existir.
        /// </summary>
        private void CarregarTurmas()
        {
            _turmas.Clear();

            try
            {
                if (File.Exists(_arquivoTurmas))
                {
                    var linhas = File.ReadAllLines(_arquivoTurmas);
                    foreach (var linha in linhas)
                    {
                        var t = (linha ?? string.Empty).Trim();
                        if (string.IsNullOrEmpty(t)) continue;

                        if (!_turmas.Any(x => x.Equals(t, StringComparison.OrdinalIgnoreCase)))
                            _turmas.Add(t);
                    }
                }
            }
            catch
            {
                // Se der qualquer erro no arquivo, ignora e usa padrão
            }

            if (_turmas.Count == 0)
            {
                // Lista padrão (a mesma que já existia antes)
                _turmas.Add("1º Ano A");
                _turmas.Add("1º Ano B");
                _turmas.Add("2º Ano A");
                _turmas.Add("2º Ano B");
                _turmas.Add("3º Ano A");
            }

            _turmas.Sort(StringComparer.CurrentCultureIgnoreCase);

            PreencherComboTurma();
        }

        private void PreencherComboTurma()
        {
            string turmaSelecionada = cboTurma.Text;

            cboTurma.BeginUpdate();
            cboTurma.Items.Clear();
            foreach (var t in _turmas)
                cboTurma.Items.Add(t);
            cboTurma.EndUpdate();

            if (!string.IsNullOrWhiteSpace(turmaSelecionada) &&
                _turmas.Any(x => x.Equals(turmaSelecionada, StringComparison.OrdinalIgnoreCase)))
            {
                cboTurma.SelectedItem = turmaSelecionada;
            }
        }

        private void SalvarTurmas()
        {
            try
            {
                File.WriteAllLines(_arquivoTurmas, _turmas);
            }
            catch
            {
                // Se não conseguir salvar, não quebra a tela.
            }
        }

        /// <summary>
        /// Handler para o botão Nova Turma.
        /// Você pode criar um botão no Designer chamado btnNovaTurma
        /// e apontar o evento Click para este método.
        /// </summary>
        private void btnNovaTurma_Click(object? sender, EventArgs e)
        {
            AdicionarNovaTurma();
        }

        private void AdicionarNovaTurma()
        {
            string entrada = Interaction.InputBox(
                "Informe a nova turma:",
                "Nova Turma",
                "");

            string novaTurma = (entrada ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(novaTurma))
                return;

            if (_turmas.Any(t => t.Equals(novaTurma, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "Essa turma já está cadastrada.",
                    "Turma já existe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _turmas.Add(novaTurma);
            _turmas.Sort(StringComparer.CurrentCultureIgnoreCase);
            SalvarTurmas();
            PreencherComboTurma();
            cboTurma.SelectedItem = novaTurma;
        }

        #endregion

        #region Eventos de produto / filtro

        private void AtualizarListaProdutos()
        {
            string filtro = txtFiltroProduto.Text?.Trim() ?? string.Empty;

            List<Produto> lista;
            if (string.IsNullOrWhiteSpace(filtro))
            {
                lista = _produtos;
            }
            else
            {
                lista = _produtos
                    .Where(p => p.Nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }

            cboProduto.DataSource = null;
            cboProduto.DataSource = lista;
            cboProduto.DisplayMember = "Nome";
            cboProduto.ValueMember = "Id";

            if (lista.Count > 0)
                cboProduto.SelectedIndex = 0;
        }

        private void txtFiltroProduto_TextChanged(object? sender, EventArgs e)
        {
            AtualizarListaProdutos();
        }

        private void cboProduto_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var produto = ObterProdutoSelecionado();
            if (produto == null)
            {
                lblUnidade.Text = "-";
                lblLocal.Text = "-";
                lblDisponivel.Text = "0,00";
                return;
            }

            lblUnidade.Text = string.IsNullOrWhiteSpace(produto.Unidade)
                ? "-"
                : produto.Unidade;

            lblLocal.Text = string.IsNullOrWhiteSpace(produto.LocalDeposito)
                ? "-"
                : produto.LocalDeposito;

            lblDisponivel.Text = produto.Quantidade.ToString("N2");
        }

        #endregion

        #region Eventos de botões / grid

        private void btnAdicionarItem_Click(object? sender, EventArgs e)
        {
            var produto = ObterProdutoSelecionado();
            if (produto == null)
            {
                MessageBox.Show("Selecione um produto.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProduto.Focus();
                return;
            }

            if (nudQuantidade.Value <= 0)
            {
                MessageBox.Show("Informe a quantidade a usar.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQuantidade.Focus();
                return;
            }

            decimal qtdUsar = nudQuantidade.Value;
            decimal disponivel = produto.Quantidade;

            if (qtdUsar > disponivel && chkDescontarEstoqueAoSalvar.Checked)
            {
                var resp = MessageBox.Show(
                    $"A quantidade informada ({qtdUsar:N2}) é maior que a disponível ({disponivel:N2}).\n" +
                    "Deseja continuar mesmo assim?",
                    "Quantidade maior que o disponível",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resp != DialogResult.Yes)
                    return;
            }

            // Se já existir item para o mesmo produto, soma quantidades
            var existente = _itensAula.FirstOrDefault(i => i.ProdutoId == produto.Id);
            if (existente != null)
            {
                existente.QuantidadeUsar += qtdUsar;
            }
            else
            {
                var item = new ItemAula
                {
                    ProdutoId = produto.Id,
                    ProdutoNome = produto.Nome,
                    Categoria = produto.Categoria,
                    QuantidadeUsar = qtdUsar,
                    Unidade = produto.Unidade,
                    Local = produto.LocalDeposito,
                    DisponivelAntes = disponivel
                };

                _itensAula.Add(item);
            }

            AtualizarResumo();
            dgvItensAula.Refresh();
            nudQuantidade.Value = nudQuantidade.Minimum;
        }

        private void dgvItensAula_SelectionChanged(object? sender, EventArgs e)
        {
            btnRemoverItemSelecionado.Enabled = dgvItensAula.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Agora remove uma quantidade informada pelo usuário.
        /// Se a quantidade for >= à do item, pergunta se remove o item inteiro.
        /// </summary>
        private void btnRemoverItemSelecionado_Click(object? sender, EventArgs e)
        {
            if (dgvItensAula.SelectedRows.Count == 0)
                return;

            var row = dgvItensAula.SelectedRows[0];
            if (row.DataBoundItem is not ItemAula item)
                return;

            // Pergunta primeiro qual lógica utilizar: remover quantidade ou remover linha inteira
            var escolha = MessageBox.Show(
                "O que deseja fazer com o item selecionado?\n\n" +
                "Sim  = remover apenas uma quantidade\n" +
                "Não = remover a linha inteira (tudo)",
                "Remover item da aula",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (escolha == DialogResult.Cancel)
                return;

            // Lógica 1: remover apenas uma quantidade
            if (escolha == DialogResult.Yes)
            {
                string valorDefault = item.QuantidadeUsar.ToString("N2");
                string entrada = Microsoft.VisualBasic.Interaction.InputBox(
                    "Informe a quantidade que deseja remover deste produto:",
                    "Remover quantidade",
                    valorDefault);

                if (string.IsNullOrWhiteSpace(entrada))
                    return;

                if (!decimal.TryParse(entrada, out decimal qtdRemover))
                {
                    MessageBox.Show("Quantidade inválida.", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (qtdRemover <= 0)
                {
                    MessageBox.Show("Informe uma quantidade maior que zero.", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (qtdRemover >= item.QuantidadeUsar)
                {
                    // Se a quantidade digitada for maior/igual, confirma remoção da linha toda
                    var resp = MessageBox.Show(
                        "A quantidade informada é maior ou igual à quantidade deste item.\n" +
                        "Deseja remover o item inteiro da aula?",
                        "Remover item",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resp != DialogResult.Yes)
                        return;

                    _itensAula.Remove(item);
                }
                else
                {
                    item.QuantidadeUsar -= qtdRemover;
                }
            }
            // Lógica 2: remover a linha inteira (tudo)
            else if (escolha == DialogResult.No)
            {
                var resp = MessageBox.Show(
                    "Confirma a remoção deste item da aula?",
                    "Remover item",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp != DialogResult.Yes)
                    return;

                _itensAula.Remove(item);
            }

            AtualizarResumo();
            dgvItensAula.Refresh();
        }


        private void btnLimpar_Click(object? sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "Deseja limpar os dados da aula e todos os itens?",
                "Limpar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            txtTituloAula.Clear();
            cboProfessor.Text = string.Empty;
            cboMateriaAula.Text = string.Empty;
            cboTurma.Text = string.Empty;
            cboTipoAula.Text = string.Empty;
            if (cboStatusAula.Items.Count > 0)
                cboStatusAula.SelectedIndex = 0;
            txtObservacoesAula.Clear();
            dateTimePicker1.Value = DateTime.Today;

            _itensAula.Clear();
            AtualizarResumo();
        }

        private void btnSalvarAula_Click(object? sender, EventArgs e)
        {
            if (!ValidarAula())
                return;

            string titulo = txtTituloAula.Text.Trim();
            string professor = cboProfessor.Text.Trim();
            string materia = cboMateriaAula.Text.Trim();
            string turma = cboTurma.Text.Trim();
            string tipoAula = cboTipoAula.Text.Trim();
            string statusAula = cboStatusAula.Text.Trim();
            string descricao = txtObservacoesAula.Text.Trim();
            DateTime dataAula = dateTimePicker1.Value.Date;

            Guid aulaId = Guid.NewGuid();

            // Monta Observacao rica, seguindo padrão usado na tela de visualização
            string observacaoBase =
                $"AulaId={aulaId}; " +
                (string.IsNullOrWhiteSpace(titulo) ? "" : $"Aula: {titulo}; ") +
                (string.IsNullOrWhiteSpace(professor) ? "" : $"Professor: {professor}; ") +
                $"DataAula: {dataAula:yyyy-MM-dd}; " +
                (string.IsNullOrWhiteSpace(materia) ? "" : $"Materia: {materia}; ") +
                (string.IsNullOrWhiteSpace(turma) ? "" : $"Turma: {turma}; ") +
                (string.IsNullOrWhiteSpace(tipoAula) ? "" : $"Tipo: {tipoAula}; ") +
                (string.IsNullOrWhiteSpace(statusAula) ? "" : $"Status: {statusAula}; ") +
                (string.IsNullOrWhiteSpace(descricao) ? "" : $"Obs: {descricao}");

            bool descontarEstoque = chkDescontarEstoqueAoSalvar.Checked;

            try
            {
                foreach (var item in _itensAula)
                {
                    // Sempre pega o produto atual do banco
                    var produto = _repositorioProdutos.BuscarPorId(item.ProdutoId);
                    if (produto == null)
                        continue;

                    string observacaoMovimento = observacaoBase;
                    if (!descontarEstoque)
                    {
                        // Marca claramente que é simulação
                        observacaoMovimento = "[SIMULACAO] " + observacaoMovimento;
                    }

                    var movimento = new Movimento
                    {
                        Tipo = "Saída",
                        Data = DateTime.Now,
                        ProdutoId = produto.Id,
                        CategoriaId = produto.CategoriaId,
                        UnidadeId = produto.UnidadeId,
                        LocalId = produto.LocalId,
                        ProdutoNome = produto.Nome,
                        Categoria = produto.Categoria,
                        Quantidade = item.QuantidadeUsar,
                        Unidade = produto.Unidade,
                        Local = produto.LocalDeposito,
                        Observacao = observacaoMovimento
                    };

                    _repositorioMovimentos.Inserir(movimento);

                    if (descontarEstoque)
                    {
                        produto.Quantidade -= item.QuantidadeUsar;
                        _repositorioProdutos.Atualizar(produto);
                    }
                }

                string msg = descontarEstoque
                    ? "Aula salva, movimentos de saída registrados e estoque atualizado com sucesso."
                    : "Aula salva em modo SIMULAÇÃO.\n" +
                      "Movimentos foram registrados, mas o estoque NÃO foi alterado.";

                MessageBox.Show(
                    msg,
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar a aula / registrar movimentos:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Métodos auxiliares

        private Produto? ObterProdutoSelecionado()
        {
            if (cboProduto.SelectedItem is Produto p)
                return p;

            if (cboProduto.SelectedValue is Guid idGuid)
                return _produtos.FirstOrDefault(x => x.Id == idGuid);

            return null;
        }

        private void AtualizarResumo()
        {
            int itens = _itensAula.Count;
            decimal totalQtd = _itensAula.Sum(i => i.QuantidadeUsar);
            int produtosDiferentes = _itensAula
                .Select(i => i.ProdutoId)
                .Distinct()
                .Count();

            lblResumoItens.Text =
                $"Itens na aula: {itens} | Produtos diferentes: {produtosDiferentes} | Quantidade total: {totalQtd:N2}";
        }

        private bool ValidarAula()
        {
            // Título da aula está oculto na UI atual; não forço validação de título.

            if (string.IsNullOrWhiteSpace(cboProfessor.Text))
            {
                MessageBox.Show("Informe o professor da aula.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProfessor.Focus();
                return false;
            }

            if (_itensAula.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um item à aula.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProduto.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Mostra no combo de professor "MATRICULA - NomeProfessor",
        /// usando os dados vindos da tabela Professores.
        /// </summary>
        private void cboProfessor_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Professor prof)
            {
                string matricula = string.IsNullOrWhiteSpace(prof.MatriculaProfessor)
                    ? string.Empty
                    : $"[{prof.MatriculaProfessor}] ";

                e.Value = $"{matricula}{prof.NomeProfessor}";
            }
        }

        #endregion
    }
}
