using System;
using System.Windows.Forms;
using alguamcoisa.Utils;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace alguamcoisa
{
    public partial class CadastrarFornecedor : alguamcoisa.Utils.ThemedForm
    {
        private readonly RepositorioFornecedores _repoFornecedores = new RepositorioFornecedores();

        private readonly bool _modoEdicao;
        private readonly Fornecedor _fornecedor;

        /// <summary>
        /// Fornecedor que foi salvo (inserido ou atualizado).
        /// </summary>
        public Fornecedor? FornecedorSalvo { get; private set; }

        public CadastrarFornecedor() : this(null)
        {
        }

        public CadastrarFornecedor(Fornecedor? fornecedor)
        {
            InitializeComponent();
            AppTheme.Apply(this);

            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            if (fornecedor == null)
            {
                _modoEdicao = false;
                _fornecedor = new Fornecedor();
                Text = "Cadastro de Fornecedor";
            }
            else
            {
                _modoEdicao = true;
                _fornecedor = fornecedor;
                Text = "Editar Fornecedor";
                PreencherCampos(_fornecedor);
            }
        }

        private void PreencherCampos(Fornecedor f)
        {
            txtNome.Text = f.nome ?? string.Empty;
            txtNomeFornecedor.Text = f.nomefornecedor ?? string.Empty;
            txtCnpj.Text = f.CNPJ ?? string.Empty;
            txtInscricaoEstadual.Text = f.inscricao_estadual ?? string.Empty;
            txtTelefone.Text = f.telefone ?? string.Empty;
            txtEmail.Text = f.email ?? string.Empty;
            txtSite.Text = f.site ?? string.Empty;
        }

        private bool LerCamposFormulario()
        {
            var nome = txtNome.Text.Trim();
            var nomeFornecedor = txtNomeFornecedor.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(nomeFornecedor))
            {
                MessageBox.Show(
                    "Informe pelo menos o campo Nome ou Nome do Fornecedor.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNome.Focus();
                return false;
            }

            _fornecedor.nome = string.IsNullOrWhiteSpace(nome) ? null : nome;
            _fornecedor.nomefornecedor = string.IsNullOrWhiteSpace(nomeFornecedor) ? null : nomeFornecedor;
            _fornecedor.CNPJ = string.IsNullOrWhiteSpace(txtCnpj.Text) ? null : txtCnpj.Text.Trim();
            _fornecedor.inscricao_estadual = string.IsNullOrWhiteSpace(txtInscricaoEstadual.Text) ? null : txtInscricaoEstadual.Text.Trim();
            _fornecedor.telefone = string.IsNullOrWhiteSpace(txtTelefone.Text) ? null : txtTelefone.Text.Trim();
            _fornecedor.email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            _fornecedor.site = string.IsNullOrWhiteSpace(txtSite.Text) ? null : txtSite.Text.Trim();

            return true;
        }

        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            if (!LerCamposFormulario())
                return;

            try
            {
                if (_modoEdicao)
                {
                    _repoFornecedores.Atualizar(_fornecedor);
                }
                else
                {
                    // Retorna e preenche idfornecedor
                    _repoFornecedores.Inserir(_fornecedor);
                }

                FornecedorSalvo = _fornecedor;

                MessageBox.Show(
                    "Fornecedor salvo com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar fornecedor:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
