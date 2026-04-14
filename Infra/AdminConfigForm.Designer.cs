namespace alguamcoisa.Infra
{
    partial class AdminConfigForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lstAdmins;

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNomeAdmin;

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmailAdmin;

        private System.Windows.Forms.Label lblSenhaNova;
        private System.Windows.Forms.TextBox txtSenhaNova;

        private System.Windows.Forms.Label lblConfirmarSenha;
        private System.Windows.Forms.TextBox txtConfirmarSenha;

        private System.Windows.Forms.Button btnNovoAdmin;
        private System.Windows.Forms.Button btnSalvarAdmin;
        private System.Windows.Forms.Button btnResetSenhaAdmin;
        private System.Windows.Forms.Button btnRemoverAdmin;
        private System.Windows.Forms.Button btnFechar;

        private System.Windows.Forms.Label lblRegras;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lstAdmins = new ListBox();
            lblNome = new Label();
            txtNomeAdmin = new TextBox();
            lblEmail = new Label();
            txtEmailAdmin = new TextBox();
            lblSenhaNova = new Label();
            txtSenhaNova = new TextBox();
            lblConfirmarSenha = new Label();
            txtConfirmarSenha = new TextBox();
            btnNovoAdmin = new Button();
            btnSalvarAdmin = new Button();
            btnResetSenhaAdmin = new Button();
            btnRemoverAdmin = new Button();
            btnFechar = new Button();
            lblRegras = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(232, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuração de Admins";
            // 
            // lstAdmins
            // 
            lstAdmins.Font = new Font("Segoe UI", 10F);
            lstAdmins.FormattingEnabled = true;
            lstAdmins.Location = new Point(24, 52);
            lstAdmins.Name = "lstAdmins";
            lstAdmins.Size = new Size(220, 344);
            lstAdmins.TabIndex = 1;
            lstAdmins.SelectedIndexChanged += lstAdmins_SelectedIndexChanged;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(260, 60);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome:";
            // 
            // txtNomeAdmin
            // 
            txtNomeAdmin.Font = new Font("Segoe UI", 10F);
            txtNomeAdmin.Location = new Point(263, 78);
            txtNomeAdmin.Name = "txtNomeAdmin";
            txtNomeAdmin.Size = new Size(350, 25);
            txtNomeAdmin.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(260, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "E-mail:";
            // 
            // txtEmailAdmin
            // 
            txtEmailAdmin.Font = new Font("Segoe UI", 10F);
            txtEmailAdmin.Location = new Point(263, 132);
            txtEmailAdmin.Name = "txtEmailAdmin";
            txtEmailAdmin.Size = new Size(350, 25);
            txtEmailAdmin.TabIndex = 5;
            // 
            // lblSenhaNova
            // 
            lblSenhaNova.AutoSize = true;
            lblSenhaNova.Location = new Point(260, 170);
            lblSenhaNova.Name = "lblSenhaNova";
            lblSenhaNova.Size = new Size(71, 15);
            lblSenhaNova.TabIndex = 6;
            lblSenhaNova.Text = "Senha nova:";
            // 
            // txtSenhaNova
            // 
            txtSenhaNova.Font = new Font("Segoe UI", 10F);
            txtSenhaNova.Location = new Point(263, 188);
            txtSenhaNova.Name = "txtSenhaNova";
            txtSenhaNova.Size = new Size(200, 25);
            txtSenhaNova.TabIndex = 7;
            txtSenhaNova.UseSystemPasswordChar = true;
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.AutoSize = true;
            lblConfirmarSenha.Location = new Point(472, 170);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(98, 15);
            lblConfirmarSenha.TabIndex = 8;
            lblConfirmarSenha.Text = "Confirmar senha:";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Font = new Font("Segoe UI", 10F);
            txtConfirmarSenha.Location = new Point(475, 188);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.Size = new Size(200, 25);
            txtConfirmarSenha.TabIndex = 9;
            txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // btnNovoAdmin
            // 
            btnNovoAdmin.Location = new Point(263, 235);
            btnNovoAdmin.Name = "btnNovoAdmin";
            btnNovoAdmin.Size = new Size(75, 30);
            btnNovoAdmin.TabIndex = 10;
            btnNovoAdmin.Text = "Novo";
            btnNovoAdmin.UseVisualStyleBackColor = true;
            btnNovoAdmin.Click += btnNovoAdmin_Click;
            // 
            // btnSalvarAdmin
            // 
            btnSalvarAdmin.Location = new Point(344, 235);
            btnSalvarAdmin.Name = "btnSalvarAdmin";
            btnSalvarAdmin.Size = new Size(75, 30);
            btnSalvarAdmin.TabIndex = 11;
            btnSalvarAdmin.Text = "Salvar";
            btnSalvarAdmin.UseVisualStyleBackColor = true;
            btnSalvarAdmin.Click += btnSalvarAdmin_Click;
            // 
            // btnResetSenhaAdmin
            // 
            btnResetSenhaAdmin.Location = new Point(425, 235);
            btnResetSenhaAdmin.Name = "btnResetSenhaAdmin";
            btnResetSenhaAdmin.Size = new Size(95, 30);
            btnResetSenhaAdmin.TabIndex = 12;
            btnResetSenhaAdmin.Text = "Reset Senha";
            btnResetSenhaAdmin.UseVisualStyleBackColor = true;
            btnResetSenhaAdmin.Click += btnResetSenhaAdmin_Click;
            // 
            // btnRemoverAdmin
            // 
            btnRemoverAdmin.Location = new Point(526, 235);
            btnRemoverAdmin.Name = "btnRemoverAdmin";
            btnRemoverAdmin.Size = new Size(75, 30);
            btnRemoverAdmin.TabIndex = 13;
            btnRemoverAdmin.Text = "Remover";
            btnRemoverAdmin.UseVisualStyleBackColor = true;
            btnRemoverAdmin.Click += btnRemoverAdmin_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(475, 340);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(200, 30);
            btnFechar.TabIndex = 15;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // lblRegras
            // 
            lblRegras.AutoSize = true;
            lblRegras.Location = new Point(260, 285);
            lblRegras.Name = "lblRegras";
            lblRegras.Size = new Size(224, 45);
            lblRegras.TabIndex = 14;
            lblRegras.Text = "- Mantenha ao menos 3 administradores.\r\n- Reset Senha redefine para 2580.\r\n- Para criar admin: Nome, Email e Senha.";
            // 
            // AdminConfigForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(739, 416);
            Controls.Add(btnFechar);
            Controls.Add(lblRegras);
            Controls.Add(btnRemoverAdmin);
            Controls.Add(btnResetSenhaAdmin);
            Controls.Add(btnSalvarAdmin);
            Controls.Add(btnNovoAdmin);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(lblConfirmarSenha);
            Controls.Add(txtSenhaNova);
            Controls.Add(lblSenhaNova);
            Controls.Add(txtEmailAdmin);
            Controls.Add(lblEmail);
            Controls.Add(txtNomeAdmin);
            Controls.Add(lblNome);
            Controls.Add(lstAdmins);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ações de Admin (oculto)";
            Load += AdminConfigForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}
