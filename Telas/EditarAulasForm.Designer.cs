namespace alguamcoisa.Telas
{
    partial class EditarAulasForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnFechar = new Button();
            btnLimpar = new Button();
            btnSalvarAula = new Button();
            dgvItensAula = new DataGridView();
            lblResumoItens = new Label();
            btnAdicionarItem = new Button();
            lblDisponivel = new Label();
            lblLocal = new Label();
            nudQuantidade = new NumericUpDown();
            cboProduto = new ComboBox();
            panel1 = new Panel();
            btnExcluirAulaCompleta = new Button();
            btnRemoverItemSelecionado = new Button();
            dateTimePicker1 = new DateTimePicker();
            cboProfessor = new ComboBox();
            txtTituloAula = new TextBox();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            lblObservacoesAula = new Label();
            cboStatusAula = new ComboBox();
            lblStatusAula = new Label();
            cboTipoAula = new ComboBox();
            lblTipoAula = new Label();
            cboTurma = new ComboBox();
            lblTurma = new Label();
            cboMateriaAula = new ComboBox();
            lblMateriaAula = new Label();
            groupBox2 = new GroupBox();
            txtFiltroProduto = new TextBox();
            lblFiltroProduto = new Label();
            lblUnidade = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvItensAula).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 28);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 3;
            label1.Text = "Título da Aula:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 28);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 4;
            label2.Text = "Professor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(510, 28);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 5;
            label3.Text = "Data:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 90);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 6;
            label4.Text = "Produto:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(288, 90);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 7;
            label5.Text = "Quantidade:";
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFechar.Location = new Point(12, 763);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(132, 45);
            btnFechar.TabIndex = 5;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(12, 156);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(132, 45);
            btnLimpar.TabIndex = 3;
            btnLimpar.Text = "Recarregar aula";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnSalvarAula
            // 
            btnSalvarAula.Location = new Point(12, 928);
            btnSalvarAula.Name = "btnSalvarAula";
            btnSalvarAula.Size = new Size(132, 45);
            btnSalvarAula.TabIndex = 1;
            btnSalvarAula.Text = "Salvar e Fechar";
            btnSalvarAula.UseVisualStyleBackColor = true;
            // 
            // dgvItensAula
            // 
            dgvItensAula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItensAula.Dock = DockStyle.Bottom;
            dgvItensAula.Location = new Point(200, 529);
            dgvItensAula.Name = "dgvItensAula";
            dgvItensAula.Size = new Size(1477, 291);
            dgvItensAula.TabIndex = 8;
            // 
            // lblResumoItens
            // 
            lblResumoItens.AutoSize = true;
            lblResumoItens.Location = new Point(206, 496);
            lblResumoItens.Name = "lblResumoItens";
            lblResumoItens.Size = new Size(197, 15);
            lblResumoItens.TabIndex = 6;
            lblResumoItens.Text = "Itens na aula: X | Quantidade total: Y";
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.Location = new Point(12, 246);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.Size = new Size(132, 58);
            btnAdicionarItem.TabIndex = 5;
            btnAdicionarItem.Text = "Adicionar / Atualizar item";
            btnAdicionarItem.UseVisualStyleBackColor = true;
            // 
            // lblDisponivel
            // 
            lblDisponivel.AutoSize = true;
            lblDisponivel.Location = new Point(6, 145);
            lblDisponivel.Name = "lblDisponivel";
            lblDisponivel.Size = new Size(119, 15);
            lblDisponivel.TabIndex = 4;
            lblDisponivel.Text = "Disponível: 0,00 unid.";
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.Location = new Point(476, 41);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(94, 15);
            lblLocal.TabIndex = 3;
            lblLocal.Text = "Local: (nenhum)";
            // 
            // nudQuantidade
            // 
            nudQuantidade.Location = new Point(288, 108);
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(98, 23);
            nudQuantidade.TabIndex = 1;
            // 
            // cboProduto
            // 
            cboProduto.FormattingEnabled = true;
            cboProduto.Location = new Point(6, 108);
            cboProduto.Name = "cboProduto";
            cboProduto.Size = new Size(254, 23);
            cboProduto.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExcluirAulaCompleta);
            panel1.Controls.Add(btnFechar);
            panel1.Controls.Add(btnAdicionarItem);
            panel1.Controls.Add(btnRemoverItemSelecionado);
            panel1.Controls.Add(btnLimpar);
            panel1.Controls.Add(btnSalvarAula);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 820);
            panel1.TabIndex = 5;
            // 
            // btnExcluirAulaCompleta
            // 
            btnExcluirAulaCompleta.BackColor = Color.IndianRed;
            btnExcluirAulaCompleta.ForeColor = SystemColors.ControlLightLight;
            btnExcluirAulaCompleta.Location = new Point(12, 529);
            btnExcluirAulaCompleta.Name = "btnExcluirAulaCompleta";
            btnExcluirAulaCompleta.Size = new Size(132, 45);
            btnExcluirAulaCompleta.TabIndex = 2;
            btnExcluirAulaCompleta.Text = "Excluir Aula";
            btnExcluirAulaCompleta.UseVisualStyleBackColor = false;
            // 
            // btnRemoverItemSelecionado
            // 
            btnRemoverItemSelecionado.Location = new Point(12, 321);
            btnRemoverItemSelecionado.Name = "btnRemoverItemSelecionado";
            btnRemoverItemSelecionado.Size = new Size(132, 45);
            btnRemoverItemSelecionado.TabIndex = 4;
            btnRemoverItemSelecionado.Text = "Remover item";
            btnRemoverItemSelecionado.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(510, 47);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // cboProfessor
            // 
            cboProfessor.FormattingEnabled = true;
            cboProfessor.Location = new Point(288, 47);
            cboProfessor.Name = "cboProfessor";
            cboProfessor.Size = new Size(183, 23);
            cboProfessor.TabIndex = 1;
            // 
            // txtTituloAula
            // 
            txtTituloAula.Location = new Point(11, 46);
            txtTituloAula.Name = "txtTituloAula";
            txtTituloAula.Size = new Size(254, 23);
            txtTituloAula.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lblObservacoesAula);
            groupBox1.Controls.Add(cboStatusAula);
            groupBox1.Controls.Add(lblStatusAula);
            groupBox1.Controls.Add(cboTipoAula);
            groupBox1.Controls.Add(lblTipoAula);
            groupBox1.Controls.Add(cboTurma);
            groupBox1.Controls.Add(lblTurma);
            groupBox1.Controls.Add(cboMateriaAula);
            groupBox1.Controls.Add(lblMateriaAula);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(cboProfessor);
            groupBox1.Controls.Add(txtTituloAula);
            groupBox1.Location = new Point(206, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1459, 271);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados da Aula (Apenas Informativo / Edição do Título)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 162);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(729, 92);
            textBox1.TabIndex = 15;
            // 
            // lblObservacoesAula
            // 
            lblObservacoesAula.AutoSize = true;
            lblObservacoesAula.Location = new Point(11, 144);
            lblObservacoesAula.Name = "lblObservacoesAula";
            lblObservacoesAula.Size = new Size(111, 15);
            lblObservacoesAula.TabIndex = 14;
            lblObservacoesAula.Text = "lblObservacoesAula";
            // 
            // cboStatusAula
            // 
            cboStatusAula.FormattingEnabled = true;
            cboStatusAula.Location = new Point(673, 100);
            cboStatusAula.Name = "cboStatusAula";
            cboStatusAula.Size = new Size(121, 23);
            cboStatusAula.TabIndex = 13;
            // 
            // lblStatusAula
            // 
            lblStatusAula.AutoSize = true;
            lblStatusAula.Location = new Point(672, 82);
            lblStatusAula.Name = "lblStatusAula";
            lblStatusAula.Size = new Size(38, 15);
            lblStatusAula.TabIndex = 12;
            lblStatusAula.Text = "label6";
            // 
            // cboTipoAula
            // 
            cboTipoAula.FormattingEnabled = true;
            cboTipoAula.Location = new Point(506, 102);
            cboTipoAula.Name = "cboTipoAula";
            cboTipoAula.Size = new Size(139, 23);
            cboTipoAula.TabIndex = 11;
            // 
            // lblTipoAula
            // 
            lblTipoAula.AutoSize = true;
            lblTipoAula.Location = new Point(506, 82);
            lblTipoAula.Name = "lblTipoAula";
            lblTipoAula.Size = new Size(38, 15);
            lblTipoAula.TabIndex = 10;
            lblTipoAula.Text = "label6";
            // 
            // cboTurma
            // 
            cboTurma.FormattingEnabled = true;
            cboTurma.Location = new Point(288, 101);
            cboTurma.Name = "cboTurma";
            cboTurma.Size = new Size(183, 23);
            cboTurma.TabIndex = 9;
            // 
            // lblTurma
            // 
            lblTurma.AutoSize = true;
            lblTurma.Location = new Point(286, 83);
            lblTurma.Name = "lblTurma";
            lblTurma.Size = new Size(42, 15);
            lblTurma.TabIndex = 8;
            lblTurma.Text = "Turma";
            // 
            // cboMateriaAula
            // 
            cboMateriaAula.FormattingEnabled = true;
            cboMateriaAula.Location = new Point(11, 102);
            cboMateriaAula.Name = "cboMateriaAula";
            cboMateriaAula.Size = new Size(249, 23);
            cboMateriaAula.TabIndex = 7;
            // 
            // lblMateriaAula
            // 
            lblMateriaAula.AutoSize = true;
            lblMateriaAula.Location = new Point(11, 82);
            lblMateriaAula.Name = "lblMateriaAula";
            lblMateriaAula.Size = new Size(47, 15);
            lblMateriaAula.TabIndex = 6;
            lblMateriaAula.Text = "Materia";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtFiltroProduto);
            groupBox2.Controls.Add(lblFiltroProduto);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lblDisponivel);
            groupBox2.Controls.Add(lblUnidade);
            groupBox2.Controls.Add(lblLocal);
            groupBox2.Controls.Add(nudQuantidade);
            groupBox2.Controls.Add(cboProduto);
            groupBox2.Location = new Point(206, 289);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1459, 182);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Itens da Aula (Adição/Ajuste)";
            // 
            // txtFiltroProduto
            // 
            txtFiltroProduto.Location = new Point(6, 44);
            txtFiltroProduto.Name = "txtFiltroProduto";
            txtFiltroProduto.Size = new Size(246, 23);
            txtFiltroProduto.TabIndex = 9;
            // 
            // lblFiltroProduto
            // 
            lblFiltroProduto.AutoSize = true;
            lblFiltroProduto.Location = new Point(4, 26);
            lblFiltroProduto.Name = "lblFiltroProduto";
            lblFiltroProduto.Size = new Size(91, 15);
            lblFiltroProduto.TabIndex = 8;
            lblFiltroProduto.Text = "Buscar produto:";
            // 
            // lblUnidade
            // 
            lblUnidade.AutoSize = true;
            lblUnidade.Location = new Point(589, 40);
            lblUnidade.Name = "lblUnidade";
            lblUnidade.Size = new Size(94, 15);
            lblUnidade.TabIndex = 3;
            lblUnidade.Text = "Local: (nenhum)";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(468, 496);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(173, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Descontar estoque ao salvar";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // EditarAulasForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1677, 820);
            Controls.Add(checkBox1);
            Controls.Add(dgvItensAula);
            Controls.Add(lblResumoItens);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditarAulasForm";
            Text = "Editar Aula";
            ((System.ComponentModel.ISupportInitialize)dgvItensAula).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFechar;
        private Button btnLimpar;
        private Button btnSalvarAula;
        private DataGridView dgvItensAula;
        private Label lblResumoItens;
        private Button btnAdicionarItem;
        private Label lblDisponivel;
        private Label lblLocal;
        private NumericUpDown nudQuantidade;
        private ComboBox cboProduto;
        private Panel panel1;
        private Button btnRemoverItemSelecionado;
        private DateTimePicker dateTimePicker1;
        private ComboBox cboProfessor;
        private TextBox txtTituloAula;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnExcluirAulaCompleta; // Novo botão
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblUnidade;
        private ComboBox cboTurma;
        private Label lblTurma;
        private ComboBox cboMateriaAula;
        private Label lblMateriaAula;
        private Label lblStatusAula;
        private ComboBox cboTipoAula;
        private Label lblTipoAula;
        private TextBox textBox1;
        private Label lblObservacoesAula;
        private ComboBox cboStatusAula;
        private TextBox txtFiltroProduto;
        private Label lblFiltroProduto;
        private CheckBox checkBox1;
    }
}