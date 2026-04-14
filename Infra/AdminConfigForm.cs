using alguamcoisa.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using EstoqueQuimico.Models;
using EstoqueQuimico.Data;

namespace alguamcoisa.Infra
{
    public partial class AdminConfigForm : ThemedForm
    {
        private readonly RepositorioAdmins _repositorioAdmins = new RepositorioAdmins();

        private BindingList<Admin> _admins = new BindingList<Admin>();
        private int _idEdicao = 0;

        public AdminConfigForm()
        {
            InitializeComponent();
            // NOVO: padroniza o form e aplica escala de DPI
            FormHelper.ConfigurarFormPadrao(this);
        }

        private void AdminConfigForm_Load(object sender, EventArgs e)
        {
            CarregarAdmins();
            LimparCampos();
        }

        // =====================================================
        // CARREGAR LISTA DE ADMINISTRADORES
        // =====================================================
        private void CarregarAdmins()
        {
            var lista = _repositorioAdmins.Listar()
                .OrderBy(a => a.Nome)
                .ToList();

            _admins = new BindingList<Admin>(lista);
            lstAdmins.DataSource = _admins;
            lstAdmins.DisplayMember = "Nome";
            lstAdmins.ValueMember = "IdAdmin";
        }

        // =====================================================
        // LISTA → CAMPOS
        // =====================================================
        private void lstAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAdmins.SelectedItem is Admin admin)
            {
                PreencherCampos(admin);
            }
        }

        private void PreencherCampos(Admin admin)
        {
            _idEdicao = admin.IdAdmin;

            txtNomeAdmin.Text = admin.Nome;
            txtEmailAdmin.Text = admin.Email;
            txtSenhaNova.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }

        private void LimparCampos()
        {
            _idEdicao = 0;

            txtNomeAdmin.Clear();
            txtEmailAdmin.Clear();
            txtSenhaNova.Clear();
            txtConfirmarSenha.Clear();

            lstAdmins.ClearSelected();
        }

        // =====================================================
        // BOTÕES
        // =====================================================
        private void btnNovoAdmin_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtNomeAdmin.Focus();
        }

        private void btnSalvarAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNomeAdmin.Text.Trim();
                string email = txtEmailAdmin.Text.Trim();
                string senhaNova = txtSenhaNova.Text;
                string senhaConfirma = txtConfirmarSenha.Text;

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show("Informe o nome do administrador.", "Admins",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeAdmin.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Informe o e-mail do administrador.", "Admins",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailAdmin.Focus();
                    return;
                }

                if (!string.IsNullOrEmpty(senhaNova) || !string.IsNullOrEmpty(senhaConfirma))
                {
                    if (senhaNova != senhaConfirma)
                    {
                        MessageBox.Show("A confirmação da senha não confere.", "Admins",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtConfirmarSenha.Focus();
                        return;
                    }
                }

                Admin admin;

                if (_idEdicao == 0)
                {
                    // Novo admin
                    admin = new Admin
                    {
                        Nome = nome,
                        Email = email
                    };

                    if (!string.IsNullOrEmpty(senhaNova))
                    {
                        admin.PasswordHash = GerarHashSenha(senhaNova);
                    }
                    else
                    {
                        // Senha padrão ao criar sem definir senha
                        admin.PasswordHash = GerarHashSenha("2580");
                    }

                    _repositorioAdmins.Inserir(admin);
                }
                else
                {
                    // Atualizar admin existente
                    admin = _admins.FirstOrDefault(a => a.IdAdmin == _idEdicao);
                    if (admin == null)
                    {
                        MessageBox.Show("Administrador não encontrado na lista.", "Admins",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    admin.Nome = nome;
                    admin.Email = email;

                    if (!string.IsNullOrEmpty(senhaNova))
                    {
                        admin.PasswordHash = GerarHashSenha(senhaNova);
                    }

                    _repositorioAdmins.Atualizar(admin);
                }

                CarregarAdmins();
                LimparCampos();

                MessageBox.Show("Administrador salvo com sucesso.", "Admins",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar administrador:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetSenhaAdmin_Click(object sender, EventArgs e)
        {
            if (!(lstAdmins.SelectedItem is Admin admin))
            {
                MessageBox.Show("Selecione um administrador.", "Admins",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    $"Resetar a senha do administrador \"{admin.Nome}\" para 2580?",
                    "Reset de Senha",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                admin.PasswordHash = GerarHashSenha("2580");
                _repositorioAdmins.Atualizar(admin);

                MessageBox.Show("Senha resetada para 2580.", "Admins",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao resetar senha:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverAdmin_Click(object sender, EventArgs e)
        {
            if (!(lstAdmins.SelectedItem is Admin admin))
            {
                MessageBox.Show("Selecione um administrador para remover.", "Admins",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mantém pelo menos 3 admins cadastrados
            if (_admins.Count <= 3)
            {
                MessageBox.Show("É necessário manter pelo menos 3 administradores cadastrados.",
                    "Admins", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(
                    $"Tem certeza que deseja remover o administrador \"{admin.Nome}\"?",
                    "Remover Admin",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _repositorioAdmins.Excluir(admin.IdAdmin);
                CarregarAdmins();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover administrador:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =====================================================
        // HASH SENHA (SHA-256)
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
