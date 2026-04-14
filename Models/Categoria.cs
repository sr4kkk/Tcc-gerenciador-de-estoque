// Models/Categoria.cs
namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.Categorias
    /// </summary>
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
    }
}
