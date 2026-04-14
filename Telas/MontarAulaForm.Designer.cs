namespace alguamcoisa.Telas
{
    partial class MontarAulaForm
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

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvItensAula = new DataGridView();
            lblResumoItens = new Label();
            chkDescontarEstoqueAoSalvar = new CheckBox();
            panelMenuLateral = new Panel();
            btnFechar = new Button();
            btnRemoverItemSelecionado = new Button();
            btnLimpar = new Button();
            btnSalvarAula = new Button();
            grpDadosAula = new GroupBox();
            lblObservacoesAula = new Label();
            txtObservacoesAula = new TextBox();
            btnNovaTurma = new Button();
            lblStatusAula = new Label();
            cboStatusAula = new ComboBox();
            lblTipoAula = new Label();
            cboTipoAula = new ComboBox();
            label1 = new Label();
            lblTurma = new Label();
            cboTurma = new ComboBox();
            lblMateriaAula = new Label();
            cboMateriaAula = new ComboBox();
            lblDataAula = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblProfessor = new Label();
            cboProfessor = new ComboBox();
            lblTituloAula = new Label();
            txtTituloAula = new TextBox();
            grpItens = new GroupBox();
            txtFiltroProduto = new TextBox();
            lblFiltroProduto = new Label();
            btnAdicionarItem = new Button();
            lblDisponivel = new Label();
            lblDisponivelCaption = new Label();
            lblLocal = new Label();
            lblLocalCaption = new Label();
            lblUnidade = new Label();
            lblUnidadeCaption = new Label();
            lblQuantidade = new Label();
            nudQuantidade = new NumericUpDown();
            lblProduto = new Label();
            cboProduto = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvItensAula).BeginInit();
            panelMenuLateral.SuspendLayout();
            grpDadosAula.SuspendLayout();
            grpItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            SuspendLayout();
            // 
            // dgvItensAula
            // 
            dgvItensAula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItensAula.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvItensAula.BorderStyle = BorderStyle.None;
            dgvItensAula.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvItensAula.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvItensAula.ColumnHeadersHeight = 30;
            dgvItensAula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(241, 241, 241);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvItensAula.DefaultCellStyle = dataGridViewCellStyle5;
            dgvItensAula.EnableHeadersVisualStyles = false;
            dgvItensAula.GridColor = Color.FromArgb(60, 60, 60);
            dgvItensAula.Location = new Point(217, 390);
            dgvItensAula.Name = "dgvItensAula";
            dgvItensAula.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvItensAula.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvItensAula.RowHeadersVisible = false;
            dgvItensAula.Size = new Size(1327, 364);
            dgvItensAula.TabIndex = 5;
            // 
            // lblResumoItens
            // 
            lblResumoItens.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumoItens.AutoSize = true;
            lblResumoItens.ForeColor = Color.Silver;
            lblResumoItens.Location = new Point(217, 761);
            lblResumoItens.Name = "lblResumoItens";
            lblResumoItens.Size = new Size(319, 15);
            lblResumoItens.TabIndex = 6;
            lblResumoItens.Text = "Itens na aula: 0 | Produtos diferentes: 0 | Quantidade total: 0";
            // 
            // chkDescontarEstoqueAoSalvar
            // 
            chkDescontarEstoqueAoSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chkDescontarEstoqueAoSalvar.AutoSize = true;
            chkDescontarEstoqueAoSalvar.Checked = true;
            chkDescontarEstoqueAoSalvar.CheckState = CheckState.Checked;
            chkDescontarEstoqueAoSalvar.ForeColor = Color.White;
            chkDescontarEstoqueAoSalvar.Location = new Point(1237, 760);
            chkDescontarEstoqueAoSalvar.Name = "chkDescontarEstoqueAoSalvar";
            chkDescontarEstoqueAoSalvar.Size = new Size(307, 19);
            chkDescontarEstoqueAoSalvar.TabIndex = 7;
            chkDescontarEstoqueAoSalvar.Text = "Descontar estoque ao salvar (desmarcar = simulação)";
            chkDescontarEstoqueAoSalvar.UseVisualStyleBackColor = true;
            // 
            // panelMenuLateral
            // 
            panelMenuLateral.BackColor = Color.FromArgb(30, 30, 30);
            panelMenuLateral.Controls.Add(btnFechar);
            panelMenuLateral.Controls.Add(btnRemoverItemSelecionado);
            panelMenuLateral.Controls.Add(btnLimpar);
            panelMenuLateral.Controls.Add(btnSalvarAula);
            panelMenuLateral.Dock = DockStyle.Left;
            panelMenuLateral.Location = new Point(0, 0);
            panelMenuLateral.Name = "panelMenuLateral";
            panelMenuLateral.Size = new Size(200, 785);
            panelMenuLateral.TabIndex = 0;
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFechar.BackColor = Color.FromArgb(45, 45, 48);
            btnFechar.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnFechar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(12, 728);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(176, 45);
            btnFechar.TabIndex = 3;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            // 
            // btnRemoverItemSelecionado
            // 
            btnRemoverItemSelecionado.BackColor = Color.FromArgb(45, 45, 48);
            btnRemoverItemSelecionado.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnRemoverItemSelecionado.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnRemoverItemSelecionado.FlatStyle = FlatStyle.Flat;
            btnRemoverItemSelecionado.ForeColor = Color.White;
            btnRemoverItemSelecionado.Location = new Point(12, 114);
            btnRemoverItemSelecionado.Name = "btnRemoverItemSelecionado";
            btnRemoverItemSelecionado.Size = new Size(176, 45);
            btnRemoverItemSelecionado.TabIndex = 2;
            btnRemoverItemSelecionado.Text = "Remover Item Selecionado";
            btnRemoverItemSelecionado.UseVisualStyleBackColor = false;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(45, 45, 48);
            btnLimpar.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnLimpar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(12, 63);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(176, 45);
            btnLimpar.TabIndex = 1;
            btnLimpar.Text = "Limpar Aula";
            btnLimpar.UseVisualStyleBackColor = false;
            // 
            // btnSalvarAula
            // 
            btnSalvarAula.BackColor = Color.FromArgb(0, 122, 204);
            btnSalvarAula.FlatAppearance.BorderSize = 0;
            btnSalvarAula.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 180);
            btnSalvarAula.FlatStyle = FlatStyle.Flat;
            btnSalvarAula.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalvarAula.ForeColor = Color.White;
            btnSalvarAula.Location = new Point(12, 12);
            btnSalvarAula.Name = "btnSalvarAula";
            btnSalvarAula.Size = new Size(176, 45);
            btnSalvarAula.TabIndex = 0;
            btnSalvarAula.Text = "SALVAR AULA";
            btnSalvarAula.UseVisualStyleBackColor = false;
            // 
            // grpDadosAula
            // 
            grpDadosAula.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDadosAula.Controls.Add(lblObservacoesAula);
            grpDadosAula.Controls.Add(txtObservacoesAula);
            grpDadosAula.Controls.Add(btnNovaTurma);
            grpDadosAula.Controls.Add(lblStatusAula);
            grpDadosAula.Controls.Add(cboStatusAula);
            grpDadosAula.Controls.Add(lblTipoAula);
            grpDadosAula.Controls.Add(cboTipoAula);
            grpDadosAula.Controls.Add(label1);
            grpDadosAula.Controls.Add(lblTurma);
            grpDadosAula.Controls.Add(cboTurma);
            grpDadosAula.Controls.Add(lblMateriaAula);
            grpDadosAula.Controls.Add(cboMateriaAula);
            grpDadosAula.Controls.Add(lblDataAula);
            grpDadosAula.Controls.Add(dateTimePicker1);
            grpDadosAula.Controls.Add(lblProfessor);
            grpDadosAula.Controls.Add(cboProfessor);
            grpDadosAula.Controls.Add(lblTituloAula);
            grpDadosAula.Controls.Add(txtTituloAula);
            grpDadosAula.ForeColor = Color.White;
            grpDadosAula.Location = new Point(217, 12);
            grpDadosAula.Name = "grpDadosAula";
            grpDadosAula.Size = new Size(1327, 215);
            grpDadosAula.TabIndex = 1;
            grpDadosAula.TabStop = false;
            grpDadosAula.Text = "Dados da Aula";
            // 
            // lblObservacoesAula
            // 
            lblObservacoesAula.AutoSize = true;
            lblObservacoesAula.ForeColor = Color.Silver;
            lblObservacoesAula.Location = new Point(20, 140);
            lblObservacoesAula.Name = "lblObservacoesAula";
            lblObservacoesAula.Size = new Size(77, 15);
            lblObservacoesAula.TabIndex = 12;
            lblObservacoesAula.Text = "Observações:";
            // 
            // txtObservacoesAula
            // 
            txtObservacoesAula.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservacoesAula.BackColor = Color.FromArgb(60, 60, 60);
            txtObservacoesAula.BorderStyle = BorderStyle.FixedSingle;
            txtObservacoesAula.ForeColor = Color.White;
            txtObservacoesAula.Location = new Point(20, 158);
            txtObservacoesAula.Multiline = true;
            txtObservacoesAula.Name = "txtObservacoesAula";
            txtObservacoesAula.ScrollBars = ScrollBars.Vertical;
            txtObservacoesAula.Size = new Size(1286, 40);
            txtObservacoesAula.TabIndex = 13;
            // 
            // btnNovaTurma
            // 
            btnNovaTurma.BackColor = Color.FromArgb(45, 45, 48);
            btnNovaTurma.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnNovaTurma.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnNovaTurma.FlatStyle = FlatStyle.Flat;
            btnNovaTurma.ForeColor = Color.White;
            btnNovaTurma.Location = new Point(576, 129);
            btnNovaTurma.Name = "btnNovaTurma";
            btnNovaTurma.Size = new Size(64, 23);
            btnNovaTurma.TabIndex = 1;
            btnNovaTurma.Text = "+";
            btnNovaTurma.UseVisualStyleBackColor = false;
            btnNovaTurma.Click += btnNovaTurma_Click;
            // 
            // lblStatusAula
            // 
            lblStatusAula.AutoSize = true;
            lblStatusAula.ForeColor = Color.Silver;
            lblStatusAula.Location = new Point(880, 85);
            lblStatusAula.Name = "lblStatusAula";
            lblStatusAula.Size = new Size(42, 15);
            lblStatusAula.TabIndex = 10;
            lblStatusAula.Text = "Status:";
            // 
            // cboStatusAula
            // 
            cboStatusAula.BackColor = Color.White;
            cboStatusAula.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusAula.FormattingEnabled = true;
            cboStatusAula.Location = new Point(880, 103);
            cboStatusAula.Name = "cboStatusAula";
            cboStatusAula.Size = new Size(200, 23);
            cboStatusAula.TabIndex = 11;
            // 
            // lblTipoAula
            // 
            lblTipoAula.AutoSize = true;
            lblTipoAula.ForeColor = Color.Silver;
            lblTipoAula.Location = new Point(660, 85);
            lblTipoAula.Name = "lblTipoAula";
            lblTipoAula.Size = new Size(33, 15);
            lblTipoAula.TabIndex = 8;
            lblTipoAula.Text = "Tipo:";
            // 
            // cboTipoAula
            // 
            cboTipoAula.BackColor = Color.White;
            cboTipoAula.FormattingEnabled = true;
            cboTipoAula.Location = new Point(660, 103);
            cboTipoAula.Name = "cboTipoAula";
            cboTipoAula.Size = new Size(200, 23);
            cboTipoAula.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(340, 132);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 6;
            label1.Text = "Nova Turma:";
            // 
            // lblTurma
            // 
            lblTurma.AutoSize = true;
            lblTurma.ForeColor = Color.Silver;
            lblTurma.Location = new Point(340, 85);
            lblTurma.Name = "lblTurma";
            lblTurma.Size = new Size(44, 15);
            lblTurma.TabIndex = 6;
            lblTurma.Text = "Turma:";
            // 
            // cboTurma
            // 
            cboTurma.BackColor = Color.White;
            cboTurma.FormattingEnabled = true;
            cboTurma.Location = new Point(340, 103);
            cboTurma.Name = "cboTurma";
            cboTurma.Size = new Size(300, 23);
            cboTurma.TabIndex = 7;
            // 
            // lblMateriaAula
            // 
            lblMateriaAula.AutoSize = true;
            lblMateriaAula.ForeColor = Color.Silver;
            lblMateriaAula.Location = new Point(20, 85);
            lblMateriaAula.Name = "lblMateriaAula";
            lblMateriaAula.Size = new Size(50, 15);
            lblMateriaAula.TabIndex = 4;
            lblMateriaAula.Text = "Matéria:";
            // 
            // cboMateriaAula
            // 
            cboMateriaAula.BackColor = Color.White;
            cboMateriaAula.FormattingEnabled = true;
            cboMateriaAula.Location = new Point(20, 103);
            cboMateriaAula.Name = "cboMateriaAula";
            cboMateriaAula.Size = new Size(300, 23);
            cboMateriaAula.TabIndex = 5;
            // 
            // lblDataAula
            // 
            lblDataAula.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDataAula.AutoSize = true;
            lblDataAula.ForeColor = Color.Silver;
            lblDataAula.Location = new Point(409, 30);
            lblDataAula.Name = "lblDataAula";
            lblDataAula.Size = new Size(34, 15);
            lblDataAula.TabIndex = 2;
            lblDataAula.Text = "Data:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(409, 48);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(127, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.ForeColor = Color.Silver;
            lblProfessor.Location = new Point(20, 30);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(59, 15);
            lblProfessor.TabIndex = 0;
            lblProfessor.Text = "Professor:";
            // 
            // cboProfessor
            // 
            cboProfessor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboProfessor.BackColor = Color.White;
            cboProfessor.FormattingEnabled = true;
            cboProfessor.Location = new Point(21, 48);
            cboProfessor.Name = "cboProfessor";
            cboProfessor.Size = new Size(299, 23);
            cboProfessor.TabIndex = 1;
            // 
            // lblTituloAula
            // 
            lblTituloAula.AutoSize = true;
            lblTituloAula.Location = new Point(16, 0);
            lblTituloAula.Name = "lblTituloAula";
            lblTituloAula.Size = new Size(0, 15);
            lblTituloAula.TabIndex = 99;
            // 
            // txtTituloAula
            // 
            txtTituloAula.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTituloAula.Location = new Point(16, -999);
            txtTituloAula.Name = "txtTituloAula";
            txtTituloAula.Size = new Size(208, 23);
            txtTituloAula.TabIndex = 100;
            txtTituloAula.Visible = false;
            // 
            // grpItens
            // 
            grpItens.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpItens.Controls.Add(txtFiltroProduto);
            grpItens.Controls.Add(lblFiltroProduto);
            grpItens.Controls.Add(btnAdicionarItem);
            grpItens.Controls.Add(lblDisponivel);
            grpItens.Controls.Add(lblDisponivelCaption);
            grpItens.Controls.Add(lblLocal);
            grpItens.Controls.Add(lblLocalCaption);
            grpItens.Controls.Add(lblUnidade);
            grpItens.Controls.Add(lblUnidadeCaption);
            grpItens.Controls.Add(lblQuantidade);
            grpItens.Controls.Add(nudQuantidade);
            grpItens.Controls.Add(lblProduto);
            grpItens.Controls.Add(cboProduto);
            grpItens.ForeColor = Color.White;
            grpItens.Location = new Point(217, 238);
            grpItens.Name = "grpItens";
            grpItens.Size = new Size(1327, 137);
            grpItens.TabIndex = 2;
            grpItens.TabStop = false;
            grpItens.Text = "Adicionar Itens na Aula";
            // 
            // txtFiltroProduto
            // 
            txtFiltroProduto.BackColor = Color.White;
            txtFiltroProduto.Location = new Point(20, 50);
            txtFiltroProduto.Name = "txtFiltroProduto";
            txtFiltroProduto.Size = new Size(185, 23);
            txtFiltroProduto.TabIndex = 1;
            // 
            // lblFiltroProduto
            // 
            lblFiltroProduto.AutoSize = true;
            lblFiltroProduto.ForeColor = Color.Silver;
            lblFiltroProduto.Location = new Point(20, 32);
            lblFiltroProduto.Name = "lblFiltroProduto";
            lblFiltroProduto.Size = new Size(66, 15);
            lblFiltroProduto.TabIndex = 0;
            lblFiltroProduto.Text = "Buscar por:";
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdicionarItem.BackColor = Color.FromArgb(50, 50, 50);
            btnAdicionarItem.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            btnAdicionarItem.FlatStyle = FlatStyle.Flat;
            btnAdicionarItem.ForeColor = Color.White;
            btnAdicionarItem.Location = new Point(1182, 31);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.Size = new Size(124, 42);
            btnAdicionarItem.TabIndex = 12;
            btnAdicionarItem.Text = "Adicionar";
            btnAdicionarItem.UseVisualStyleBackColor = false;
            // 
            // lblDisponivel
            // 
            lblDisponivel.AutoSize = true;
            lblDisponivel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDisponivel.ForeColor = Color.FromArgb(0, 192, 0);
            lblDisponivel.Location = new Point(92, 104);
            lblDisponivel.Name = "lblDisponivel";
            lblDisponivel.Size = new Size(31, 15);
            lblDisponivel.TabIndex = 11;
            lblDisponivel.Text = "0,00";
            // 
            // lblDisponivelCaption
            // 
            lblDisponivelCaption.AutoSize = true;
            lblDisponivelCaption.ForeColor = Color.Silver;
            lblDisponivelCaption.Location = new Point(21, 104);
            lblDisponivelCaption.Name = "lblDisponivelCaption";
            lblDisponivelCaption.Size = new Size(65, 15);
            lblDisponivelCaption.TabIndex = 10;
            lblDisponivelCaption.Text = "Disponível:";
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocal.ForeColor = Color.White;
            lblLocal.Location = new Point(1001, 53);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(12, 15);
            lblLocal.TabIndex = 9;
            lblLocal.Text = "-";
            // 
            // lblLocalCaption
            // 
            lblLocalCaption.AutoSize = true;
            lblLocalCaption.ForeColor = Color.Silver;
            lblLocalCaption.Location = new Point(957, 53);
            lblLocalCaption.Name = "lblLocalCaption";
            lblLocalCaption.Size = new Size(38, 15);
            lblLocalCaption.TabIndex = 8;
            lblLocalCaption.Text = "Local:";
            // 
            // lblUnidade
            // 
            lblUnidade.AutoSize = true;
            lblUnidade.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUnidade.ForeColor = Color.White;
            lblUnidade.Location = new Point(918, 53);
            lblUnidade.Name = "lblUnidade";
            lblUnidade.Size = new Size(12, 15);
            lblUnidade.TabIndex = 7;
            lblUnidade.Text = "-";
            // 
            // lblUnidadeCaption
            // 
            lblUnidadeCaption.AutoSize = true;
            lblUnidadeCaption.ForeColor = Color.Silver;
            lblUnidadeCaption.Location = new Point(858, 53);
            lblUnidadeCaption.Name = "lblUnidadeCaption";
            lblUnidadeCaption.Size = new Size(54, 15);
            lblUnidadeCaption.TabIndex = 6;
            lblUnidadeCaption.Text = "Unidade:";
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.ForeColor = Color.Silver;
            lblQuantidade.Location = new Point(716, 31);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(72, 15);
            lblQuantidade.TabIndex = 4;
            lblQuantidade.Text = "Quantidade:";
            // 
            // nudQuantidade
            // 
            nudQuantidade.BackColor = Color.White;
            nudQuantidade.DecimalPlaces = 2;
            nudQuantidade.Location = new Point(716, 49);
            nudQuantidade.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(120, 23);
            nudQuantidade.TabIndex = 5;
            nudQuantidade.ThousandsSeparator = true;
            nudQuantidade.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.ForeColor = Color.Silver;
            lblProduto.Location = new Point(225, 31);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(53, 15);
            lblProduto.TabIndex = 2;
            lblProduto.Text = "Produto:";
            // 
            // cboProduto
            // 
            cboProduto.BackColor = Color.White;
            cboProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduto.FormattingEnabled = true;
            cboProduto.Location = new Point(225, 49);
            cboProduto.Name = "cboProduto";
            cboProduto.Size = new Size(471, 23);
            cboProduto.TabIndex = 3;
            // 
            // MontarAulaForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(1556, 785);
            Controls.Add(grpItens);
            Controls.Add(grpDadosAula);
            Controls.Add(panelMenuLateral);
            Controls.Add(chkDescontarEstoqueAoSalvar);
            Controls.Add(lblResumoItens);
            Controls.Add(dgvItensAula);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MontarAulaForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Configurar Aulas";
            ((System.ComponentModel.ISupportInitialize)dgvItensAula).EndInit();
            panelMenuLateral.ResumeLayout(false);
            grpDadosAula.ResumeLayout(false);
            grpDadosAula.PerformLayout();
            grpItens.ResumeLayout(false);
            grpItens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItensAula;
        private System.Windows.Forms.Label lblResumoItens;
        private System.Windows.Forms.CheckBox chkDescontarEstoqueAoSalvar;
        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnRemoverItemSelecionado;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvarAula;
        private System.Windows.Forms.GroupBox grpDadosAula;
        private System.Windows.Forms.Label lblObservacoesAula;
        private System.Windows.Forms.TextBox txtObservacoesAula;
        private System.Windows.Forms.Label lblStatusAula;
        private System.Windows.Forms.ComboBox cboStatusAula;
        private System.Windows.Forms.Label lblTipoAula;
        private System.Windows.Forms.ComboBox cboTipoAula;
        private System.Windows.Forms.Label lblTurma;
        private System.Windows.Forms.ComboBox cboTurma;
        private System.Windows.Forms.Label lblMateriaAula;
        private System.Windows.Forms.ComboBox cboMateriaAula;
        private System.Windows.Forms.Label lblDataAula;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.ComboBox cboProfessor;
        private System.Windows.Forms.Label lblTituloAula;
        private System.Windows.Forms.TextBox txtTituloAula;
        private System.Windows.Forms.GroupBox grpItens;
        private System.Windows.Forms.TextBox txtFiltroProduto;
        private System.Windows.Forms.Label lblFiltroProduto;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Label lblDisponivel;
        private System.Windows.Forms.Label lblDisponivelCaption;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblLocalCaption;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.Label lblUnidadeCaption;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cboProduto;
        private Button btnNovaTurma;
        private Label label1;
    }
}