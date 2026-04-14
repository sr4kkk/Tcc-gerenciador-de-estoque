using System.Drawing;
using System.Windows.Forms;

namespace alguamcoisa
{
    partial class ThemaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            pnlHomeThema = new Panel();
            label1 = new Label();
            label3 = new Label();
            lblTitulo = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            lbltextS = new Label();
            pnlHomeThema.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHomeThema
            // 
            pnlHomeThema.Controls.Add(label1);
            pnlHomeThema.Controls.Add(label3);
            pnlHomeThema.Controls.Add(lblTitulo);
            pnlHomeThema.Controls.Add(comboBox2);
            pnlHomeThema.Controls.Add(comboBox1);
            pnlHomeThema.Controls.Add(label2);
            pnlHomeThema.Controls.Add(lbltextS);
            pnlHomeThema.Dock = DockStyle.Fill;
            pnlHomeThema.Location = new Point(0, 0);
            pnlHomeThema.Name = "pnlHomeThema";
            pnlHomeThema.Size = new Size(1142, 621);
            pnlHomeThema.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 312);
            label1.Name = "label1";
            label1.Size = new Size(418, 45);
            label1.TabIndex = 6;
            label1.Text = "Selecione a cor principal do sistema. A cor escolhida será aplicada em botões, \r\ndestaques e áreas de interação. \r\nIdeal para adaptar o sistema à identidade visual da sua organização.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 157);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 5;
            label3.Text = "Modo Claro/Escuro";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(262, 25);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Configurações de Aparência";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 406);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 191);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 253);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 1;
            label2.Text = "Paleta de Cores";
            // 
            // lbltextS
            // 
            lbltextS.AutoSize = true;
            lbltextS.Location = new Point(12, 73);
            lbltextS.Name = "lbltextS";
            lbltextS.Size = new Size(454, 45);
            lbltextS.TabIndex = 0;
            lbltextS.Text = "Altere entre modo claro e modo escuro para melhorar o conforto visual. \r\n\r\nO modo escuro reduz a fadiga ocular e é ideal para ambientes com baixa iluminação.";
            // 
            // ThemaForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1142, 621);
            Controls.Add(pnlHomeThema);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ThemaForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.Manual;
            Text = "ThemaForm";
            Load += ThemaForm_Load;
            pnlHomeThema.ResumeLayout(false);
            pnlHomeThema.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHomeThema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltextS;
    }
}
