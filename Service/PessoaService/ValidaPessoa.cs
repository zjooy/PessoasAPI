using cadastroPessoas.Models;
using System.Text.RegularExpressions;

namespace cadastroPessoas.Service.PessoaService
{
    public static class ValidaPessoa
    {
        public static bool Validar(PessoaModel pessoa, out string mensagemErro)
        {
            var cpf = pessoa.CPF;

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

            if (string.IsNullOrEmpty(cpf))
            {
                mensagemErro = "Informe o CPF.";
                return false;
            }

            if (!Regex.IsMatch(cpf, @"^[\d\.\-]+$"))
            {
                mensagemErro = "O CPF deve conter apenas números, pontos e traços.";
                return false;
            }

            cpf = Regex.Replace(cpf ?? "", @"[^\d]", "");
            if (cpf.Length != 11)
            {
                mensagemErro = "O CPF deve conter exatamente 11 números.";
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
