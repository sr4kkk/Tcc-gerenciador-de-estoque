// Models/LocalEspecifico.cs
namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.LocaisEspecificos
    /// </summary>
    public class LocalEspecifico
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
    }
}
