using System;
using System.Drawing;
using System.Windows.Forms;

namespace alguamcoisa.Utils
{
    public static class GridHelper
    {
        /// <summary>
        /// Aplica o padrão oficial de comportamento do sistema
        /// (sem editar visual) a um DataGridView.
        /// </summary>
        public static void ConfigurarGridPadrao(DataGridView grid)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;

            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;

            // Em telas de relatório você pode alterar depois,
            // mas ter um padrão inicial ajuda.
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Garante que o DataBindingComplete limpe a seleção
            grid.DataBindingComplete -= Grid_DataBindingComplete;
            grid.DataBindingComplete += Grid_DataBindingComplete;
        }

        /// <summary>
        /// Aplica comportamento + estilização visual padrão
        /// e (opcionalmente) Dock = Fill no grid.
        /// 
        /// Use assim no Form:
        /// 
        /// public MeuForm()
        /// {
        ///     InitializeComponent();
        ///     GridHelper.ConfigurarGridCompleto(meuGrid);
        /// }
        /// </summary>
        public static void ConfigurarGridCompleto(DataGridView grid, bool dockFill = true)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            // Regras de comportamento (read-only, seleção, etc.)
            ConfigurarGridPadrao(grid);

            // ============ ESTILO VISUAL ============

            // Remove borda "grossa" e deixa mais clean
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Cabeçalho customizado (sem estilo padrão do Windows)
            grid.EnableHeadersVisualStyles = false;

            // Usa o fundo do container como base, mas respeitando o tema atual
            Color backContainer = grid.Parent?.BackColor ?? AppTheme.BackForm;

            // Paleta baseada no AppTheme (modo claro/escuro + acento escolhido)
            Color headerBack = AppTheme.BackPanel;
            Color headerFore = AppTheme.Fore;
            Color rowsBack = backContainer;
            Color altRowsBack = Color.FromArgb(
                Math.Min(rowsBack.R + 6, 255),
                Math.Min(rowsBack.G + 6, 255),
                Math.Min(rowsBack.B + 6, 255));

            Color selectionBack = AppTheme.SelBack;
            Color selectionFore = AppTheme.SelFore;
            Color gridLines = AppTheme.Border;

            // Fundo geral
            grid.BackgroundColor = rowsBack;
            grid.GridColor = gridLines;

            // Cabeçalho
            grid.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = headerFore;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);

            // Células padrão
            grid.DefaultCellStyle.BackColor = rowsBack;
            grid.DefaultCellStyle.ForeColor = AppTheme.Fore;
            grid.DefaultCellStyle.SelectionBackColor = selectionBack;
            grid.DefaultCellStyle.SelectionForeColor = selectionFore;

            // Linhas alternadas
            grid.AlternatingRowsDefaultCellStyle.BackColor = altRowsBack;

            // Aumenta a altura das linhas
            grid.RowTemplate.Height = 40;

            // Deixa as linhas com pequena margem para respirar
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Dock opcional
            if (dockFill)
            {
                grid.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Evento padrão: após bind, limpa a seleção inicial.
        /// </summary>
        private static void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                grid.ClearSelection();
            }
        }

        /// <summary>
        /// Helper para saber se existe alguma linha selecionada.
        /// </summary>
        public static bool TemLinhaSelecionada(DataGridView grid)
        {
            return grid != null &&
                   grid.CurrentRow != null &&
                   grid.CurrentRow.Index >= 0 &&
                   !grid.CurrentRow.IsNewRow;
        }
    }
}
