using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using alguamcoisa.Utils;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class FornecedorListForm : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioFornecedores _repoFornecedores = new RepositorioFornecedores();
        private List<Fornecedor> _fornecedores = new List<Fornecedor>();

        public FornecedorListForm()
        {
            InitializeComponent();
            GridHelper.ConfigurarGridCompleto(dgvFornecedores);
            Load += FornecedorListForm_Load;

            btnNovo.Click += BtnNovo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnAtualizar.Click += BtnAtualizar_Click;
            btnFechar.Click += BtnFechar_Click;
            txtBusca.TextChanged += TxtBusca_TextChanged;

            // 👉 quando mudar a seleção, atualiza os botões
            dgvFornecedores.SelectionChanged += (s, e) => AtualizarEstadoBotoes();

            // 👉 ao abrir a tela, nenhum fornecedor selecionado e botões desligados
            AtualizarEstadoBotoes();
        }

        private void FornecedorListForm_Load(object? sender, EventArgs e)
        {
            CarregarFornecedores();
        }

        private void CarregarFornecedores()
        {
            _fornecedores = _repoFornecedores.Listar();

            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            string termo = txtBusca.Text.Trim();

            IEnumerable<Fornecedor> consulta = _fornecedores;

            if (!string.IsNullOrWhiteSpace(termo))
            {
                consulta = consulta.Where(f =>
                    (!string.IsNullOrWhiteSpace(f.nome) &&
                     f.nome.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0)
                    ||
                    (!string.IsNullOrWhiteSpace(f.nomefornecedor) &&
                     f.nomefornecedor.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0)
                    ||
                    (!string.IsNullOrWhiteSpace(f.CNPJ) &&
                     f.CNPJ.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            var listaOrdenada = consulta
                .OrderBy(f => f.nome ?? f.nomefornecedor)
                .ToList();

            dgvFornecedores.AutoGenerateColumns = true;
            dgvFornecedores.DataSource = listaOrdenada;
        }

        private void AtualizarEstadoBotoes()
        {
            bool temSelecao = GridHelper.TemLinhaSelecionada(dgvFornecedores);

            btnEditar.Enabled = temSelecao;
            btnExcluir.Enabled = temSelecao;
        }


        private void TxtBusca_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private Fornecedor? ObterFornecedorSelecionado()
        {
            if (dgvFornecedores.CurrentRow == null)
                return null;

            return dgvFornecedores.CurrentRow.DataBoundItem as Fornecedor;
        }

        private void BtnNovo_Click(object? sender, EventArgs e)
        {
            using (var frm = new CadastrarFornecedor())
            {
                if (frm.ShowDialog(this) == DialogResult.OK && frm.FornecedorSalvo != null)
                {
                    // Adiciona na lista e recarrega
                    _fornecedores.Add(frm.FornecedorSalvo);
                    AplicarFiltro();
                }
            }
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            var selecionado = ObterFornecedorSelecionado();
            if (selecionado == null)
            {
                MessageBox.Show(
                    "Selecione um fornecedor para editar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Busca versão mais atual no banco
            var fornecedorAtual = _repoFornecedores.BuscarPorId(selecionado.idfornecedor);
            if (fornecedorAtual == null)
            {
                MessageBox.Show(
                    "Fornecedor não encontrado no banco de dados.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                CarregarFornecedores();
                return;
            }

            using (var frm = new CadastrarFornecedor(fornecedorAtual))
            {
                if (frm.ShowDialog(this) == DialogResult.OK && frm.FornecedorSalvo != null)
                {
                    // Atualiza na lista em memória
                    var idx = _fornecedores.FindIndex(f => f.idfornecedor == fornecedorAtual.idfornecedor);
                    if (idx >= 0)
                        _fornecedores[idx] = frm.FornecedorSalvo;

                    AplicarFiltro();
                }
            }
        }

        private void BtnExcluir_Click(object? sender, EventArgs e)
        {
            var selecionado = ObterFornecedorSelecionado();
            if (selecionado == null)
            {
                MessageBox.Show(
                    "Selecione um fornecedor para excluir.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var resposta = MessageBox.Show(
                $"Confirma a exclusão do fornecedor:\n{selecionado.nomefornecedor ?? selecionado.nome}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                _repoFornecedores.Excluir(selecionado.idfornecedor);

                _fornecedores.RemoveAll(f => f.idfornecedor == selecionado.idfornecedor);
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir fornecedor:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizar_Click(object? sender, EventArgs e)
        {
            CarregarFornecedores();
        }

        private void BtnFechar_Click(object? sender, EventArgs e)
        {
            Close();
        }

   
    }
}
