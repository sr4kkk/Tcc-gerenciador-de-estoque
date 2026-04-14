// Models/Admin.cs
using System;

namespace EstoqueQuimico.Models
{
    /// <summary>
    /// Representa a tabela dbo.Admins
    /// </summary>
    public class Admin
    {
        public int IdAdmin { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; }
    }
}
