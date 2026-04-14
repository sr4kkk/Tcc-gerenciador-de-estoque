using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EstoqueQuimico.Models; // Produto/Movimento

namespace alguamcoisa
{
    public static class PrintUtils
    {
        // ================== Núcleo de sessão/renderização ==================
        private class Session
        {
            public List<string> Headers = new List<string>();     // títulos das colunas
            public List<Func<int, string>> ValueAt = new List<Func<int, string>>(); // pega texto [rowIndex] para cada coluna
            public List<DataGridViewContentAlignment> Align = new List<DataGridViewContentAlignment>();

            public int RowCount;

            public int[] ColWidths = Array.Empty<int>();
            public int TitleHeight;
            public int HeaderHeight;
            public int RowHeight;
            // dentro de Session
            public int TotalRows;             // total original (para o "Total de itens")
            public bool PendingTotal = true;  // controla a impressão do total na última página

            public string Titulo = "";
            public bool Landscape = false;
            public Margins Margins = new Margins(50, 50, 60, 60);

            public Font TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            public Font HeaderFont = new Font("Segoe UI", 9, FontStyle.Bold);
            public Font CellFont = new Font("Segoe UI", 9, FontStyle.Regular);

            public int PageNumber = 1;

            // cache para medição
            public Dictionary<int, int> Measured = new Dictionary<int, int>();
        }

        private const int CellHPad = 6;
        private const float MinFontPt = 7f;

        // ================== APIs públicas ==================

        /// <summary>
        /// Imprime exatamente o que está VISÍVEL no DataGridView (respeita filtros/ocultações).
        /// Use no Form4/5/6 quando quiser “o que estou vendo na tela”.
        /// </summary>
        public static void ImprimirGrid(DataGridView grid, string titulo, bool landscape = false, Margins margins = null)
        {
            if (grid == null) return;

            try { grid.EndEdit(); grid.CommitEdit(DataGridViewDataErrorContexts.Commit); } catch { }

            // Captura colunas VISÍVEIS na ordem de exibição
            var cols = grid.Columns.Cast<DataGridViewColumn>()
                                   .Where(c => c.Visible)
                                   .OrderBy(c => c.DisplayIndex)
                                   .ToList();

            // Captura somente as linhas VISÍVEIS (sem “nova linha”)
            var rows = grid.Rows.Cast<DataGridViewRow>()
                                .Where(r => r.Visible && !r.IsNewRow)
                                .ToList();

            var sess = new Session
            {
                Titulo = titulo ?? "",
                Landscape = landscape,
                Margins = margins ?? new Margins(50, 50, 60, 60),
                RowCount = rows.Count
            };

            foreach (var c in cols)
            {
                sess.Headers.Add(c.HeaderText);
                sess.Align.Add(GuessAlign(c.HeaderText, c.DefaultCellStyle.Alignment));
                int colIndex = c.Index;
                sess.ValueAt.Add((ri) =>
                {
                    if (ri < 0 || ri >= rows.Count) return "";
                    var cell = rows[ri].Cells[colIndex];
                    return Convert.ToString(cell?.FormattedValue) ?? "";
                });
            }

            PrintWithSession(sess);
        }

        /// <summary>
        /// Imprime um levantamento direto de uma lista de produtos (sem grid).
        /// Espera propriedades: Nome, Categoria, Quantidade (decimal), Unidade, LocalDeposito, Validade (DateTime?).
        /// </summary>
        public static void ImprimirProdutos(
            IEnumerable<Produto> produtos,
            string titulo,
            bool landscape = false,
            Margins margins = null,
            bool includeNovaQuantidade = false)   // ⬅️ novo parâmetro opcional
        {
            var list = (produtos ?? Enumerable.Empty<Produto>()).ToList();
            var sess = new Session
            {
                Titulo = titulo ?? "Levantamento de Estoque",
                Landscape = landscape,
                Margins = margins ?? new Margins(50, 50, 60, 60),
                RowCount = list.Count
            };

            // colunas padrão
            sess.Headers.AddRange(new[] { "Categoria", "Produto", "Qtd", "Un", "Local", "Validade" });
            sess.Align.AddRange(new[]
            {
                DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter,
                DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleCenter
            });

            sess.ValueAt.Add(i => Safe(list, i)?.Categoria ?? "");
            sess.ValueAt.Add(i => Safe(list, i)?.Nome ?? "");
            sess.ValueAt.Add(i => (Safe(list, i)?.Quantidade ?? 0m).ToString("N2"));
            sess.ValueAt.Add(i => Safe(list, i)?.Unidade ?? "");               // mantém "un" se vier assim no dado
            sess.ValueAt.Add(i => Safe(list, i)?.LocalDeposito ?? "");
            sess.ValueAt.Add(i =>
            {
                var v = Safe(list, i)?.Validade;
                return v is DateTime dt ? dt.ToString("dd/MM/yyyy") : "";
            });

            // ➕ coluna opcional para anotar à caneta
            if (includeNovaQuantidade)
            {
                sess.Headers.Add("Nova Quantidade");
                sess.Align.Add(DataGridViewContentAlignment.MiddleCenter);
                sess.ValueAt.Add(_ => ""); // vazio para escrever manualmente
            }

            PrintWithSession(sess);
        }


        /// <summary>
        /// Imprime um relatório direto de uma lista de movimentos (Entradas ou Saídas).
        /// Usa: Data, ProdutoNome, Categoria, Quantidade, Unidade, Local, Observacao.
        /// </summary>
        public static void ImprimirMovimentos(IEnumerable<Movimento> movimentos, string titulo, bool landscape = false, Margins margins = null)
        {
            var list = (movimentos ?? Enumerable.Empty<Movimento>()).ToList();
            var sess = new Session
            {
                Titulo = titulo ?? "Relatório de Movimentos",
                Landscape = landscape,
                Margins = margins ?? new Margins(50, 50, 60, 60),
                RowCount = list.Count
            };

            sess.Headers.AddRange(new[] { "Data", "Produto", "Categoria", "Qtd", "Un", "Local", "Observação" });
            sess.Align.AddRange(new[]
            {
                DataGridViewContentAlignment.MiddleCenter,
                DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter,
                DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleLeft
            });

            sess.ValueAt.Add(i => Safe(list, i).Data.ToString("dd/MM/yyyy HH:mm"));
            sess.ValueAt.Add(i => Safe(list, i).ProdutoNome ?? "");
            sess.ValueAt.Add(i => Safe(list, i).Categoria ?? "");
            sess.ValueAt.Add(i => Safe(list, i).Quantidade.ToString("N2"));
            sess.ValueAt.Add(i => Safe(list, i).Unidade ?? "");
            // aqui usa a propriedade REAL do Movimento: Local
            sess.ValueAt.Add(i => Safe(list, i).Local ?? "");
            sess.ValueAt.Add(i => Safe(list, i).Observacao ?? "");

            PrintWithSession(sess);
        }

        // ================== Núcleo de impressão (comum às APIs) ==================

        private static void PrintWithSession(Session sess)
        {
            var doc = new PrintDocument
            {
                DefaultPageSettings =
        {
            Landscape = sess.Landscape,
            Margins = sess.Margins
        }
            };

            doc.BeginPrint += (_, __) => PrepareLayout(sess);
            doc.PrintPage += (_, e) => DrawPage(e, sess);

            // Descobre o form "dono" apenas para o preview (não abre mais PrintDialog aqui)
            Form owner = null;
            try
            {
                owner = Form.ActiveForm;
                if (owner == null && Application.OpenForms.Count > 0)
                    owner = Application.OpenForms[0];
            }
            catch
            {
                // se der erro, segue sem owner
            }

            using (var prev = new PrintPreviewDialog
            {
                Document = doc,
                Width = 1200,
                Height = 800,
                StartPosition = FormStartPosition.CenterScreen
            })
            {
                if (owner != null)
                    prev.ShowDialog(owner);
                else
                    prev.ShowDialog();
            }

            // IMPORTANTE:
            // - Para realmente imprimir: clicar no ícone de impressora
            //   na barra da janela "Visualizar impressão".
            // - Aí o Windows abre a tela de escolher impressora / PDF.
        }




        private static void PrepareLayout(Session s)
        {
            s.PageNumber = 1;
            s.Measured.Clear();
            s.ColWidths = Array.Empty<int>();
            // alturas serão medidas no Graphics real (DrawPage)
            s.TitleHeight = 0;
            s.HeaderHeight = 0;
            s.RowHeight = 0;
        }

        private static Rectangle ToPixels(Graphics g, Rectangle displayRect) // centésimos de polegada → px
        {
            float x = displayRect.X * g.DpiX / 100f;
            float y = displayRect.Y * g.DpiY / 100f;
            float w = displayRect.Width * g.DpiX / 100f;
            float h = displayRect.Height * g.DpiY / 100f;
            return Rectangle.Round(new RectangleF(x, y, w, h));
        }

        private static void EnsureHeights(Graphics g, Session s)
        {
            if (s.RowHeight != 0) return;
            s.TitleHeight = (int)Math.Ceiling(s.TitleFont.GetHeight(g)) + 10;
            s.HeaderHeight = (int)Math.Ceiling(s.HeaderFont.GetHeight(g)) + 12;
            s.RowHeight = (int)Math.Ceiling(s.CellFont.GetHeight(g)) + 10;
        }

        private static StringFormat MakeFmt(DataGridViewContentAlignment align)
        {
            var fmt = new StringFormat
            {
                Trimming = StringTrimming.None,
                FormatFlags = StringFormatFlags.NoWrap,
                LineAlignment = StringAlignment.Center
            };
            fmt.Alignment = align switch
            {
                DataGridViewContentAlignment.MiddleRight or DataGridViewContentAlignment.TopRight or DataGridViewContentAlignment.BottomRight
                    => StringAlignment.Far,
                DataGridViewContentAlignment.MiddleCenter or DataGridViewContentAlignment.TopCenter or DataGridViewContentAlignment.BottomCenter
                    => StringAlignment.Center,
                _ => StringAlignment.Near
            };
            return fmt;
        }

        private static SizeF Measure(Graphics g, string text, Font font, StringFormat fmt)
        {
            if (string.IsNullOrEmpty(text)) return SizeF.Empty;
            return g.MeasureString(text, font, int.MaxValue, fmt);
        }

        private static void MeasureColumns(Graphics g, Session s)
        {
            if (s.Measured.Count > 0) return;

            for (int c = 0; c < s.Headers.Count; c++)
            {
                int max = (int)Math.Ceiling(Measure(g, s.Headers[c], s.HeaderFont, MakeFmt(s.Align[c])).Width) + CellHPad * 2;
                // mede linhas
                for (int r = 0; r < s.RowCount; r++)
                {
                    string txt = s.ValueAt[c](r) ?? "";
                    max = Math.Max(max, (int)Math.Ceiling(Measure(g, txt, s.CellFont, MakeFmt(s.Align[c])).Width) + CellHPad * 2);
                }
                s.Measured[c] = max;
            }
        }

        private static void EnsureColumnWidths(Graphics g, Session s, int availableWidth)
        {
            MeasureColumns(g, s);

            int[] ideal = Enumerable.Range(0, s.Headers.Count).Select(i => s.Measured[i]).ToArray();
            int sumIdeal = ideal.Sum();

            if (sumIdeal <= availableWidth)
            {
                s.ColWidths = ideal;
                s.ColWidths[^1] += availableWidth - sumIdeal;
                return;
            }

            // Escala proporcional quando não cabe tudo
            double scale = (double)availableWidth / sumIdeal;
            int[] scaled = new int[ideal.Length];
            int sum = 0;
            for (int i = 0; i < ideal.Length; i++)
            {
                scaled[i] = Math.Max(30, (int)Math.Floor(ideal[i] * scale));
                sum += scaled[i];
            }
            int diff = availableWidth - sum;
            if (diff != 0) scaled[^1] += diff;

            s.ColWidths = scaled;
        }

        private static Rectangle ContentRect(Rectangle rect)
        {
            rect.Inflate(-CellHPad, 0);
            return rect;
        }

        private static void DrawShrink(Graphics g, string text, Font baseFont, Brush brush, Rectangle rect, StringFormat fmt)
        {
            if (string.IsNullOrEmpty(text))
            {
                // nada
                return;
            }
            var sz = Measure(g, text, baseFont, fmt);
            if (sz.Width <= rect.Width)
            {
                g.DrawString(text, baseFont, brush, rect, fmt);
                return;
            }
            // busca binária no range [MinFontPt, baseFont.Size]
            float low = MinFontPt, high = baseFont.Size;
            for (int i = 0; i < 8; i++)
            {
                float mid = Math.Max(MinFontPt, (low + high) / 2f);
                using var tmp = new Font(baseFont.FontFamily, mid, baseFont.Style, GraphicsUnit.Point);
                var m = Measure(g, text, tmp, fmt);
                if (m.Width <= rect.Width) low = mid; else high = mid;
            }
            using var final = new Font(baseFont.FontFamily, Math.Max(MinFontPt, low), baseFont.Style, GraphicsUnit.Point);
            g.DrawString(text, final, brush, rect, fmt);
        }

        private static void DrawPage(PrintPageEventArgs e, Session s)
        {
            var g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;

            // converte margens para pixels
            Rectangle area = ToPixels(g, e.MarginBounds);

            // respiro interno
            int pad = 6;
            area = new Rectangle(area.Left + pad, area.Top + pad,
                                 Math.Max(10, area.Width - pad * 2),
                                 Math.Max(10, area.Height - pad * 2));

            EnsureHeights(g, s);
            EnsureColumnWidths(g, s, area.Width);

            int xLeft = area.Left;
            int xRight = area.Right;
            int y = area.Top;

            // Título
            if (!string.IsNullOrWhiteSpace(s.Titulo))
            {
                var titleRect = new Rectangle(xLeft, y, xRight - xLeft, s.TitleHeight);
                using var fmtTitle = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near, Trimming = StringTrimming.None, FormatFlags = StringFormatFlags.NoWrap };
                using var br = new SolidBrush(Color.Black);
                g.DrawString(s.Titulo, s.TitleFont, br, titleRect, fmtTitle);
                y += s.TitleHeight + 2;
            }

            // Cabeçalho
            int x = xLeft;
            using (var back = new SolidBrush(Color.FromArgb(234, 234, 234)))
            using (var fore = new SolidBrush(Color.Black))
            using (var pen = new Pen(Color.Gainsboro))
            {
                var hdrAll = new Rectangle(xLeft, y, xRight - xLeft, s.HeaderHeight);
                g.FillRectangle(back, hdrAll);

                for (int i = 0; i < s.Headers.Count; i++)
                {
                    int w = s.ColWidths[i];
                    var rect = new Rectangle(x, y, w, s.HeaderHeight);
                    var content = ContentRect(rect);
                    using var fmt = MakeFmt(s.Align[i]);
                    DrawShrink(g, s.Headers[i], s.HeaderFont, fore, content, fmt);
                    g.DrawRectangle(pen, rect);
                    x += w;
                }
            }
            y += s.HeaderHeight + 4;

            // Linhas
            bool zebra = true;
            int zebraToggle = 0;

            using var penCell = new Pen(Color.Gainsboro);
            using var foreCell = new SolidBrush(Color.Black);
            using var backZebra = new SolidBrush(Color.FromArgb(248, 248, 248));

            for (int r = 0; r < s.RowCount; r++)
            {
                if (y + s.RowHeight > area.Bottom)
                {
                    DrawFooter(g, area, s);
                    e.HasMorePages = true;
                    s.PageNumber++;
                    // avança “cursor” virtual das linhas
                    // estratégia simples: reduz RowCount e remove linhas já desenhadas
                    TrimSessionRows(s, r);
                    return;
                }

                int xi = xLeft;
                if (zebra && (zebraToggle % 2 == 1))
                    g.FillRectangle(backZebra, new Rectangle(xLeft, y, xRight - xLeft, s.RowHeight));

                for (int c = 0; c < s.Headers.Count; c++)
                {
                    int w = s.ColWidths[c];
                    var rect = new Rectangle(xi, y, w, s.RowHeight);
                    var content = ContentRect(rect);

                    string txt = s.ValueAt[c](r) ?? "";
                    using var fmt = MakeFmt(s.Align[c]);
                    DrawShrink(g, txt, s.CellFont, foreCell, content, fmt);

                    g.DrawRectangle(penCell, rect);
                    xi += w;
                }

                y += s.RowHeight;
                zebraToggle++;
            }

            DrawFooter(g, area, s);
            e.HasMorePages = false;
        }

        private static void DrawFooter(Graphics g, Rectangle area, Session s)
        {
            string left = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string right = $"Página {s.PageNumber}";
            int h = (int)Math.Ceiling(s.CellFont.GetHeight(g)) + 2;

            using var br = new SolidBrush(Color.Gray);
            using var fmtL = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
            using var fmtR = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near };

            g.DrawString(left, s.CellFont, br, new Rectangle(area.Left, area.Bottom - h, area.Width / 2, h), fmtL);
            g.DrawString(right, s.CellFont, br, new Rectangle(area.Left + area.Width / 2, area.Bottom - h, area.Width / 2, h), fmtR);
        }

        private static void TrimSessionRows(Session s, int drawnRows)
        {
            // Quando paginar, “anda” nas funções ValueAt pra começar na próxima linha
            for (int c = 0; c < s.ValueAt.Count; c++)
            {
                var prev = s.ValueAt[c];
                s.ValueAt[c] = (ri) => prev(ri + drawnRows);
            }
            s.RowCount -= drawnRows;
        }

        // ================== Helpers ==================
        private static TextFormatFlags GetTextFlags(DataGridViewContentAlignment align, bool wordBreak = true)
        {
            var flags = TextFormatFlags.NoPrefix | TextFormatFlags.Top;
            if (wordBreak) flags |= TextFormatFlags.WordBreak;

            // alinhamento horizontal
            flags |= align switch
            {
                DataGridViewContentAlignment.MiddleCenter or DataGridViewContentAlignment.TopCenter or DataGridViewContentAlignment.BottomCenter
                    => TextFormatFlags.HorizontalCenter,
                DataGridViewContentAlignment.MiddleRight or DataGridViewContentAlignment.TopRight or DataGridViewContentAlignment.BottomRight
                    => TextFormatFlags.Right,
                _ => TextFormatFlags.Left
            };

            return flags;
        }

        private static int MeasureWrappedHeight(Graphics g, string text, Font font, int width)
        {
            if (string.IsNullOrEmpty(text)) return (int)Math.Ceiling(font.GetHeight(g)) + 10;
            var size = TextRenderer.MeasureText(text, font, new Size(Math.Max(1, width), int.MaxValue),
                                                GetTextFlags(DataGridViewContentAlignment.MiddleLeft, wordBreak: true));
            return Math.Max((int)Math.Ceiling(font.GetHeight(g)) + 10, size.Height + 8); // padding vertical
        }

        private static int MeasureRowHeight(Graphics g, Session s, int rowIndex)
        {
            int maxH = 0;
            int xPad = CellHPad * 2;
            for (int c = 0; c < s.Headers.Count; c++)
            {
                string txt = s.ValueAt[c](rowIndex) ?? "";
                int w = Math.Max(10, s.ColWidths[c] - xPad);
                int h = MeasureWrappedHeight(g, txt, s.CellFont, w);
                maxH = Math.Max(maxH, h);
            }
            return maxH;
        }

        private static T Safe<T>(IList<T> list, int index) where T : class
        {
            if (index < 0 || index >= list.Count) return null;
            return list[index];
        }

        private static DataGridViewContentAlignment GuessAlign(string header, DataGridViewContentAlignment existing)
        {
            if (existing != DataGridViewContentAlignment.NotSet) return existing;
            string h = (header ?? "").ToLowerInvariant();
            if (h.Contains("qtd") || h.Contains("quant") || h.Contains("valor") || h.Contains("preço") || h.Contains("preco"))
                return DataGridViewContentAlignment.MiddleRight;
            if (h == "data" || h.Contains("valid"))
                return DataGridViewContentAlignment.MiddleCenter;
            if (h == "un" || h.Contains("unid"))
                return DataGridViewContentAlignment.MiddleCenter;
            return DataGridViewContentAlignment.MiddleLeft;
        }
    }
}
