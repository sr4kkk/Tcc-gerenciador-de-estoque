// Models/Recipiente.cs
namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.recipiente
    /// </summary>
    public class Recipiente
    {
        public int idrecipiente { get; set; }

        public string nome { get; set; } = string.Empty;
    }
}
