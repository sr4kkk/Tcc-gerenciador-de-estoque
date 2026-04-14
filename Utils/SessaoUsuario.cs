// Utils/SessaoUsuario.cs
namespace alguamcoisa.Utils
{
    /// <summary>
    /// Sessão em memória para o usuário logado (Admin ou Professor).
    /// Não mexe em banco, só guarda info para a UI.
    /// </summary>
    public static class SessaoUsuario
    {
        public enum TipoUsuario
        {
            Admin,
            Professor
        }

        public static int? IdProfessor { get; private set; }
        public static string Nome { get; private set; } = "Usuário não autenticado";
        public static TipoUsuario? Perfil { get; private set; }

        public static void DefinirProfessor(int idProfessor, string nome)
        {
            IdProfessor = idProfessor;
            Nome = nome;
            Perfil = TipoUsuario.Professor;
        }

        public static void DefinirAdmin(string nome)
        {
            IdProfessor = null;
            Nome = nome;
            Perfil = TipoUsuario.Admin;
        }

        public static void Limpar()
        {
            IdProfessor = null;
            Nome = "Usuário não autenticado";
            Perfil = null;
        }

        public static string ObterDescricao()
        {
            if (Perfil == TipoUsuario.Admin)
                return $"Admin: {Nome}";

            if (Perfil == TipoUsuario.Professor)
                return $"Professor: {Nome}";

            return Nome;
        }
    }
}
