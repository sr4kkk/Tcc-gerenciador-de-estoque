// Models/EstadoFisico.cs
namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.estado
    /// </summary>
    public class EstadoFisico
    {
        public int idE { get; set; }

        public string estado { get; set; } = string.Empty;
    }
}
