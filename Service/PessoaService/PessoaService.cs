using cadastroPessoas.DataContext;
using cadastroPessoas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cadastroPessoas.Service.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> GetPessoas()
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                serviceResponse.Dados = _context.Pessoas.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhuma pessoa cadastrada!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> GetPessoasById(int id)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();

            try
            {
                var pessoa = _context.Pessoas.SingleOrDefault(p => p.ID_Pessoa == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não localizada.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = pessoa;
                serviceResponse.Mensagem = "Cadastro localizado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> PostPessoa(PessoaModel novaPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                if (!ValidaPessoa.Validar(novaPessoa, out var mensagemErro))
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = mensagemErro;
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novaPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoas.ToList();
                serviceResponse.Mensagem = "Cadastro realizado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> PutPessoa(PessoaModel editadoPessoa)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();

            try
            {
                var pessoa = _context.Pessoas.AsNoTracking().SingleOrDefault(p => p.ID_Pessoa == editadoPessoa.ID_Pessoa);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não localizada.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                if (!ValidaPessoa.Validar(editadoPessoa, out var mensagemErro))
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = mensagemErro ?? "a";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                pessoa.DT_Alteracao = DateTime.Now;

                _context.Pessoas.Update(editadoPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = pessoa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int id)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                var pessoa = _context.Pessoas.SingleOrDefault(p => p.ID_Pessoa == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não localizada.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoas.ToList();
                serviceResponse.Mensagem = "Cadastro removido com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
