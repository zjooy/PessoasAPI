using System.ComponentModel.DataAnnotations;

namespace cadastroPessoas.Models
{
    public class PessoaModel
    {
        [Key]
        public int ID_Pessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DT_Aniversario { get; set; }
        public DateTime DT_Cadastro { get; set; } = DateTime.Now;
        public DateTime? DT_Alteracao { get; set; }
    }
}
