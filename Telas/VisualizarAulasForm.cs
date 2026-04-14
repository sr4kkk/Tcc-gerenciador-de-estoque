using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa.Telas
{
    public partial class VisualizarAulasForm : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioMovimentos _repositorioMovimentos = new RepositorioMovimentos();

        /// <summary>
        /// Cache de movimentos de saída usados para montar as aulas.
        /// Evita buscar do banco duas vezes desnecessariamente.
        /// </summary>
        private List<Movimento> _cacheSaidas = new List<Movimento>();

        /// <summary>
        /// Modelo exibido no grid de aulas.
        /// </summary>
        private class AulaGridItem
        {
            public string AulaId { get; set; } = string.Empty; // Chave para edição/exclusão
            public string Titulo { get; set; } = string.Empty;
            public string Professor { get; set; } = string.Empty;
            public string Materia { get; set; } = string.Empty;
            public DateTime DataAula { get; set; }
            public string Status { get; set; } = string.Empty;
        }

        public VisualizarAulasForm()
        {
            InitializeComponent();

            ConfigurarGrid();
            ConfigurarEventos();
            CarregarFiltrosIniciais();
            CarregarAulas();
        }

        #region Configuração

        private void ConfigurarGrid()
        {
            dgvAulas.ReadOnly = true;
            dgvAulas.AllowUserToAddRows = false;
            dgvAulas.AllowUserToDeleteRows = false;
            dgvAulas.MultiSelect = false;
            dgvAulas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAulas.RowHeadersVisible = false;

            dgvAulas.AutoGenerateColumns = false;
            dgvAulas.Columns.Clear();

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AulaGridItem.Titulo),
                HeaderText = "Título da Aula",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AulaGridItem.Professor),
                HeaderText = "Professor",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AulaGridItem.Materia),
                HeaderText = "Matéria",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AulaGridItem.DataAula),
                HeaderText = "Dia",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AulaGridItem.Status),
                HeaderText = "Status",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(AulaGridItem.AulaId),
                HeaderText = "ID (Oculto)",
                Visible = false
            });
        }

        private void ConfigurarEventos()
        {
            dgvAulas.SelectionChanged += dgvAulas_SelectionChanged;
            dgvAulas.CellDoubleClick += dgvAulas_CellDoubleClick;
            dgvAulas.DataBindingComplete += dgvAulas_DataBindingComplete;

            btnBuscar.Click += (s, e) => CarregarAulas();
            btnEditarAula.Click += btnEditarAula_Click;
            btnExcluirAula.Click += btnExcluirAula_Click;
            btnFechar.Click += (s, e) => Close();
        }

        /// <summary>
        /// Define datas padrão e carrega listas de Professor / Matéria a partir dos movimentos.
        /// </summary>
        private void CarregarFiltrosIniciais()
        {
            dtpDataInicio.Value = DateTime.Today.AddMonths(-1);
            dtpDataFim.Value = DateTime.Today.AddDays(7);

            try
            {
                // Carrega cache de saídas uma única vez aqui
                _cacheSaidas = _repositorioMovimentos.ListarSaidas();
                var movimentosSaida = _cacheSaidas;

                var professores = movimentosSaida
                    .Where(m => !string.IsNullOrWhiteSpace(m.Observacao))
                    .Select(m => ExtrairTrecho(m.Observacao!, "Professor:"))
                    .Where(p => !string.IsNullOrWhiteSpace(p))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(p => p)
                    .ToList();

                cboProfessor.Items.Clear();
                cboProfessor.Items.Add(string.Empty); // (Todos)
                foreach (var p in professores)
                    cboProfessor.Items.Add(p);

                var materias = movimentosSaida
                    .Where(m => !string.IsNullOrWhiteSpace(m.Observacao))
                    .Select(m => ExtrairTrecho(m.Observacao!, "Materia:"))
                    .Where(p => !string.IsNullOrWhiteSpace(p))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(p => p)
                    .ToList();

                cboMateria.Items.Clear();
                cboMateria.Items.Add(string.Empty); // (Todas)
                foreach (var mat in materias)
                    cboMateria.Items.Add(mat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar filtros iniciais:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Carregar Aulas

        private void CarregarAulas()
        {
            try
            {
                // Reaproveita cache de saídas; se estiver vazio, recarrega do banco
                var movimentosSaida = _cacheSaidas;
                if (movimentosSaida == null || movimentosSaida.Count == 0)
                {
                    movimentosSaida = _repositorioMovimentos.ListarSaidas();
                    _cacheSaidas = movimentosSaida;
                }

                var movimentosComAula = movimentosSaida
                    .Where(m => !string.IsNullOrWhiteSpace(m.Observacao) &&
                                m.Observacao!.IndexOf("AulaId=", StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                var grupos = movimentosComAula
                    .GroupBy(m => ExtrairAulaId(m.Observacao!))
                    .Where(g => !string.IsNullOrWhiteSpace(g.Key));

                var listaAulas = new List<AulaGridItem>();

                foreach (var grupo in grupos)
                {
                    var movimentos = grupo.ToList();
                    var primeiro = movimentos.OrderBy(m => m.Data).First();
                    string obs = primeiro.Observacao ?? string.Empty;

                    string titulo = ExtrairTrecho(obs, "Aula:");
                    string professor = ExtrairTrecho(obs, "Professor:");
                    string materia = ExtrairTrecho(obs, "Materia:");
                    string dataStr = ExtrairTrecho(obs, "DataAula:");

                    DateTime dataAula;
                    if (!DateTime.TryParse(dataStr, out dataAula))
                    {
                        dataAula = primeiro.Data;
                    }

                    var aula = new AulaGridItem
                    {
                        AulaId = grupo.Key,
                        Titulo = string.IsNullOrWhiteSpace(titulo) ? "(Sem título)" : titulo,
                        Professor = professor,
                        Materia = materia,
                        DataAula = dataAula,
                        Status = CalcularStatusAula(movimentos)
                    };

                    listaAulas.Add(aula);
                }

                // Filtros
                DateTime inicio = dtpDataInicio.Value.Date;
                DateTime fim = dtpDataFim.Value.Date;

                var filtrada = listaAulas
                    .Where(a => a.DataAula.Date >= inicio && a.DataAula.Date <= fim);

                string professorFiltro = cboProfessor.Text?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(professorFiltro))
                {
                    filtrada = filtrada.Where(a =>
                        a.Professor.Equals(professorFiltro, StringComparison.OrdinalIgnoreCase));
                }

                string materiaFiltro = cboMateria.Text?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(materiaFiltro))
                {
                    filtrada = filtrada.Where(a =>
                        a.Materia.Equals(materiaFiltro, StringComparison.OrdinalIgnoreCase));
                }

                var listaFinal = filtrada
                    .OrderBy(a => a.DataAula)
                    .ThenBy(a => a.Professor)
                    .ThenBy(a => a.Titulo)
                    .ToList();

                dgvAulas.DataSource = listaFinal;

                AtualizarEstadoBotoes();
                AtualizarResumoTitulo(listaFinal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar aulas:\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtrairAulaId(string observacao)
        {
            if (string.IsNullOrWhiteSpace(observacao))
                return string.Empty;

            var idx = observacao.IndexOf("AulaId=", StringComparison.OrdinalIgnoreCase);
            if (idx < 0)
                return string.Empty;

            idx += "AulaId=".Length;

            int fim = observacao.IndexOfAny(new[] { ';', ' ', '\r', '\n' }, idx);
            if (fim < 0) fim = observacao.Length;

            return observacao.Substring(idx, fim - idx).Trim();
        }

        /// <summary>
        /// Extrai um trecho da observação no padrão "Chave: valor; ...".
        /// </summary>
        private string ExtrairTrecho(string texto, string chave)
        {
            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrWhiteSpace(chave))
                return string.Empty;

            int idx = texto.IndexOf(chave, StringComparison.OrdinalIgnoreCase);
            if (idx < 0)
                return string.Empty;

            idx += chave.Length;
            while (idx < texto.Length && (texto[idx] == ' ' || texto[idx] == ':'))
                idx++;

            int fim = texto.IndexOf(';', idx);
            if (fim < 0) fim = texto.Length;

            return texto.Substring(idx, fim - idx).Trim();
        }

        private string CalcularStatusAula(IReadOnlyCollection<Movimento> movimentos)
        {
            string obsConcat = string.Join(" ", movimentos
                .Select(m => m.Observacao ?? string.Empty));

            if (obsConcat.IndexOf("[AULA CANCELADA]", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Cancelada";

            if (obsConcat.IndexOf("[AULA OCORRIDA]", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Concluída";

            return "Montada";
        }

        /// <summary>
        /// Atualiza o Text do formulário com um resumo das aulas filtradas.
        /// </summary>
        private void AtualizarResumoTitulo(IReadOnlyCollection<AulaGridItem> aulas)
        {
            int total = aulas.Count;
            int canceladas = aulas.Count(a =>
                string.Equals(a.Status, "Cancelada", StringComparison.OrdinalIgnoreCase));
            int concluidas = aulas.Count(a =>
                string.Equals(a.Status, "Concluída", StringComparison.OrdinalIgnoreCase));
            int montadas = aulas.Count(a =>
                string.Equals(a.Status, "Montada", StringComparison.OrdinalIgnoreCase));

            this.Text =
                $"Visualizar e Editar Aulas Salvas - Total: {total} (Montadas: {montadas}, Concluídas: {concluidas}, Canceladas: {canceladas})";
        }

        #endregion

        #region Eventos

        private void dgvAulas_SelectionChanged(object? sender, EventArgs e)
        {
            AtualizarEstadoBotoes();
        }

        private void dgvAulas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Duplo clique faz a mesma ação do botão Editar
            btnEditarAula_Click(sender, EventArgs.Empty);
        }

        private void dgvAulas_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Colorir linhas conforme o status da aula
            foreach (DataGridViewRow row in dgvAulas.Rows)
            {
                if (row.DataBoundItem is not AulaGridItem item)
                    continue;

                // Cores suaves para não brigar com o tema
                if (string.Equals(item.Status, "Cancelada", StringComparison.OrdinalIgnoreCase))
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else if (string.Equals(item.Status, "Concluída", StringComparison.OrdinalIgnoreCase))
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                }
                else
                {
                    // Montada / outros
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void AtualizarEstadoBotoes()
        {
            bool hasSelection = dgvAulas.SelectedRows.Count > 0;
            btnEditarAula.Enabled = hasSelection;
            btnExcluirAula.Enabled = hasSelection;
        }

        private void btnEditarAula_Click(object? sender, EventArgs e)
        {
            if (dgvAulas.SelectedRows.Count == 0)
                return;

            if (dgvAulas.SelectedRows[0].DataBoundItem is not AulaGridItem itemSelecionado)
                return;

            using (var formEdicao = new EditarAulasForm(itemSelecionado.AulaId))
            {
                formEdicao.ShowDialog();
            }

            // Recarrega lista para refletir alterações (status, etc.)
            CarregarAulas();
        }

        private void btnExcluirAula_Click(object? sender, EventArgs e)
        {
            if (dgvAulas.SelectedRows.Count == 0)
                return;

            if (dgvAulas.SelectedRows[0].DataBoundItem is not AulaGridItem itemSelecionado)
                return;

            // Em vez de duplicar a lógica de exclusão aqui, aproveitamos
            // o fluxo completo do EditarAulasForm (onde já existe o botão
            // "Excluir Aula" com toda a regra de estoque).
            using (var formEdicao = new EditarAulasForm(itemSelecionado.AulaId))
            {
                formEdicao.ShowDialog();
            }

            CarregarAulas();
        }

        #endregion
    }
}
