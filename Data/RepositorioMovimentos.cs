// Data/RepositorioMovimentos.cs
using alguamcoisa.Data;
using EstoqueQuimico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EstoqueQuimico.Data
{
    public class RepositorioMovimentos
    {
        private object ToDbNull(object? valor) =>
            valor ?? DBNull.Value;

        public List<Movimento> Listar()
        {
            var lista = new List<Movimento>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT Id,
       Tipo,
       Data,
       ProdutoId,
       CategoriaId,
       UnidadeId,
       LocalId,
       ProdutoNome,
       Categoria,
       Quantidade,
       Unidade,
       Local,
       Observacao
  FROM dbo.Movimentos
 ORDER BY Data DESC, Id DESC;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var m = new Movimento
                        {
                            Id = (int)reader["Id"],
                            Tipo = (string)reader["Tipo"],
                            Data = (DateTime)reader["Data"],
                            ProdutoId = reader["ProdutoId"] != DBNull.Value ? (Guid?)reader["ProdutoId"] : null,
                            CategoriaId = reader["CategoriaId"] != DBNull.Value ? (int?)reader["CategoriaId"] : null,
                            UnidadeId = reader["UnidadeId"] != DBNull.Value ? (int?)reader["UnidadeId"] : null,
                            LocalId = reader["LocalId"] != DBNull.Value ? (int?)reader["LocalId"] : null,
                            ProdutoNome = (string)reader["ProdutoNome"],
                            Categoria = reader["Categoria"] as string,
                            Quantidade = (decimal)reader["Quantidade"],
                            Unidade = reader["Unidade"] as string,
                            Local = reader["Local"] as string,
                            Observacao = reader["Observacao"] as string
                        };

                        lista.Add(m);
                    }
                }
            }

            return lista;
        }

        public Movimento? BuscarPorId(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT Id,
       Tipo,
       Data,
       ProdutoId,
       CategoriaId,
       UnidadeId,
       LocalId,
       ProdutoNome,
       Categoria,
       Quantidade,
       Unidade,
       Local,
       Observacao
  FROM dbo.Movimentos
 WHERE Id = @Id;";

                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new Movimento
                    {
                        Id = (int)reader["Id"],
                        Tipo = (string)reader["Tipo"],
                        Data = (DateTime)reader["Data"],
                        ProdutoId = reader["ProdutoId"] != DBNull.Value ? (Guid?)reader["ProdutoId"] : null,
                        CategoriaId = reader["CategoriaId"] != DBNull.Value ? (int?)reader["CategoriaId"] : null,
                        UnidadeId = reader["UnidadeId"] != DBNull.Value ? (int?)reader["UnidadeId"] : null,
                        LocalId = reader["LocalId"] != DBNull.Value ? (int?)reader["LocalId"] : null,
                        ProdutoNome = (string)reader["ProdutoNome"],
                        Categoria = reader["Categoria"] as string,
                        Quantidade = (decimal)reader["Quantidade"],
                        Unidade = reader["Unidade"] as string,
                        Local = reader["Local"] as string,
                        Observacao = reader["Observacao"] as string
                    };
                }
            }
        }

        public int Inserir(Movimento movimento)
        {
            if (movimento.Data == default)
                movimento.Data = DateTime.Now;

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.Movimentos
    (Tipo, Data, ProdutoId, CategoriaId, UnidadeId, LocalId,
     ProdutoNome, Categoria, Quantidade, Unidade, Local, Observacao)
VALUES
    (@Tipo, @Data, @ProdutoId, @CategoriaId, @UnidadeId, @LocalId,
     @ProdutoNome, @Categoria, @Quantidade, @Unidade, @Local, @Observacao);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@Tipo", movimento.Tipo);
                cmd.Parameters.AddWithValue("@Data", movimento.Data);
                cmd.Parameters.AddWithValue("@ProdutoId", ToDbNull(movimento.ProdutoId));
                cmd.Parameters.AddWithValue("@CategoriaId", ToDbNull(movimento.CategoriaId));
                cmd.Parameters.AddWithValue("@UnidadeId", ToDbNull(movimento.UnidadeId));
                cmd.Parameters.AddWithValue("@LocalId", ToDbNull(movimento.LocalId));
                cmd.Parameters.AddWithValue("@ProdutoNome", movimento.ProdutoNome);
                cmd.Parameters.AddWithValue("@Categoria", ToDbNull(movimento.Categoria));
                cmd.Parameters.AddWithValue("@Quantidade", movimento.Quantidade);
                cmd.Parameters.AddWithValue("@Unidade", ToDbNull(movimento.Unidade));
                cmd.Parameters.AddWithValue("@Local", ToDbNull(movimento.Local));
                cmd.Parameters.AddWithValue("@Observacao", ToDbNull(movimento.Observacao));

                var id = (int)cmd.ExecuteScalar();
                movimento.Id = id;
                return id;
            }
        }

        public void Atualizar(Movimento movimento)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.Movimentos
   SET Tipo        = @Tipo,
       Data        = @Data,
       ProdutoId   = @ProdutoId,
       CategoriaId = @CategoriaId,
       UnidadeId   = @UnidadeId,
       LocalId     = @LocalId,
       ProdutoNome = @ProdutoNome,
       Categoria   = @Categoria,
       Quantidade  = @Quantidade,
       Unidade     = @Unidade,
       Local       = @Local,
       Observacao  = @Observacao
 WHERE Id          = @Id;";

                cmd.Parameters.AddWithValue("@Id", movimento.Id);
                cmd.Parameters.AddWithValue("@Tipo", movimento.Tipo);
                cmd.Parameters.AddWithValue("@Data", movimento.Data);
                cmd.Parameters.AddWithValue("@ProdutoId", ToDbNull(movimento.ProdutoId));
                cmd.Parameters.AddWithValue("@CategoriaId", ToDbNull(movimento.CategoriaId));
                cmd.Parameters.AddWithValue("@UnidadeId", ToDbNull(movimento.UnidadeId));
                cmd.Parameters.AddWithValue("@LocalId", ToDbNull(movimento.LocalId));
                cmd.Parameters.AddWithValue("@ProdutoNome", movimento.ProdutoNome);
                cmd.Parameters.AddWithValue("@Categoria", ToDbNull(movimento.Categoria));
                cmd.Parameters.AddWithValue("@Quantidade", movimento.Quantidade);
                cmd.Parameters.AddWithValue("@Unidade", ToDbNull(movimento.Unidade));
                cmd.Parameters.AddWithValue("@Local", ToDbNull(movimento.Local));
                cmd.Parameters.AddWithValue("@Observacao", ToDbNull(movimento.Observacao));

                cmd.ExecuteNonQuery();
            }
        }

        // --------------------------------------------------------------------
        //  LISTAGENS ESPECÍFICAS (ENTRADAS / SAÍDAS / POR FORNECEDOR)
        // --------------------------------------------------------------------

        /// <summary>
        /// Lista movimentos filtrando pelo Tipo (ex: "Entrada", "Saída").
        /// </summary>
        public List<Movimento> ListarPorTipo(string tipo)
        {
            var lista = new List<Movimento>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT Id,
       Tipo,
       Data,
       ProdutoId,
       CategoriaId,
       UnidadeId,
       LocalId,
       ProdutoNome,
       Categoria,
       Quantidade,
       Unidade,
       Local,
       Observacao
  FROM dbo.Movimentos
 WHERE Tipo = @Tipo
 ORDER BY Data DESC, Id DESC;";

                cmd.Parameters.AddWithValue("@Tipo", tipo);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var m = new Movimento
                        {
                            Id = (int)reader["Id"],
                            Tipo = (string)reader["Tipo"],
                            Data = (DateTime)reader["Data"],
                            ProdutoId = reader["ProdutoId"] != DBNull.Value ? (Guid?)reader["ProdutoId"] : null,
                            CategoriaId = reader["CategoriaId"] != DBNull.Value ? (int?)reader["CategoriaId"] : null,
                            UnidadeId = reader["UnidadeId"] != DBNull.Value ? (int?)reader["UnidadeId"] : null,
                            LocalId = reader["LocalId"] != DBNull.Value ? (int?)reader["LocalId"] : null,
                            ProdutoNome = (string)reader["ProdutoNome"],
                            Categoria = reader["Categoria"] as string,
                            Quantidade = (decimal)reader["Quantidade"],
                            Unidade = reader["Unidade"] as string,
                            Local = reader["Local"] as string,
                            Observacao = reader["Observacao"] as string
                        };

                        lista.Add(m);
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Lista apenas movimentos de ENTRADA.
        /// </summary>
        public List<Movimento> ListarEntradas()
        {
            return ListarPorTipo("Entrada");
        }

        /// <summary>
        /// Lista apenas movimentos de SAÍDA.
        /// </summary>
        public List<Movimento> ListarSaidas()
        {
            return ListarPorTipo("Saída");
        }

        /// <summary>
        /// Lista movimentos relacionados a um fornecedor específico.
        /// Usa o vínculo ProdutoId -> Produtos.FornecedorId.
        /// </summary>
        public List<Movimento> ListarPorFornecedor(int fornecedorId)
        {
            var lista = new List<Movimento>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT m.Id,
       m.Tipo,
       m.Data,
       m.ProdutoId,
       m.CategoriaId,
       m.UnidadeId,
       m.LocalId,
       m.ProdutoNome,
       m.Categoria,
       m.Quantidade,
       m.Unidade,
       m.Local,
       m.Observacao
  FROM dbo.Movimentos m
  LEFT JOIN dbo.Produtos p ON p.Id = m.ProdutoId
 WHERE p.FornecedorId = @FornecedorId
 ORDER BY m.Data DESC, m.Id DESC;";

                cmd.Parameters.AddWithValue("@FornecedorId", fornecedorId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var m = new Movimento
                        {
                            Id = (int)reader["Id"],
                            Tipo = (string)reader["Tipo"],
                            Data = (DateTime)reader["Data"],
                            ProdutoId = reader["ProdutoId"] != DBNull.Value ? (Guid?)reader["ProdutoId"] : null,
                            CategoriaId = reader["CategoriaId"] != DBNull.Value ? (int?)reader["CategoriaId"] : null,
                            UnidadeId = reader["UnidadeId"] != DBNull.Value ? (int?)reader["UnidadeId"] : null,
                            LocalId = reader["LocalId"] != DBNull.Value ? (int?)reader["LocalId"] : null,
                            ProdutoNome = (string)reader["ProdutoNome"],
                            Categoria = reader["Categoria"] as string,
                            Quantidade = (decimal)reader["Quantidade"],
                            Unidade = reader["Unidade"] as string,
                            Local = reader["Local"] as string,
                            Observacao = reader["Observacao"] as string
                        };

                        lista.Add(m);
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Verifica se existe pelo menos um movimento associado a um produto.
        /// Usado para impedir a exclusão de produtos com histórico de estoque.
        /// </summary>
        public bool ExisteMovimentoParaProduto(Guid produtoId)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT TOP 1 1
  FROM dbo.Movimentos
 WHERE ProdutoId = @ProdutoId;";
                cmd.Parameters.AddWithValue("@ProdutoId", produtoId);

                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value;
            }
        }

        public void Excluir(int id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.Movimentos WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
