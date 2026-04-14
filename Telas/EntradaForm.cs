using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using alguamcoisa.Utils;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class EntradaForm : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioMovimentos _repoMovimentos = new RepositorioMovimentos();
        private readonly RepositorioProdutos _repoProdutos = new RepositorioProdutos();
        private readonly RepositorioCategorias _repoCategorias = new RepositorioCategorias();

        // Cache em memória para ficar muito rápido
        private List<Movimento> _todosMovimentosEntrada = new();
        private List<Produto> _produtos = new();
        private List<Categoria> _categorias = new();

        public EntradaForm()
        {
            InitializeComponent();

            // Tema COMPLETO do grid (visual + comportamento)
            GridHelper.ConfigurarGridCompleto(dgvMovimentos);

            // Configuração das colunas (remove ProdutoId, CategoriaId, UnidadeId, LocalId, etc.)
            ConfigurarColunasGrid();

            // Ajuste de formato dos DateTimePickers (só a data)
            ConfigurarDatePickers();

            // Eventos
            Load += EntradaForm_Load;
            btnFiltrar.Click += BtnFiltrar_Click;
            btnLimpar.Click += BtnLimpar_Click;
            btnFechar.Click += BtnFechar_Click;

            cboProduto.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cboCategoria.SelectedIndexChanged += (s, e) => AplicarFiltros();
            dtpInicio.ValueChanged += (s, e) => AplicarFiltros();
            dtpFim.ValueChanged += (s, e) => AplicarFiltros();
        }




        /// <summary>
        /// Configura manualmente as colunas do grid,
        /// exibindo apenas o que é relevante na tela de Entradas.
        /// </summary>
        private void ConfigurarColunasGrid()
        {
            dgvMovimentos.AutoGenerateColumns = false;
            dgvMovimentos.Columns.Clear();

            // Id
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Id),
                HeaderText = "Id",
                Width = 60,
                ReadOnly = true
            };

            // Data
            var colData = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Data),
                HeaderText = "Data",
                Width = 140,
                ReadOnly = true
            };
            colData.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Produto
            var colProduto = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.ProdutoNome),
                HeaderText = "Produto",
                Width = 300,
                ReadOnly = true
            };

            // Categoria
            var colCategoria = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Categoria),
                HeaderText = "Categoria",
                Width = 160,
                ReadOnly = true
            };

            // Quantidade
            var colQuantidade = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Quantidade),
                HeaderText = "Quantidade",
                Width = 110,
                ReadOnly = true
            };
            colQuantidade.DefaultCellStyle.Format = "N2";
            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Unidade
            var colUnidade = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Unidade),
                HeaderText = "Unidade",
                Width = 80,
                ReadOnly = true
            };

            // Local
            var colLocal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Local),
                HeaderText = "Local",
                Width = 150,
                ReadOnly = true
            };

            // Observação
            var colObs = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Movimento.Observacao),
                HeaderText = "Observação",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };

            dgvMovimentos.Columns.AddRange(
                colId,
                colData,
                colProduto,
                colCategoria,
                colQuantidade,
                colUnidade,
                colLocal,
                colObs
            );
        }

        /// <summary>
        /// Deixa os DateTimePickers mostrando só a data (sem nome do dia/semana).
        /// </summary>
        private void ConfigurarDatePickers()
        {
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd/MM/yyyy";

            dtpFim.Format = DateTimePickerFormat.Custom;
            dtpFim.CustomFormat = "dd/MM/yyyy";
        }

        private void EntradaForm_Load(object? sender, EventArgs e)
        {
            // Período padrão: últimos 30 dias
            dtpFim.Value = DateTime.Today;
            dtpInicio.Value = DateTime.Today.AddDays(-30);

            CarregarDadosBase();
            PopularCombos();
            AplicarFiltros();
        }

        private void CarregarDadosBase()
        {
            // Usa a listagem ESPECÍFICA de ENTRADAS do repositório
            _todosMovimentosEntrada = _repoMovimentos
                .ListarEntradas()
                .OrderByDescending(m => m.Data)
                .ThenByDescending(m => m.Id)
                .ToList();

            // Produtos e categorias só para preencher combos (não mexe em estoque)
            _produtos = _repoProdutos.Listar();
            _categorias = _repoCategorias.Listar();
        }

        private void PopularCombos()
        {
            // Produto (filtro por nome de produto)
            var nomesProdutos = _todosMovimentosEntrada
                .Select(m => m.ProdutoNome)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(n => n)
                .ToList();

            nomesProdutos.Insert(0, "[Todos]");
            cboProduto.DataSource = nomesProdutos;

            // Categoria (filtro por categoria)
            var nomesCategorias = _todosMovimentosEntrada
                .Select(m => m.Categoria)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(n => n)
                .ToList();

            nomesCategorias.Insert(0, "[Todas]");
            cboCategoria.DataSource = nomesCategorias;
        }

        private void BtnFiltrar_Click(object? sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            dtpFim.Value = DateTime.Today;
            dtpInicio.Value = DateTime.Today.AddDays(-30);

            if (cboProduto.Items.Count > 0)
                cboProduto.SelectedIndex = 0;

            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;

            AplicarFiltros();
        }

        private void BtnFechar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void AplicarFiltros()
        {
            if (_todosMovimentosEntrada.Count == 0)
            {
                dgvMovimentos.DataSource = null;
                return;
            }

            DateTime inicio = dtpInicio.Value.Date;
            DateTime fim = dtpFim.Value.Date;

            if (fim < inicio)
                fim = inicio;

            var query = _todosMovimentosEntrada.AsEnumerable();

            // Filtro por período (inclusive)
            query = query.Where(m => m.Data.Date >= inicio && m.Data.Date <= fim);

            // Filtro por produto (nome exato da lista)
            if (cboProduto.SelectedIndex > 0)
            {
                string prod = cboProduto.SelectedItem?.ToString() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(prod))
                    query = query.Where(m =>
                        string.Equals(m.ProdutoNome, prod, StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por categoria
            if (cboCategoria.SelectedIndex > 0)
            {
                string cat = cboCategoria.SelectedItem?.ToString() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(cat))
                    query = query.Where(m =>
                        string.Equals(m.Categoria, cat, StringComparison.OrdinalIgnoreCase));
            }

            var listaFiltrada = query
                .OrderByDescending(m => m.Data)
                .ThenByDescending(m => m.Id)
                .ToList();

            dgvMovimentos.DataSource = listaFiltrada;
        }
    }
}
