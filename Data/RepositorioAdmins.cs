// Data/RepositorioAdmins.cs
using alguamcoisa.Data;
using EstoqueQuimico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EstoqueQuimico.Data
{
    /// <summary>
    /// Repositório para a tabela dbo.Admins
    /// </summary>
    public class RepositorioAdmins
    {
        private object ToDbNull(string? valor) =>
            string.IsNullOrWhiteSpace(valor) ? DBNull.Value : valor;

        // ================================================
        // LISTAR TODOS
        // ================================================
        public List<Admin> Listar()
        {
            var lista = new List<Admin>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT IdAdmin,
       Nome,
       Email,
       PasswordHash,
       CriadoEm
  FROM dbo.Admins
 ORDER BY Nome;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var admin = new Admin
                        {
                            IdAdmin = (int)reader["IdAdmin"],
                            Nome = (string)reader["Nome"],
                            Email = (string)reader["Email"],
                            PasswordHash = (string)reader["PasswordHash"],
                            CriadoEm = (DateTime)reader["CriadoEm"]
                        };

                        lista.Add(admin);
                    }
                }
            }

            return lista;
        }

        // ================================================
        // BUSCAR POR ID
        // ================================================
        public Admin? BuscarPorId(int idAdmin)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT IdAdmin,
       Nome,
       Email,
       PasswordHash,
       CriadoEm
  FROM dbo.Admins
 WHERE IdAdmin = @IdAdmin;";

                cmd.Parameters.AddWithValue("@IdAdmin", idAdmin);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Admin
                    {
                        IdAdmin = (int)reader["IdAdmin"],
                        Nome = (string)reader["Nome"],
                        Email = (string)reader["Email"],
                        PasswordHash = (string)reader["PasswordHash"],
                        CriadoEm = (DateTime)reader["CriadoEm"]
                    };
                }
            }
        }

        // ================================================
        // BUSCAR POR EMAIL
        // ================================================
        public Admin? BuscarPorEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT IdAdmin,
       Nome,
       Email,
       PasswordHash,
       CriadoEm
  FROM dbo.Admins
 WHERE Email = @Email;";

                cmd.Parameters.AddWithValue("@Email", email);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Admin
                    {
                        IdAdmin = (int)reader["IdAdmin"],
                        Nome = (string)reader["Nome"],
                        Email = (string)reader["Email"],
                        PasswordHash = (string)reader["PasswordHash"],
                        CriadoEm = (DateTime)reader["CriadoEm"]
                    };
                }
            }
        }

        // ================================================
        // INSERIR
        // ================================================
        public int Inserir(Admin admin)
        {
            if (admin == null) throw new ArgumentNullException(nameof(admin));

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.Admins (Nome, Email, PasswordHash)
VALUES (@Nome, @Email, @PasswordHash);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@Nome", ToDbNull(admin.Nome));
                cmd.Parameters.AddWithValue("@Email", ToDbNull(admin.Email));
                cmd.Parameters.AddWithValue("@PasswordHash", ToDbNull(admin.PasswordHash));

                var id = (int)cmd.ExecuteScalar();
                admin.IdAdmin = id;
                return id;
            }
        }

        // ================================================
        // ATUALIZAR
        // ================================================
        public void Atualizar(Admin admin)
        {
            if (admin == null) throw new ArgumentNullException(nameof(admin));
            if (admin.IdAdmin <= 0) throw new ArgumentException("IdAdmin inválido para atualização.", nameof(admin));

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.Admins
   SET Nome         = @Nome,
       Email        = @Email,
       PasswordHash = @PasswordHash
 WHERE IdAdmin      = @IdAdmin;";

                cmd.Parameters.AddWithValue("@IdAdmin", admin.IdAdmin);
                cmd.Parameters.AddWithValue("@Nome", ToDbNull(admin.Nome));
                cmd.Parameters.AddWithValue("@Email", ToDbNull(admin.Email));
                cmd.Parameters.AddWithValue("@PasswordHash", ToDbNull(admin.PasswordHash));

                cmd.ExecuteNonQuery();
            }
        }

        // ================================================
        // EXCLUIR
        // ================================================
        public void Excluir(int idAdmin)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.Admins WHERE IdAdmin = @IdAdmin;";
                cmd.Parameters.AddWithValue("@IdAdmin", idAdmin);
                cmd.ExecuteNonQuery();
            }
        }

        // ================================================
        // EXISTE ALGUM ADMIN?
        // ================================================
        public bool ExisteAlgumAdmin()
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP (1) 1 FROM dbo.Admins;";
                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value;
            }
        }
    }
}
