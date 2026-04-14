// Data/RepositorioFornecedores.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioFornecedores
    {
        private object ToDbNull(string? valor) =>
            string.IsNullOrWhiteSpace(valor) ? DBNull.Value : valor;

        public List<Fornecedor> Listar()
        {
            var lista = new List<Fornecedor>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT idfornecedor,
       nome,
       nomefornecedor,
       CNPJ,
       inscricao_estadual,
       telefone,
       email,
       site
  FROM dbo.fornecedor
 ORDER BY nomefornecedor, nome;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var f = new Fornecedor
                        {
                            idfornecedor = (int)reader["idfornecedor"],
                            nome = reader["nome"] as string,
                            nomefornecedor = reader["nomefornecedor"] as string,
                            CNPJ = reader["CNPJ"] as string,
                            inscricao_estadual = reader["inscricao_estadual"] as string,
                            telefone = reader["telefone"] as string,
                            email = reader["email"] as string,
                            site = reader["site"] as string
                        };
                        lista.Add(f);
                    }
                }
            }

            return lista;
        }

        public Fornecedor? BuscarPorId(int idfornecedor)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT idfornecedor,
       nome,
       nomefornecedor,
       CNPJ,
       inscricao_estadual,
       telefone,
       email,
       site
  FROM dbo.fornecedor
 WHERE idfornecedor = @idfornecedor;";

                cmd.Parameters.AddWithValue("@idfornecedor", idfornecedor);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new Fornecedor
                    {
                        idfornecedor = (int)reader["idfornecedor"],
                        nome = reader["nome"] as string,
                        nomefornecedor = reader["nomefornecedor"] as string,
                        CNPJ = reader["CNPJ"] as string,
                        inscricao_estadual = reader["inscricao_estadual"] as string,
                        telefone = reader["telefone"] as string,
                        email = reader["email"] as string,
                        site = reader["site"] as string
                    };
                }
            }
        }

        public int Inserir(Fornecedor fornecedor)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.fornecedor
    (nome, nomefornecedor, CNPJ, inscricao_estadual, telefone, email, site)
VALUES
    (@nome, @nomefornecedor, @CNPJ, @inscricao_estadual, @telefone, @email, @site);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@nome", ToDbNull(fornecedor.nome));
                cmd.Parameters.AddWithValue("@nomefornecedor", ToDbNull(fornecedor.nomefornecedor));
                cmd.Parameters.AddWithValue("@CNPJ", ToDbNull(fornecedor.CNPJ));
                cmd.Parameters.AddWithValue("@inscricao_estadual", ToDbNull(fornecedor.inscricao_estadual));
                cmd.Parameters.AddWithValue("@telefone", ToDbNull(fornecedor.telefone));
                cmd.Parameters.AddWithValue("@email", ToDbNull(fornecedor.email));
                cmd.Parameters.AddWithValue("@site", ToDbNull(fornecedor.site));

                var id = (int)cmd.ExecuteScalar();
                fornecedor.idfornecedor = id;
                return id;
            }
        }

        public void Atualizar(Fornecedor fornecedor)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.fornecedor
   SET nome               = @nome,
       nomefornecedor     = @nomefornecedor,
       CNPJ               = @CNPJ,
       inscricao_estadual = @inscricao_estadual,
       telefone           = @telefone,
       email              = @email,
       site               = @site
 WHERE idfornecedor       = @idfornecedor;";

                cmd.Parameters.AddWithValue("@idfornecedor", fornecedor.idfornecedor);
                cmd.Parameters.AddWithValue("@nome", ToDbNull(fornecedor.nome));
                cmd.Parameters.AddWithValue("@nomefornecedor", ToDbNull(fornecedor.nomefornecedor));
                cmd.Parameters.AddWithValue("@CNPJ", ToDbNull(fornecedor.CNPJ));
                cmd.Parameters.AddWithValue("@inscricao_estadual", ToDbNull(fornecedor.inscricao_estadual));
                cmd.Parameters.AddWithValue("@telefone", ToDbNull(fornecedor.telefone));
                cmd.Parameters.AddWithValue("@email", ToDbNull(fornecedor.email));
                cmd.Parameters.AddWithValue("@site", ToDbNull(fornecedor.site));

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int idfornecedor)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.fornecedor WHERE idfornecedor = @idfornecedor";
                cmd.Parameters.AddWithValue("@idfornecedor", idfornecedor);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
