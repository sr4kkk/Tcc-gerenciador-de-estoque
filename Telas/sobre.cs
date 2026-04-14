using alguamcoisa.Utils;
using System;
using System.Windows.Forms;

namespace alguamcoisa
{
    public partial class sobre : alguamcoisa.Utils.ThemedForm
    {
        public sobre()
        {
            InitializeComponent();

            // Como esta tela será usada dentro de painel, removemos bordas.
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Fecha quando estiver dentro de painel
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }
    }
}
