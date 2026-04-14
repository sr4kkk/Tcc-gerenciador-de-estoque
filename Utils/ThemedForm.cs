using System;
using System.Windows.Forms;

namespace alguamcoisa.Utils
{
    /// <summary>
    /// Form base que evita flicker (flash branco) e aplica o AppTheme
    /// antes do primeiro paint.
    /// </summary>
    public class ThemedForm : Form
    {


        private void AplicarEscalaAutomatica(Control root, float scale)
        {
            foreach (Control c in root.Controls)
            {
                // Escala tamanho
                c.Width = (int)(c.Width * scale);
                c.Height = (int)(c.Height * scale);

                // Escala posição
                c.Left = (int)(c.Left * scale);
                c.Top = (int)(c.Top * scale);

                // Escala fonte
                c.Font = new Font(c.Font.FontFamily, c.Font.Size * scale, c.Font.Style);

                // Recursão para filhos
                if (c.HasChildren)
                    AplicarEscalaAutomatica(c, scale);
            }
        }


        public ThemedForm()
        {
            // Otimizações de pintura
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);
            UpdateStyles();

            // Evita flicker em redimensionamento/primeira pintura
            DoubleBuffered = true;

            // Garante cores corretas ANTES de criar os filhos
            BackColor = AppTheme.BackForm;
            ForeColor = AppTheme.Fore;
        }

        // Força composição do Windows (evita “blink” branco em muitos casos)
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                const int WS_EX_COMPOSITED = 0x02000000;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }

        // Aplica o tema assim que o handle existir (antes do primeiro paint)
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AppTheme.Apply(this);
        }
    }
}
