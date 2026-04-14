using alguamcoisa.Telas;
using alguamcoisa.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace alguamcoisa
{
    public partial class HomeForm : ThemedForm
    {
        private string _avatarInicial = "?";
        private bool _avatarHover = false;

        public HomeForm()
        {
            InitializeComponent();

            ConfigurarAvatarCircular();
            AtualizarUsuarioUI();
        }

        // ============================
        //  UI DO USUÁRIO (NOME + AVATAR)
        // ============================
        private void AtualizarUsuarioUI()
        {
            if (lblUsuario == null || picAvatarUsuario == null)
                return;

            // Texto (Admin: X, Professor: Y, etc.)
            lblUsuario.Text = SessaoUsuario.ObterDescricao();

            // Pega a inicial do nome do usuário logado
            string nome = SessaoUsuario.Nome ?? string.Empty;
            string inicial = "?";

            foreach (char ch in nome.Trim())
            {
                if (!char.IsWhiteSpace(ch))
                {
                    inicial = ch.ToString().ToUpper();
                    break;
                }
            }

            _avatarInicial = inicial;
            picAvatarUsuario.Invalidate();
        }

        private void ConfigurarAvatarCircular()
        {
            if (picAvatarUsuario == null || picAvatarUsuario.Width <= 0 || picAvatarUsuario.Height <= 0)
                return;

            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, picAvatarUsuario.Width - 1, picAvatarUsuario.Height - 1);
                picAvatarUsuario.Region = new Region(path);
            }
        }

        // ============================
        //  INFRA: ABRIR FORM NO PANEL
        // ============================
        private void AbrirFormNoPanel(Form form)
        {
            pnlHome.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlHome.Controls.Add(form);
            form.Show();
        }

        // --------------------------------
        //  MENU MONTAR / EDITAR AULAS
        // --------------------------------
        private void montarAulasMenuItem_Click(object sender, EventArgs e)
        {
            var tela = new MontarAulaForm();
            AbrirFormNoPanel(tela);
        }

        private void editarAulasMenuItem_Click(object sender, EventArgs e)
        {
            var tela = new VisualizarAulasForm();
            AbrirFormNoPanel(tela);
        }

        // --------------------------
        //  VISUALIZAR
        // --------------------------
        private void visEstoqueMenuItem_Click(object sender, EventArgs e)
        {
            var tela = new EstoqueForm();
            AbrirFormNoPanel(tela);
        }

        private void visDepositoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tela de depósito - ainda não implementada.");
            // Exemplo futuro:
            // AbrirFormNoPanel(new DepositoForm());
        }

        private void visFornecedoresMenuItem_Click(object sender, EventArgs e)
        {
            // LISTA + EDITA + EXCLUI fornecedores
            var tela = new FornecedorListForm();
            AbrirFormNoPanel(tela);
        }

        // --------------------------
        //  CADASTRAR
        // --------------------------
        private void cadFornecedoresMenuItem_Click(object sender, EventArgs e)
        {
            // CADASTRO novo de fornecedor
            var tela = new CadastrarFornecedor();
            AbrirFormNoPanel(tela);
        }

        private void cadProdutosMenuItem_Click(object sender, EventArgs e)
        {
            var tela = new CadastroProduto();
            AbrirFormNoPanel(tela);
        }

        private void cadProfessoresMenuItem_Click(object sender, EventArgs e)
        {
            var tela = new CadastrarProfessores();
            AbrirFormNoPanel(tela);
        }

        // ----------------------------------
        //  RELATÓRIOS
        // ----------------------------------
        private void relEntradaMenuItem_Click(object sender, EventArgs e)
        {
            // Relatório de ENTRADAS (Movimentos Tipo = 'E')
            var tela = new EntradaForm();
            AbrirFormNoPanel(tela);
        }

        private void relSaidasMenuItem_Click(object sender, EventArgs e)
        {
            // Relatório de SAÍDAS (Movimentos Tipo = 'S')
            var tela = new SaidaForm();
            AbrirFormNoPanel(tela);
        }

        private void relFornecedoresMenuItem_Click(object sender, EventArgs e)
        {
            // Relatório de movimentação por FORNECEDOR
            var tela = new FornecedorRelatorioForm();
            AbrirFormNoPanel(tela);
        }

        // ----------------------------------
        //  CONFIGURAÇÕES / USUÁRIO
        // ----------------------------------
        private void configuracoesSistema_Click(object sender, EventArgs e)
        {
            var tela = new ConfigForm();
            AbrirFormNoPanel(tela);
        }

        private void trocarUsuario_Click(object sender, EventArgs e)
        {
            // Guarda o usuário atual (para restaurar se cancelar)
            var descricaoAnterior = SessaoUsuario.ObterDescricao();

            // Limpa telas atuais
            pnlHome.Controls.Clear();

            using (var login = new LoginForm())
            {
                var result = login.ShowDialog(this);

                if (result != DialogResult.OK)
                {
                    // Usuário cancelou → mantém usuário anterior
                    lblUsuario.Text = descricaoAnterior;
                    return;
                }

                // Se o LoginForm validou, ele já atualizou SessaoUsuario
            }

            AtualizarUsuarioUI();
        }

        private void pnlHome_Paint(object sender, PaintEventArgs e)
        {
        }

        // ----------------------------------
        //  AVATAR + CONTEXT MENU
        // ----------------------------------
        private void MostrarMenuUsuario(Control origem)
        {
            if (ctxUsuario == null)
                return;

            var pt = origem.PointToScreen(new Point(0, origem.Height + 2));
            ctxUsuario.Show(pt);
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            MostrarMenuUsuario(lblUsuario);
        }

        private void picAvatarUsuario_Click(object sender, EventArgs e)
        {
            MostrarMenuUsuario(picAvatarUsuario);
        }

        private void ctxTrocarUsuarioMenuItem_Click(object sender, EventArgs e)
        {
            trocarUsuario_Click(sender, e);
        }

        private void ctxSairMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            // Se quiser fechar tudo de vez:
            // Application.Exit();
        }

        private void lblUsuario_MouseEnter(object sender, EventArgs e)
        {
            _avatarHover = true;
            lblUsuario.BackColor = Color.FromArgb(70, 70, 75);
            picAvatarUsuario.Invalidate();
        }

        private void lblUsuario_MouseLeave(object sender, EventArgs e)
        {
            _avatarHover = false;
            lblUsuario.BackColor = Color.FromArgb(45, 45, 48);
            picAvatarUsuario.Invalidate();
        }

        private void picAvatarUsuario_MouseEnter(object sender, EventArgs e)
        {
            lblUsuario_MouseEnter(sender, e);
        }

        private void picAvatarUsuario_MouseLeave(object sender, EventArgs e)
        {
            lblUsuario_MouseLeave(sender, e);
        }

        private void picAvatarUsuario_Paint(object sender, PaintEventArgs e)
        {
            if (picAvatarUsuario.Width <= 0 || picAvatarUsuario.Height <= 0)
                return;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, picAvatarUsuario.Width - 1, picAvatarUsuario.Height - 1);

            Color back = _avatarHover
                ? Color.FromArgb(120, 100, 230)  // hover mais claro
                : Color.FromArgb(93, 63, 211);   // roxo premium

            using (var brush = new SolidBrush(back))
            using (var pen = new Pen(Color.FromArgb(20, 20, 20), 1f))
            {
                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
            }

            if (!string.IsNullOrWhiteSpace(_avatarInicial))
            {
                using (var font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point))
                using (var textBrush = new SolidBrush(Color.White))
                using (var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString(_avatarInicial, font, textBrush, rect, sf);
                }
            }
        }

        private void picAvatarUsuario_Resize(object sender, EventArgs e)
        {
            ConfigurarAvatarCircular();
        }
    }
}
