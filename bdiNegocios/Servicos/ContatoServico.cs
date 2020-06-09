using bdiEntidades.Entidades;
using bdiNegocios.Exceptions;
using bdiNegocios.Interfaces;
using bdiNegocios.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bdiNegocios.Servicos
{
    public class ContatoServico : IContatoServico
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoServico(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<Contato> AdicionarAsync(Contato contato)
        {
            var idade = CalcularIdade(contato.DataNascimento);

            if (!ValidarIdadeContato(idade))
            {
                throw new NegocioException($"O Contato não tem permissão para ser criado, pois tem idade inferior a 5 anos");
            }

            if (ExisteContatoCadastrado(contato.Nome))
            {
                throw new NegocioException($"Já existe registro de contato com mesmo nome na base de dados.");
            }

            contato.Idade = idade;

            return await Task.FromResult(_contatoRepositorio.Adicionar(contato));
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var contato = _contatoRepositorio.ObterPorId(id);

            if (contato == null)
            {
               throw new NegocioException($"Contato não encontrado para o id: {id}");
            }

            return await Task.FromResult(_contatoRepositorio.Deletar(contato));
        }

        public bool ValidarIdadeContato(int idade)
        {
            return idade >= 5;
        }

        public async Task<Contato> EditarAsync(Contato contato)
        {

            var idade = CalcularIdade(contato.DataNascimento);
           
            if (!ValidarIdadeContato(idade))
            {
                throw new NegocioException($"Contato {contato.Nome} não tem permissão para ser editado, pois tem idade inferior a 5 anos");
            }

            var contatoBase = _contatoRepositorio.ObterPorId(contato.Id);

            if (contatoBase == null)
            {
                throw new NegocioException($"Contato não encontrado para o id: {contato.Id}");
            }

            if (ExisteContatoCadastrado(contato.Nome) && contato.Id != contatoBase.Id)
            {
                throw new NegocioException($"Já existe registro do contato {contato.Nome} na base de dados.");
            }

            var contatoOld = new Contato(contatoBase);

            contatoBase.Nome = contato.Nome;
            contatoBase.Sexo = contato.Sexo;
            contatoBase.DataNascimento = contato.DataNascimento;
            contatoBase.Idade = idade;

            return await Task.FromResult(_contatoRepositorio.Editar(contatoOld, contatoBase));
        }

        public async Task<List<Contato>> ListarContatosAsync()
        {
            var contatos = _contatoRepositorio.ListarTodos();

            return await Task.FromResult(contatos);
        }

       
        public async Task<Contato> ObterPorIdAsync(int id)
        {
            var contato = _contatoRepositorio.ObterPorId(id);

            if (contato == null)
            {
                if (contato == null)
                {
                    throw new NegocioException($"Contato não encontrado para o id: {id}");
                }
            }

            return await Task.FromResult(contato);
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            var idade = (DateTime.Now.Year - dataNascimento.Year);

            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade -= 1;
            }

            return idade;
        }

        private bool ExisteContatoCadastrado(string nome)
        {
          return  _contatoRepositorio.ObterPorNome(nome) != null;
        }
    }
}
