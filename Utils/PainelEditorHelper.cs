using System;
using System.Drawing;
using System.Windows.Forms;

namespace alguamcoisa.Utils
{
    /// <summary>
    /// Helper global para criar e dimensionar painéis de edição
    /// que hospedam forms (TopLevel = false) ao lado de um grid.
    /// </summary>
    public static class PainelEditorHelper
    {
        // Configurações padrão (podem ser usadas em todo o sistema)
        public const float PercentualPadrao = 0.45f; // 45% da área do container
        public const int MinEditorPadrao = 480;      // largura mínima (em 96 DPI)
        public const int MinGridPadrao = 600;        // largura mínima "ideal" para o grid

        /// <summary>
        /// Calcula a largura do painel de edição considerando DPI, largura do container,
        /// limites mínimos para painel/grid e, opcionalmente, a largura base do form.
        /// </summary>
        /// <param name="container">Controle pai (por ex. pnlGrid).</param>
        /// <param name="percentual">Percentual da largura total (padrão 45%).</param>
        /// <param name="minEditor">Largura mínima do editor em 96 DPI.</param>
        /// <param name="minGrid">Largura mínima do grid em 96 DPI.</param>
        /// <param name="larguraFormBase96Dpi">
        ///     Largura base do form em 96 DPI (ex.: ClientSize.Width do form no designer).
        ///     Se informado, o painel nunca será menor que essa largura (ajustada ao DPI).
        /// </param>
        public static int CalcularLarguraPainelEditor(
            Control container,
            float? percentual = null,
            int? minEditor = null,
            int? minGrid = null,
            int? larguraFormBase96Dpi = null)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            // Descobre o form pai para obter o DPI
            Form form = container.FindForm();
            float dpiScale = 1f;

            if (form != null)
            {
                dpiScale = form.DeviceDpi / 96f; // 96 = DPI padrão
            }

            int larguraTotal = container.ClientSize.Width;

            int minEd = (int)((minEditor ?? MinEditorPadrao) * dpiScale);
            int minGr = (int)((minGrid ?? MinGridPadrao) * dpiScale);
            float p = percentual ?? PercentualPadrao;

            // Se informarmos a largura base do form (ClientSize.Width do designer),
            // garantimos que o painel nunca ficará menor do que ele.
            if (larguraFormBase96Dpi.HasValue)
            {
                int larguraFormReal = (int)(larguraFormBase96Dpi.Value * dpiScale);
                if (larguraFormReal > minEd)
                    minEd = larguraFormReal;
            }

            int larguraEditor = (int)(larguraTotal * p);

            // Garante mínimo para o editor
            if (larguraEditor < minEd)
                larguraEditor = minEd;

            // Se há espaço, tenta garantir também um mínimo para o grid
            if (larguraTotal >= (minEd + minGr))
            {
                if (larguraTotal - larguraEditor < minGr)
                {
                    larguraEditor = larguraTotal - minGr;
                }
            }
            else
            {
                // Em telas pequenas, divide mais ou menos meio a meio
                larguraEditor = Math.Max(minEd, larguraTotal / 2);
            }

            // Segurança extra: nunca maior que a área total
            if (larguraEditor > larguraTotal)
                larguraEditor = larguraTotal;

            return larguraEditor;
        }

        /// <summary>
        /// Remove o painel de edição anterior (se existir) e cria um novo,
        /// já com largura calculada de forma responsiva.
        /// </summary>
        public static Panel CriarOuSubstituirPainelEditor(
            Control container,
            ref Panel painelEditor,
            Color backColor,
            DockStyle dock = DockStyle.Right,
            Padding? padding = null,
            float? percentual = null,
            int? minEditor = null,
            int? minGrid = null,
            int? larguraFormBase96Dpi = null)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            // Remove painel anterior, se existir
            if (painelEditor != null)
            {
                if (container.Controls.Contains(painelEditor))
                    container.Controls.Remove(painelEditor);

                painelEditor.Dispose();
                painelEditor = null;
            }

            int larguraEditor = CalcularLarguraPainelEditor(
                container,
                percentual,
                minEditor,
                minGrid,
                larguraFormBase96Dpi);

            painelEditor = new Panel
            {
                Dock = dock,
                Width = larguraEditor,
                BackColor = backColor,
                Padding = padding ?? Padding.Empty
            };

            container.Controls.Add(painelEditor);
            container.Controls.SetChildIndex(painelEditor, 0);

            return painelEditor;
        }
    }
}
