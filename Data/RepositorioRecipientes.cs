// Data/RepositorioRecipientes.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioRecipientes
    {
        public List<Recipiente> Listar()
        {
            var lista = new List<Recipiente>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idrecipiente, nome FROM dbo.recipiente ORDER BY nome";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var recipiente = new Recipiente
                        {
                            idrecipiente = (int)reader["idrecipiente"],
                            nome = (string)reader["nome"]
                        };
                        lista.Add(recipiente);
                    }
                }
            }

            return lista;
        }

        public Recipiente? BuscarPorId(int idrecipiente)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idrecipiente, nome FROM dbo.recipiente WHERE idrecipiente = @idrecipiente";
                cmd.Parameters.AddWithValue("@idrecipiente", idrecipiente);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new Recipiente
                    {
                        idrecipiente = (int)reader["idrecipiente"],
                        nome = (string)reader["nome"]
                    };
                }
            }
        }

        public int Inserir(Recipiente recipiente)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.recipiente (nome)
VALUES (@nome);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@nome", recipiente.nome);

                var id = (int)cmd.ExecuteScalar();
                recipiente.idrecipiente = id;
                return id;
            }
        }

        public void Atualizar(Recipiente recipiente)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.recipiente
   SET nome = @nome
 WHERE idrecipiente = @idrecipiente;";

                cmd.Parameters.AddWithValue("@nome", recipiente.nome);
                cmd.Parameters.AddWithValue("@idrecipiente", recipiente.idrecipiente);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int idrecipiente)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.recipiente WHERE idrecipiente = @idrecipiente";
                cmd.Parameters.AddWithValue("@idrecipiente", idrecipiente);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
