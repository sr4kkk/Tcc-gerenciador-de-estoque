using alguamcoisa.Utils;
using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using EstoqueQuimico.Models;
using alguamcoisa.Data;
using System.Net.Mail;

namespace alguamcoisa
{
    public partial class CadastrarProfessores : ThemedForm
    {
        private readonly RepositorioProfessores _repositorioProfessores = new RepositorioProfessores();
        private BindingList<Professor> _professores = new BindingList<Professor>();

        // Guarda o ID para editar
        private int _idEdicao = 0;

        // Controle de mostrar/ocultar senha
        private bool _mostrandoSenha = false;

        public CadastrarProfessores()
        {
            InitializeComponent();
        }

        private void CadastrarProfessores_Load(object sender, EventArgs e)
        {
            // aplica o padrão visual do grid
            GridHelper.ConfigurarGridCompleto(dgvProfessores);

            // carrega a lista de professores (sem o ADMIN)
            CarregarProfessores();

            // limpa os campos do formulário (modo novo)
            LimparCampos();

            // começa sem nada selecionado
            dgvProfessores.ClearSelection();

            // remover coluna PasswordHash do grid
            if (dgvProfessores.Columns["PasswordHash"] != null)
                dgvProfessores.Columns["PasswordHash"].Visible = false;

            // CPF com máscara 000.000.000-00 (14 caracteres no máximo)
            txtCpfProfessor.MaxLength = 14;

            // Sempre começa ocultando a senha
            _mostrandoSenha = false;
            txtSenhaProfessor.UseSystemPasswordChar = true;
        }

        // =====================================================
        // CARREGAR LISTA NO GRID (SEM ADMIN)
        // =====================================================
        private void CarregarProfessores()
        {
            var lista = _repositorioProfessores.Listar();

            var somenteProfessores = lista
                .Where(p => !string.Equals(p.DepartamentoProfessor ?? string.Empty,
                                           "ADMIN",
                                           StringComparison.OrdinalIgnoreCase))
                .ToList();

            _professores = new BindingList<Professor>(somenteProfessores);
            dgvProfessores.AutoGenerateColumns = true;
            dgvProfessores.DataSource = _professores;

            AtualizarEstadoBotoes();
        }

        // =====================================================
        // BOTÕES
        // =====================================================

        private void btnNovoProfessor_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtNomeProfessor.Focus();
        }

        private void btnSalvarProfessor_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação de campos (nenhum pode ficar vazio)
                if (!ValidarCampos())
                    return;

                var professor = ObterProfessorDaTela();

                if (_idEdicao == 0)
                {
                    _repositorioProfessores.Inserir(professor);
                }
                else
                {
                    professor.IdProfessor = _idEdicao;
                    _repositorioProfessores.Atualizar(professor);
                }

                CarregarProfessores();
                LimparCampos();

                MessageBox.Show("Professor salvo com sucesso.",
                    "Professores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar professor:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirProfessor_Click(object sender, EventArgs e)
        {
            if (dgvProfessores.CurrentRow == null)
                return;

            var professor = dgvProfessores.CurrentRow.DataBoundItem as Professor;
            if (professor == null) return;

            if (MessageBox.Show($"Excluir professor \"{professor.NomeProfessor}\"?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _repositorioProfessores.Excluir(professor.IdProfessor);
                    CarregarProfessores();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir professor:\n\n" + ex.Message,
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarProfessor_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Botão para editar o professor atualmente selecionado no grid.
        /// </summary>
        private void btnEditarProfessorSelecionado_Click(object sender, EventArgs e)
        {
            if (dgvProfessores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um professor na lista para editar.",
                    "Professores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var professor = dgvProfessores.CurrentRow.DataBoundItem as Professor;
            if (professor == null)
                return;

            PreencherCampos(professor);
            txtNomeProfessor.Focus();
        }

        // =====================================================
        // GRID SELEÇÃO
        // =====================================================

        private void dgvProfessores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Duplo clique também abre para edição
            btnEditarProfessorSelecionado_Click(sender, EventArgs.Empty);
        }

        private void dgvProfessores_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarEstadoBotoes();
        }

        private void AtualizarEstadoBotoes()
        {
            bool temSelecionado = dgvProfessores.CurrentRow != null &&
                                  dgvProfessores.CurrentRow.DataBoundItem is Professor;

            btnEditarProfessorSelecionado.Enabled = temSelecionado;
            btnExcluirProfessor.Enabled = temSelecionado;
        }

        // =====================================================
        // MONTAR / LER OBJETO PROFESSOR
        // =====================================================

        private void PreencherCampos(Professor professor)
        {
            _idEdicao = professor.IdProfessor;

            txtNomeProfessor.Text = professor.NomeProfessor;
            txtMatriculaProfessor.Text = professor.MatriculaProfessor;
            txtEmailProfessor.Text = professor.EmailProfessor;
            txtTelefoneProfessor.Text = professor.TelefoneProfessor;
            txtDepartamentoProfessor.Text = professor.DepartamentoProfessor;
            txtObservacaoProfessor.Text = professor.ObservacaoProfessor;

            // Aplica máscara no CPF ao carregar (se vier apenas com dígitos)
            var cpf = professor.CPFProfessor ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                var digitos = SomenteDigitos(cpf);
                txtCpfProfessor.Text = MontarCpfFormatado(digitos);
            }
            else
            {
                txtCpfProfessor.Clear();
            }

            // Senha nunca é mostrada ao editar
            txtSenhaProfessor.Clear();
            _mostrandoSenha = false;
            txtSenhaProfessor.UseSystemPasswordChar = true;

            // Quando editar, senha começa desabilitada
            txtSenhaProfessor.Enabled = false;
            btnMostrarSenhaProfessor.Enabled = false;

            // Perguntar se deseja alterar a senha
            var resp = MessageBox.Show(
                "Você deseja alterar a senha deste professor?",
                "Alterar senha",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                txtSenhaProfessor.Enabled = true;
                btnMostrarSenhaProfessor.Enabled = true;
                txtSenhaProfessor.Focus();
            }
        }

        private Professor ObterProfessorDaTela()
        {
            var professor = new Professor();

            professor.NomeProfessor = txtNomeProfessor.Text.Trim();
            professor.MatriculaProfessor = txtMatriculaProfessor.Text.Trim();
            professor.EmailProfessor = txtEmailProfessor.Text.Trim();
            professor.TelefoneProfessor = txtTelefoneProfessor.Text.Trim();
            professor.DepartamentoProfessor = txtDepartamentoProfessor.Text.Trim();
            professor.ObservacaoProfessor = txtObservacaoProfessor.Text.Trim();

            // CPF salvo apenas com dígitos, tamanho no máximo 11
            var cpfDigitos = SomenteDigitos(txtCpfProfessor.Text);
            if (cpfDigitos.Length > 11)
                cpfDigitos = cpfDigitos.Substring(0, 11);
            professor.CPFProfessor = cpfDigitos;

            // Só gera hash se tiver algo digitado
            if (!string.IsNullOrWhiteSpace(txtSenhaProfessor.Text))
            {
                professor.PasswordHash = GerarHashSenha(txtSenhaProfessor.Text);
            }

            return professor;
        }

        private void LimparCampos()
        {
            _idEdicao = 0;

            txtNomeProfessor.Clear();
            txtMatriculaProfessor.Clear();
            txtEmailProfessor.Clear();
            txtTelefoneProfessor.Clear();
            txtDepartamentoProfessor.Clear();
            txtObservacaoProfessor.Clear();
            txtCpfProfessor.Clear();
            txtSenhaProfessor.Clear();

            // Modo "novo": senha sempre habilitada
            txtSenhaProfessor.Enabled = true;
            _mostrandoSenha = false;
            txtSenhaProfessor.UseSystemPasswordChar = true;
            btnMostrarSenhaProfessor.Enabled = true;
            btnMostrarSenhaProfessor.Text = "Mostrar";

            dgvProfessores.ClearSelection();
            AtualizarEstadoBotoes();
        }

        // =====================================================
        // VALIDAÇÃO DE CAMPOS
        // =====================================================

        private bool ValidarCampos()
        {
            // Nenhum campo pode ficar vazio

            if (string.IsNullOrWhiteSpace(txtNomeProfessor.Text))
            {
                MessageBox.Show("Informe o nome do professor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeProfessor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatriculaProfessor.Text))
            {
                MessageBox.Show("Informe a matrícula do professor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatriculaProfessor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCpfProfessor.Text))
            {
                MessageBox.Show("Informe o CPF do professor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpfProfessor.Focus();
                return false;
            }

            // Senha:
            // - Novo professor (_idEdicao == 0) => obrigatório
            // - Edição: obrigatória somente se o campo estiver habilitado
            if (_idEdicao == 0)
            {
                if (string.IsNullOrWhiteSpace(txtSenhaProfessor.Text))
                {
                    MessageBox.Show("Informe a senha de acesso do professor.",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaProfessor.Focus();
                    return false;
                }
            }
            else
            {
                if (txtSenhaProfessor.Enabled &&
                    string.IsNullOrWhiteSpace(txtSenhaProfessor.Text))
                {
                    MessageBox.Show("Informe a nova senha ou cancele a alteração de senha.",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaProfessor.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtEmailProfessor.Text))
            {
                MessageBox.Show("Informe o e-mail do professor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailProfessor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefoneProfessor.Text))
            {
                MessageBox.Show("Informe o telefone do professor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefoneProfessor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDepartamentoProfessor.Text))
            {
                MessageBox.Show("Informe o departamento do professor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartamentoProfessor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtObservacaoProfessor.Text))
            {
                MessageBox.Show("Informe uma observação (pode ser um traço se não tiver nada).",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacaoProfessor.Focus();
                return false;
            }

            // Telefone deve ter 10 ou 11 dígitos
            var telefoneDigitos = SomenteDigitos(txtTelefoneProfessor.Text);
            if (telefoneDigitos.Length < 10 || telefoneDigitos.Length > 11)
            {
                MessageBox.Show("Telefone inválido. Informe com DDD (10 ou 11 dígitos).",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefoneProfessor.Focus();
                return false;
            }

            // CPF deve ter exatamente 11 dígitos
            var cpfDigitos = SomenteDigitos(txtCpfProfessor.Text);
            if (cpfDigitos.Length != 11)
            {
                MessageBox.Show("CPF inválido. Informe 11 dígitos.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpfProfessor.Focus();
                return false;
            }

            // E-mail deve ter formato válido
            var email = txtEmailProfessor.Text.Trim();
            try
            {
                var mail = new MailAddress(email);
            }
            catch
            {
                MessageBox.Show("E-mail inválido.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailProfessor.Focus();
                return false;
            }

            return true;
        }

        // =====================================================
        // HELPERS DE TEXTO
        // =====================================================

        private string SomenteDigitos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            var sb = new StringBuilder(texto.Length);
            foreach (var c in texto)
            {
                if (char.IsDigit(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private string MontarCpfFormatado(string digitos)
        {
            if (string.IsNullOrEmpty(digitos))
                return string.Empty;

            if (digitos.Length > 11)
                digitos = digitos.Substring(0, 11);

            if (digitos.Length <= 3)
            {
                return digitos;
            }
            else if (digitos.Length <= 6)
            {
                return $"{digitos.Substring(0, 3)}.{digitos.Substring(3)}";
            }
            else if (digitos.Length <= 9)
            {
                return $"{digitos.Substring(0, 3)}.{digitos.Substring(3, 3)}.{digitos.Substring(6)}";
            }
            else // 10 ou 11
            {
                return $"{digitos.Substring(0, 3)}.{digitos.Substring(3, 3)}.{digitos.Substring(6, 3)}-{digitos.Substring(9)}";
            }
        }

        // =====================================================
        // EVENTOS DOS CAMPOS (MELHORIAS VISUAIS)
        // =====================================================

        // TELEFONE ------------------------------------------------

        private void txtTelefoneProfessor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e teclas de controle (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefoneProfessor_TextChanged(object sender, EventArgs e)
        {
            // Remove eventos duplicados para evitar loop
            txtTelefoneProfessor.TextChanged -= txtTelefoneProfessor_TextChanged;

            string somenteDigitos = SomenteDigitos(txtTelefoneProfessor.Text);

            if (somenteDigitos.Length == 0)
            {
                txtTelefoneProfessor.Clear();
                txtTelefoneProfessor.TextChanged += txtTelefoneProfessor_TextChanged;
                return;
            }

            string textoFormatado;

            if (somenteDigitos.Length <= 2)
            {
                textoFormatado = $"({somenteDigitos}";
            }
            else if (somenteDigitos.Length <= 6)
            {
                textoFormatado = $"({somenteDigitos.Substring(0, 2)}) {somenteDigitos.Substring(2)}";
            }
            else if (somenteDigitos.Length <= 10)
            {
                int n = somenteDigitos.Length;
                int qtdMeio = n - 6; // entre DDD e últimos 4
                string meio = somenteDigitos.Substring(2, qtdMeio);
                string ultimos4 = somenteDigitos.Substring(n - 4, 4);
                textoFormatado = $"({somenteDigitos.Substring(0, 2)}) {meio}-{ultimos4}";
            }
            else
            {
                // Máximo permitido: 11 dígitos => (XX) XXXXX-XXXX
                string d = somenteDigitos.Substring(0, 11);
                textoFormatado = $"({d.Substring(0, 2)}) {d.Substring(2, 5)}-{d.Substring(7, 4)}";
            }

            txtTelefoneProfessor.Text = textoFormatado;
            txtTelefoneProfessor.SelectionStart = txtTelefoneProfessor.Text.Length;

            txtTelefoneProfessor.TextChanged += txtTelefoneProfessor_TextChanged;
        }

        // CPF -----------------------------------------------------

        private void txtCpfProfessor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e controle
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCpfProfessor_TextChanged(object sender, EventArgs e)
        {
            txtCpfProfessor.TextChanged -= txtCpfProfessor_TextChanged;

            var digitos = SomenteDigitos(txtCpfProfessor.Text);

            if (digitos.Length == 0)
            {
                txtCpfProfessor.Clear();
                txtCpfProfessor.TextChanged += txtCpfProfessor_TextChanged;
                return;
            }

            if (digitos.Length > 11)
                digitos = digitos.Substring(0, 11);

            txtCpfProfessor.Text = MontarCpfFormatado(digitos);
            txtCpfProfessor.SelectionStart = txtCpfProfessor.Text.Length;

            txtCpfProfessor.TextChanged += txtCpfProfessor_TextChanged;
        }

        private void txtCpfProfessor_Leave(object sender, EventArgs e)
        {
            var digitos = SomenteDigitos(txtCpfProfessor.Text);

            if (string.IsNullOrEmpty(digitos))
                return;

            if (digitos.Length != 11)
            {
                MessageBox.Show("CPF deve conter 11 dígitos.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpfProfessor.Focus();
            }
        }

        // E-MAIL --------------------------------------------------

        private void txtEmailProfessor_Leave(object sender, EventArgs e)
        {
            string email = txtEmailProfessor.Text.Trim();

            if (string.IsNullOrEmpty(email))
                return; // Validação de vazio é feita em ValidarCampos()

            // Se não tiver @ ou . nem tenta validar → evita erro precoce
            if (!email.Contains("@") || !email.Contains("."))
                return;

            try
            {
                var mail = new MailAddress(email);
            }
            catch
            {
                MessageBox.Show("E-mail inválido.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailProfessor.Focus();
            }
        }

        // SENHA – MOSTRAR / OCULTAR -------------------------------

        private void btnMostrarSenhaProfessor_Click(object sender, EventArgs e)
        {
            if (!txtSenhaProfessor.Enabled)
                return; // se não pode alterar, não precisa mostrar/ocultar

            _mostrandoSenha = !_mostrandoSenha;
            txtSenhaProfessor.UseSystemPasswordChar = !_mostrandoSenha;
            btnMostrarSenhaProfessor.Text = _mostrandoSenha ? "Ocultar" : "Mostrar";
        }

        // =====================================================
        // HASH SHA-256
        // =====================================================

        private string GerarHashSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return string.Empty;

            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(senha);
                var hash = sha256.ComputeHash(bytes);

                var sb = new StringBuilder(hash.Length * 2);
                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
