using Microsoft.AspNetCore.Identity;

namespace cadastroPessoas.Service.PessoaService
{
    public static class EncriptaSenha
    {
        private static PasswordHasher<string> hasher = new PasswordHasher<string>();

        public static string hashSenha(string password)
        {
            return hasher.HashPassword(null, password);
        }
    }
}
