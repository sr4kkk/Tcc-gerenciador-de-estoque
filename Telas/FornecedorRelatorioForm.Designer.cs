namespace alguamcoisa
{
    partial class FornecedorRelatorioForm
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
            pnlTopo = new Panel();
            lblTituloS = new Label();
            label2 = new Label();
            btnFechar = new Button();
            btnFiltrar = new Button();
            pnlSubTopo = new Panel();
            btnImprimi = new Button();
            lblBuscar = new Label();
            txtBuscarFornecedor = new TextBox();
            btnExportar = new Button();
            pnlfinal = new Panel();
            lblContFornecedor = new Label();
            pnlGridRelatorio = new Panel();
            dgvRelatorio = new DataGridView();
            pnlTopo.SuspendLayout();
            pnlSubTopo.SuspendLayout();
            pnlfinal.SuspendLayout();
            pnlGridRelatorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRelatorio).BeginInit();
            SuspendLayout();
            // 
            // pnlTopo
            // 
            pnlTopo.Controls.Add(lblTituloS);
            pnlTopo.Controls.Add(label2);
            pnlTopo.Dock = DockStyle.Top;
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1142, 133);
            pnlTopo.TabIndex = 0;
            // 
            // lblTituloS
            // 
            lblTituloS.AutoSize = true;
            lblTituloS.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloS.Location = new Point(12, 89);
            lblTituloS.Name = "lblTituloS";
            lblTituloS.Size = new Size(445, 20);
            lblTituloS.TabIndex = 0;
            lblTituloS.Text = "Mostra todos os fornecedores atualmente cadastrados no sistema.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(394, 30);
            label2.TabIndex = 0;
            label2.Text = "Relatório de Fornecedores Cadastrados";
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Segoe UI Historic", 12F);
            btnFechar.Location = new Point(1015, 28);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(139, 44);
            btnFechar.TabIndex = 2;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Font = new Font("Segoe UI Historic", 12F);
            btnFiltrar.Location = new Point(499, 28);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(150, 44);
            btnFiltrar.TabIndex = 0;
            btnFiltrar.Text = "Recarregar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // pnlSubTopo
            // 
            pnlSubTopo.Controls.Add(btnImprimi);
            pnlSubTopo.Controls.Add(lblBuscar);
            pnlSubTopo.Controls.Add(btnFechar);
            pnlSubTopo.Controls.Add(txtBuscarFornecedor);
            pnlSubTopo.Controls.Add(btnExportar);
            pnlSubTopo.Controls.Add(btnFiltrar);
            pnlSubTopo.Dock = DockStyle.Top;
            pnlSubTopo.Location = new Point(0, 133);
            pnlSubTopo.Name = "pnlSubTopo";
            pnlSubTopo.Size = new Size(1142, 107);
            pnlSubTopo.TabIndex = 1;
            // 
            // btnImprimi
            // 
            btnImprimi.Font = new Font("Segoe UI Historic", 12F);
            btnImprimi.Location = new Point(862, 28);
            btnImprimi.Name = "btnImprimi";
            btnImprimi.Size = new Size(128, 44);
            btnImprimi.TabIndex = 6;
            btnImprimi.Text = "imprimir";
            btnImprimi.UseVisualStyleBackColor = true;
            btnImprimi.Click += btnImprimir_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(21, 21);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(105, 15);
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "Buscar Fornecedor";
            // 
            // txtBuscarFornecedor
            // 
            txtBuscarFornecedor.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarFornecedor.Location = new Point(21, 39);
            txtBuscarFornecedor.Name = "txtBuscarFornecedor";
            txtBuscarFornecedor.Size = new Size(194, 33);
            txtBuscarFornecedor.TabIndex = 4;
            // 
            // btnExportar
            // 
            btnExportar.Font = new Font("Segoe UI Historic", 12F);
            btnExportar.Location = new Point(688, 28);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(128, 44);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click_1;
            // 
            // pnlfinal
            // 
            pnlfinal.Controls.Add(lblContFornecedor);
            pnlfinal.Dock = DockStyle.Bottom;
            pnlfinal.Location = new Point(0, 591);
            pnlfinal.Name = "pnlfinal";
            pnlfinal.Size = new Size(1142, 30);
            pnlfinal.TabIndex = 2;
            // 
            // lblContFornecedor
            // 
            lblContFornecedor.AutoSize = true;
            lblContFornecedor.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContFornecedor.Location = new Point(3, 3);
            lblContFornecedor.Name = "lblContFornecedor";
            lblContFornecedor.Size = new Size(159, 20);
            lblContFornecedor.TabIndex = 2;
            lblContFornecedor.Text = "Fornecedores exibidos:";
            lblContFornecedor.Click += lblContFornecedor_Click;
            // 
            // pnlGridRelatorio
            // 
            pnlGridRelatorio.Controls.Add(dgvRelatorio);
            pnlGridRelatorio.Dock = DockStyle.Fill;
            pnlGridRelatorio.Location = new Point(0, 240);
            pnlGridRelatorio.Name = "pnlGridRelatorio";
            pnlGridRelatorio.Size = new Size(1142, 351);
            pnlGridRelatorio.TabIndex = 3;
            // 
            // dgvRelatorio
            // 
            dgvRelatorio.AllowUserToAddRows = false;
            dgvRelatorio.AllowUserToDeleteRows = false;
            dgvRelatorio.AllowUserToResizeColumns = false;
            dgvRelatorio.AllowUserToResizeRows = false;
            dgvRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRelatorio.Dock = DockStyle.Fill;
            dgvRelatorio.Location = new Point(0, 0);
            dgvRelatorio.MultiSelect = false;
            dgvRelatorio.Name = "dgvRelatorio";
            dgvRelatorio.ReadOnly = true;
            dgvRelatorio.Size = new Size(1142, 351);
            dgvRelatorio.TabIndex = 0;
            // 
            // FornecedorRelatorioForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1142, 621);
            Controls.Add(pnlGridRelatorio);
            Controls.Add(pnlfinal);
            Controls.Add(pnlSubTopo);
            Controls.Add(pnlTopo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FornecedorRelatorioForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "FornecedorRelatorioForm";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlSubTopo.ResumeLayout(false);
            pnlSubTopo.PerformLayout();
            pnlfinal.ResumeLayout(false);
            pnlfinal.PerformLayout();
            pnlGridRelatorio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRelatorio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopo;
        private Panel pnlSubTopo;
        private Button btnFechar;
        private Button btnFiltrar;
        private Button btnExportar;
        private Label lblTituloS;
        private Label label2;
        private Panel pnlfinal;
        private Label lblContFornecedor;
        private Panel pnlGridRelatorio;
        private DataGridView dgvRelatorio;
        private Label lblBuscar;
        private TextBox txtBuscarFornecedor;
        private Button btnImprimi;
    }
}