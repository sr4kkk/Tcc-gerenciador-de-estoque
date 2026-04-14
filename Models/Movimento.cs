// Models/Movimento.cs
using System;

namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.Movimentos
    /// </summary>
    public class Movimento
    {
        public int Id { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public Guid? ProdutoId { get; set; }

        public int? CategoriaId { get; set; }

        public int? UnidadeId { get; set; }

        public int? LocalId { get; set; }

        public string ProdutoNome { get; set; } = string.Empty;

        public string? Categoria { get; set; }

        public decimal Quantidade { get; set; }

        public string? Unidade { get; set; }

        public string? Local { get; set; }

        public string? Observacao { get; set; }
    }
}
