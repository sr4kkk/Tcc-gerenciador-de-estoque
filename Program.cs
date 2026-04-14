using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using alguamcoisa.Infra;
using alguamcoisa.Utils;

namespace alguamcoisa
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            AppTheme.LoadTheme();

            // 1️⃣ Verificar se existe connection string
            var cs = ConfigurationManager.ConnectionStrings["EstoqueQuimico"];
            bool precisaConfigurar = cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString);

            if (!precisaConfigurar)
            {
                // 2️⃣ Testar se a conexão funciona
                try
                {
                    using (var conn = new SqlConnection(cs.ConnectionString))
                    {
                        conn.Open();
                    }
                }
                catch
                {
                    precisaConfigurar = true;
                }
            }

            // 3️⃣ Se não existir ou for inválida → abrir tela de configuração
            if (precisaConfigurar)
            {
                using (var frmConexao = new ConexaoBancoForm())
                {
                    DialogResult result = frmConexao.ShowDialog();

                    if (result != DialogResult.OK)
                    {
                        MessageBox.Show("O sistema não pode iniciar sem uma conexão válida.",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 4️⃣ Conexão OK → pedir login
            using (var login = new LoginForm())
            {
                var result = login.ShowDialog();

                if (result != DialogResult.OK)
                {
                    // Usuário cancelou ou falhou no login
                    return;
                }

                // Se login temporário (admin/2580 sem admin cadastrado),
                // obriga abrir a configuração dos 3 admins antes de entrar no sistema.
                if (login.LoginTemporario)
                {
                    using (var adminForm = new AdminConfigForm())
                    {
                        adminForm.ShowDialog();
                    }
                }
            }

            // 5️⃣ Login OK → abrir sistema principal
            Application.Run(new HomeForm());
        }
    }
}
