namespace alguamcoisa
{
    partial class SaidaForm
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
            dgvMovimentos = new DataGridView();
            panel1 = new Panel();
            pnlTopo = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnFiltrar = new Button();
            btnLimpar = new Button();
            btnFechar = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cboProduto = new ComboBox();
            cboCategoria = new ComboBox();
            lblFiltrarPeriodo = new Label();
            dtpFim = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentos).BeginInit();
            panel1.SuspendLayout();
            pnlTopo.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMovimentos
            // 
            dgvMovimentos.AllowUserToAddRows = false;
            dgvMovimentos.AllowUserToDeleteRows = false;
            dgvMovimentos.AllowUserToResizeColumns = false;
            dgvMovimentos.AllowUserToResizeRows = false;
            dgvMovimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimentos.Dock = DockStyle.Fill;
            dgvMovimentos.Location = new Point(0, 0);
            dgvMovimentos.Name = "dgvMovimentos";
            dgvMovimentos.Size = new Size(1467, 652);
            dgvMovimentos.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvMovimentos);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 152);
            panel1.Name = "panel1";
            panel1.Size = new Size(1467, 652);
            panel1.TabIndex = 2;
            // 
            // pnlTopo
            // 
            pnlTopo.Controls.Add(flowLayoutPanel1);
            pnlTopo.Controls.Add(label3);
            pnlTopo.Controls.Add(label2);
            pnlTopo.Controls.Add(label1);
            pnlTopo.Controls.Add(cboProduto);
            pnlTopo.Controls.Add(cboCategoria);
            pnlTopo.Controls.Add(lblFiltrarPeriodo);
            pnlTopo.Controls.Add(dtpFim);
            pnlTopo.Controls.Add(dtpInicio);
            pnlTopo.Dock = DockStyle.Top;
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1467, 152);
            pnlTopo.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnFiltrar);
            flowLayoutPanel1.Controls.Add(btnLimpar);
            flowLayoutPanel1.Controls.Add(btnFechar);
            flowLayoutPanel1.Location = new Point(482, 94);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(533, 52);
            flowLayoutPanel1.TabIndex = 13;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrar.Location = new Point(3, 3);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(142, 43);
            btnFiltrar.TabIndex = 11;
            btnFiltrar.Text = "aplica filtros";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            btnLimpar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpar.Location = new Point(151, 3);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(142, 43);
            btnLimpar.TabIndex = 12;
            btnLimpar.Text = "limpa filtros";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFechar.Location = new Point(299, 3);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(142, 43);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(242, 82);
            label3.Name = "label3";
            label3.Size = new Size(123, 17);
            label3.TabIndex = 7;
            label3.Text = "filtrar por categoria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(116, 17);
            label2.TabIndex = 6;
            label2.Text = "filtrar por produto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(216, 28);
            label1.Name = "label1";
            label1.Size = new Size(20, 25);
            label1.TabIndex = 5;
            label1.Text = "/";
            // 
            // cboProduto
            // 
            cboProduto.FormattingEnabled = true;
            cboProduto.Location = new Point(12, 102);
            cboProduto.Name = "cboProduto";
            cboProduto.Size = new Size(200, 25);
            cboProduto.TabIndex = 4;
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(242, 102);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(200, 25);
            cboCategoria.TabIndex = 3;
            // 
            // lblFiltrarPeriodo
            // 
            lblFiltrarPeriodo.AutoSize = true;
            lblFiltrarPeriodo.Location = new Point(12, 10);
            lblFiltrarPeriodo.Name = "lblFiltrarPeriodo";
            lblFiltrarPeriodo.Size = new Size(117, 17);
            lblFiltrarPeriodo.TabIndex = 2;
            lblFiltrarPeriodo.Text = "Filtrar por periodo";
            // 
            // dtpFim
            // 
            dtpFim.Location = new Point(242, 31);
            dtpFim.Name = "dtpFim";
            dtpFim.Size = new Size(200, 25);
            dtpFim.TabIndex = 1;
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(12, 31);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(200, 25);
            dtpInicio.TabIndex = 0;
            // 
            // SaidaForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1467, 804);
            Controls.Add(panel1);
            Controls.Add(pnlTopo);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SaidaForm";
            Text = "SaidaForm";
            ((System.ComponentModel.ISupportInitialize)dgvMovimentos).EndInit();
            panel1.ResumeLayout(false);
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMovimentos;
        private Panel panel1;
        private Panel pnlTopo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnFiltrar;
        private Button btnLimpar;
        private Button btnFechar;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cboProduto;
        private ComboBox cboCategoria;
        private Label lblFiltrarPeriodo;
        private DateTimePicker dtpFim;
        private DateTimePicker dtpInicio;
    }
}
