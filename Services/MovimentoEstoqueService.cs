using System;
using EstoqueQuimico.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Services
{
    /// <summary>
    /// Serviço responsável por registrar Entradas/Saídas
    /// e atualizar o estoque (dbo.Produtos) via repositórios.
    /// Nenhum acesso SQL direto na UI.
    /// </summary>
    public class MovimentoEstoqueService
    {
        private readonly RepositorioProdutos _repoProdutos;
        private readonly RepositorioMovimentos _repoMovimentos;

        public MovimentoEstoqueService()
        {
            _repoProdutos = new RepositorioProdutos();
            _repoMovimentos = new RepositorioMovimentos();
        }

        public void RegistrarEntrada(Guid produtoId, decimal quantidade, DateTime data, string? observacao)
            => RegistrarMovimentoInterno("Entrada", produtoId, quantidade, data, observacao);

        public void RegistrarSaida(Guid produtoId, decimal quantidade, DateTime data, string? observacao)
            => RegistrarMovimentoInterno("Saída", produtoId, quantidade, data, observacao);

        private void RegistrarMovimentoInterno(
            string tipo,
            Guid produtoId,
            decimal quantidade,
            DateTime data,
            string? observacao)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

            // 1) Busca produto atual no banco
            var produto = _repoProdutos.BuscarPorId(produtoId);
            if (produto == null)
                throw new InvalidOperationException("Produto não encontrado.");

            // 2) Valida saldo para saída
            if (tipo == "Saída" && produto.Quantidade - quantidade < 0)
                throw new InvalidOperationException("Quantidade em estoque insuficiente para saída.");

            if (data == default)
                data = DateTime.Now;

            // 3) Atualiza quantidade do produto
            if (tipo == "Entrada")
                produto.Quantidade += quantidade;
            else
                produto.Quantidade -= quantidade;

            _repoProdutos.Atualizar(produto);

            // 4) Grava movimento em dbo.Movimentos
            var movimento = new Movimento
            {
                Tipo = tipo,
                Data = data,
                ProdutoId = produto.Id,
                CategoriaId = produto.CategoriaId,
                UnidadeId = produto.UnidadeId,
                LocalId = produto.LocalId,
                ProdutoNome = produto.Nome,
                Categoria = produto.Categoria,
                Quantidade = quantidade,
                Unidade = produto.Unidade,
                Local = produto.LocalDeposito,
                Observacao = string.IsNullOrWhiteSpace(observacao) ? null : observacao.Trim()
            };

            _repoMovimentos.Inserir(movimento);
        }
    }
}
