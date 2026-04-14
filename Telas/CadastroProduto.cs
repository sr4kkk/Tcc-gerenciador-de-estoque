using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // <-- ADICIONADO
using Microsoft.VisualBasic; // Para Interaction.InputBox
using alguamcoisa.Utils;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class CadastroProduto : ThemedForm
    {
        private readonly RepositorioProdutos _repositorioProdutos = new RepositorioProdutos();

        // Repositórios de apoio para combos
        private readonly RepositorioCategorias _repositorioCategorias = new RepositorioCategorias();
        private readonly RepositorioUnidadesMedida _repositorioUnidades = new RepositorioUnidadesMedida();
        private readonly RepositorioLocaisArmazenamento _repositorioLocaisArmazenamento = new RepositorioLocaisArmazenamento();
        private readonly RepositorioLocaisEspecificos _repositorioLocaisEspecificos = new RepositorioLocaisEspecificos();
        private readonly RepositorioRecipientes _repositorioRecipientes = new RepositorioRecipientes();
        private readonly RepositorioEstadosFisicos _repositorioEstadosFisicos = new RepositorioEstadosFisicos();
        private readonly RepositorioFornecedores _repositorioFornecedores = new RepositorioFornecedores();

        // null = modo cadastro; diferente de null = modo edição
        private Produto? _produtoEmEdicao;

        public CadastroProduto()
        {
            InitializeComponent();

            


            // Configuração padrão do DateTimePicker de validade
            dtValidade.Format = DateTimePickerFormat.Custom;
            dtValidade.CustomFormat = " ";
            dtValidade.Enabled = false;
        }

        /// <summary>
        /// Construtor para modo de edição.
        /// </summary>
        public CadastroProduto(Produto produtoParaEditar) : this()
        {
            _produtoEmEdicao = produtoParaEditar ?? throw new ArgumentNullException(nameof(produtoParaEditar));

            Text = "Editar Produto";
            btnCadastrar.Text = "Salvar alterações";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // aplica o estilo especial nos botões "+"
            ConfigurarBotoesPlus();

            try
            {
                CarregarCombos();

                if (_produtoEmEdicao != null)
                {
                    PreencherFormulario(_produtoEmEdicao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar listas de apoio (categorias, unidades, locais, etc.):\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        //   ESTILO BOTÕES "+"
        // =========================

        /// <summary>
        /// Configura visualmente todos os botões de "+" deste formulário
        /// para que o símbolo fique sempre visível em qualquer DPI/tema.
        /// </summary>
        private void ConfigurarBotoesPlus()
        {
            // Usa as mesmas cores/estilo do botão principal (Cadastrar),
            // assim mantém a identidade visual do AppTheme.
            Color back = btnCadastrar.BackColor;
            Color fore = btnCadastrar.ForeColor;
            FlatStyle flat = btnCadastrar.FlatStyle;

            ConfigurarBotaoPlus(btnAddCategoria, back, fore, flat);
            ConfigurarBotaoPlus(btnAddUnidade, back, fore, flat);
            ConfigurarBotaoPlus(btnAddLocalDeposito, back, fore, flat);
            ConfigurarBotaoPlus(btnAddLocalEspecifico, back, fore, flat);
            ConfigurarBotaoPlus(btnAddRecipiente, back, fore, flat);
            ConfigurarBotaoPlus(btnAddEstadoFisico, back, fore, flat);
            ConfigurarBotaoPlus(button1, back, fore, flat); // botão de fornecedor
        }

        /// <summary>
        /// Aplica um estilo consistente a um botão "+" específico.
        /// </summary>
        private void ConfigurarBotaoPlus(Button btn, Color backColor, Color foreColor, FlatStyle flatStyle)
        {
            if (btn == null)
                return;

            btn.Text = "+"; // garante que o texto esteja correto
            btn.FlatStyle = flatStyle;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.UseVisualStyleBackColor = false;

            // Deixa o + um pouco mais forte/visível
            btn.Font = new Font(btn.Font.FontFamily, 11f, FontStyle.Bold);

            // Evita margem exagerada em botões pequenos
            btn.Margin = new Padding(0);

            // Garante alinhamento central
            btn.TextAlign = ContentAlignment.MiddleCenter;
        }

        // =========================
        //      BOTÕES
        // =========================

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                    return;

                // Detecção de duplicidade (Nome + Depósito)
                if (ExisteProdutoDuplicado())
                {
                    var resposta = MessageBox.Show(
                        "Já existe um produto com este nome neste depósito.\n\nDeseja continuar mesmo assim?",
                        "Produto duplicado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resposta == DialogResult.No)
                        return;
                }

                if (_produtoEmEdicao == null)
                {
                    // MODO CADASTRO (INSERT)
                    Produto produto = CriarProdutoAPartirDoFormulario();

                    _repositorioProdutos.Inserir(produto);

                    MessageBox.Show("Produto cadastrado com sucesso.",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    LimparCampos();
                }
                else
                {
                    // MODO EDIÇÃO (UPDATE)
                    AtualizarProdutoAPartirDoFormulario(_produtoEmEdicao);

                    _repositorioProdutos.Atualizar(_produtoEmEdicao);

                    MessageBox.Show("Produto atualizado com sucesso.",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar produto:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =========================
        //   BOTÕES "+" EXISTENTES
        // =========================

        /// <summary>
        /// Botão "+" ao lado do depósito (Local de Armazenamento).
        /// </summary>
        private void btnAddLocalDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = txtLocalDeposito.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe o nome do novo depósito (local de armazenamento):",
                    "Novo Depósito",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (txtLocalDeposito.Items.Contains(input))
                {
                    txtLocalDeposito.SelectedItem = input;
                    return;
                }

                var novoLocal = new LocalArmazenamento { Nome = input };
                _repositorioLocaisArmazenamento.Inserir(novoLocal);

                txtLocalDeposito.Items.Add(novoLocal.Nome);
                txtLocalDeposito.SelectedItem = novoLocal.Nome;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar novo depósito:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botão "+" ao lado do local específico (gaveta, prateleira, etc.).
        /// </summary>
        private void btnAddLocalEspecifico_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = txtLocal.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe o nome do novo local específico (gaveta, prateleira, armário, etc.):",
                    "Novo Local Específico",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (txtLocal.Items.Contains(input))
                {
                    txtLocal.SelectedItem = input;
                    return;
                }

                var novoLocalEsp = new LocalEspecifico { Nome = input };
                _repositorioLocaisEspecificos.Inserir(novoLocalEsp);

                txtLocal.Items.Add(novoLocalEsp.Nome);
                txtLocal.SelectedItem = novoLocalEsp.Nome;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar novo local específico:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = txtCategoria.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe o nome da nova categoria:",
                    "Nova Categoria",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (txtCategoria.Items.Contains(input))
                {
                    txtCategoria.SelectedItem = input;
                    return;
                }

                var novaCategoria = new Categoria { Nome = input };
                _repositorioCategorias.Inserir(novaCategoria);

                txtCategoria.Items.Add(novaCategoria.Nome);
                txtCategoria.SelectedItem = novaCategoria.Nome;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar nova categoria:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = txtUnidade.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe a nova unidade de medida:",
                    "Nova Unidade",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (txtUnidade.Items.Contains(input))
                {
                    txtUnidade.SelectedItem = input;
                    return;
                }

                var novaUnidade = new UnidadeMedida { unidademedida = input };
                _repositorioUnidades.Inserir(novaUnidade);

                txtUnidade.Items.Add(novaUnidade.unidademedida);
                txtUnidade.SelectedItem = novaUnidade.unidademedida;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar nova unidade de medida:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRecipiente_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = txtRecipiente.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe o nome do novo recipiente:",
                    "Novo Recipiente",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (txtRecipiente.Items.Contains(input))
                {
                    txtRecipiente.SelectedItem = input;
                    return;
                }

                var novoRecipiente = new Recipiente { nome = input };
                _repositorioRecipientes.Inserir(novoRecipiente);

                txtRecipiente.Items.Add(novoRecipiente.nome);
                txtRecipiente.SelectedItem = novoRecipiente.nome;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar novo recipiente:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEstadoFisico_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = txtEstadoFisico.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe o novo estado físico (ex.: Líquido, Sólido):",
                    "Novo Estado Físico",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (txtEstadoFisico.Items.Contains(input))
                {
                    txtEstadoFisico.SelectedItem = input;
                    return;
                }

                var novoEstado = new EstadoFisico { estado = input };
                _repositorioEstadosFisicos.Inserir(novoEstado);

                txtEstadoFisico.Items.Add(novoEstado.estado);
                txtEstadoFisico.SelectedItem = novoEstado.estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar novo estado físico:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botão "+" do fornecedor (no Designer o botão está como button1).
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string valorAtual = cboFabricante.Text?.Trim() ?? string.Empty;

                string input = Interaction.InputBox(
                    "Informe o nome do novo fornecedor:",
                    "Novo Fornecedor",
                    valorAtual);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                input = input.Trim();

                if (cboFabricante.Items.Contains(input))
                {
                    cboFabricante.SelectedItem = input;
                    return;
                }

                var novoFornecedor = new Fornecedor { nomefornecedor = input };
                _repositorioFornecedores.Inserir(novoFornecedor);

                cboFabricante.Items.Add(input);
                cboFabricante.SelectedItem = input;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar novo fornecedor:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        //   EVENTOS DE VALIDADE
        // =========================

        private void chkPerecivel_CheckedChanged(object sender, EventArgs e)
        {
            dtValidade.Enabled = chkPerecivel.Checked;

            if (!chkPerecivel.Checked)
            {
                dtValidade.CustomFormat = " ";
            }
            else
            {
                dtValidade.Format = DateTimePickerFormat.Custom;
                dtValidade.CustomFormat = "dd/MM/yyyy";
            }

            AplicarCorValidade();
        }

        private void dtValidade_ValueChanged(object sender, EventArgs e)
        {
            AplicarCorValidade();
        }

        /// <summary>
        /// Ajusta cor do calendário conforme situação da validade.
        /// </summary>
        private void AplicarCorValidade()
        {
            if (!chkPerecivel.Checked)
            {
                dtValidade.CalendarMonthBackground = System.Drawing.SystemColors.Window;
                return;
            }

            var hoje = DateTime.Today;
            var data = dtValidade.Value.Date;

            if (data < hoje)
            {
                // vencido
                dtValidade.CalendarMonthBackground = System.Drawing.Color.LightCoral;
            }
            else if (data <= hoje.AddDays(30))
            {
                // próximo do vencimento
                dtValidade.CalendarMonthBackground = System.Drawing.Color.Khaki;
            }
            else
            {
                dtValidade.CalendarMonthBackground = System.Drawing.SystemColors.Window;
            }
        }

        // =========================
        //   MÉTODOS AUXILIARES
        // =========================

        private void CarregarCombos()
        {
            // Categoria
            txtCategoria.Items.Clear();
            foreach (var categoria in _repositorioCategorias.Listar())
            {
                if (!string.IsNullOrWhiteSpace(categoria.Nome))
                    txtCategoria.Items.Add(categoria.Nome);
            }

            // Unidade
            txtUnidade.Items.Clear();
            foreach (var unidade in _repositorioUnidades.Listar())
            {
                if (!string.IsNullOrWhiteSpace(unidade.unidademedida))
                    txtUnidade.Items.Add(unidade.unidademedida);
            }

            // Depósito
            txtLocalDeposito.Items.Clear();
            foreach (var local in _repositorioLocaisArmazenamento.Listar())
            {
                if (!string.IsNullOrWhiteSpace(local.Nome))
                    txtLocalDeposito.Items.Add(local.Nome);
            }

            // Local específico
            txtLocal.Items.Clear();
            foreach (var localEsp in _repositorioLocaisEspecificos.Listar())
            {
                if (!string.IsNullOrWhiteSpace(localEsp.Nome))
                    txtLocal.Items.Add(localEsp.Nome);
            }

            // Recipiente
            txtRecipiente.Items.Clear();
            foreach (var recipiente in _repositorioRecipientes.Listar())
            {
                if (!string.IsNullOrWhiteSpace(recipiente.nome))
                    txtRecipiente.Items.Add(recipiente.nome);
            }

            // Estado físico
            txtEstadoFisico.Items.Clear();
            foreach (var estado in _repositorioEstadosFisicos.Listar())
            {
                if (!string.IsNullOrWhiteSpace(estado.estado))
                    txtEstadoFisico.Items.Add(estado.estado);
            }

            // Fornecedores
            cboFabricante.Items.Clear();
            foreach (var forn in _repositorioFornecedores.Listar())
            {
                var nome = !string.IsNullOrWhiteSpace(forn.nomefornecedor)
                    ? forn.nomefornecedor
                    : forn.nome;

                if (!string.IsNullOrWhiteSpace(nome) && !cboFabricante.Items.Contains(nome))
                    cboFabricante.Items.Add(nome);
            }
        }

        /// <summary>
        /// Validação de campos obrigatórios e regras simples.
        /// </summary>
        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do produto.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (!decimal.TryParse(txtQuantidade.Text, NumberStyles.Number,
                    CultureInfo.CurrentCulture, out decimal quantidade) || quantidade < 0)
            {
                MessageBox.Show("Informe uma quantidade válida (número maior ou igual a 0).", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Focus();
                return false;
            }

            // Sugestão automática de estoque mínimo = 1 se estiver vazio
            if (string.IsNullOrWhiteSpace(txtEstoqueMinimo.Text))
            {
                txtEstoqueMinimo.Text = "1";
            }

            if (!decimal.TryParse(txtEstoqueMinimo.Text, NumberStyles.Number,
                    CultureInfo.CurrentCulture, out decimal estoqueMinimo) || estoqueMinimo < 0)
            {
                MessageBox.Show("Informe um estoque mínimo válido (número maior ou igual a 0).", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEstoqueMinimo.Focus();
                return false;
            }

            // Validade obrigatória apenas para produtos perecíveis
            if (chkPerecivel.Checked)
            {
                // DateTimePicker já garante data válida; aqui podemos bloquear datas absurdas, se quiser.
                if (dtValidade.Value.Date < DateTime.Today.AddYears(-1))
                {
                    MessageBox.Show("Data de validade muito antiga. Verifique.", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtValidade.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifica se já existe produto com mesmo Nome + Depósito.
        /// </summary>
        private bool ExisteProdutoDuplicado()
        {
            string nome = txtNome.Text.Trim();
            string deposito = txtLocalDeposito.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(deposito))
                return false;

            var todos = _repositorioProdutos.Listar();

            var duplicado = todos.FirstOrDefault(p =>
                !string.IsNullOrWhiteSpace(p.Nome) &&
                !string.IsNullOrWhiteSpace(p.LocalDeposito) &&
                string.Equals(p.Nome.Trim(), nome, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(p.LocalDeposito.Trim(), deposito, StringComparison.OrdinalIgnoreCase) &&
                (_produtoEmEdicao == null || p.Id != _produtoEmEdicao.Id));

            return duplicado != null;
        }

        private Produto CriarProdutoAPartirDoFormulario()
        {
            decimal.TryParse(txtQuantidade.Text, NumberStyles.Number,
                CultureInfo.CurrentCulture, out decimal quantidade);

            decimal.TryParse(txtEstoqueMinimo.Text, NumberStyles.Number,
                CultureInfo.CurrentCulture, out decimal estoqueMinimo);

            DateTime? validade = null;
            if (chkPerecivel.Checked)
            {
                validade = dtValidade.Value.Date;
            }

            var produto = new Produto
            {
                Id = Guid.Empty,
                Nome = txtNome.Text.Trim(),

                Categoria = string.IsNullOrWhiteSpace(txtCategoria.Text) ? null : txtCategoria.Text.Trim(),
                Quantidade = quantidade,
                Unidade = string.IsNullOrWhiteSpace(txtUnidade.Text) ? null : txtUnidade.Text.Trim(),
                LocalDeposito = string.IsNullOrWhiteSpace(txtLocalDeposito.Text) ? null : txtLocalDeposito.Text.Trim(),
                Validade = validade,
                EstoqueMinimo = estoqueMinimo,
                Fabricante = string.IsNullOrWhiteSpace(cboFabricante.Text) ? null : cboFabricante.Text.Trim(),
                EstadoFisico = string.IsNullOrWhiteSpace(txtEstadoFisico.Text) ? null : txtEstadoFisico.Text.Trim(),
                Recipiente = string.IsNullOrWhiteSpace(txtRecipiente.Text) ? null : txtRecipiente.Text.Trim(),
                LocalEspecifico = string.IsNullOrWhiteSpace(txtLocal.Text) ? null : txtLocal.Text.Trim(),

                CategoriaId = null,
                UnidadeId = null,
                LocalId = null,
                EstadoFisicoId = null,
                RecipienteId = null,
                FornecedorId = null,
                DataCompra = null,
                CriadoEm = DateTime.MinValue
            };

            return produto;
        }

        private void AtualizarProdutoAPartirDoFormulario(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            decimal.TryParse(txtQuantidade.Text, NumberStyles.Number,
                CultureInfo.CurrentCulture, out decimal quantidade);

            decimal.TryParse(txtEstoqueMinimo.Text, NumberStyles.Number,
                CultureInfo.CurrentCulture, out decimal estoqueMinimo);

            DateTime? validade = null;
            if (chkPerecivel.Checked)
            {
                validade = dtValidade.Value.Date;
            }

            produto.Nome = txtNome.Text.Trim();
            produto.Categoria = string.IsNullOrWhiteSpace(txtCategoria.Text) ? null : txtCategoria.Text.Trim();
            produto.Quantidade = quantidade;
            produto.Unidade = string.IsNullOrWhiteSpace(txtUnidade.Text) ? null : txtUnidade.Text.Trim();
            produto.LocalDeposito = string.IsNullOrWhiteSpace(txtLocalDeposito.Text) ? null : txtLocalDeposito.Text.Trim();
            produto.Validade = validade;
            produto.EstoqueMinimo = estoqueMinimo;
            produto.Fabricante = string.IsNullOrWhiteSpace(cboFabricante.Text) ? null : cboFabricante.Text.Trim();
            produto.EstadoFisico = string.IsNullOrWhiteSpace(txtEstadoFisico.Text) ? null : txtEstadoFisico.Text.Trim();
            produto.Recipiente = string.IsNullOrWhiteSpace(txtRecipiente.Text) ? null : txtRecipiente.Text.Trim();
            produto.LocalEspecifico = string.IsNullOrWhiteSpace(txtLocal.Text) ? null : txtLocal.Text.Trim();
        }

        private void PreencherFormulario(Produto produto)
        {
            if (produto == null) return;

            txtNome.Text = produto.Nome ?? string.Empty;
            txtCategoria.Text = produto.Categoria ?? string.Empty;
            txtQuantidade.Text = produto.Quantidade.ToString("N2", CultureInfo.CurrentCulture);
            txtUnidade.Text = produto.Unidade ?? string.Empty;

            txtLocal.Text = produto.LocalEspecifico ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(txtLocal.Text) && !txtLocal.Items.Contains(txtLocal.Text))
                txtLocal.Items.Add(txtLocal.Text);

            txtLocalDeposito.Text = produto.LocalDeposito ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(txtLocalDeposito.Text) && !txtLocalDeposito.Items.Contains(txtLocalDeposito.Text))
                txtLocalDeposito.Items.Add(txtLocalDeposito.Text);

            txtEstoqueMinimo.Text = produto.EstoqueMinimo.ToString("N2", CultureInfo.CurrentCulture);

            cboFabricante.Text = produto.Fabricante ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(cboFabricante.Text) && !cboFabricante.Items.Contains(cboFabricante.Text))
                cboFabricante.Items.Add(cboFabricante.Text);

            txtEstadoFisico.Text = produto.EstadoFisico ?? string.Empty;
            txtRecipiente.Text = produto.Recipiente ?? string.Empty;

            if (produto.Validade.HasValue)
            {
                chkPerecivel.Checked = true;
                dtValidade.Format = DateTimePickerFormat.Custom;
                dtValidade.CustomFormat = "dd/MM/yyyy";
                dtValidade.Value = produto.Validade.Value;
            }
            else
            {
                chkPerecivel.Checked = false;
                dtValidade.CustomFormat = " ";
            }

            AplicarCorValidade();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtQuantidade.Clear();
            txtEstoqueMinimo.Clear();

            txtCategoria.SelectedIndex = -1;
            txtCategoria.Text = string.Empty;

            txtUnidade.SelectedIndex = -1;
            txtUnidade.Text = string.Empty;

            txtLocalDeposito.SelectedIndex = -1;
            txtLocalDeposito.Text = string.Empty;

            txtLocal.SelectedIndex = -1;
            txtLocal.Text = string.Empty;

            txtRecipiente.SelectedIndex = -1;
            txtRecipiente.Text = string.Empty;

            txtEstadoFisico.SelectedIndex = -1;
            txtEstadoFisico.Text = string.Empty;

            cboFabricante.SelectedIndex = -1;
            cboFabricante.Text = string.Empty;

            chkPerecivel.Checked = false;
            dtValidade.Value = DateTime.Today;
            dtValidade.CustomFormat = " ";

            txtNome.Focus();
        }
    }
}
