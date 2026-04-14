// Models/Professor.cs
using System;

namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.Professores
    /// </summary>
    public class Professor
    {
        public int IdProfessor { get; set; }

        public string NomeProfessor { get; set; } = string.Empty;

        public string? MatriculaProfessor { get; set; }

        public string? EmailProfessor { get; set; }

        public string? TelefoneProfessor { get; set; }

        public string? DepartamentoProfessor { get; set; }

        public string? ObservacaoProfessor { get; set; }

        public string? CPFProfessor { get; set; }

        public string? PasswordHash { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
