// Models/Fornecedor.cs
using System;

namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.fornecedor
    /// </summary>
    public class Fornecedor
    {
        public int idfornecedor { get; set; }

        public string? nome { get; set; }

        public string? nomefornecedor { get; set; }

        public string? CNPJ { get; set; }

        public string? inscricao_estadual { get; set; }

        public string? telefone { get; set; }

        public string? email { get; set; }

        public string? site { get; set; }
    }
}
