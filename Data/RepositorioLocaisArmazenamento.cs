// Data/RepositorioLocaisArmazenamento.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioLocaisArmazenamento
    {
        public List<LocalArmazenamento> Listar()
        {
            var lista = new List<LocalArmazenamento>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Nome FROM dbo.LocaisArmazenamento ORDER BY Nome";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var local = new LocalArmazenamento
                        {
                            Id = (int)reader["Id"],
                            Nome = (string)reader["Nome"]
                        };
                        lista.Add(local);
                    }
                }
            }

            return lista;
        }

        public LocalArmazenamento? BuscarPorId(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Nome FROM dbo.LocaisArmazenamento WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new LocalArmazenamento
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"]
                    };
                }
            }
        }

        public int Inserir(LocalArmazenamento local)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.LocaisArmazenamento (Nome)
VALUES (@Nome);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@Nome", local.Nome);

                var id = (int)cmd.ExecuteScalar();
                local.Id = id;
                return id;
            }
        }

        public void Atualizar(LocalArmazenamento local)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.LocaisArmazenamento
   SET Nome = @Nome
 WHERE Id = @Id;";

                cmd.Parameters.AddWithValue("@Nome", local.Nome);
                cmd.Parameters.AddWithValue("@Id", local.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.LocaisArmazenamento WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
