// Data/RepositorioEstadosFisicos.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioEstadosFisicos
    {
        public List<EstadoFisico> Listar()
        {
            var lista = new List<EstadoFisico>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idE, estado FROM dbo.estado ORDER BY estado";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var estado = new EstadoFisico
                        {
                            idE = (int)reader["idE"],
                            estado = (string)reader["estado"]
                        };
                        lista.Add(estado);
                    }
                }
            }

            return lista;
        }

        public EstadoFisico? BuscarPorId(int idE)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT idE, estado FROM dbo.estado WHERE idE = @idE";
                cmd.Parameters.AddWithValue("@idE", idE);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new EstadoFisico
                    {
                        idE = (int)reader["idE"],
                        estado = (string)reader["estado"]
                    };
                }
            }
        }

        public int Inserir(EstadoFisico estadoFisico)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.estado (estado)
VALUES (@estado);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@estado", estadoFisico.estado);

                var id = (int)cmd.ExecuteScalar();
                estadoFisico.idE = id;
                return id;
            }
        }

        public void Atualizar(EstadoFisico estadoFisico)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.estado
   SET estado = @estado
 WHERE idE = @idE;";

                cmd.Parameters.AddWithValue("@estado", estadoFisico.estado);
                cmd.Parameters.AddWithValue("@idE", estadoFisico.idE);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int idE)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.estado WHERE idE = @idE";
                cmd.Parameters.AddWithValue("@idE", idE);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
