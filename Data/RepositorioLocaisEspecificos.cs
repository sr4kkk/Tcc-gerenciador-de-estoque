// Data/RepositorioLocaisEspecificos.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioLocaisEspecificos
    {
        public List<LocalEspecifico> Listar()
        {
            var lista = new List<LocalEspecifico>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Nome FROM dbo.LocaisEspecificos ORDER BY Nome";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var local = new LocalEspecifico
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

        public LocalEspecifico? BuscarPorId(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Nome FROM dbo.LocaisEspecificos WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new LocalEspecifico
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"]
                    };
                }
            }
        }

        public int Inserir(LocalEspecifico local)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.LocaisEspecificos (Nome)
VALUES (@Nome);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@Nome", local.Nome);

                var id = (int)cmd.ExecuteScalar();
                local.Id = id;
                return id;
            }
        }

        public void Atualizar(LocalEspecifico local)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.LocaisEspecificos
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
                cmd.CommandText = "DELETE FROM dbo.LocaisEspecificos WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
