using EstoqueQuimico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace alguamcoisa.Data
{
    public class RepositorioProfessores
    {
        private object ToDbNull(string? valor) =>
            string.IsNullOrWhiteSpace(valor) ? DBNull.Value : valor;

        // ------------------------------------------------------
        // LISTAR TODOS
        // ------------------------------------------------------
        public List<Professor> Listar()
        {
            var lista = new List<Professor>();

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT
    IdProfessor,
    NomeProfessor,
    MatriculaProfessor,
    EmailProfessor,
    TelefoneProfessor,
    DepartamentoProfessor,
    ObservacaoProfessor,
    CPFProfessor,
    PasswordHash,
    CriadoEm
FROM dbo.Professores
ORDER BY NomeProfessor;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Professor
                        {
                            IdProfessor = (int)reader["IdProfessor"],
                            NomeProfessor = (string)reader["NomeProfessor"],
                            MatriculaProfessor = reader["MatriculaProfessor"] as string,
                            EmailProfessor = reader["EmailProfessor"] as string,
                            TelefoneProfessor = reader["TelefoneProfessor"] as string,
                            DepartamentoProfessor = reader["DepartamentoProfessor"] as string,
                            ObservacaoProfessor = reader["ObservacaoProfessor"] as string,
                            CPFProfessor = reader["CPFProfessor"] as string,
                            PasswordHash = reader["PasswordHash"] as string,
                            CriadoEm = (DateTime)reader["CriadoEm"]
                        };

                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        // ------------------------------------------------------
        // OBTER POR ID
        // ------------------------------------------------------
        public Professor? ObterPorId(int idProfessor)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT
    IdProfessor,
    NomeProfessor,
    MatriculaProfessor,
    EmailProfessor,
    TelefoneProfessor,
    DepartamentoProfessor,
    ObservacaoProfessor,
    CPFProfessor,
    PasswordHash,
    CriadoEm
FROM dbo.Professores
WHERE IdProfessor = @IdProfessor;";

                cmd.Parameters.AddWithValue("@IdProfessor", idProfessor);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Professor
                        {
                            IdProfessor = (int)reader["IdProfessor"],
                            NomeProfessor = (string)reader["NomeProfessor"],
                            MatriculaProfessor = reader["MatriculaProfessor"] as string,
                            EmailProfessor = reader["EmailProfessor"] as string,
                            TelefoneProfessor = reader["TelefoneProfessor"] as string,
                            DepartamentoProfessor = reader["DepartamentoProfessor"] as string,
                            ObservacaoProfessor = reader["ObservacaoProfessor"] as string,
                            CPFProfessor = reader["CPFProfessor"] as string,
                            PasswordHash = reader["PasswordHash"] as string,
                            CriadoEm = (DateTime)reader["CriadoEm"]
                        };
                    }
                }
            }

            return null;
        }

        // ------------------------------------------------------
        // INSERIR
        // ------------------------------------------------------
        public void Inserir(Professor professor)
        {
            if (professor == null)
                throw new ArgumentNullException(nameof(professor));

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                // IdProfessor é IDENTITY(1,1) – não precisa informar
                cmd.CommandText = @"
INSERT INTO dbo.Professores
(
    NomeProfessor,
    MatriculaProfessor,
    EmailProfessor,
    TelefoneProfessor,
    DepartamentoProfessor,
    ObservacaoProfessor,
    CPFProfessor,
    PasswordHash
)
VALUES
(
    @NomeProfessor,
    @MatriculaProfessor,
    @EmailProfessor,
    @TelefoneProfessor,
    @DepartamentoProfessor,
    @ObservacaoProfessor,
    @CPFProfessor,
    @PasswordHash
);

SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@NomeProfessor", professor.NomeProfessor);
                cmd.Parameters.AddWithValue("@MatriculaProfessor", ToDbNull(professor.MatriculaProfessor));
                cmd.Parameters.AddWithValue("@EmailProfessor", ToDbNull(professor.EmailProfessor));
                cmd.Parameters.AddWithValue("@TelefoneProfessor", ToDbNull(professor.TelefoneProfessor));
                cmd.Parameters.AddWithValue("@DepartamentoProfessor", ToDbNull(professor.DepartamentoProfessor));
                cmd.Parameters.AddWithValue("@ObservacaoProfessor", ToDbNull(professor.ObservacaoProfessor));
                cmd.Parameters.AddWithValue("@CPFProfessor", ToDbNull(professor.CPFProfessor));
                cmd.Parameters.AddWithValue("@PasswordHash", ToDbNull(professor.PasswordHash));

                var idGerado = cmd.ExecuteScalar();
                if (idGerado != null && idGerado != DBNull.Value)
                {
                    professor.IdProfessor = Convert.ToInt32(idGerado);
                }
            }
        }

        // ------------------------------------------------------
        // ATUALIZAR
        // ------------------------------------------------------
        public void Atualizar(Professor professor)
        {
            if (professor == null)
                throw new ArgumentNullException(nameof(professor));

            if (professor.IdProfessor <= 0)
                throw new ArgumentException("IdProfessor inválido para atualização.", nameof(professor));

            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE dbo.Professores
   SET NomeProfessor         = @NomeProfessor,
       MatriculaProfessor    = @MatriculaProfessor,
       EmailProfessor        = @EmailProfessor,
       TelefoneProfessor     = @TelefoneProfessor,
       DepartamentoProfessor = @DepartamentoProfessor,
       ObservacaoProfessor   = @ObservacaoProfessor,
       CPFProfessor          = @CPFProfessor,
       PasswordHash          = @PasswordHash
 WHERE IdProfessor           = @IdProfessor;";

                cmd.Parameters.AddWithValue("@IdProfessor", professor.IdProfessor);
                cmd.Parameters.AddWithValue("@NomeProfessor", professor.NomeProfessor);
                cmd.Parameters.AddWithValue("@MatriculaProfessor", ToDbNull(professor.MatriculaProfessor));
                cmd.Parameters.AddWithValue("@EmailProfessor", ToDbNull(professor.EmailProfessor));
                cmd.Parameters.AddWithValue("@TelefoneProfessor", ToDbNull(professor.TelefoneProfessor));
                cmd.Parameters.AddWithValue("@DepartamentoProfessor", ToDbNull(professor.DepartamentoProfessor));
                cmd.Parameters.AddWithValue("@ObservacaoProfessor", ToDbNull(professor.ObservacaoProfessor));
                cmd.Parameters.AddWithValue("@CPFProfessor", ToDbNull(professor.CPFProfessor));
                cmd.Parameters.AddWithValue("@PasswordHash", ToDbNull(professor.PasswordHash));

                cmd.ExecuteNonQuery();
            }
        }

        // ------------------------------------------------------
        // EXCLUIR
        // ------------------------------------------------------
        public void Excluir(int idProfessor)
        {
            using (var conn = Sql.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM dbo.Professores WHERE IdProfessor = @IdProfessor;";
                cmd.Parameters.AddWithValue("@IdProfessor", idProfessor);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
