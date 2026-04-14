using System.Drawing;
using System.Windows.Forms;

namespace alguamcoisa
{
    partial class sobre
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblVersao;
        private Label lblDesc;
        private Label lblDev;
        private Label lblEquipe;
        private Button btnSair;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo designer

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblVersao = new Label();
            lblDesc = new Label();
            lblDev = new Label();
            lblEquipe = new Label();
            btnSair = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.Location = new Point(2, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(291, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Estoque";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 12F);
            lblSubtitulo.Location = new Point(2, 64);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(504, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Controle inteligente e automatizado de produtos, reagentes e materiais.";
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Font = new Font("Segoe UI", 11F);
            lblVersao.Location = new Point(5, 103);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(134, 20);
            lblVersao.TabIndex = 2;
            lblVersao.Text = "Versão: 1.0.0 (Beta)";
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 10.5F);
            lblDesc.Location = new Point(2, 143);
            lblDesc.MaximumSize = new Size(788, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(501, 19);
            lblDesc.TabIndex = 3;
            lblDesc.Text = "Software desenvolvido para auxiliar no gerenciamento de estoque com agilidade.";
            // 
            // lblDev
            // 
            lblDev.AutoSize = true;
            lblDev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDev.Location = new Point(2, 202);
            lblDev.Name = "lblDev";
            lblDev.Size = new Size(136, 20);
            lblDev.TabIndex = 4;
            lblDev.Text = "Desenvolvido por:";
            // 
            // lblEquipe
            // 
            lblEquipe.AutoSize = true;
            lblEquipe.Font = new Font("Segoe UI", 12F);
            lblEquipe.Location = new Point(5, 234);
            lblEquipe.Name = "lblEquipe";
            lblEquipe.Size = new Size(70, 147);
            lblEquipe.TabIndex = 5;
            lblEquipe.Text = "Ana\r\nEmilly\r\nFlavio\r\nJose\r\nJulia\r\nMatheus\r\nSara";
            // 
            // btnSair
            // 
            btnSair.Font = new Font("Segoe UI", 12F);
            btnSair.Location = new Point(5, 419);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(128, 38);
            btnSair.TabIndex = 6;
            btnSair.Text = "Fechar";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // sobre
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1142, 621);
            Controls.Add(btnSair);
            Controls.Add(lblEquipe);
            Controls.Add(lblDev);
            Controls.Add(lblDesc);
            Controls.Add(lblVersao);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "sobre";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}
