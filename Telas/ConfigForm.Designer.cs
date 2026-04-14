// ConfigForm.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace alguamcoisa
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMostrar = new Panel();
            pnlFill = new Panel();
            pnlTopo = new Panel();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            pnlLeft = new Panel();
            btnSobre = new Button();
            BtnConexao = new Button();
            btnAparencia = new Button();
            lblTituloConfig = new Label();
            pnlFill.SuspendLayout();
            pnlTopo.SuspendLayout();
            pnlLeft.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMostrar
            // 
            pnlMostrar.Dock = DockStyle.Fill;
            pnlMostrar.Location = new Point(270, 156);
            pnlMostrar.Name = "pnlMostrar";
            pnlMostrar.Size = new Size(1030, 580);
            pnlMostrar.TabIndex = 2;
            // 
            // pnlFill
            // 
            pnlFill.Controls.Add(pnlMostrar);
            pnlFill.Controls.Add(pnlTopo);
            pnlFill.Controls.Add(pnlLeft);
            pnlFill.Dock = DockStyle.Fill;
            pnlFill.Location = new Point(0, 0);
            pnlFill.Name = "pnlFill";
            pnlFill.Size = new Size(1300, 736);
            pnlFill.TabIndex = 1;
            // 
            // pnlTopo
            // 
            pnlTopo.Controls.Add(label2);
            pnlTopo.Controls.Add(label1);
            pnlTopo.Controls.Add(label3);
            pnlTopo.Dock = DockStyle.Top;
            pnlTopo.Location = new Point(270, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1030, 156);
            pnlTopo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 7;
            label2.Text = "Bem vindo(a)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(127, 17);
            label1.TabIndex = 8;
            label1.Text = "Funções do sistema ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 60);
            label3.Name = "label3";
            label3.Size = new Size(334, 68);
            label3.TabIndex = 8;
            label3.Text = "Aparencia: modo escuro/claro  \r\ntrocar de cores \r\nNova conexão\r\nTela de sobre > Visualizar informações sobre o sistema\r\n";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(btnSobre);
            pnlLeft.Controls.Add(BtnConexao);
            pnlLeft.Controls.Add(btnAparencia);
            pnlLeft.Controls.Add(lblTituloConfig);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(270, 736);
            pnlLeft.TabIndex = 0;
            // 
            // btnSobre
            // 
            btnSobre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSobre.Location = new Point(30, 307);
            btnSobre.Name = "btnSobre";
            btnSobre.Size = new Size(210, 41);
            btnSobre.TabIndex = 5;
            btnSobre.Text = "Sobre";
            btnSobre.UseVisualStyleBackColor = true;
            btnSobre.Click += btnSobre_Click;
            // 
            // BtnConexao
            // 
            BtnConexao.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnConexao.Location = new Point(30, 245);
            BtnConexao.Name = "BtnConexao";
            BtnConexao.Size = new Size(210, 41);
            BtnConexao.TabIndex = 4;
            BtnConexao.Text = "Nova Conexão";
            BtnConexao.UseVisualStyleBackColor = true;
            BtnConexao.Click += BtnConexao_Click;
            // 
            // btnAparencia
            // 
            btnAparencia.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAparencia.Location = new Point(30, 178);
            btnAparencia.Name = "btnAparencia";
            btnAparencia.Size = new Size(210, 44);
            btnAparencia.TabIndex = 3;
            btnAparencia.Text = "Aparência";
            btnAparencia.UseVisualStyleBackColor = true;
            btnAparencia.Click += btnAparencia_Click;
            // 
            // lblTituloConfig
            // 
            lblTituloConfig.AutoSize = true;
            lblTituloConfig.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloConfig.Location = new Point(15, 43);
            lblTituloConfig.Name = "lblTituloConfig";
            lblTituloConfig.Size = new Size(252, 25);
            lblTituloConfig.TabIndex = 0;
            lblTituloConfig.Text = "Configurações do sistema";
            // 
            // ConfigForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1300, 736);
            Controls.Add(pnlFill);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigForm";
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Configurações";
            pnlFill.ResumeLayout(false);
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMostrar;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSobre;
        private System.Windows.Forms.Button BtnConexao;
        private System.Windows.Forms.Button btnAparencia;
        private System.Windows.Forms.Label lblTituloConfig;
        private Label label1;
    }
}
