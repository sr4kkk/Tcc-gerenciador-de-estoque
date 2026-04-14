using alguamcoisa.Infra;
using alguamcoisa.Utils;
using System;
using System.Windows.Forms;

namespace alguamcoisa
{
    public partial class ConfigForm : alguamcoisa.Utils.ThemedForm
    {
        private Form _formAtual;

        public ConfigForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Aplica tema assim que o form de configuração abrir
            AppTheme.Apply(this);
        }

        /// <summary>
        /// Abre um form dentro do painel pnlMostrar.
        /// </summary>
        private void AbrirFormNoPainel(Form form)
        {
            if (_formAtual != null)
            {
                try
                {
                    _formAtual.Close();
                    _formAtual.Dispose();
                }
                catch { }
                _formAtual = null;
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlMostrar.Controls.Clear();
            pnlMostrar.Controls.Add(form);

            _formAtual = form;

            // Aplica o tema no formulário filho também
            AppTheme.Apply(form);

            form.Show();
        }

        private void btnAparencia_Click(object sender, EventArgs e)
        {
            var frm = new ThemaForm();
            AbrirFormNoPainel(frm);
        }

        private void BtnConexao_Click(object sender, EventArgs e)
        {
            AbrirFormNoPainel(new ConexaoBancoForm());
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            AbrirFormNoPainel(new sobre());
        }
    }
}
