using System;
using System.Drawing;
using System.Windows.Forms;

namespace alguamcoisa.Utils
{
    /// <summary>
    /// Helper para padronizar pequenas configurações de Form.
    /// IMPORTANTE: neste momento NÃO fazemos escala automática por DPI,
    /// para evitar "explodir" o layout em altas escalas (ex.: 200%, 225%).
    /// </summary>
    public static class FormHelper
    {
        /// <summary>
        /// Configuração padrão para qualquer Form do sistema.
        /// Deve ser chamada no construtor do form:
        /// FormHelper.ConfigurarFormPadrao(this);
        /// 
        /// O parâmetro aplicarDpi está desativado por padrão para não
        /// causar dupla escala em conjunto com o Windows.
        /// </summary>
        public static void ConfigurarFormPadrao(Form form, bool aplicarDpi = false)
        {
            if (form == null) throw new ArgumentNullException(nameof(form));

            // NÃO mexer em AutoScaleMode aqui.
            // Cada form usa o que foi definido no designer (Font ou Dpi).

            // Ajuste de posicionamento padrão para forms independentes
            if (form.TopLevel &&
                (form.StartPosition == FormStartPosition.WindowsDefaultLocation ||
                 form.StartPosition == FormStartPosition.WindowsDefaultBounds))
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }

            // Se um dia quisermos aplicar escala manual,
            // fazemos isso passando aplicarDpi = true explicitamente.
            if (aplicarDpi)
            {
                AplicarEscalaDpi(form);
            }
        }

        /// <summary>
        /// Mantemos este método para uso FUTURO e controlado.
        /// No uso atual do sistema, ele NÃO é chamado.
        /// </summary>
        public static void AplicarEscalaDpi(Form form)
        {
            if (form == null) throw new ArgumentNullException(nameof(form));

            float scaleFactor = form.DeviceDpi / 96f;
            if (Math.Abs(scaleFactor - 1f) < 0.01f)
                return; // DPI padrão, não precisa escalar

            // Evita escalar o mesmo form duas vezes
            if (form.Tag is string tag && tag.Contains("DpiScaled"))
                return;

            form.Tag = (form.Tag?.ToString() + "|DpiScaled") ?? "DpiScaled";

            ScaleControlTree(form, scaleFactor);
        }

        private static void ScaleControlTree(Control root, float scale)
        {
            foreach (Control c in root.Controls)
            {
                // Escala posição e tamanho
                var bounds = c.Bounds;
                c.SetBounds(
                    (int)Math.Round(bounds.X * scale),
                    (int)Math.Round(bounds.Y * scale),
                    (int)Math.Round(bounds.Width * scale),
                    (int)Math.Round(bounds.Height * scale));

                // Escala fonte
                if (c.Font != null)
                {
                    c.Font = new Font(
                        c.Font.FontFamily,
                        c.Font.Size * scale,
                        c.Font.Style,
                        c.Font.Unit,
                        c.Font.GdiCharSet,
                        c.Font.GdiVerticalFont);
                }

                // Escala padding
                if (c.Padding != Padding.Empty)
                {
                    c.Padding = new Padding(
                        (int)Math.Round(c.Padding.Left * scale),
                        (int)Math.Round(c.Padding.Top * scale),
                        (int)Math.Round(c.Padding.Right * scale),
                        (int)Math.Round(c.Padding.Bottom * scale));
                }

                // Escala margin
                if (c.Margin != Padding.Empty)
                {
                    c.Margin = new Padding(
                        (int)Math.Round(c.Margin.Left * scale),
                        (int)Math.Round(c.Margin.Top * scale),
                        (int)Math.Round(c.Margin.Right * scale),
                        (int)Math.Round(c.Margin.Bottom * scale));
                }

                if (c.HasChildren)
                    ScaleControlTree(c, scale);
            }
        }
    }
}
