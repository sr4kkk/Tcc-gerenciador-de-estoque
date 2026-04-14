using alguamcoisa.Utils;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using EstoqueQuimico.Models;
using alguamcoisa.Data;
using EstoqueQuimico.Data;   // ✅ para RepositorioAdmins
using alguamcoisa.Infra;     // ✅ para AdminConfigForm

namespace alguamcoisa
{
    public partial class LoginForm : ThemedForm
    {
        private readonly RepositorioProfessores _repositorioProfessores = new RepositorioProfessores();
        private readonly RepositorioAdmins _repositorioAdmins = new RepositorioAdmins();

        private static readonly string RememberFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login_remember.dat");

        public Professor? UsuarioLogado { get; private set; }
        public Admin? AdminLogado { get; private set; }
        public bool LoginTemporario { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            if (cmbPerfil.Items.Count > 0 && cmbPerfil.SelectedIndex < 0)
                cmbPerfil.SelectedIndex = 0; // Professor como padrão

            CarregarLoginLembrado();
            txtNome.Focus();
        }

        // Atalho oculto: Ctrl + Alt + A para abrir menu admin
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Menu oculto: Ctrl + Alt + A
            if (e.Control && e.Alt && e.KeyCode == Keys.A)
            {
                // 1️⃣ Primeiro pede autenticação de administrador (tabela Admins)
                using (var prompt = new PasswordPrompt())
                {
                    var result = prompt.ShowDialog(this);

                    if (result == DialogResult.OK && prompt.AdminAutenticado != null)
                    {
                        // 2️⃣ Se autenticou, abre o painel de administradores
                        using (var frm = new AdminConfigForm())
                        {
                            frm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        // Se cancelar ou falhar, apenas não abre nada
                    }
                }

                // Volta foco para o campo de nome
                txtNome.Focus();
            }
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Só muda o label para ficar mais amigável visualmente
            var perfil = cmbPerfil.SelectedItem?.ToString() ?? "Professor";
            if (perfil == "Professor")
                lblSenha.Text = "Senha (Professor)";
            else
                lblSenha.Text = "Senha (Admin)";
        }

        private void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = !chkMostrarSenha.Checked;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            TentarLogin();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar.PerformClick();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar.PerformClick();
        }

        // ======================= LOGIN ==========================
        private void TentarLogin()
        {
            string nomeOuEmail = txtNome.Text.Trim();
            string senha = txtSenha.Text;
            string perfil = (cmbPerfil.SelectedItem as string) ?? "Professor";

            if (string.IsNullOrWhiteSpace(nomeOuEmail))
            {
                MessageBox.Show("Informe seu nome ou e-mail.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Informe a senha.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }

            try
            {
                if (perfil == "Admin")
                {
                    // ===== LOGIN COMO ADMIN (tabela Admins) =====
                    bool existeAlgumAdmin = _repositorioAdmins.ExisteAlgumAdmin();

                    // --- LOGIN TEMPORÁRIO (quando não existir nenhum admin cadastrado) ---
                    if (!existeAlgumAdmin &&
                        string.Equals(nomeOuEmail, "admin", StringComparison.OrdinalIgnoreCase) &&
                        senha == "2580")
                    {
                        LoginTemporario = true;
                        UsuarioLogado = null;
                        AdminLogado = null;

                        // Atualiza sessão como admin temporário
                        SessaoUsuario.DefinirAdmin("Admin temporário");

                        // não vale a pena lembrar o temporário
                        SalvarOuLimparLoginLembrado(chkLembrarSenha: false);

                        DialogResult = DialogResult.OK;
                        Close();
                        return;
                    }

                    // --- LOGIN NORMAL NA TABELA ADMINS ---
                    var admins = _repositorioAdmins.Listar();

                    var admin = admins.FirstOrDefault(a =>
                        string.Equals(a.Email?.Trim() ?? "", nomeOuEmail, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(a.Nome?.Trim() ?? "", nomeOuEmail, StringComparison.OrdinalIgnoreCase));

                    if (admin == null)
                    {
                        MessageBox.Show("Administrador não encontrado.",
                            "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(admin.PasswordHash))
                    {
                        MessageBox.Show("Este administrador ainda não possui senha cadastrada.",
                            "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string hashInformada = GerarHashSenha(senha);

                    if (!string.Equals(admin.PasswordHash, hashInformada, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Senha inválida.", "Login",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenha.SelectAll();
                        txtSenha.Focus();
                        return;
                    }

                    // Sucesso - login como admin
                    UsuarioLogado = null;
                    AdminLogado = admin;
                    LoginTemporario = false;

                    // Atualiza sessão como Admin normal
                    var nomeAdmin = !string.IsNullOrWhiteSpace(admin.Nome)
                        ? admin.Nome
                        : (admin.Email ?? "Administrador");

                    SessaoUsuario.DefinirAdmin(nomeAdmin);

                    SalvarOuLimparLoginLembrado(false);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    // ===== LOGIN COMO PROFESSOR =====
                    var listaProf = _repositorioProfessores.Listar();

                    // Ignora qualquer professor que tenha Departamento = ADMIN (não queremos misturar mais)
                    var professor = listaProf.FirstOrDefault(p =>
                        (string.Equals(p.NomeProfessor?.Trim() ?? "", nomeOuEmail, StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(p.EmailProfessor?.Trim() ?? "", nomeOuEmail, StringComparison.OrdinalIgnoreCase)) &&
                        !string.Equals(p.DepartamentoProfessor ?? "", "ADMIN", StringComparison.OrdinalIgnoreCase));

                    if (professor == null)
                    {
                        MessageBox.Show("Usuário não encontrado para o perfil selecionado.",
                            "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(professor.PasswordHash))
                    {
                        MessageBox.Show("Este usuário ainda não possui senha cadastrada.",
                            "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string hashInformada = GerarHashSenha(senha);
                    if (!string.Equals(professor.PasswordHash, hashInformada, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Senha inválida.", "Login",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenha.SelectAll();
                        txtSenha.Focus();
                        return;
                    }


                    UsuarioLogado = professor;
                    AdminLogado = null;
                    LoginTemporario = false;

                    // Atualiza sessão como Professor
                    var nomeProf = !string.IsNullOrWhiteSpace(professor.NomeProfessor)
                        ? professor.NomeProfessor
                        : "Professor";

                    SessaoUsuario.DefinirProfessor(professor.IdProfessor, nomeProf);

                    SalvarOuLimparLoginLembrado(false);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar efetuar login:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================= LEMBRAR LOGIN ==================
        private void CarregarLoginLembrado()
        {
            try
            {
                if (!File.Exists(RememberFilePath))
                    return;

                var conteudo = File.ReadAllText(RememberFilePath);
                var partes = conteudo.Split('|');

                if (partes.Length >= 2)
                {
                    txtNome.Text = partes[0];
                    txtSenha.Text = partes[1];
                }
            }
            catch
            {
                // ignora erros ao ler
            }
        }

        private void SalvarOuLimparLoginLembrado(bool chkLembrarSenha)
        {
            try
            {
                if (chkLembrarSenha)
                {
                    var conteudo = $"{txtNome.Text}|{txtSenha.Text}";
                    File.WriteAllText(RememberFilePath, conteudo);
                }
                else
                {
                    if (File.Exists(RememberFilePath))
                        File.Delete(RememberFilePath);
                }
            }
            catch
            {
                // não quebra login
            }
        }

        // ======================= HASH SENHA =====================
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
