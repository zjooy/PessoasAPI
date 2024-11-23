using cadastroPessoas.Models;

namespace cadastroPessoas.Service.PessoaService
{
    public static class ValidaPessoa
    {
        public static bool Validar(PessoaModel pessoa, out string mensagemErro)
        {

            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                mensagemErro = "Nome é obrigatório.";
                return false;
            }

            if (!pessoa.Email.Contains("@"))
            {
                mensagemErro = "E-mail inválido.";
                return false;
            }

            if (pessoa.DT_Aniversario > DateTime.Now)
            {
                mensagemErro = "Data de nascimento inválida.";
                return false;
            }

            mensagemErro = string.Empty;
            return true;

        }
    }
}
