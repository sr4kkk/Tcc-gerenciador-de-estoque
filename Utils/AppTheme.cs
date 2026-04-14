using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace alguamcoisa.Utils
{
    public static class AppTheme
    {

        // Caminho simples para guardar as preferências de tema do usuário
        private static readonly string _configFilePath = GetConfigFilePath();

        // Construtor estático: tenta carregar o tema salvo ao iniciar a aplicação
        static AppTheme()
        {
            TryLoadFromStorage();
        }

        public static bool Dark { get; private set; } = true;

        // ===== OPÇÕES DINÂMICAS =====
        public enum AccentScheme
        {
            Roxo,
            Azul,
            Verde,
            Cinza
        }

        private static AccentScheme _accentScheme = AccentScheme.Roxo;
        private static float _fontScale = 1.0f; // 1.0 = padrão

        public static AccentScheme CurrentAccentScheme => _accentScheme;
        public static float FontScale => _fontScale;

        // ===== MÉTODO DE COMPATIBILIDADE =====
        // Caso algum ponto do código ainda chame AppTheme.LoadTheme()
        public static void LoadTheme()
        {
            // Hoje a paleta é calculada "on the fly" pelas propriedades,
            // então aqui não precisamos fazer nada pesado.
            ReapplyToOpenForms();
        }

        // ===== PALETA BASE =====

        // Fundos principais (ajustados para ficar bem parecido com VS/SSMS)
        public static Color BackForm => Dark ? Color.FromArgb(24, 24, 24) : Color.FromArgb(247, 249, 252);
        public static Color BackPanel => Dark ? Color.FromArgb(37, 37, 38) : Color.White;
        public static Color BackAlt => Dark ? Color.FromArgb(32, 32, 32) : Color.FromArgb(241, 243, 247);

        // Textos
        public static Color Fore => Dark ? Color.FromArgb(241, 241, 241) : Color.FromArgb(33, 37, 41);
        public static Color ForeDim => Dark ? Color.FromArgb(190, 190, 190) : Color.FromArgb(110, 115, 120);

        // ===== PALETA DE ACENTO DINÂMICA =====
        private static (
            Color AccentDark, Color AccentLight,
            Color SoftDark, Color SoftLight,
            Color SelectDark, Color SelectLight,
            Color BtnBackDark, Color BtnBackLight,
            Color BtnHoverDark, Color BtnHoverLight,
            Color BtnDownDark, Color BtnDownLight
        ) GetAccentPalette()
        {
            switch (_accentScheme)
            {
                case AccentScheme.Azul:
                    return (
                        AccentDark: Color.FromArgb(0, 122, 204),
                        AccentLight: Color.FromArgb(0, 122, 204),
                        SoftDark: Color.FromArgb(15, 76, 117),
                        SoftLight: Color.FromArgb(224, 240, 255),
                        SelectDark: Color.FromArgb(45, 137, 239),
                        SelectLight: Color.FromArgb(204, 228, 255),
                        BtnBackDark: Color.FromArgb(0, 122, 204),
                        BtnBackLight: Color.FromArgb(0, 122, 204),
                        BtnHoverDark: Color.FromArgb(0, 140, 230),
                        BtnHoverLight: Color.FromArgb(0, 140, 230),
                        BtnDownDark: Color.FromArgb(0, 90, 158),
                        BtnDownLight: Color.FromArgb(0, 90, 158)
                    );

                case AccentScheme.Verde:
                    return (
                        AccentDark: Color.FromArgb(0, 153, 0),
                        AccentLight: Color.FromArgb(0, 153, 0),
                        SoftDark: Color.FromArgb(14, 82, 14),
                        SoftLight: Color.FromArgb(220, 245, 220),
                        SelectDark: Color.FromArgb(0, 170, 0),
                        SelectLight: Color.FromArgb(204, 238, 204),
                        BtnBackDark: Color.FromArgb(0, 153, 0),
                        BtnBackLight: Color.FromArgb(0, 153, 0),
                        BtnHoverDark: Color.FromArgb(0, 180, 0),
                        BtnHoverLight: Color.FromArgb(0, 180, 0),
                        BtnDownDark: Color.FromArgb(0, 110, 0),
                        BtnDownLight: Color.FromArgb(0, 110, 0)
                    );

                case AccentScheme.Cinza:
                    return (
                        AccentDark: Color.FromArgb(120, 120, 120),
                        AccentLight: Color.FromArgb(120, 120, 120),
                        SoftDark: Color.FromArgb(70, 70, 70),
                        SoftLight: Color.FromArgb(230, 230, 230),
                        SelectDark: Color.FromArgb(150, 150, 150),
                        SelectLight: Color.FromArgb(210, 210, 210),
                        BtnBackDark: Color.FromArgb(120, 120, 120),
                        BtnBackLight: Color.FromArgb(120, 120, 120),
                        BtnHoverDark: Color.FromArgb(150, 150, 150),
                        BtnHoverLight: Color.FromArgb(150, 150, 150),
                        BtnDownDark: Color.FromArgb(90, 90, 90),
                        BtnDownLight: Color.FromArgb(90, 90, 90)
                    );

                case AccentScheme.Roxo:
                default:
                    // Roxo “SQL Server / VS”
                    return (
                        AccentDark: Color.FromArgb(104, 33, 122),
                        AccentLight: Color.FromArgb(104, 33, 122),
                        SoftDark: Color.FromArgb(60, 20, 90),
                        SoftLight: Color.FromArgb(230, 220, 245),
                        SelectDark: Color.FromArgb(130, 70, 170),
                        SelectLight: Color.FromArgb(210, 190, 235),
                        BtnBackDark: Color.FromArgb(104, 33, 122),
                        BtnBackLight: Color.FromArgb(104, 33, 122),
                        BtnHoverDark: Color.FromArgb(122, 44, 144),
                        BtnHoverLight: Color.FromArgb(122, 44, 144),
                        BtnDownDark: Color.FromArgb(85, 24, 99),
                        BtnDownLight: Color.FromArgb(85, 24, 99)
                    );
            }
        }

        private static (Color AccentDark, Color AccentLight,
                        Color SoftDark, Color SoftLight,
                        Color SelectDark, Color SelectLight,
                        Color BtnBackDark, Color BtnBackLight,
                        Color BtnHoverDark, Color BtnHoverLight,
                        Color BtnDownDark, Color BtnDownLight) Palette
            => GetAccentPalette();

        public static Color Accent => Dark ? Palette.AccentDark : Palette.AccentLight;
        public static Color AccentSoft => Dark ? Palette.SoftDark : Palette.SoftLight;
        public static Color AccentSelect => Dark ? Palette.SelectDark : Palette.SelectLight;

        // Botões
        public static Color BtnBack => Dark ? Palette.BtnBackDark : Palette.BtnBackLight;
        public static Color BtnHover => Dark ? Palette.BtnHoverDark : Palette.BtnHoverLight;
        public static Color BtnDown => Dark ? Palette.BtnDownDark : Palette.BtnDownLight;

        public static Color Border => Dark ? Color.FromArgb(63, 63, 70) : Color.FromArgb(210, 215, 220);

        // Seleção
        public static Color SelBack => Dark ? Palette.SelectDark : Palette.SelectLight;
        public static Color SelFore => Dark ? Color.White : Color.Black;

        // TextBoxes estilo SSMS
        public static Color TextBoxBack => Dark ? Color.FromArgb(60, 60, 60) : Color.White;
        public static Color TextBoxBorder => Dark ? Color.FromArgb(85, 85, 85) : Color.Gray;
        public static Color TextBoxDisabledBack => Dark ? Color.FromArgb(42, 42, 42) : Color.LightGray;

        // =====================================================================
        // APLICAÇÃO DE TEMA
        // =====================================================================
        public static void Apply(Control root, bool panelContrast = true)
        {
            if (root == null) return;

            root.BackColor = BackForm;
            root.ForeColor = Fore;

            foreach (Control c in root.Controls)
            {
                switch (c)
                {
                    case Panel or FlowLayoutPanel or GroupBox:
                        c.BackColor = panelContrast ? BackPanel : BackForm;
                        c.ForeColor = Fore;
                        break;

                    case MenuStrip ms:
                        ms.BackColor = BackPanel;
                        ms.ForeColor = Fore;
                        ms.RenderMode = ToolStripRenderMode.Professional;
                        ms.Renderer = new ThemedRenderer(new ThemedColorTable());
                        foreach (ToolStripMenuItem item in ms.Items)
                        {
                            item.ForeColor = Fore;
                            item.BackColor = Color.Transparent;

                            if (item.DropDown is ToolStripDropDownMenu dd)
                            {
                                dd.ShowImageMargin = false;
                                dd.ShowCheckMargin = false;
                                dd.BackColor = BackPanel;
                                dd.ForeColor = Fore;
                                dd.Renderer = ms.Renderer;

                                foreach (ToolStripItem sub in dd.Items)
                                {
                                    sub.ForeColor = Fore;
                                    sub.BackColor = BackPanel;
                                }
                            }
                        }
                        break;

                    case StatusStrip s:
                        s.BackColor = BackPanel;
                        foreach (ToolStripItem it in s.Items)
                            it.ForeColor = ForeDim;
                        break;

                    case DataGridView g:
                        ApplyGrid(g);
                        break;

                    case Button b:
                        b.BackColor = BtnBack;
                        b.ForeColor = Fore;
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderColor = Border;
                        b.FlatAppearance.MouseOverBackColor = BtnHover;
                        b.FlatAppearance.MouseDownBackColor = BtnDown;
                        //b.Padding = new Padding(6, 4, 6, 4);
                        break;

                    case ComboBox cb:
                        ThemeComboBox(cb);
                        break;

                    case TextBox tb:
                        tb.BackColor = TextBoxBack;
                        tb.ForeColor = Fore;
                        tb.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case DateTimePicker dtp:
                        dtp.CalendarMonthBackground = TextBoxBack;
                        dtp.BackColor = TextBoxBack;
                        dtp.ForeColor = Fore;
                        dtp.CalendarForeColor = Fore;
                        dtp.CalendarTitleBackColor = BackPanel;
                        dtp.CalendarTitleForeColor = Fore;
                        break;

                    case NumericUpDown nud:
                        nud.BackColor = TextBoxBack;
                        nud.ForeColor = Fore;
                        nud.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case MaskedTextBox mtb:
                        mtb.BackColor = TextBoxBack;
                        mtb.ForeColor = Fore;
                        mtb.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case CheckBox chk:
                        chk.ForeColor = Fore;
                        break;

                    case Label:
                        c.ForeColor = Fore;
                        break;
                }

                Apply(c, panelContrast);
            }
        }

        // ===== GRID =====
        private static void ApplyGrid(DataGridView g)
        {
            g.BackgroundColor = BackForm;
            g.BorderStyle = BorderStyle.None;
            g.GridColor = Dark
                ? Color.FromArgb(78, 80, 86)
                : Color.FromArgb(220, 220, 220);

            g.EnableHeadersVisualStyles = false;

            // Cabeçalho
            g.ColumnHeadersDefaultCellStyle.BackColor = BackPanel;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Fore;
            g.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            g.ColumnHeadersDefaultCellStyle.Font = MakeHeaderFont();

            // Células
            g.DefaultCellStyle.BackColor = BackForm;
            g.DefaultCellStyle.ForeColor = Fore;
            g.DefaultCellStyle.SelectionBackColor = SelBack;
            g.DefaultCellStyle.SelectionForeColor = SelFore;
            g.DefaultCellStyle.Font = MakeCellFont();
            g.AlternatingRowsDefaultCellStyle.BackColor = BackAlt;

            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.RowHeadersVisible = false;

            // Nenhum evento de animação extra
        }

        // ===== TIPOGRAFIA =====
        private static Font MakeHeaderFont()
        {
            float size = 10f * _fontScale;
            try { return new Font("Segoe UI", size, FontStyle.Bold); }
            catch { return new Font(SystemFonts.DefaultFont.FontFamily, size, FontStyle.Bold); }
        }

        private static Font MakeCellFont()
        {
            float size = 10f * _fontScale;
            try { return new Font("Segoe UI", size, FontStyle.Regular); }
            catch { return new Font(SystemFonts.DefaultFont.FontFamily, size, FontStyle.Regular); }
        }

        // ===== COMBOBOX =====
        private static void ThemeComboBox(ComboBox cb)
        {
            cb.FlatStyle = FlatStyle.Flat;
            cb.BackColor = TextBoxBack;
            cb.ForeColor = Fore;
            // Sem owner-draw, sem animação extra
        }

        // Reaplica tema em todos os forms
        private static void ReapplyToOpenForms()
        {
            foreach (Form f in Application.OpenForms)
            {
                Apply(f);
                f.Invalidate(true);
            }
        }

        // ===== ALTERAÇÕES DE ESTADO =====
        public static void SetDark(bool dark)
        {
            Dark = dark;
            SaveToStorage();
            ReapplyToOpenForms();
        }

        public static void Toggle()
        {
            Dark = !Dark;
            SaveToStorage();
            ReapplyToOpenForms();
        }

        public static void SetAccentScheme(AccentScheme scheme)
        {
            _accentScheme = scheme;
            SaveToStorage();
            ReapplyToOpenForms();
        }

        public static void SetFontScale(float scale)
        {
            if (scale < 0.8f) scale = 0.8f;
            if (scale > 1.3f) scale = 1.3f;
            _fontScale = scale;
            SaveToStorage();
            ReapplyToOpenForms();
        }

        // ===== RENDERER DE MENUS =====
        private sealed class ThemedRenderer : ToolStripProfessionalRenderer
        {
            public ThemedRenderer(ProfessionalColorTable table) : base(table)
            {
                RoundedEdges = false;
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using var b = new SolidBrush(BackPanel);
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                var r = new Rectangle(Point.Empty, e.Item.Size);
                bool active = e.Item.Selected || e.Item.Pressed;
                using var b = new SolidBrush(active ? BtnHover : BackPanel);
                e.Graphics.FillRectangle(b, r);
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Fore;
                base.OnRenderItemText(e);
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                if (e.ToolStrip is ToolStripDropDownMenu)
                {
                    using var p = new Pen(Border);
                    e.Graphics.DrawRectangle(p, 0, 0,
                        e.ToolStrip.Width - 1,
                        e.ToolStrip.Height - 1);
                }
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                using var p = new Pen(Border);
                int y = e.Item.ContentRectangle.Top +
                        e.Item.ContentRectangle.Height / 2;

                e.Graphics.DrawLine(p,
                    e.Item.ContentRectangle.Left + 8, y,
                    e.Item.ContentRectangle.Right - 8, y);
            }
        }

        private sealed class ThemedColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => BackPanel;
            public override Color MenuStripGradientEnd => BackPanel;
            public override Color ToolStripDropDownBackground => BackPanel;
            public override Color MenuItemSelected => BtnHover;
            public override Color MenuItemPressedGradientBegin => BtnHover;
            public override Color MenuItemPressedGradientEnd => BtnHover;
            public override Color MenuBorder => Border;
            public override Color SeparatorDark => Border;
            public override Color ImageMarginGradientBegin => BackPanel;
            public override Color ImageMarginGradientEnd => BackPanel;
        }

        // =====================================================================
        // PERSISTÊNCIA SIMPLES DAS PREFERÊNCIAS DO TEMA
        // =====================================================================
        private static string GetConfigFilePath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "EstoqueQuimicoTema");
            try
            {
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
            }
            catch
            {
                // Se não conseguir criar pasta, usa o próprio AppData como fallback
                folder = appData;
            }

            return Path.Combine(folder, "theme.config");
        }

        private static void TryLoadFromStorage()
        {
            try
            {
                if (!File.Exists(_configFilePath))
                    return;

                var lines = File.ReadAllLines(_configFilePath);
                bool? dark = null;
                AccentScheme? accent = null;
                float? scale = null;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length != 2) continue;

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    if (key.Equals("Dark", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(value, out bool d))
                            dark = d;
                    }
                    else if (key.Equals("Accent", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Enum.TryParse(value, ignoreCase: true, out AccentScheme s))
                            accent = s;
                    }
                    else if (key.Equals("FontScale", StringComparison.OrdinalIgnoreCase))
                    {
                        if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float f))
                            scale = f;
                    }
                }

                // Aplica o que foi carregado, se existir
                if (dark.HasValue)
                    Dark = dark.Value;

                if (accent.HasValue)
                    _accentScheme = accent.Value;

                if (scale.HasValue)
                    _fontScale = scale.Value;
            }
            catch
            {
                // Se der qualquer problema ao ler/parsing, ignora e mantém padrão
            }
        }

        private static void SaveToStorage()
        {
            try
            {
                var lines = new[]
                {
                    $"Dark={Dark}",
                    $"Accent={_accentScheme}",
                    $"FontScale={_fontScale.ToString(CultureInfo.InvariantCulture)}"
                };
                File.WriteAllLines(_configFilePath, lines);
            }
            catch
            {
                // Não deixa exceção de IO quebrar a aplicação
            }
        }
    }
}
