using cadastroPessoas.Models;
using cadastroPessoas.Service.PessoaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cadastroPessoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;
        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> GetPessoas()
        {
            return Ok(await _pessoaInterface.GetPessoas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> GetPessoasById(int id)
        {
            return Ok(await _pessoaInterface.GetPessoasById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> PostPessoa(PessoaModel pessoa)
        {
            return Ok(await _pessoaInterface.PostPessoa(pessoa));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> PutPessoa(PessoaModel pessoaEditado)
        {
            return Ok(await _pessoaInterface.PutPessoa(pessoaEditado));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> DeletePessoa(int id)
        {
            return Ok(await _pessoaInterface.DeletePessoa(id));
        }
    }
}
