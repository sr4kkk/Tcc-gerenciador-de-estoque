// Data/RepositorioCategorias.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioCategorias
    {
        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Nome FROM dbo.Categorias ORDER BY Nome";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoria = new Categoria
                        {
                            Id = (int)reader["Id"],
                            Nome = (string)reader["Nome"]
                        };
                        lista.Add(categoria);
                    }
                }
            }

            return lista;
        }

        public Categoria? BuscarPorId(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Nome FROM dbo.Categorias WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new Categoria
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"]
                    };
                }
            }
        }

        public int Inserir(Categoria categoria)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.Categorias (Nome)
VALUES (@Nome);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);

                var id = (int)cmd.ExecuteScalar();
                categoria.Id = id;
                return id;
            }
        }

        public void Atualizar(Categoria categoria)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.Categorias
   SET Nome = @Nome
 WHERE Id = @Id;";

                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);
                cmd.Parameters.AddWithValue("@Id", categoria.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.Categorias WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
