namespace alguamcoisa
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            components = new System.ComponentModel.Container();
            pnlHome = new Panel();
            configuracoesSistema = new ToolStripMenuItem();
            relSaidasMenuItem = new ToolStripMenuItem();
            relFornecedoresMenuItem = new ToolStripMenuItem();
            relEntradaMenuItem = new ToolStripMenuItem();
            relatoriosToolStripMenuItem = new ToolStripMenuItem();
            visFornecedoresMenuItem = new ToolStripMenuItem();
            visEstoqueMenuItem = new ToolStripMenuItem();
            cadProfessoresMenuItem = new ToolStripMenuItem();
            cadProdutosMenuItem = new ToolStripMenuItem();
            cadFornecedoresMenuItem = new ToolStripMenuItem();
            cadastrarToolStripMenuItem = new ToolStripMenuItem();
            montarAulasMenuItem = new ToolStripMenuItem();
            editarAulasMenuItem = new ToolStripMenuItem();
            configurarAulasToolStripMenuItem = new ToolStripMenuItem();
            visualizarToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            picAvatarUsuario = new PictureBox();
            ctxUsuario = new ContextMenuStrip(components);
            ctxTrocarUsuarioMenuItem = new ToolStripMenuItem();
            ctxSairMenuItem = new ToolStripMenuItem();
            lblUsuario = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarUsuario).BeginInit();
            ctxUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHome
            // 
            pnlHome.Dock = DockStyle.Fill;
            pnlHome.Location = new Point(0, 37);
            pnlHome.Name = "pnlHome";
            pnlHome.Size = new Size(1278, 691);
            pnlHome.TabIndex = 3;
            pnlHome.Paint += pnlHome_Paint;
            // 
            // configuracoesSistema
            // 
            configuracoesSistema.Name = "configuracoesSistema";
            configuracoesSistema.Size = new Size(194, 33);
            configuracoesSistema.Text = "Configurações";
            configuracoesSistema.Click += configuracoesSistema_Click;
            // 
            // relSaidasMenuItem
            // 
            relSaidasMenuItem.Name = "relSaidasMenuItem";
            relSaidasMenuItem.Size = new Size(250, 34);
            relSaidasMenuItem.Text = "Saídas";
            relSaidasMenuItem.Click += relSaidasMenuItem_Click;
            // 
            // relFornecedoresMenuItem
            // 
            relFornecedoresMenuItem.Name = "relFornecedoresMenuItem";
            relFornecedoresMenuItem.Size = new Size(250, 34);
            relFornecedoresMenuItem.Text = "Fornecedores";
            relFornecedoresMenuItem.Click += relFornecedoresMenuItem_Click;
            // 
            // relEntradaMenuItem
            // 
            relEntradaMenuItem.Name = "relEntradaMenuItem";
            relEntradaMenuItem.Size = new Size(250, 34);
            relEntradaMenuItem.Text = "Entradas";
            relEntradaMenuItem.Click += relEntradaMenuItem_Click;
            // 
            // relatoriosToolStripMenuItem
            // 
            relatoriosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { relEntradaMenuItem, relFornecedoresMenuItem, relSaidasMenuItem });
            relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            relatoriosToolStripMenuItem.Size = new Size(145, 33);
            relatoriosToolStripMenuItem.Text = "Relatórios";
            // 
            // visFornecedoresMenuItem
            // 
            visFornecedoresMenuItem.Name = "visFornecedoresMenuItem";
            visFornecedoresMenuItem.Size = new Size(250, 34);
            visFornecedoresMenuItem.Text = "Fornecedores";
            visFornecedoresMenuItem.Click += visFornecedoresMenuItem_Click;
            // 
            // visEstoqueMenuItem
            // 
            visEstoqueMenuItem.Name = "visEstoqueMenuItem";
            visEstoqueMenuItem.Size = new Size(250, 34);
            visEstoqueMenuItem.Text = "Estoque";
            visEstoqueMenuItem.Click += visEstoqueMenuItem_Click;
            // 
            // cadProfessoresMenuItem
            // 
            cadProfessoresMenuItem.Name = "cadProfessoresMenuItem";
            cadProfessoresMenuItem.Size = new Size(250, 34);
            cadProfessoresMenuItem.Text = "Professores";
            cadProfessoresMenuItem.Click += cadProfessoresMenuItem_Click;
            // 
            // cadProdutosMenuItem
            // 
            cadProdutosMenuItem.Name = "cadProdutosMenuItem";
            cadProdutosMenuItem.Size = new Size(250, 34);
            cadProdutosMenuItem.Text = "Produtos";
            cadProdutosMenuItem.Click += cadProdutosMenuItem_Click;
            // 
            // cadFornecedoresMenuItem
            // 
            cadFornecedoresMenuItem.Name = "cadFornecedoresMenuItem";
            cadFornecedoresMenuItem.Size = new Size(250, 34);
            cadFornecedoresMenuItem.Text = "Fornecedores";
            cadFornecedoresMenuItem.Click += cadFornecedoresMenuItem_Click;
            // 
            // cadastrarToolStripMenuItem
            // 
            cadastrarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadFornecedoresMenuItem, cadProdutosMenuItem, cadProfessoresMenuItem });
            cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            cadastrarToolStripMenuItem.Size = new Size(138, 33);
            cadastrarToolStripMenuItem.Text = "Cadastrar";
            // 
            // montarAulasMenuItem
            // 
            montarAulasMenuItem.Name = "montarAulasMenuItem";
            montarAulasMenuItem.Size = new Size(237, 34);
            montarAulasMenuItem.Text = "Montar Aulas";
            montarAulasMenuItem.Click += montarAulasMenuItem_Click;
            // 
            // editarAulasMenuItem
            // 
            editarAulasMenuItem.Name = "editarAulasMenuItem";
            editarAulasMenuItem.Size = new Size(237, 34);
            editarAulasMenuItem.Text = "Editar Aulas";
            editarAulasMenuItem.Click += editarAulasMenuItem_Click;
            // 
            // configurarAulasToolStripMenuItem
            // 
            configurarAulasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editarAulasMenuItem, montarAulasMenuItem });
            configurarAulasToolStripMenuItem.Name = "configurarAulasToolStripMenuItem";
            configurarAulasToolStripMenuItem.Size = new Size(218, 33);
            configurarAulasToolStripMenuItem.Text = "Configurar Aulas";
            // 
            // visualizarToolStripMenuItem
            // 
            visualizarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { visEstoqueMenuItem, visFornecedoresMenuItem });
            visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            visualizarToolStripMenuItem.Size = new Size(138, 33);
            visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { configurarAulasToolStripMenuItem, cadastrarToolStripMenuItem, visualizarToolStripMenuItem, relatoriosToolStripMenuItem, configuracoesSistema });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1278, 37);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // picAvatarUsuario
            // 
            picAvatarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picAvatarUsuario.BackColor = Color.Transparent;
            picAvatarUsuario.ContextMenuStrip = ctxUsuario;
            picAvatarUsuario.Location = new Point(1090, 2);
            picAvatarUsuario.Name = "picAvatarUsuario";
            picAvatarUsuario.Size = new Size(32, 32);
            picAvatarUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatarUsuario.TabIndex = 4;
            picAvatarUsuario.TabStop = false;
            picAvatarUsuario.Click += picAvatarUsuario_Click;
            picAvatarUsuario.Paint += picAvatarUsuario_Paint;
            picAvatarUsuario.MouseEnter += picAvatarUsuario_MouseEnter;
            picAvatarUsuario.MouseLeave += picAvatarUsuario_MouseLeave;
            picAvatarUsuario.Resize += picAvatarUsuario_Resize;
            // 
            // ctxUsuario
            // 
            ctxUsuario.BackColor = Color.FromArgb(45, 45, 48);
            ctxUsuario.Font = new Font("Segoe UI", 10F);
            ctxUsuario.ForeColor = Color.WhiteSmoke;
            ctxUsuario.ImageScalingSize = new Size(20, 20);
            ctxUsuario.Items.AddRange(new ToolStripItem[] { ctxTrocarUsuarioMenuItem, ctxSairMenuItem });
            ctxUsuario.Name = "ctxUsuario";
            ctxUsuario.RenderMode = ToolStripRenderMode.System;
            ctxUsuario.ShowImageMargin = false;
            ctxUsuario.Size = new Size(161, 52);
            // 
            // ctxTrocarUsuarioMenuItem
            // 
            ctxTrocarUsuarioMenuItem.Name = "ctxTrocarUsuarioMenuItem";
            ctxTrocarUsuarioMenuItem.Size = new Size(160, 24);
            ctxTrocarUsuarioMenuItem.Text = "Trocar de Usuário";
            ctxTrocarUsuarioMenuItem.Click += ctxTrocarUsuarioMenuItem_Click;
            // 
            // ctxSairMenuItem
            // 
            ctxSairMenuItem.Name = "ctxSairMenuItem";
            ctxSairMenuItem.Size = new Size(160, 24);
            ctxSairMenuItem.Text = "Sair";
            ctxSairMenuItem.Click += ctxSairMenuItem_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.FromArgb(45, 45, 48);
            lblUsuario.BorderStyle = BorderStyle.FixedSingle;
            lblUsuario.ContextMenuStrip = ctxUsuario;
            lblUsuario.Cursor = Cursors.Hand;
            lblUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.WhiteSmoke;
            lblUsuario.Location = new Point(1128, 6);
            lblUsuario.Margin = new Padding(0, 5, 15, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Padding = new Padding(8, 3, 8, 3);
            lblUsuario.Size = new Size(114, 28);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuário atual";
            lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
            lblUsuario.Click += lblUsuario_Click;
            lblUsuario.MouseEnter += lblUsuario_MouseEnter;
            lblUsuario.MouseLeave += lblUsuario_MouseLeave;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            ClientSize = new Size(1278, 728);
            Controls.Add(lblUsuario);
            Controls.Add(picAvatarUsuario);
            Controls.Add(pnlHome);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema ERP";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatarUsuario).EndInit();
            ctxUsuario.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.ToolStripMenuItem configuracoesSistema;
        private System.Windows.Forms.ToolStripMenuItem relSaidasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relFornecedoresMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relEntradaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visFornecedoresMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visEstoqueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadProfessoresMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadProdutosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadFornecedoresMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem montarAulasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarAulasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarAulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.PictureBox picAvatarUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ContextMenuStrip ctxUsuario;
        private System.Windows.Forms.ToolStripMenuItem ctxTrocarUsuarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxSairMenuItem;
    }
}
