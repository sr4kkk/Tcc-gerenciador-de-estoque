namespace alguamcoisa
{
    partial class EstoqueForm
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTopo = new Panel();
            flpBtn = new FlowLayoutPanel();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnQuantidade = new Button();
            lblCategoriaFiltro = new Label();
            cboCategoriaFiltro = new ComboBox();
            lblFIltrar = new Label();
            cboFiltro = new ComboBox();
            txtBuscarProduto = new TextBox();
            btnImprimir = new Button();
            btnImportardadosSql = new Button();
            lblProcurar = new Label();
            lblTituloEstoque = new Label();
            pnlGrid = new Panel();
            dgvEstoque = new DataGridView();
            pnlTopo.SuspendLayout();
            flpBtn.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
            SuspendLayout();
            // 
            // pnlTopo
            // 
            pnlTopo.Controls.Add(flpBtn);
            pnlTopo.Controls.Add(lblCategoriaFiltro);
            pnlTopo.Controls.Add(cboCategoriaFiltro);
            pnlTopo.Controls.Add(lblFIltrar);
            pnlTopo.Controls.Add(cboFiltro);
            pnlTopo.Controls.Add(txtBuscarProduto);
            pnlTopo.Controls.Add(btnImprimir);
            pnlTopo.Controls.Add(btnImportardadosSql);
            pnlTopo.Controls.Add(lblProcurar);
            pnlTopo.Controls.Add(lblTituloEstoque);
            pnlTopo.Dock = DockStyle.Top;
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1142, 178);
            pnlTopo.TabIndex = 21;
            // 
            // flpBtn
            // 
            flpBtn.Controls.Add(btnExcluir);
            flpBtn.Controls.Add(btnEditar);
            flpBtn.Controls.Add(btnQuantidade);
            flpBtn.Location = new Point(3, 113);
            flpBtn.Name = "flpBtn";
            flpBtn.Size = new Size(812, 49);
            flpBtn.TabIndex = 35;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(3, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(142, 35);
            btnExcluir.TabIndex = 31;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(151, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(134, 35);
            btnEditar.TabIndex = 30;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnQuantidade
            // 
            btnQuantidade.Location = new Point(291, 3);
            btnQuantidade.Name = "btnQuantidade";
            btnQuantidade.Size = new Size(142, 35);
            btnQuantidade.TabIndex = 32;
            btnQuantidade.Text = "Adicionar/Remover";
            btnQuantidade.UseVisualStyleBackColor = true;
            // 
            // lblCategoriaFiltro
            // 
            lblCategoriaFiltro.AutoSize = true;
            lblCategoriaFiltro.Location = new Point(460, 37);
            lblCategoriaFiltro.Name = "lblCategoriaFiltro";
            lblCategoriaFiltro.Size = new Size(61, 15);
            lblCategoriaFiltro.TabIndex = 34;
            lblCategoriaFiltro.Text = "Categoria:";
            // 
            // cboCategoriaFiltro
            // 
            cboCategoriaFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoriaFiltro.FormattingEnabled = true;
            cboCategoriaFiltro.Location = new Point(460, 55);
            cboCategoriaFiltro.Name = "cboCategoriaFiltro";
            cboCategoriaFiltro.Size = new Size(180, 23);
            cboCategoriaFiltro.TabIndex = 33;
            // 
            // lblFIltrar
            // 
            lblFIltrar.AutoSize = true;
            lblFIltrar.Location = new Point(285, 37);
            lblFIltrar.Name = "lblFIltrar";
            lblFIltrar.Size = new Size(90, 15);
            lblFIltrar.TabIndex = 32;
            lblFIltrar.Text = "Validade (filtro):";
            // 
            // cboFiltro
            // 
            cboFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltro.FormattingEnabled = true;
            cboFiltro.Location = new Point(285, 55);
            cboFiltro.Name = "cboFiltro";
            cboFiltro.Size = new Size(156, 23);
            cboFiltro.TabIndex = 31;
            // 
            // txtBuscarProduto
            // 
            txtBuscarProduto.Location = new Point(12, 55);
            txtBuscarProduto.Name = "txtBuscarProduto";
            txtBuscarProduto.Size = new Size(254, 23);
            txtBuscarProduto.TabIndex = 30;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(678, 16);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(122, 36);
            btnImprimir.TabIndex = 26;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnImportardadosSql
            // 
            btnImportardadosSql.Location = new Point(678, 70);
            btnImportardadosSql.Name = "btnImportardadosSql";
            btnImportardadosSql.Size = new Size(122, 37);
            btnImportardadosSql.TabIndex = 25;
            btnImportardadosSql.Text = "Importar Dados";
            btnImportardadosSql.UseVisualStyleBackColor = true;
            // 
            // lblProcurar
            // 
            lblProcurar.AutoSize = true;
            lblProcurar.Location = new Point(12, 37);
            lblProcurar.Name = "lblProcurar";
            lblProcurar.Size = new Size(55, 15);
            lblProcurar.TabIndex = 24;
            lblProcurar.Text = "Procurar:";
            // 
            // lblTituloEstoque
            // 
            lblTituloEstoque.AutoSize = true;
            lblTituloEstoque.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloEstoque.Location = new Point(12, 7);
            lblTituloEstoque.Name = "lblTituloEstoque";
            lblTituloEstoque.Size = new Size(231, 21);
            lblTituloEstoque.TabIndex = 23;
            lblTituloEstoque.Text = "Visualizar Produtos cadastrados";
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvEstoque);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 178);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1142, 443);
            pnlGrid.TabIndex = 23;
            // 
            // dgvEstoque
            // 
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeColumns = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstoque.Dock = DockStyle.Fill;
            dgvEstoque.Location = new Point(0, 0);
            dgvEstoque.Name = "dgvEstoque";
            dgvEstoque.Size = new Size(1142, 443);
            dgvEstoque.TabIndex = 33;
            // 
            // EstoqueForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1142, 621);
            Controls.Add(pnlGrid);
            Controls.Add(pnlTopo);
            FormBorderStyle = FormBorderStyle.None;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "EstoqueForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Estoque sistema ERP";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            flpBtn.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopo;
        private Label lblCategoriaFiltro;
        private ComboBox cboCategoriaFiltro;
        private Label lblFIltrar;
        private ComboBox cboFiltro;
        private TextBox txtBuscarProduto;
        private Button btnImprimir;
        private Button btnImportardadosSql;
        private Label lblProcurar;
        private Label lblTituloEstoque;
        private Panel pnlGrid;
        private DataGridView dgvEstoque;
        private FlowLayoutPanel flpBtn;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnQuantidade;
    }
}
