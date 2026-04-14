// Models/UnidadeMedida.cs
namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.unidademedida
    /// </summary>
    public class UnidadeMedida
    {
        public int idum { get; set; }

        public string unidademedida { get; set; } = string.Empty;
    }
}
