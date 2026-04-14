// Data/RepositorioUnidadesMedida.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioUnidadesMedida
    {
        public List<UnidadeMedida> Listar()
        {
            var lista = new List<UnidadeMedida>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idum, unidademedida FROM dbo.unidademedida ORDER BY unidademedida";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var unidade = new UnidadeMedida
                        {
                            idum = (int)reader["idum"],
                            unidademedida = (string)reader["unidademedida"]
                        };
                        lista.Add(unidade);
                    }
                }
            }

            return lista;
        }

        public UnidadeMedida? BuscarPorId(int idum)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idum, unidademedida FROM dbo.unidademedida WHERE idum = @idum";
                cmd.Parameters.AddWithValue("@idum", idum);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new UnidadeMedida
                    {
                        idum = (int)reader["idum"],
                        unidademedida = (string)reader["unidademedida"]
                    };
                }
            }
        }

        public int Inserir(UnidadeMedida unidade)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.unidademedida (unidademedida)
VALUES (@unidademedida);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@unidademedida", unidade.unidademedida);

                var id = (int)cmd.ExecuteScalar();
                unidade.idum = id;
                return id;
            }
        }

        public void Atualizar(UnidadeMedida unidade)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.unidademedida
   SET unidademedida = @unidademedida
 WHERE idum = @idum;";

                cmd.Parameters.AddWithValue("@unidademedida", unidade.unidademedida);
                cmd.Parameters.AddWithValue("@idum", unidade.idum);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int idum)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.unidademedida WHERE idum = @idum";
                cmd.Parameters.AddWithValue("@idum", idum);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
