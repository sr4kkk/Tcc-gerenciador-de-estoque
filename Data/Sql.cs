using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace alguamcoisa.Data
{
    public static class Sql
    {
        public static SqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["EstoqueQuimico"];

            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
            {
                throw new InvalidOperationException(
                    "A conexão 'EstoqueQuimico' não está configurada. Abra a tela de conexão para configurar.");
            }

            SqlConnection conn = new SqlConnection(cs.ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
