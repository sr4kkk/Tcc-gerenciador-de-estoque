using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using EstoqueQuimico.Data;
using alguamcoisa.Utils;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class PasswordPrompt : ThemedForm
    {
        private readonly RepositorioAdmins _repositorioAdmins = new RepositorioAdmins();

        public Admin? AdminAutenticado { get; private set; }

        public PasswordPrompt()
        {
            InitializeComponent();
        }

        private void PasswordPrompt_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = !chkMostrarSenha.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Autenticar();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Autenticar();
        }

        private void Autenticar()
        {
            string login = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Informe o e-mail ou nome do administrador.",
                    "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Informe a senha.", "Admin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }

            try
            {
                bool existeAdmin = _repositorioAdmins.ExisteAlgumAdmin();

                // Login temporário
                if (!existeAdmin &&
                    login.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                    senha == "2580")
                {
                    AdminAutenticado = new Admin
                    {
                        IdAdmin = 0,
                        Nome = "Admin temporário",
                        Email = "admin"
                    };
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                var admins = _repositorioAdmins.Listar();

                var admin = admins.FirstOrDefault(a =>
                    a.Email.Equals(login, StringComparison.OrdinalIgnoreCase) ||
                    a.Nome.Equals(login, StringComparison.OrdinalIgnoreCase));

                if (admin == null)
                {
                    MessageBox.Show("Administrador não encontrado.",
                        "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hash = GerarHashSenha(senha);

                if (!admin.PasswordHash.Equals(hash, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Senha incorreta.",
                        "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.SelectAll();
                    return;
                }

                AdminAutenticado = admin;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao autenticar administrador:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GerarHashSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(senha);
                var hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
