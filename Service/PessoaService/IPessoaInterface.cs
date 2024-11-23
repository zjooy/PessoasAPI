using cadastroPessoas.Models;

namespace cadastroPessoas.Service.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaModel>>> GetPessoas();
        Task<ServiceResponse<PessoaModel>> GetPessoasById(int id);
        Task<ServiceResponse<List<PessoaModel>>> PostPessoa(PessoaModel novaPessoa);
        Task<ServiceResponse<PessoaModel>> PutPessoa(PessoaModel editadoPessoa);
        Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int id);
    }
}
