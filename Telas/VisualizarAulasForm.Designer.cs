namespace alguamcoisa.Telas
{
    partial class VisualizarAulasForm
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
            groupBoxFiltros = new GroupBox();
            btnAtualizar = new Button();
            btnLimparFiltros = new Button();
            hkSomenteComItens = new CheckBox();
            cboStatusFiltro = new ComboBox();
            lblStatusFiltro = new Label();
            btnBuscar = new Button();
            lblTituloFiltro = new Label();
            txtTituloFiltro = new TextBox();
            dtpDataFim = new DateTimePicker();
            label4 = new Label();
            dtpDataInicio = new DateTimePicker();
            label3 = new Label();
            cboMateria = new ComboBox();
            label2 = new Label();
            cboProfessor = new ComboBox();
            label1 = new Label();
            dgvAulas = new DataGridView();
            panelAcoes = new Panel();
            btnExcluirAula = new Button();
            btnEditarAula = new Button();
            btnFechar = new Button();
            groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAulas).BeginInit();
            panelAcoes.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(btnAtualizar);
            groupBoxFiltros.Controls.Add(btnLimparFiltros);
            groupBoxFiltros.Controls.Add(hkSomenteComItens);
            groupBoxFiltros.Controls.Add(cboStatusFiltro);
            groupBoxFiltros.Controls.Add(lblStatusFiltro);
            groupBoxFiltros.Controls.Add(btnBuscar);
            groupBoxFiltros.Controls.Add(lblTituloFiltro);
            groupBoxFiltros.Controls.Add(txtTituloFiltro);
            groupBoxFiltros.Controls.Add(dtpDataFim);
            groupBoxFiltros.Controls.Add(label4);
            groupBoxFiltros.Controls.Add(dtpDataInicio);
            groupBoxFiltros.Controls.Add(label3);
            groupBoxFiltros.Controls.Add(cboMateria);
            groupBoxFiltros.Controls.Add(label2);
            groupBoxFiltros.Controls.Add(cboProfessor);
            groupBoxFiltros.Controls.Add(label1);
            groupBoxFiltros.Dock = DockStyle.Top;
            groupBoxFiltros.Location = new Point(0, 0);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(1467, 181);
            groupBoxFiltros.TabIndex = 0;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de Busca";
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(559, 108);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(130, 40);
            btnAtualizar.TabIndex = 15;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(396, 108);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(130, 40);
            btnLimparFiltros.TabIndex = 14;
            btnLimparFiltros.Text = "Limpar filtros";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            // 
            // hkSomenteComItens
            // 
            hkSomenteComItens.AutoSize = true;
            hkSomenteComItens.Location = new Point(20, 148);
            hkSomenteComItens.Name = "hkSomenteComItens";
            hkSomenteComItens.Size = new Size(158, 19);
            hkSomenteComItens.TabIndex = 13;
            hkSomenteComItens.Text = "Somente aulas com itens";
            hkSomenteComItens.UseVisualStyleBackColor = true;
            // 
            // cboStatusFiltro
            // 
            cboStatusFiltro.FormattingEnabled = true;
            cboStatusFiltro.Location = new Point(20, 108);
            cboStatusFiltro.Name = "cboStatusFiltro";
            cboStatusFiltro.Size = new Size(146, 23);
            cboStatusFiltro.TabIndex = 12;
            // 
            // lblStatusFiltro
            // 
            lblStatusFiltro.AutoSize = true;
            lblStatusFiltro.Location = new Point(20, 88);
            lblStatusFiltro.Name = "lblStatusFiltro";
            lblStatusFiltro.Size = new Size(42, 15);
            lblStatusFiltro.TabIndex = 11;
            lblStatusFiltro.Text = "Status:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(235, 108);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 40);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblTituloFiltro
            // 
            lblTituloFiltro.AutoSize = true;
            lblTituloFiltro.Location = new Point(20, 28);
            lblTituloFiltro.Name = "lblTituloFiltro";
            lblTituloFiltro.Size = new Size(82, 15);
            lblTituloFiltro.TabIndex = 10;
            lblTituloFiltro.Text = "Título da aula:";
            // 
            // txtTituloFiltro
            // 
            txtTituloFiltro.Location = new Point(20, 46);
            txtTituloFiltro.Name = "txtTituloFiltro";
            txtTituloFiltro.Size = new Size(252, 23);
            txtTituloFiltro.TabIndex = 9;
            // 
            // dtpDataFim
            // 
            dtpDataFim.Format = DateTimePickerFormat.Short;
            dtpDataFim.Location = new Point(1029, 53);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.Size = new Size(120, 23);
            dtpDataFim.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1029, 35);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 6;
            label4.Text = "Data Fim:";
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.Format = DateTimePickerFormat.Short;
            dtpDataInicio.Location = new Point(874, 53);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(120, 23);
            dtpDataInicio.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(874, 35);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 4;
            label3.Text = "Data Início:";
            // 
            // cboMateria
            // 
            cboMateria.FormattingEnabled = true;
            cboMateria.Location = new Point(559, 46);
            cboMateria.Name = "cboMateria";
            cboMateria.Size = new Size(250, 23);
            cboMateria.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(559, 28);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Matéria:";
            // 
            // cboProfessor
            // 
            cboProfessor.FormattingEnabled = true;
            cboProfessor.Location = new Point(291, 46);
            cboProfessor.Name = "cboProfessor";
            cboProfessor.Size = new Size(250, 23);
            cboProfessor.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(291, 28);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Professor:";
            // 
            // dgvAulas
            // 
            dgvAulas.AllowUserToAddRows = false;
            dgvAulas.AllowUserToDeleteRows = false;
            dgvAulas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAulas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAulas.Location = new Point(20, 264);
            dgvAulas.Name = "dgvAulas";
            dgvAulas.ReadOnly = true;
            dgvAulas.RowHeadersVisible = false;
            dgvAulas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAulas.Size = new Size(1417, 450);
            dgvAulas.TabIndex = 1;
            // 
            // panelAcoes
            // 
            panelAcoes.Controls.Add(btnExcluirAula);
            panelAcoes.Controls.Add(btnEditarAula);
            panelAcoes.Controls.Add(btnFechar);
            panelAcoes.Dock = DockStyle.Bottom;
            panelAcoes.Location = new Point(0, 724);
            panelAcoes.Name = "panelAcoes";
            panelAcoes.Size = new Size(1467, 80);
            panelAcoes.TabIndex = 2;
            // 
            // btnExcluirAula
            // 
            btnExcluirAula.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluirAula.BackColor = SystemColors.ControlLight;
            btnExcluirAula.Enabled = false;
            btnExcluirAula.Location = new Point(1167, 15);
            btnExcluirAula.Name = "btnExcluirAula";
            btnExcluirAula.Size = new Size(130, 50);
            btnExcluirAula.TabIndex = 2;
            btnExcluirAula.Text = "Excluir Aula";
            btnExcluirAula.UseVisualStyleBackColor = false;
            // 
            // btnEditarAula
            // 
            btnEditarAula.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditarAula.Enabled = false;
            btnEditarAula.Location = new Point(1317, 15);
            btnEditarAula.Name = "btnEditarAula";
            btnEditarAula.Size = new Size(130, 50);
            btnEditarAula.TabIndex = 1;
            btnEditarAula.Text = "Editar Aula";
            btnEditarAula.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFechar.Location = new Point(20, 15);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(130, 50);
            btnFechar.TabIndex = 0;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // VisualizarAulasForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1467, 804);
            Controls.Add(panelAcoes);
            Controls.Add(dgvAulas);
            Controls.Add(groupBoxFiltros);
            Name = "VisualizarAulasForm";
            Text = "Visualizar e Editar Aulas Salvas";
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAulas).EndInit();
            panelAcoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxFiltros;
        private Label label1;
        private Button btnBuscar;
        private DateTimePicker dtpDataFim;
        private Label label4;
        private DateTimePicker dtpDataInicio;
        private Label label3;
        private ComboBox cboMateria;
        private Label label2;
        private ComboBox cboProfessor;
        private DataGridView dgvAulas;
        private Panel panelAcoes;
        private Button btnEditarAula;
        private Button btnFechar;
        private Button btnExcluirAula;
        private ComboBox cboStatusFiltro;
        private Label lblStatusFiltro;
        private Label lblTituloFiltro;
        private TextBox txtTituloFiltro;
        private Button btnAtualizar;
        private Button btnLimparFiltros;
        private CheckBox hkSomenteComItens;
    }
}