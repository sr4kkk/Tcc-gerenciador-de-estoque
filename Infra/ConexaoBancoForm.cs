// Infra/ConexaoBancoForm.cs
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace alguamcoisa.Infra
{
    public partial class ConexaoBancoForm : Form
    {
        private Label lblTitulo;
        private Label lblServidor;
        private TextBox txtServidor;
        private Label lblAutenticacao;
        private ComboBox cboAutenticacao;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblBanco;
        private TextBox txtBanco;
        private Button btnTestar;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label lblStatus;

        public ConexaoBancoForm()
        {
            InitializeComponent();
            CarregarConfiguracaoExistente();
        }

        #region Inicialização / Designer

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblServidor = new Label();
            txtServidor = new TextBox();
            lblAutenticacao = new Label();
            cboAutenticacao = new ComboBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblBanco = new Label();
            txtBanco = new TextBox();
            btnTestar = new Button();
            btnSalvar = new Button();
            btnCancelar = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(460, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuração de Conexão com Banco de Dados";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Location = new Point(18, 66);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(53, 15);
            lblServidor.TabIndex = 1;
            lblServidor.Text = "Servidor:";
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(18, 84);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(360, 23);
            txtServidor.TabIndex = 0;
            // 
            // lblAutenticacao
            // 
            lblAutenticacao.AutoSize = true;
            lblAutenticacao.Location = new Point(18, 125);
            lblAutenticacao.Name = "lblAutenticacao";
            lblAutenticacao.Size = new Size(80, 15);
            lblAutenticacao.TabIndex = 3;
            lblAutenticacao.Text = "Autenticação:";
            // 
            // cboAutenticacao
            // 
            cboAutenticacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAutenticacao.FormattingEnabled = true;
            cboAutenticacao.Items.AddRange(new object[] { "Autenticação do Windows", "Autenticação do SQL Server" });
            cboAutenticacao.Location = new Point(18, 143);
            cboAutenticacao.Name = "cboAutenticacao";
            cboAutenticacao.Size = new Size(360, 23);
            cboAutenticacao.TabIndex = 1;
            cboAutenticacao.SelectedIndexChanged += cboAutenticacao_SelectedIndexChanged;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(18, 181);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(18, 199);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(220, 23);
            txtUsuario.TabIndex = 2;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(247, 181);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(42, 15);
            lblSenha.TabIndex = 7;
            lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(247, 199);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(131, 23);
            txtSenha.TabIndex = 3;
            // 
            // lblBanco
            // 
            lblBanco.AutoSize = true;
            lblBanco.Location = new Point(15, 240);
            lblBanco.Name = "lblBanco";
            lblBanco.Size = new Size(95, 15);
            lblBanco.TabIndex = 9;
            lblBanco.Text = "Banco de Dados:";
            // 
            // txtBanco
            // 
            txtBanco.Location = new Point(15, 271);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(360, 23);
            txtBanco.TabIndex = 4;
            // 
            // btnTestar
            // 
            btnTestar.Location = new Point(18, 324);
            btnTestar.Name = "btnTestar";
            btnTestar.Size = new Size(120, 42);
            btnTestar.TabIndex = 5;
            btnTestar.Text = "Testar Conexão";
            btnTestar.UseVisualStyleBackColor = true;
            btnTestar.Click += btnTestar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(144, 324);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 42);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(270, 324);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 42);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Fechar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoEllipsis = true;
            lblStatus.ForeColor = Color.DarkBlue;
            lblStatus.Location = new Point(12, 443);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 40);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Informe os dados de conexão e clique em Testar.";
            // 
            // ConexaoBancoForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(478, 492);
            Controls.Add(lblStatus);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(btnTestar);
            Controls.Add(txtBanco);
            Controls.Add(lblBanco);
            Controls.Add(txtSenha);
            Controls.Add(lblSenha);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(cboAutenticacao);
            Controls.Add(lblAutenticacao);
            Controls.Add(txtServidor);
            Controls.Add(lblServidor);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConexaoBancoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conexão com Banco de Dados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Lógica da Tela

        private void cboAutenticacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool sqlAuth = cboAutenticacao.SelectedIndex == 1; // 0 = Windows, 1 = SQL Server

            txtUsuario.Enabled = sqlAuth;
            txtSenha.Enabled = sqlAuth;
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text.Trim();

            if (string.IsNullOrWhiteSpace(servidor))
            {
                MessageBox.Show("Informe o servidor.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServidor.Focus();
                return;
            }

            if (cboAutenticacao.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tipo de autenticação.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAutenticacao.Focus();
                return;
            }

            string connectionString = MontarConnectionStringParaTeste();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }

                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text = "Conexão realizada com sucesso.";
                MessageBox.Show("Conexão realizada com sucesso.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Text = "Erro ao conectar: " + ex.Message;
                MessageBox.Show("Erro ao conectar ao banco de dados:\n\n" + ex.Message,
                    "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text.Trim();

            if (string.IsNullOrWhiteSpace(servidor))
            {
                MessageBox.Show("Informe o servidor.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServidor.Focus();
                return;
            }

            if (cboAutenticacao.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tipo de autenticação.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAutenticacao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBanco.Text))
            {
                MessageBox.Show("Informe o nome do banco de dados.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBanco.Focus();
                return;
            }

            string connectionString = MontarConnectionStringPadraoAplicacao();

            // Testa conexão com o banco informado
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                var resp = MessageBox.Show(
                    "Erro ao conectar com as configurações informadas:\n\n" + ex.Message +
                    "\n\nDeseja salvar mesmo assim?",
                    "Erro de conexão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resp != DialogResult.Yes)
                    return;
            }

            try
            {
                SalvarConnectionStringNoConfig(connectionString);
                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text = "Configuração salva com sucesso.";

                MessageBox.Show("Configuração de conexão salva com sucesso.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Text = "Erro ao salvar configuração: " + ex.Message;

                MessageBox.Show("Erro ao salvar configuração de conexão:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Montagem e Persistência da Connection String

        /// <summary>
        /// Monta a connection string apontando para o banco master (uso para teste).
        /// </summary>
        private string MontarConnectionStringParaTeste()
        {
            string servidor = txtServidor.Text.Trim();
            bool sqlAuth = cboAutenticacao.SelectedIndex == 1;

            if (!sqlAuth)
            {
                // Autenticação do Windows
                return $"Server={servidor};Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
            }
            else
            {
                string usuario = txtUsuario.Text.Trim();
                string senha = txtSenha.Text;

                return $"Server={servidor};Database=master;User Id={usuario};Password={senha};TrustServerCertificate=True;";
            }
        }

        /// <summary>
        /// Monta a connection string que será usada pelo sistema (aponta para o banco escolhido em txtBanco).
        /// </summary>
        private string MontarConnectionStringPadraoAplicacao()
        {
            string servidor = txtServidor.Text.Trim();
            string banco = txtBanco.Text.Trim();
            bool sqlAuth = cboAutenticacao.SelectedIndex == 1;

            if (!sqlAuth)
            {
                return $"Server={servidor};Database={banco};Trusted_Connection=True;TrustServerCertificate=True;";
            }
            else
            {
                string usuario = txtUsuario.Text.Trim();
                string senha = txtSenha.Text;

                return $"Server={servidor};Database={banco};User Id={usuario};Password={senha};TrustServerCertificate=True;";
            }
        }

        private void SalvarConnectionStringNoConfig(string connectionString)
        {
            // Atualiza/Cria ConnectionString "EstoqueQuimico" no app.config
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var section = (ConnectionStringsSection)config.GetSection("connectionStrings");
            if (section.ConnectionStrings["EstoqueQuimico"] == null)
            {
                section.ConnectionStrings.Add(new ConnectionStringSettings
                {
                    Name = "EstoqueQuimico",
                    ConnectionString = connectionString,
                    ProviderName = "Microsoft.Data.SqlClient"
                });
            }
            else
            {
                section.ConnectionStrings["EstoqueQuimico"].ConnectionString = connectionString;
                section.ConnectionStrings["EstoqueQuimico"].ProviderName = "Microsoft.Data.SqlClient";
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void CarregarConfiguracaoExistente()
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["EstoqueQuimico"];
                if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                {
                    // Sem config ainda
                    cboAutenticacao.SelectedIndex = 1; // deixa SQL Server como padrão
                    lblStatus.Text = "Informe os dados de conexão e clique em Testar.";
                    lblStatus.ForeColor = Color.DarkBlue;
                    return;
                }

                string conn = cs.ConnectionString;

                string servidor = ExtrairValor(conn, "Server");
                string usuario = ExtrairValor(conn, "User Id");
                string trusted = ExtrairValor(conn, "Trusted_Connection");
                string banco = ExtrairValor(conn, "Database");

                txtServidor.Text = servidor;
                txtBanco.Text = banco;

                if (!string.IsNullOrEmpty(trusted) &&
                    trusted.Equals("True", StringComparison.OrdinalIgnoreCase))
                {
                    // Windows
                    cboAutenticacao.SelectedIndex = 0;
                    txtUsuario.Enabled = false;
                    txtSenha.Enabled = false;
                }
                else
                {
                    // SQL Server
                    cboAutenticacao.SelectedIndex = 1;
                    txtUsuario.Text = usuario;
                    txtUsuario.Enabled = true;
                    txtSenha.Enabled = true;
                }

                lblStatus.Text = "Configuração atual carregada. Você pode alterar e salvar novamente.";
                lblStatus.ForeColor = Color.DarkBlue;
            }
            catch
            {
                cboAutenticacao.SelectedIndex = 1;
                lblStatus.Text = "Não foi possível carregar a configuração. Informe os dados e salve novamente.";
                lblStatus.ForeColor = Color.DarkRed;
            }
        }

        private string ExtrairValor(string connectionString, string chave)
        {
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(chave))
                return string.Empty;

            string[] partes = connectionString.Split(';');
            foreach (var p in partes)
            {
                if (string.IsNullOrWhiteSpace(p)) continue;

                var idx = p.IndexOf('=');
                if (idx <= 0) continue;

                var k = p.Substring(0, idx).Trim();
                var v = p.Substring(idx + 1).Trim();

                if (k.Equals(chave, StringComparison.OrdinalIgnoreCase))
                    return v;
            }

            return string.Empty;
        }

        #endregion
    }
}
