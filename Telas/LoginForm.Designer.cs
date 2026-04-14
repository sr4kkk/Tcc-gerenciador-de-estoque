namespace alguamcoisa
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.CheckBox chkMostrarSenha;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnEntrar;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            pnlCard = new Panel();
            btnSair = new Button();
            btnEntrar = new Button();
            chkMostrarSenha = new CheckBox();
            txtSenha = new TextBox();
            lblSenha = new Label();
            cmbPerfil = new ComboBox();
            lblPerfil = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            lblTitulo = new Label();
            lblSub = new Label();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCard.AutoSize = true;
            pnlCard.Controls.Add(btnSair);
            pnlCard.Controls.Add(btnEntrar);
            pnlCard.Controls.Add(chkMostrarSenha);
            pnlCard.Controls.Add(txtSenha);
            pnlCard.Controls.Add(lblSenha);
            pnlCard.Controls.Add(cmbPerfil);
            pnlCard.Controls.Add(lblPerfil);
            pnlCard.Controls.Add(txtNome);
            pnlCard.Controls.Add(lblNome);
            pnlCard.Controls.Add(lblTitulo);
            pnlCard.Controls.Add(lblSub);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(640, 415);
            pnlCard.TabIndex = 0;
            // 
            // btnSair
            // 
            btnSair.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSair.Location = new Point(173, 333);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(90, 37);
            btnSair.TabIndex = 7;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(284, 333);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(120, 37);
            btnEntrar.TabIndex = 8;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // chkMostrarSenha
            // 
            chkMostrarSenha.AutoSize = true;
            chkMostrarSenha.Location = new Point(361, 287);
            chkMostrarSenha.Name = "chkMostrarSenha";
            chkMostrarSenha.Size = new Size(129, 25);
            chkMostrarSenha.TabIndex = 6;
            chkMostrarSenha.Text = "Mostrar senha";
            chkMostrarSenha.UseVisualStyleBackColor = true;
            chkMostrarSenha.CheckedChanged += chkMostrarSenha_CheckedChanged;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(177, 285);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(178, 29);
            txtSenha.TabIndex = 5;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(173, 261);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(53, 21);
            lblSenha.TabIndex = 4;
            lblSenha.Text = "Senha";
            // 
            // cmbPerfil
            // 
            cmbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerfil.FormattingEnabled = true;
            cmbPerfil.Items.AddRange(new object[] { "Professor", "Admin" });
            cmbPerfil.Location = new Point(177, 144);
            cmbPerfil.Name = "cmbPerfil";
            cmbPerfil.Size = new Size(180, 29);
            cmbPerfil.TabIndex = 3;
            cmbPerfil.SelectedIndexChanged += cmbPerfil_SelectedIndexChanged;
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Location = new Point(177, 120);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(45, 21);
            lblPerfil.TabIndex = 2;
            lblPerfil.Text = "Perfil";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(177, 211);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(280, 29);
            txtNome.TabIndex = 1;
            txtNome.KeyDown += txtNome_KeyDown;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(173, 187);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(150, 21);
            lblNome.TabIndex = 1;
            lblNome.Text = "Seu nome ou e-mail";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(173, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(167, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bem-vindo!";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.Font = new Font("Segoe UI", 10F);
            lblSub.Location = new Point(189, 74);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(134, 19);
            lblSub.TabIndex = 0;
            lblSub.Text = "Entre para continuar";
            // 
            // LoginForm
            // 
            AcceptButton = btnEntrar;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnSair;
            ClientSize = new Size(640, 415);
            Controls.Add(pnlCard);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entrar";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}
