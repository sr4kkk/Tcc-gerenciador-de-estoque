// Models/Produto.cs
using System;

namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.Produtos
    /// </summary>
    public class Produto
    {
        // PK
        public Guid Id { get; set; }

        // Campos de descrição principal
        public string Nome { get; set; } = string.Empty;

        // Chaves estrangeiras (nullable conforme SQL)
        public int? CategoriaId { get; set; }
        public int? UnidadeId { get; set; }
        public int? LocalId { get; set; }
        public int? EstadoFisicoId { get; set; }
        public int? RecipienteId { get; set; }
        public int? FornecedorId { get; set; }

        // Campos “denormalizados” da própria tabela Produtos
        public string? Categoria { get; set; }

        public decimal Quantidade { get; set; }

        public string? Unidade { get; set; }

        public string? LocalDeposito { get; set; }

        public DateTime? Validade { get; set; }

        public decimal EstoqueMinimo { get; set; }

        public string? Fabricante { get; set; }

        public string? EstadoFisico { get; set; }

        public string? Recipiente { get; set; }

        public DateTime? DataCompra { get; set; }

        public DateTime CriadoEm { get; set; }

        // Campo adicionado posteriormente no script
        public string? LocalEspecifico { get; set; }
    }
}
