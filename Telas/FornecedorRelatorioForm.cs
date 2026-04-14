using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using alguamcoisa.Utils;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class FornecedorRelatorioForm : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioFornecedores _repoFornecedores = new RepositorioFornecedores();
        private List<Fornecedor> _fornecedores = new();

        // Menu de exportação (PDF / Excel)
        private ContextMenuStrip _exportMenu;

        public FornecedorRelatorioForm()
        {
            InitializeComponent();

            // Aqui o grid já recebe:
            // - Comportamento padrão
            // - Tema (claro/escuro)
            // - Espaçamento (RowTemplate.Height >= 32)
            // - Dock = Fill (se configurado no helper)
            GridHelper.ConfigurarGridCompleto(dgvRelatorio);

            // Eventos que NÃO vêm do designer
            Load += FornecedorRelatorioForm_Load;

            if (txtBuscarFornecedor != null)
            {
                txtBuscarFornecedor.TextChanged += (s, e) => PreencherGrid();
                txtBuscarFornecedor.KeyDown += TxtBuscarFornecedor_KeyDown;
            }
        }

        private void FornecedorRelatorioForm_Load(object? sender, EventArgs e)
        {
            CarregarDadosBase();
            ConfigurarGrid();
            PreencherGrid();
        }

        private void CarregarDadosBase()
        {
            _fornecedores = _repoFornecedores.Listar();
        }

        private void ConfigurarGrid()
        {
            // NÃO reaplica GridHelper aqui pra não ficar mexendo de novo em Dock/altura.
            // O visual + espaçamento já foi definido no construtor.

            dgvRelatorio.AutoGenerateColumns = false;
            dgvRelatorio.Columns.Clear();

            // Regras específicas desta tela (muitas já vêm do helper, mas reforçar não quebra nada)
            dgvRelatorio.ReadOnly = true;
            dgvRelatorio.MultiSelect = false;
            dgvRelatorio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRelatorio.RowHeadersVisible = false;
            dgvRelatorio.AllowUserToAddRows = false;
            dgvRelatorio.AllowUserToDeleteRows = false;
            dgvRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // IMPORTANTE:
            // Não mexer em RowTemplate.Height aqui.
            // Deixa o GridHelper controlar o espaçamento (altura das linhas).

            void AddColumn(string header, string property, int minWidth = 80, float fillWeight = 100f)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = header,
                    DataPropertyName = property,
                    Name = property,
                    MinimumWidth = minWidth,
                    FillWeight = fillWeight,
                    SortMode = DataGridViewColumnSortMode.Automatic
                };
                dgvRelatorio.Columns.Add(col);
            }

            AddColumn("Código", "Codigo", 70, 50f);
            AddColumn("Fornecedor", "Nome", 220, 200f);
            AddColumn("CNPJ", "CNPJ", 120, 120f);
            AddColumn("Inscrição Est.", "InscricaoEstadual", 110, 110f);
            AddColumn("Telefone", "Telefone", 110, 110f);
            AddColumn("E-mail", "Email", 150, 150f);
            AddColumn("Site", "Site", 150, 150f);

            if (dgvRelatorio.Columns["Codigo"] is DataGridViewColumn colCodigo)
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvRelatorio.Columns["CNPJ"] is DataGridViewColumn colCnpj)
                colCnpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvRelatorio.Columns["InscricaoEstadual"] is DataGridViewColumn colIe)
                colIe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvRelatorio.Columns["Telefone"] is DataGridViewColumn colTel)
                colTel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void PreencherGrid()
        {
            if (_fornecedores == null || _fornecedores.Count == 0)
            {
                dgvRelatorio.DataSource = null;
                AtualizarTotal();
                return;
            }

            string termo = txtBuscarFornecedor?.Text?.Trim() ?? string.Empty;
            IEnumerable<Fornecedor> query = _fornecedores;

            if (!string.IsNullOrWhiteSpace(termo))
            {
                string termoUpper = termo.ToUpperInvariant();

                query = query.Where(f =>
                {
                    string nome = (f.nomefornecedor ?? f.nome ?? string.Empty).ToUpperInvariant();
                    string cnpj = (f.CNPJ ?? string.Empty).ToUpperInvariant();
                    return nome.Contains(termoUpper) || cnpj.Contains(termoUpper);
                });
            }

            var listaGrid = query
                .Select(f => new
                {
                    Codigo = f.idfornecedor,
                    Nome = f.nomefornecedor ?? f.nome ?? $"Fornecedor {f.idfornecedor}",
                    CNPJ = f.CNPJ,
                    InscricaoEstadual = f.inscricao_estadual,
                    Telefone = f.telefone,
                    Email = f.email,
                    Site = f.site
                })
                .OrderBy(f => f.Nome)
                .ToList();

            dgvRelatorio.DataSource = listaGrid;
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            if (lblContFornecedor == null)
                return;

            int total = dgvRelatorio?.Rows?.Count ?? 0;
            lblContFornecedor.Text = $"Fornecedores exibidos: {total}";
        }

        private void TxtBuscarFornecedor_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                PreencherGrid();
            }
        }

        private void lblContFornecedor_Click(object sender, EventArgs e)
        {
        }

        // -----------------------
        //    IMPRESSÃO (via PrintUtils)
        // -----------------------

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para imprimir.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Usa o utilitário padrão do sistema para imprimir o grid
            PrintUtils.ImprimirGrid(
                dgvRelatorio,
                "Relatório de Fornecedores",
                landscape: false);
        }

        // -----------------------
        //    EXPORTAR (PDF / EXCEL)
        // -----------------------

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_exportMenu == null)
            {
                _exportMenu = new ContextMenuStrip();

                var itemPdf = new ToolStripMenuItem("Exportar para PDF");
                itemPdf.Click += (s, ev) => ExportarParaPdf();
                _exportMenu.Items.Add(itemPdf);

                var itemExcel = new ToolStripMenuItem("Exportar para Excel (.csv)");
                itemExcel.Click += (s, ev) => ExportarParaExcel();
                _exportMenu.Items.Add(itemExcel);
            }

            var button = sender as Control ?? btnExportar;
            var location = new Point(0, button.Height);
            _exportMenu.Show(button, location);
        }

        private void ExportarParaPdf()
        {
            if (dgvRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                "Para gerar um PDF deste relatório:\n\n" +
                "1. Na pré-visualização de impressão, escolha a impressora 'Microsoft Print to PDF' (ou outra impressora PDF).\n" +
                "2. Confirme e escolha o local para salvar o arquivo.",
                "Exportar para PDF",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Reaproveita a lógica de impressão (abre o preview do PrintUtils)
            PrintUtils.ImprimirGrid(
                dgvRelatorio,
                "Relatório de Fornecedores",
                landscape: false);
        }

        private void ExportarParaExcel()
        {
            if (dgvRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Exportar para Excel";
                sfd.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
                sfd.FileName = $"Relatorio_Fornecedores_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        var headers = dgvRelatorio.Columns
                            .Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .Select(c => EscaparCsv(c.HeaderText));

                        sw.WriteLine(string.Join(";", headers));

                        foreach (DataGridViewRow row in dgvRelatorio.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var cells = dgvRelatorio.Columns
                                .Cast<DataGridViewColumn>()
                                .Where(c => c.Visible)
                                .Select(c =>
                                {
                                    var value = row.Cells[c.Name].Value?.ToString() ?? string.Empty;
                                    return EscaparCsv(value);
                                });

                            sw.WriteLine(string.Join(";", cells));
                        }
                    }

                    MessageBox.Show(
                        "Exportação para Excel (CSV) concluída.\n" +
                        "Você pode abrir o arquivo diretamente no Excel.",
                        "Exportar Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao exportar para Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string EscaparCsv(string value)
        {
            if (value.Contains("\"") || value.Contains(";") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }

            return value;
        }

        // -----------------------
        //    OUTROS BOTÕES
        // -----------------------

        private void btnExportar_Click_1(object sender, EventArgs e)
        {
            btnExportar_Click(sender, e);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            PreencherGrid();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
