namespace alguamcoisa
{
    partial class FornecedorListForm
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
            txtBusca = new TextBox();
            lblFornecedorTitulo = new Label();
            pnlTopo = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnNovo = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnAtualizar = new Button();
            btnFechar = new Button();
            label1 = new Label();
            pnlGridList = new Panel();
            dgvFornecedores = new DataGridView();
            pnlTopo.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlGridList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFornecedores).BeginInit();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBusca.Location = new Point(12, 50);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(317, 29);
            txtBusca.TabIndex = 0;
            // 
            // lblFornecedorTitulo
            // 
            lblFornecedorTitulo.AutoSize = true;
            lblFornecedorTitulo.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFornecedorTitulo.Location = new Point(12, 22);
            lblFornecedorTitulo.Name = "lblFornecedorTitulo";
            lblFornecedorTitulo.Size = new Size(211, 25);
            lblFornecedorTitulo.TabIndex = 6;
            lblFornecedorTitulo.Text = "Procurar Fornecedor ";
            // 
            // pnlTopo
            // 
            pnlTopo.Controls.Add(flowLayoutPanel1);
            pnlTopo.Controls.Add(label1);
            pnlTopo.Controls.Add(lblFornecedorTitulo);
            pnlTopo.Controls.Add(txtBusca);
            pnlTopo.Dock = DockStyle.Top;
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1142, 122);
            pnlTopo.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnNovo);
            flowLayoutPanel1.Controls.Add(btnEditar);
            flowLayoutPanel1.Controls.Add(btnExcluir);
            flowLayoutPanel1.Controls.Add(btnAtualizar);
            flowLayoutPanel1.Controls.Add(btnFechar);
            flowLayoutPanel1.Location = new Point(431, 40);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1120, 66);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnNovo
            // 
            btnNovo.Font = new Font("Segoe UI", 11.25F);
            btnNovo.Location = new Point(3, 3);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(160, 46);
            btnNovo.TabIndex = 7;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI", 11.25F);
            btnEditar.Location = new Point(169, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(160, 47);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Font = new Font("Segoe UI", 11.25F);
            btnExcluir.Location = new Point(335, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(160, 47);
            btnExcluir.TabIndex = 9;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Font = new Font("Segoe UI", 11.25F);
            btnAtualizar.Location = new Point(501, 3);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(160, 46);
            btnAtualizar.TabIndex = 6;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Segoe UI", 11.25F);
            btnFechar.Location = new Point(667, 3);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(160, 46);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 86);
            label1.Name = "label1";
            label1.Size = new Size(265, 30);
            label1.TabIndex = 7;
            label1.Text = "Buscar fornecedor (nome / nome fantasia / CNPJ\r\n\r\n";
            // 
            // pnlGridList
            // 
            pnlGridList.Controls.Add(dgvFornecedores);
            pnlGridList.Dock = DockStyle.Fill;
            pnlGridList.Location = new Point(0, 122);
            pnlGridList.Name = "pnlGridList";
            pnlGridList.Size = new Size(1142, 499);
            pnlGridList.TabIndex = 1;
            // 
            // dgvFornecedores
            // 
            dgvFornecedores.AllowUserToAddRows = false;
            dgvFornecedores.AllowUserToDeleteRows = false;
            dgvFornecedores.AllowUserToResizeColumns = false;
            dgvFornecedores.AllowUserToResizeRows = false;
            dgvFornecedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFornecedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFornecedores.Dock = DockStyle.Fill;
            dgvFornecedores.Location = new Point(0, 0);
            dgvFornecedores.MultiSelect = false;
            dgvFornecedores.Name = "dgvFornecedores";
            dgvFornecedores.ReadOnly = true;
            dgvFornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFornecedores.Size = new Size(1142, 499);
            dgvFornecedores.TabIndex = 3;
            // 
            // FornecedorListForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1142, 621);
            Controls.Add(pnlGridList);
            Controls.Add(pnlTopo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FornecedorListForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "FornecedorListForm";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            pnlGridList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFornecedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBusca;
        private Label lblFornecedorTitulo;
        private Panel pnlTopo;
        private Panel pnlGridList;
        private DataGridView dgvFornecedores;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnNovo;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnAtualizar;
        private Button btnFechar;
    }
}