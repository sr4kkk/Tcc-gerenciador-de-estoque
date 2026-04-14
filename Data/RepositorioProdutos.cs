// Data/RepositorioProdutos.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using alguamcoisa.Data;
using EstoqueQuimico.Models;

namespace EstoqueQuimico.Data
{
    public class RepositorioProdutos
    {
        private object ToDbNull(object? valor) =>
            valor ?? DBNull.Value;

        public List<Produto> Listar()
        {
            var lista = new List<Produto>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT Id,
       Nome,
       CategoriaId,
       UnidadeId,
       LocalId,
       EstadoFisicoId,
       RecipienteId,
       FornecedorId,
       Categoria,
       Quantidade,
       Unidade,
       LocalDeposito,
       Validade,
       EstoqueMinimo,
       Fabricante,
       EstadoFisico,
       Recipiente,
       DataCompra,
       CriadoEm,
       LocalEspecifico
  FROM dbo.Produtos
 ORDER BY Nome;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Produto
                        {
                            Id = (Guid)reader["Id"],
                            Nome = (string)reader["Nome"],
                            CategoriaId = reader["CategoriaId"] != DBNull.Value ? (int?)reader["CategoriaId"] : null,
                            UnidadeId = reader["UnidadeId"] != DBNull.Value ? (int?)reader["UnidadeId"] : null,
                            LocalId = reader["LocalId"] != DBNull.Value ? (int?)reader["LocalId"] : null,
                            EstadoFisicoId = reader["EstadoFisicoId"] != DBNull.Value ? (int?)reader["EstadoFisicoId"] : null,
                            RecipienteId = reader["RecipienteId"] != DBNull.Value ? (int?)reader["RecipienteId"] : null,
                            FornecedorId = reader["FornecedorId"] != DBNull.Value ? (int?)reader["FornecedorId"] : null,

                            Categoria = reader["Categoria"] as string,
                            Quantidade = (decimal)reader["Quantidade"],
                            Unidade = reader["Unidade"] as string,
                            LocalDeposito = reader["LocalDeposito"] as string,
                            Validade = reader["Validade"] != DBNull.Value ? (DateTime?)reader["Validade"] : null,
                            EstoqueMinimo = (decimal)reader["EstoqueMinimo"],
                            Fabricante = reader["Fabricante"] as string,
                            EstadoFisico = reader["EstadoFisico"] as string,
                            Recipiente = reader["Recipiente"] as string,
                            DataCompra = reader["DataCompra"] != DBNull.Value ? (DateTime?)reader["DataCompra"] : null,
                            CriadoEm = (DateTime)reader["CriadoEm"],
                            LocalEspecifico = reader["LocalEspecifico"] as string
                        };

                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        public Produto? BuscarPorId(Guid id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT Id,
       Nome,
       CategoriaId,
       UnidadeId,
       LocalId,
       EstadoFisicoId,
       RecipienteId,
       FornecedorId,
       Categoria,
       Quantidade,
       Unidade,
       LocalDeposito,
       Validade,
       EstoqueMinimo,
       Fabricante,
       EstadoFisico,
       Recipiente,
       DataCompra,
       CriadoEm,
       LocalEspecifico
  FROM dbo.Produtos
 WHERE Id = @Id;";

                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new Produto
                    {
                        Id = (Guid)reader["Id"],
                        Nome = (string)reader["Nome"],
                        CategoriaId = reader["CategoriaId"] != DBNull.Value ? (int?)reader["CategoriaId"] : null,
                        UnidadeId = reader["UnidadeId"] != DBNull.Value ? (int?)reader["UnidadeId"] : null,
                        LocalId = reader["LocalId"] != DBNull.Value ? (int?)reader["LocalId"] : null,
                        EstadoFisicoId = reader["EstadoFisicoId"] != DBNull.Value ? (int?)reader["EstadoFisicoId"] : null,
                        RecipienteId = reader["RecipienteId"] != DBNull.Value ? (int?)reader["RecipienteId"] : null,
                        FornecedorId = reader["FornecedorId"] != DBNull.Value ? (int?)reader["FornecedorId"] : null,

                        Categoria = reader["Categoria"] as string,
                        Quantidade = (decimal)reader["Quantidade"],
                        Unidade = reader["Unidade"] as string,
                        LocalDeposito = reader["LocalDeposito"] as string,
                        Validade = reader["Validade"] != DBNull.Value ? (DateTime?)reader["Validade"] : null,
                        EstoqueMinimo = (decimal)reader["EstoqueMinimo"],
                        Fabricante = reader["Fabricante"] as string,
                        EstadoFisico = reader["EstadoFisico"] as string,
                        Recipiente = reader["Recipiente"] as string,
                        DataCompra = reader["DataCompra"] != DBNull.Value ? (DateTime?)reader["DataCompra"] : null,
                        CriadoEm = (DateTime)reader["CriadoEm"],
                        LocalEspecifico = reader["LocalEspecifico"] as string
                    };
                }
            }
        }

        public Guid Inserir(Produto produto)
        {
            if (produto.Id == Guid.Empty)
                produto.Id = Guid.NewGuid();

            if (produto.CriadoEm == default)
                produto.CriadoEm = DateTime.Now;

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO dbo.Produtos
    (Id, Nome, CategoriaId, UnidadeId, LocalId, EstadoFisicoId, RecipienteId, FornecedorId,
     Categoria, Quantidade, Unidade, LocalDeposito, Validade, EstoqueMinimo,
     Fabricante, EstadoFisico, Recipiente, DataCompra, CriadoEm, LocalEspecifico)
VALUES
    (@Id, @Nome, @CategoriaId, @UnidadeId, @LocalId, @EstadoFisicoId, @RecipienteId, @FornecedorId,
     @Categoria, @Quantidade, @Unidade, @LocalDeposito, @Validade, @EstoqueMinimo,
     @Fabricante, @EstadoFisico, @Recipiente, @DataCompra, @CriadoEm, @LocalEspecifico);";

                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@CategoriaId", ToDbNull(produto.CategoriaId));
                cmd.Parameters.AddWithValue("@UnidadeId", ToDbNull(produto.UnidadeId));
                cmd.Parameters.AddWithValue("@LocalId", ToDbNull(produto.LocalId));
                cmd.Parameters.AddWithValue("@EstadoFisicoId", ToDbNull(produto.EstadoFisicoId));
                cmd.Parameters.AddWithValue("@RecipienteId", ToDbNull(produto.RecipienteId));
                cmd.Parameters.AddWithValue("@FornecedorId", ToDbNull(produto.FornecedorId));
                cmd.Parameters.AddWithValue("@Categoria", ToDbNull(produto.Categoria));
                cmd.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("@Unidade", ToDbNull(produto.Unidade));
                cmd.Parameters.AddWithValue("@LocalDeposito", ToDbNull(produto.LocalDeposito));
                cmd.Parameters.AddWithValue("@Validade", ToDbNull(produto.Validade));
                cmd.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                cmd.Parameters.AddWithValue("@Fabricante", ToDbNull(produto.Fabricante));
                cmd.Parameters.AddWithValue("@EstadoFisico", ToDbNull(produto.EstadoFisico));
                cmd.Parameters.AddWithValue("@Recipiente", ToDbNull(produto.Recipiente));
                cmd.Parameters.AddWithValue("@DataCompra", ToDbNull(produto.DataCompra));
                cmd.Parameters.AddWithValue("@CriadoEm", produto.CriadoEm);
                cmd.Parameters.AddWithValue("@LocalEspecifico", ToDbNull(produto.LocalEspecifico));

                cmd.ExecuteNonQuery();
            }

            return produto.Id;
        }

        public void Atualizar(Produto produto)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.Produtos
   SET Nome           = @Nome,
       CategoriaId    = @CategoriaId,
       UnidadeId      = @UnidadeId,
       LocalId        = @LocalId,
       EstadoFisicoId = @EstadoFisicoId,
       RecipienteId   = @RecipienteId,
       FornecedorId   = @FornecedorId,
       Categoria      = @Categoria,
       Quantidade     = @Quantidade,
       Unidade        = @Unidade,
       LocalDeposito  = @LocalDeposito,
       Validade       = @Validade,
       EstoqueMinimo  = @EstoqueMinimo,
       Fabricante     = @Fabricante,
       EstadoFisico   = @EstadoFisico,
       Recipiente     = @Recipiente,
       DataCompra     = @DataCompra,
       LocalEspecifico = @LocalEspecifico
 WHERE Id             = @Id;";

                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@CategoriaId", ToDbNull(produto.CategoriaId));
                cmd.Parameters.AddWithValue("@UnidadeId", ToDbNull(produto.UnidadeId));
                cmd.Parameters.AddWithValue("@LocalId", ToDbNull(produto.LocalId));
                cmd.Parameters.AddWithValue("@EstadoFisicoId", ToDbNull(produto.EstadoFisicoId));
                cmd.Parameters.AddWithValue("@RecipienteId", ToDbNull(produto.RecipienteId));
                cmd.Parameters.AddWithValue("@FornecedorId", ToDbNull(produto.FornecedorId));
                cmd.Parameters.AddWithValue("@Categoria", ToDbNull(produto.Categoria));
                cmd.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("@Unidade", ToDbNull(produto.Unidade));
                cmd.Parameters.AddWithValue("@LocalDeposito", ToDbNull(produto.LocalDeposito));
                cmd.Parameters.AddWithValue("@Validade", ToDbNull(produto.Validade));
                cmd.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                cmd.Parameters.AddWithValue("@Fabricante", ToDbNull(produto.Fabricante));
                cmd.Parameters.AddWithValue("@EstadoFisico", ToDbNull(produto.EstadoFisico));
                cmd.Parameters.AddWithValue("@Recipiente", ToDbNull(produto.Recipiente));
                cmd.Parameters.AddWithValue("@DataCompra", ToDbNull(produto.DataCompra));
                cmd.Parameters.AddWithValue("@LocalEspecifico", ToDbNull(produto.LocalEspecifico));

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(Guid id)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.Produtos WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
