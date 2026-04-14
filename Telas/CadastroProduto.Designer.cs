namespace alguamcoisa
{
    partial class CadastroProduto
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
            label2 = new Label();
            pnlLeft = new Panel();
            lblTitulo = new Label();
            lblTituloS = new Label();
            btnFechar = new Button();
            btnCadastrar = new Button();
            btnLimpar = new Button();
            lblEstoque = new Label();
            txtEstadoFisico = new ComboBox();
            txtRecipiente = new ComboBox();
            lblEstadoFisico = new Label();
            lblRecipiente = new Label();
            btnAddLocalDeposito = new Button();
            txtLocalDeposito = new ComboBox();
            txtEstoqueMinimo = new TextBox();
            btnAddLocalEspecifico = new Button();
            txtLocal = new ComboBox();
            txtUnidade = new ComboBox();
            txtQuantidade = new TextBox();
            txtCategoria = new ComboBox();
            txtNome = new TextBox();
            lblFabricante = new Label();
            lblEstoqueMinimo = new Label();
            lblValidade = new Label();
            lbllocal = new Label();
            lblNovoLocal = new Label();
            lblNovoDeposito = new Label();
            lblDeposito = new Label();
            lblUnidade = new Label();
            lblQuantidade = new Label();
            lblCategoria = new Label();
            lblNomeProduto = new Label();
            pnlFundo = new Panel();
            dtValidade = new DateTimePicker();
            chkPerecivel = new CheckBox();
            button1 = new Button();
            btnAddRecipiente = new Button();
            cboFabricante = new ComboBox();
            btnAddUnidade = new Button();
            btnAddEstadoFisico = new Button();
            btnAddCategoria = new Button();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            pnlLeft.SuspendLayout();
            pnlFundo.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(304, 39);
            label2.Name = "label2";
            label2.Size = new Size(254, 30);
            label2.TabIndex = 26;
            label2.Text = "Informações do Produto\r\n";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(lblTitulo);
            pnlLeft.Controls.Add(lblTituloS);
            pnlLeft.Controls.Add(btnFechar);
            pnlLeft.Controls.Add(btnCadastrar);
            pnlLeft.Controls.Add(btnLimpar);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(282, 621);
            pnlLeft.TabIndex = 57;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(3, 39);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(270, 30);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Cadastrar Novos Produtos";
            // 
            // lblTituloS
            // 
            lblTituloS.AutoSize = true;
            lblTituloS.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloS.Location = new Point(12, 84);
            lblTituloS.Name = "lblTituloS";
            lblTituloS.Size = new Size(199, 20);
            lblTituloS.TabIndex = 27;
            lblTituloS.Text = "Cadastrar ou Editar Produtos";
            // 
            // btnFechar
            // 
            btnFechar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFechar.FlatStyle = FlatStyle.System;
            btnFechar.Location = new Point(23, 337);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(188, 43);
            btnFechar.TabIndex = 55;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnCadastrar
            // 
            btnCadastrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCadastrar.FlatStyle = FlatStyle.System;
            btnCadastrar.Location = new Point(23, 258);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(188, 43);
            btnCadastrar.TabIndex = 53;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpar.BackColor = Color.Gray;
            btnLimpar.FlatStyle = FlatStyle.System;
            btnLimpar.ForeColor = Color.Transparent;
            btnLimpar.Location = new Point(23, 181);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(188, 43);
            btnLimpar.TabIndex = 54;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Location = new Point(23, 227);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(0, 20);
            lblEstoque.TabIndex = 56;
            // 
            // txtEstadoFisico
            // 
            txtEstadoFisico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtEstadoFisico.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtEstadoFisico.Font = new Font("Segoe UI", 11.25F);
            txtEstadoFisico.FormattingEnabled = true;
            txtEstadoFisico.Location = new Point(609, 507);
            txtEstadoFisico.Name = "txtEstadoFisico";
            txtEstadoFisico.Size = new Size(171, 28);
            txtEstadoFisico.TabIndex = 52;
            // 
            // txtRecipiente
            // 
            txtRecipiente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtRecipiente.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtRecipiente.Font = new Font("Segoe UI", 11.25F);
            txtRecipiente.FormattingEnabled = true;
            txtRecipiente.Location = new Point(310, 507);
            txtRecipiente.Name = "txtRecipiente";
            txtRecipiente.Size = new Size(170, 28);
            txtRecipiente.TabIndex = 51;
            // 
            // lblEstadoFisico
            // 
            lblEstadoFisico.AutoSize = true;
            lblEstadoFisico.Location = new Point(609, 488);
            lblEstadoFisico.Name = "lblEstadoFisico";
            lblEstadoFisico.Size = new Size(93, 20);
            lblEstadoFisico.TabIndex = 50;
            lblEstadoFisico.Text = "Estado fisico";
            // 
            // lblRecipiente
            // 
            lblRecipiente.AutoSize = true;
            lblRecipiente.Location = new Point(310, 484);
            lblRecipiente.Name = "lblRecipiente";
            lblRecipiente.Size = new Size(79, 20);
            lblRecipiente.TabIndex = 49;
            lblRecipiente.Text = "Recipiente";
            // 
            // btnAddLocalDeposito
            // 
            btnAddLocalDeposito.FlatStyle = FlatStyle.System;
            btnAddLocalDeposito.Font = new Font("Segoe UI", 11.25F);
            btnAddLocalDeposito.Location = new Point(444, 389);
            btnAddLocalDeposito.Name = "btnAddLocalDeposito";
            btnAddLocalDeposito.Size = new Size(36, 29);
            btnAddLocalDeposito.TabIndex = 25;
            btnAddLocalDeposito.Text = "+";
            btnAddLocalDeposito.UseVisualStyleBackColor = true;
            btnAddLocalDeposito.Click += btnAddLocalDeposito_Click;
            // 
            // txtLocalDeposito
            // 
            txtLocalDeposito.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtLocalDeposito.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtLocalDeposito.Font = new Font("Segoe UI", 11.25F);
            txtLocalDeposito.FormattingEnabled = true;
            txtLocalDeposito.Location = new Point(310, 360);
            txtLocalDeposito.Name = "txtLocalDeposito";
            txtLocalDeposito.Size = new Size(170, 28);
            txtLocalDeposito.TabIndex = 46;
            // 
            // txtEstoqueMinimo
            // 
            txtEstoqueMinimo.Font = new Font("Segoe UI", 11.25F);
            txtEstoqueMinimo.Location = new Point(891, 134);
            txtEstoqueMinimo.Name = "txtEstoqueMinimo";
            txtEstoqueMinimo.Size = new Size(134, 27);
            txtEstoqueMinimo.TabIndex = 44;
            // 
            // btnAddLocalEspecifico
            // 
            btnAddLocalEspecifico.FlatStyle = FlatStyle.System;
            btnAddLocalEspecifico.Font = new Font("Segoe UI", 11.25F);
            btnAddLocalEspecifico.Location = new Point(766, 394);
            btnAddLocalEspecifico.Name = "btnAddLocalEspecifico";
            btnAddLocalEspecifico.Size = new Size(36, 29);
            btnAddLocalEspecifico.TabIndex = 25;
            btnAddLocalEspecifico.Text = "+";
            btnAddLocalEspecifico.UseVisualStyleBackColor = true;
            btnAddLocalEspecifico.Click += btnAddLocalEspecifico_Click;
            // 
            // txtLocal
            // 
            txtLocal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtLocal.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtLocal.Font = new Font("Segoe UI", 11.25F);
            txtLocal.FormattingEnabled = true;
            txtLocal.Location = new Point(609, 364);
            txtLocal.Name = "txtLocal";
            txtLocal.Size = new Size(194, 28);
            txtLocal.TabIndex = 41;
            // 
            // txtUnidade
            // 
            txtUnidade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUnidade.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtUnidade.Font = new Font("Segoe UI", 11.25F);
            txtUnidade.FormattingEnabled = true;
            txtUnidade.Location = new Point(609, 227);
            txtUnidade.Name = "txtUnidade";
            txtUnidade.Size = new Size(161, 28);
            txtUnidade.TabIndex = 40;
            // 
            // txtQuantidade
            // 
            txtQuantidade.Font = new Font("Segoe UI", 11.25F);
            txtQuantidade.Location = new Point(709, 134);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(151, 27);
            txtQuantidade.TabIndex = 39;
            // 
            // txtCategoria
            // 
            txtCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtCategoria.Font = new Font("Segoe UI", 11.25F);
            txtCategoria.FormattingEnabled = true;
            txtCategoria.Location = new Point(310, 223);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(205, 28);
            txtCategoria.TabIndex = 38;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNome.Location = new Point(310, 134);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(370, 27);
            txtNome.TabIndex = 37;
            // 
            // lblFabricante
            // 
            lblFabricante.AutoSize = true;
            lblFabricante.Location = new Point(891, 341);
            lblFabricante.Name = "lblFabricante";
            lblFabricante.Size = new Size(84, 20);
            lblFabricante.TabIndex = 36;
            lblFabricante.Text = "Fornecedor";
            // 
            // lblEstoqueMinimo
            // 
            lblEstoqueMinimo.AutoSize = true;
            lblEstoqueMinimo.Location = new Point(891, 111);
            lblEstoqueMinimo.Name = "lblEstoqueMinimo";
            lblEstoqueMinimo.Size = new Size(117, 20);
            lblEstoqueMinimo.TabIndex = 35;
            lblEstoqueMinimo.Text = "Estoque minimo";
            // 
            // lblValidade
            // 
            lblValidade.AutoSize = true;
            lblValidade.Location = new Point(822, 204);
            lblValidade.Name = "lblValidade";
            lblValidade.Size = new Size(67, 20);
            lblValidade.TabIndex = 34;
            lblValidade.Text = "Validade";
            // 
            // lbllocal
            // 
            lbllocal.AutoSize = true;
            lbllocal.Location = new Point(609, 341);
            lbllocal.Name = "lbllocal";
            lbllocal.Size = new Size(44, 20);
            lbllocal.TabIndex = 33;
            lbllocal.Text = "Local";
            // 
            // lblNovoLocal
            // 
            lblNovoLocal.AutoSize = true;
            lblNovoLocal.Location = new Point(609, 394);
            lblNovoLocal.Name = "lblNovoLocal";
            lblNovoLocal.Size = new Size(84, 20);
            lblNovoLocal.TabIndex = 32;
            lblNovoLocal.Text = "Novo Local\r\n";
            // 
            // lblNovoDeposito
            // 
            lblNovoDeposito.AutoSize = true;
            lblNovoDeposito.Location = new Point(310, 391);
            lblNovoDeposito.Name = "lblNovoDeposito";
            lblNovoDeposito.Size = new Size(110, 20);
            lblNovoDeposito.TabIndex = 32;
            lblNovoDeposito.Text = "Novo Deposito";
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(310, 337);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(70, 20);
            lblDeposito.TabIndex = 32;
            lblDeposito.Text = "Deposito";
            // 
            // lblUnidade
            // 
            lblUnidade.AutoSize = true;
            lblUnidade.Location = new Point(609, 204);
            lblUnidade.Name = "lblUnidade";
            lblUnidade.Size = new Size(65, 20);
            lblUnidade.TabIndex = 31;
            lblUnidade.Text = "Unidade";
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(709, 111);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(90, 20);
            lblQuantidade.TabIndex = 30;
            lblQuantidade.Text = "Quantidade:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(310, 200);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(77, 20);
            lblCategoria.TabIndex = 29;
            lblCategoria.Text = "Categoria:";
            // 
            // lblNomeProduto
            // 
            lblNomeProduto.AutoSize = true;
            lblNomeProduto.Location = new Point(310, 111);
            lblNomeProduto.Name = "lblNomeProduto";
            lblNomeProduto.Size = new Size(133, 20);
            lblNomeProduto.TabIndex = 28;
            lblNomeProduto.Text = "Nome do produto:";
            // 
            // pnlFundo
            // 
            pnlFundo.AutoScroll = true;
            pnlFundo.Controls.Add(dtValidade);
            pnlFundo.Controls.Add(chkPerecivel);
            pnlFundo.Controls.Add(button1);
            pnlFundo.Controls.Add(btnAddRecipiente);
            pnlFundo.Controls.Add(cboFabricante);
            pnlFundo.Controls.Add(btnAddUnidade);
            pnlFundo.Controls.Add(label2);
            pnlFundo.Controls.Add(btnAddEstadoFisico);
            pnlFundo.Controls.Add(pnlLeft);
            pnlFundo.Controls.Add(btnAddCategoria);
            pnlFundo.Controls.Add(lblEstoque);
            pnlFundo.Controls.Add(txtEstadoFisico);
            pnlFundo.Controls.Add(txtRecipiente);
            pnlFundo.Controls.Add(label5);
            pnlFundo.Controls.Add(lblEstadoFisico);
            pnlFundo.Controls.Add(lblRecipiente);
            pnlFundo.Controls.Add(btnAddLocalDeposito);
            pnlFundo.Controls.Add(txtLocalDeposito);
            pnlFundo.Controls.Add(txtEstoqueMinimo);
            pnlFundo.Controls.Add(btnAddLocalEspecifico);
            pnlFundo.Controls.Add(txtLocal);
            pnlFundo.Controls.Add(txtUnidade);
            pnlFundo.Controls.Add(txtQuantidade);
            pnlFundo.Controls.Add(txtCategoria);
            pnlFundo.Controls.Add(txtNome);
            pnlFundo.Controls.Add(lblFabricante);
            pnlFundo.Controls.Add(lblEstoqueMinimo);
            pnlFundo.Controls.Add(lblValidade);
            pnlFundo.Controls.Add(lbllocal);
            pnlFundo.Controls.Add(label6);
            pnlFundo.Controls.Add(lblNovoLocal);
            pnlFundo.Controls.Add(label1);
            pnlFundo.Controls.Add(label4);
            pnlFundo.Controls.Add(label3);
            pnlFundo.Controls.Add(lblNovoDeposito);
            pnlFundo.Controls.Add(lblDeposito);
            pnlFundo.Controls.Add(lblUnidade);
            pnlFundo.Controls.Add(lblQuantidade);
            pnlFundo.Controls.Add(lblCategoria);
            pnlFundo.Controls.Add(lblNomeProduto);
            pnlFundo.Dock = DockStyle.Fill;
            pnlFundo.Font = new Font("Segoe UI", 11.25F);
            pnlFundo.Location = new Point(0, 0);
            pnlFundo.Name = "pnlFundo";
            pnlFundo.Size = new Size(1142, 621);
            pnlFundo.TabIndex = 1;
            // 
            // dtValidade
            // 
            dtValidade.CustomFormat = "dd/MM/yyyy";
            dtValidade.Format = DateTimePickerFormat.Custom;
            dtValidade.Location = new Point(950, 225);
            dtValidade.Name = "dtValidade";
            dtValidade.Size = new Size(134, 27);
            dtValidade.TabIndex = 62;
            dtValidade.Value = new DateTime(2025, 11, 24, 0, 0, 0, 0);
            dtValidade.ValueChanged += dtValidade_ValueChanged;
            // 
            // chkPerecivel
            // 
            chkPerecivel.AutoSize = true;
            chkPerecivel.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkPerecivel.Location = new Point(831, 230);
            chkPerecivel.Name = "chkPerecivel";
            chkPerecivel.Size = new Size(113, 21);
            chkPerecivel.TabIndex = 61;
            chkPerecivel.Text = "Ativar/Desativar";
            chkPerecivel.UseVisualStyleBackColor = true;
            chkPerecivel.CheckedChanged += chkPerecivel_CheckedChanged;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 11.25F);
            button1.Location = new Point(1027, 394);
            button1.Name = "button1";
            button1.Size = new Size(36, 29);
            button1.TabIndex = 59;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnAddRecipiente
            // 
            btnAddRecipiente.FlatStyle = FlatStyle.System;
            btnAddRecipiente.Font = new Font("Segoe UI", 11.25F);
            btnAddRecipiente.Location = new Point(444, 535);
            btnAddRecipiente.Name = "btnAddRecipiente";
            btnAddRecipiente.Size = new Size(36, 29);
            btnAddRecipiente.TabIndex = 25;
            btnAddRecipiente.Text = "+";
            btnAddRecipiente.UseVisualStyleBackColor = true;
            btnAddRecipiente.Click += btnAddRecipiente_Click;
            // 
            // cboFabricante
            // 
            cboFabricante.FormattingEnabled = true;
            cboFabricante.Location = new Point(891, 364);
            cboFabricante.Name = "cboFabricante";
            cboFabricante.Size = new Size(172, 28);
            cboFabricante.TabIndex = 58;
            // 
            // btnAddUnidade
            // 
            btnAddUnidade.FlatStyle = FlatStyle.System;
            btnAddUnidade.Font = new Font("Segoe UI", 11.25F);
            btnAddUnidade.Location = new Point(734, 256);
            btnAddUnidade.Name = "btnAddUnidade";
            btnAddUnidade.Size = new Size(36, 29);
            btnAddUnidade.TabIndex = 25;
            btnAddUnidade.Text = "+";
            btnAddUnidade.UseVisualStyleBackColor = true;
            btnAddUnidade.Click += btnAddUnidade_Click;
            // 
            // btnAddEstadoFisico
            // 
            btnAddEstadoFisico.FlatStyle = FlatStyle.System;
            btnAddEstadoFisico.Font = new Font("Segoe UI", 11.25F);
            btnAddEstadoFisico.Location = new Point(744, 535);
            btnAddEstadoFisico.Name = "btnAddEstadoFisico";
            btnAddEstadoFisico.Size = new Size(36, 29);
            btnAddEstadoFisico.TabIndex = 25;
            btnAddEstadoFisico.Text = "+";
            btnAddEstadoFisico.UseVisualStyleBackColor = true;
            btnAddEstadoFisico.Click += btnAddEstadoFisico_Click;
            // 
            // btnAddCategoria
            // 
            btnAddCategoria.FlatStyle = FlatStyle.System;
            btnAddCategoria.Font = new Font("Segoe UI", 11.25F);
            btnAddCategoria.Location = new Point(479, 252);
            btnAddCategoria.Name = "btnAddCategoria";
            btnAddCategoria.Size = new Size(36, 29);
            btnAddCategoria.TabIndex = 90;
            btnAddCategoria.Text = "+";
            btnAddCategoria.UseVisualStyleBackColor = true;
            btnAddCategoria.Click += btnAddCategoria_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(609, 539);
            label5.Name = "label5";
            label5.Size = new Size(133, 20);
            label5.TabIndex = 50;
            label5.Text = "Novo Estado fisico";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(891, 395);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 32;
            label6.Text = "Novo Fornecedor";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 252);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 32;
            label1.Text = "Nova Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(310, 537);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 32;
            label4.Text = "Novo Recipiente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(609, 258);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 32;
            label3.Text = "Nova Unidade";
            // 
            // CadastroProduto
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1142, 621);
            Controls.Add(pnlFundo);
            FormBorderStyle = FormBorderStyle.None;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "CadastroProduto";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "CadastroProduto";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlFundo.ResumeLayout(false);
            pnlFundo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Panel pnlLeft;
        private Label lblTitulo;
        private Label lblTituloS;
        private Button btnFechar;
        private Button btnCadastrar;
        private Button btnLimpar;
        private Label lblEstoque;
        private ComboBox txtEstadoFisico;
        private ComboBox txtRecipiente;
        private Label lblEstadoFisico;
        private Label lblRecipiente;
        private Button btnAddLocalDeposito;
        private ComboBox txtLocalDeposito;
        private TextBox txtEstoqueMinimo;
        private Button btnAddLocalEspecifico;
        private ComboBox txtLocal;
        private ComboBox txtUnidade;
        private TextBox txtQuantidade;
        private ComboBox txtCategoria;
        private TextBox txtNome;
        private Label lblFabricante;
        private Label lblEstoqueMinimo;
        private Label lblValidade;
        private Label lbllocal;
        private Label lblNovoLocal;
        private Label lblNovoDeposito;
        private Label lblDeposito;
        private Label lblUnidade;
        private Label lblQuantidade;
        private Label lblCategoria;
        private Label lblNomeProduto;
        private Panel pnlFundo;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label5;
        private ComboBox cboFabricante;
        private Button btnAddRecipiente;
        private Button btnAddUnidade;
        private Button btnAddEstadoFisico;
        private Button button1;
        private DateTimePicker dtValidade;
        private CheckBox chkPerecivel;
        private Label label6;
        public Button btnAddCategoria;
    }
}
