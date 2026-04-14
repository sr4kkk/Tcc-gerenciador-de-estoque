namespace alguamcoisa
{
    partial class CadastrarProfessores
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
        /// Método necessário para suporte ao Designer – não modificar
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNomeProfessor = new System.Windows.Forms.TextBox();
            this.lblNomeProfessor = new System.Windows.Forms.Label();
            this.txtMatriculaProfessor = new System.Windows.Forms.TextBox();
            this.lblMatriculaProfessor = new System.Windows.Forms.Label();
            this.txtCpfProfessor = new System.Windows.Forms.TextBox();
            this.txtSenhaProfessor = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblSenhaProfessor = new System.Windows.Forms.Label();
            this.txtEmailProfessor = new System.Windows.Forms.TextBox();
            this.lblEmailProfessor = new System.Windows.Forms.Label();
            this.txtTelefoneProfessor = new System.Windows.Forms.TextBox();
            this.lblTelefoneProfessor = new System.Windows.Forms.Label();
            this.txtDepartamentoProfessor = new System.Windows.Forms.TextBox();
            this.lblDepartamentoProfessor = new System.Windows.Forms.Label();
            this.txtObservacaoProfessor = new System.Windows.Forms.TextBox();
            this.lblObservacaoProfessor = new System.Windows.Forms.Label();
            this.groupBoxDadosProfessor = new System.Windows.Forms.GroupBox();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.btnCancelarProfessor = new System.Windows.Forms.Button();
            this.btnExcluirProfessor = new System.Windows.Forms.Button();
            this.btnSalvarProfessor = new System.Windows.Forms.Button();
            this.btnEditarProfessorSelecionado = new System.Windows.Forms.Button();
            this.btnNovoProfessor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProfessores = new System.Windows.Forms.DataGridView();
            this.btnMostrarSenhaProfessor = new System.Windows.Forms.Button();
            this.groupBoxDadosProfessor.SuspendLayout();
            this.panelBotoes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfessores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeProfessor
            // 
            this.txtNomeProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeProfessor.Location = new System.Drawing.Point(10, 42);
            this.txtNomeProfessor.Name = "txtNomeProfessor";
            this.txtNomeProfessor.Size = new System.Drawing.Size(441, 23);
            this.txtNomeProfessor.TabIndex = 1;
            // 
            // lblNomeProfessor
            // 
            this.lblNomeProfessor.AutoSize = true;
            this.lblNomeProfessor.Location = new System.Drawing.Point(10, 24);
            this.lblNomeProfessor.Name = "lblNomeProfessor";
            this.lblNomeProfessor.Size = new System.Drawing.Size(43, 15);
            this.lblNomeProfessor.TabIndex = 0;
            this.lblNomeProfessor.Text = "Nome:";
            // 
            // txtMatriculaProfessor
            // 
            this.txtMatriculaProfessor.Location = new System.Drawing.Point(9, 87);
            this.txtMatriculaProfessor.Name = "txtMatriculaProfessor";
            this.txtMatriculaProfessor.Size = new System.Drawing.Size(160, 23);
            this.txtMatriculaProfessor.TabIndex = 2;
            // 
            // lblMatriculaProfessor
            // 
            this.lblMatriculaProfessor.AutoSize = true;
            this.lblMatriculaProfessor.Location = new System.Drawing.Point(10, 69);
            this.lblMatriculaProfessor.Name = "lblMatriculaProfessor";
            this.lblMatriculaProfessor.Size = new System.Drawing.Size(60, 15);
            this.lblMatriculaProfessor.TabIndex = 2;
            this.lblMatriculaProfessor.Text = "Matrícula:";
            // 
            // txtCpfProfessor
            // 
            this.txtCpfProfessor.Location = new System.Drawing.Point(201, 87);
            this.txtCpfProfessor.Name = "txtCpfProfessor";
            this.txtCpfProfessor.Size = new System.Drawing.Size(160, 23);
            this.txtCpfProfessor.TabIndex = 3;
            this.txtCpfProfessor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpfProfessor_KeyPress);
            this.txtCpfProfessor.TextChanged += new System.EventHandler(this.txtCpfProfessor_TextChanged);
            this.txtCpfProfessor.Leave += new System.EventHandler(this.txtCpfProfessor_Leave);
            // 
            // txtSenhaProfessor
            // 
            this.txtSenhaProfessor.Location = new System.Drawing.Point(409, 87);
            this.txtSenhaProfessor.Name = "txtSenhaProfessor";
            this.txtSenhaProfessor.Size = new System.Drawing.Size(160, 23);
            this.txtSenhaProfessor.TabIndex = 4;
            this.txtSenhaProfessor.UseSystemPasswordChar = true;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(201, 69);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(29, 15);
            this.lblCpf.TabIndex = 4;
            this.lblCpf.Text = "Cpf:";
            // 
            // lblSenhaProfessor
            // 
            this.lblSenhaProfessor.AutoSize = true;
            this.lblSenhaProfessor.Location = new System.Drawing.Point(409, 68);
            this.lblSenhaProfessor.Name = "lblSenhaProfessor";
            this.lblSenhaProfessor.Size = new System.Drawing.Size(42, 15);
            this.lblSenhaProfessor.TabIndex = 4;
            this.lblSenhaProfessor.Text = "Senha:";
            // 
            // txtEmailProfessor
            // 
            this.txtEmailProfessor.Location = new System.Drawing.Point(9, 158);
            this.txtEmailProfessor.Name = "txtEmailProfessor";
            this.txtEmailProfessor.Size = new System.Drawing.Size(250, 23);
            this.txtEmailProfessor.TabIndex = 5;
            this.txtEmailProfessor.Leave += new System.EventHandler(this.txtEmailProfessor_Leave);
            // 
            // lblEmailProfessor
            // 
            this.lblEmailProfessor.AutoSize = true;
            this.lblEmailProfessor.Location = new System.Drawing.Point(9, 140);
            this.lblEmailProfessor.Name = "lblEmailProfessor";
            this.lblEmailProfessor.Size = new System.Drawing.Size(44, 15);
            this.lblEmailProfessor.TabIndex = 6;
            this.lblEmailProfessor.Text = "E-mail:";
            // 
            // txtTelefoneProfessor
            // 
            this.txtTelefoneProfessor.Location = new System.Drawing.Point(269, 158);
            this.txtTelefoneProfessor.Name = "txtTelefoneProfessor";
            this.txtTelefoneProfessor.Size = new System.Drawing.Size(160, 23);
            this.txtTelefoneProfessor.TabIndex = 6;
            this.txtTelefoneProfessor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefoneProfessor_KeyPress);
            this.txtTelefoneProfessor.TextChanged += new System.EventHandler(this.txtTelefoneProfessor_TextChanged);
            // 
            // lblTelefoneProfessor
            // 
            this.lblTelefoneProfessor.AutoSize = true;
            this.lblTelefoneProfessor.Location = new System.Drawing.Point(269, 140);
            this.lblTelefoneProfessor.Name = "lblTelefoneProfessor";
            this.lblTelefoneProfessor.Size = new System.Drawing.Size(55, 15);
            this.lblTelefoneProfessor.TabIndex = 8;
            this.lblTelefoneProfessor.Text = "Telefone:";
            // 
            // txtDepartamentoProfessor
            // 
            this.txtDepartamentoProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDepartamentoProfessor.Location = new System.Drawing.Point(439, 158);
            this.txtDepartamentoProfessor.Name = "txtDepartamentoProfessor";
            this.txtDepartamentoProfessor.Size = new System.Drawing.Size(745, 23);
            this.txtDepartamentoProfessor.TabIndex = 7;
            // 
            // lblDepartamentoProfessor
            // 
            this.lblDepartamentoProfessor.AutoSize = true;
            this.lblDepartamentoProfessor.Location = new System.Drawing.Point(439, 140);
            this.lblDepartamentoProfessor.Name = "lblDepartamentoProfessor";
            this.lblDepartamentoProfessor.Size = new System.Drawing.Size(86, 15);
            this.lblDepartamentoProfessor.TabIndex = 10;
            this.lblDepartamentoProfessor.Text = "Departamento:";
            // 
            // txtObservacaoProfessor
            // 
            this.txtObservacaoProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacaoProfessor.Location = new System.Drawing.Point(9, 206);
            this.txtObservacaoProfessor.Multiline = true;
            this.txtObservacaoProfessor.Name = "txtObservacaoProfessor";
            this.txtObservacaoProfessor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacaoProfessor.Size = new System.Drawing.Size(1188, 40);
            this.txtObservacaoProfessor.TabIndex = 8;
            // 
            // lblObservacaoProfessor
            // 
            this.lblObservacaoProfessor.AutoSize = true;
            this.lblObservacaoProfessor.Location = new System.Drawing.Point(9, 188);
            this.lblObservacaoProfessor.Name = "lblObservacaoProfessor";
            this.lblObservacaoProfessor.Size = new System.Drawing.Size(72, 15);
            this.lblObservacaoProfessor.TabIndex = 12;
            this.lblObservacaoProfessor.Text = "Observação:";
            // 
            // groupBoxDadosProfessor
            // 
            this.groupBoxDadosProfessor.Controls.Add(this.btnMostrarSenhaProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblObservacaoProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.panelBotoes);
            this.groupBoxDadosProfessor.Controls.Add(this.txtObservacaoProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblDepartamentoProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.txtDepartamentoProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblTelefoneProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.txtTelefoneProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblEmailProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.txtEmailProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblSenhaProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblCpf);
            this.groupBoxDadosProfessor.Controls.Add(this.txtSenhaProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.txtCpfProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblMatriculaProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.txtMatriculaProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.lblNomeProfessor);
            this.groupBoxDadosProfessor.Controls.Add(this.txtNomeProfessor);
            this.groupBoxDadosProfessor.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDadosProfessor.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDadosProfessor.Name = "groupBoxDadosProfessor";
            this.groupBoxDadosProfessor.Size = new System.Drawing.Size(1208, 273);
            this.groupBoxDadosProfessor.TabIndex = 0;
            this.groupBoxDadosProfessor.TabStop = false;
            this.groupBoxDadosProfessor.Text = "Dados do Professor";
            // 
            // panelBotoes
            // 
            this.panelBotoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBotoes.Controls.Add(this.btnCancelarProfessor);
            this.panelBotoes.Controls.Add(this.btnExcluirProfessor);
            this.panelBotoes.Controls.Add(this.btnSalvarProfessor);
            this.panelBotoes.Controls.Add(this.btnEditarProfessorSelecionado);
            this.panelBotoes.Controls.Add(this.btnNovoProfessor);
            this.panelBotoes.Location = new System.Drawing.Point(596, 20);
            this.panelBotoes.Name = "panelBotoes";
            this.panelBotoes.Size = new System.Drawing.Size(606, 64);
            this.panelBotoes.TabIndex = 2;
            // 
            // btnCancelarProfessor
            // 
            this.btnCancelarProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarProfessor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarProfessor.Location = new System.Drawing.Point(480, 3);
            this.btnCancelarProfessor.Name = "btnCancelarProfessor";
            this.btnCancelarProfessor.Size = new System.Drawing.Size(90, 40);
            this.btnCancelarProfessor.TabIndex = 12;
            this.btnCancelarProfessor.Text = "Cancelar";
            this.btnCancelarProfessor.UseVisualStyleBackColor = true;
            this.btnCancelarProfessor.Click += new System.EventHandler(this.btnCancelarProfessor_Click);
            // 
            // btnExcluirProfessor
            // 
            this.btnExcluirProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirProfessor.Location = new System.Drawing.Point(195, 2);
            this.btnExcluirProfessor.Name = "btnExcluirProfessor";
            this.btnExcluirProfessor.Size = new System.Drawing.Size(90, 41);
            this.btnExcluirProfessor.TabIndex = 11;
            this.btnExcluirProfessor.Text = "Excluir";
            this.btnExcluirProfessor.UseVisualStyleBackColor = true;
            this.btnExcluirProfessor.Click += new System.EventHandler(this.btnExcluirProfessor_Click);
            // 
            // btnSalvarProfessor
            // 
            this.btnSalvarProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarProfessor.Location = new System.Drawing.Point(384, 3);
            this.btnSalvarProfessor.Name = "btnSalvarProfessor";
            this.btnSalvarProfessor.Size = new System.Drawing.Size(90, 40);
            this.btnSalvarProfessor.TabIndex = 10;
            this.btnSalvarProfessor.Tag = "";
            this.btnSalvarProfessor.Text = "Salvar";
            this.btnSalvarProfessor.UseVisualStyleBackColor = true;
            this.btnSalvarProfessor.Click += new System.EventHandler(this.btnSalvarProfessor_Click);
            // 
            // btnEditarProfessorSelecionado
            // 
            this.btnEditarProfessorSelecionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarProfessorSelecionado.Location = new System.Drawing.Point(3, 2);
            this.btnEditarProfessorSelecionado.Name = "btnEditarProfessorSelecionado";
            this.btnEditarProfessorSelecionado.Size = new System.Drawing.Size(90, 41);
            this.btnEditarProfessorSelecionado.TabIndex = 9;
            this.btnEditarProfessorSelecionado.Tag = "";
            this.btnEditarProfessorSelecionado.Text = "Editar";
            this.btnEditarProfessorSelecionado.UseVisualStyleBackColor = true;
            this.btnEditarProfessorSelecionado.Click += new System.EventHandler(this.btnEditarProfessorSelecionado_Click);
            // 
            // btnNovoProfessor
            // 
            this.btnNovoProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoProfessor.Location = new System.Drawing.Point(99, 3);
            this.btnNovoProfessor.Name = "btnNovoProfessor";
            this.btnNovoProfessor.Size = new System.Drawing.Size(90, 40);
            this.btnNovoProfessor.TabIndex = 8;
            this.btnNovoProfessor.Tag = "";
            this.btnNovoProfessor.Text = "Novo";
            this.btnNovoProfessor.UseVisualStyleBackColor = true;
            this.btnNovoProfessor.Click += new System.EventHandler(this.btnNovoProfessor_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1208, 381);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProfessores);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1208, 381);
            this.panel2.TabIndex = 0;
            // 
            // dgvProfessores
            // 
            this.dgvProfessores.AllowUserToAddRows = false;
            this.dgvProfessores.AllowUserToDeleteRows = false;
            this.dgvProfessores.AllowUserToResizeRows = false;
            this.dgvProfessores.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfessores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProfessores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProfessores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProfessores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProfessores.Location = new System.Drawing.Point(0, 0);
            this.dgvProfessores.MultiSelect = false;
            this.dgvProfessores.Name = "dgvProfessores";
            this.dgvProfessores.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfessores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProfessores.RowHeadersVisible = false;
            this.dgvProfessores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfessores.Size = new System.Drawing.Size(1208, 381);
            this.dgvProfessores.TabIndex = 9;
            this.dgvProfessores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProfessores_CellDoubleClick);
            this.dgvProfessores.SelectionChanged += new System.EventHandler(this.dgvProfessores_SelectionChanged);
            // 
            // btnMostrarSenhaProfessor
            // 
            this.btnMostrarSenhaProfessor.Location = new System.Drawing.Point(575, 87);
            this.btnMostrarSenhaProfessor.Name = "btnMostrarSenhaProfessor";
            this.btnMostrarSenhaProfessor.Size = new System.Drawing.Size(70, 23);
            this.btnMostrarSenhaProfessor.TabIndex = 5;
            this.btnMostrarSenhaProfessor.Text = "Mostrar";
            this.btnMostrarSenhaProfessor.UseVisualStyleBackColor = true;
            this.btnMostrarSenhaProfessor.Click += new System.EventHandler(this.btnMostrarSenhaProfessor_Click);
            // 
            // CadastrarProfessores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancelarProfessor;
            this.ClientSize = new System.Drawing.Size(1208, 654);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxDadosProfessor);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CadastrarProfessores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cadastro de Professores";
            this.Load += new System.EventHandler(this.CadastrarProfessores_Load);
            this.groupBoxDadosProfessor.ResumeLayout(false);
            this.groupBoxDadosProfessor.PerformLayout();
            this.panelBotoes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfessores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNomeProfessor;
        private System.Windows.Forms.Label lblNomeProfessor;
        private System.Windows.Forms.TextBox txtMatriculaProfessor;
        private System.Windows.Forms.Label lblMatriculaProfessor;
        private System.Windows.Forms.TextBox txtCpfProfessor;
        private System.Windows.Forms.TextBox txtSenhaProfessor;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblSenhaProfessor;
        private System.Windows.Forms.TextBox txtEmailProfessor;
        private System.Windows.Forms.Label lblEmailProfessor;
        private System.Windows.Forms.TextBox txtTelefoneProfessor;
        private System.Windows.Forms.Label lblTelefoneProfessor;
        private System.Windows.Forms.TextBox txtDepartamentoProfessor;
        private System.Windows.Forms.Label lblDepartamentoProfessor;
        private System.Windows.Forms.TextBox txtObservacaoProfessor;
        private System.Windows.Forms.Label lblObservacaoProfessor;
        private System.Windows.Forms.GroupBox groupBoxDadosProfessor;
        private System.Windows.Forms.Panel panelBotoes;
        private System.Windows.Forms.Button btnCancelarProfessor;
        private System.Windows.Forms.Button btnExcluirProfessor;
        private System.Windows.Forms.Button btnSalvarProfessor;
        private System.Windows.Forms.Button btnNovoProfessor;
        private System.Windows.Forms.Panel pnlFundo;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvProfessores;
        private System.Windows.Forms.Button btnEditarProfessorSelecionado;
        private System.Windows.Forms.Button btnMostrarSenhaProfessor;
    }
}
