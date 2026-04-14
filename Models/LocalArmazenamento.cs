// Models/LocalArmazenamento.cs
namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.LocaisArmazenamento
    /// </summary>
    public class LocalArmazenamento
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
    }
}
