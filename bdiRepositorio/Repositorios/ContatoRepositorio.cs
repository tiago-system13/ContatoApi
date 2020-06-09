using bdiEntidades.Entidades;
using bdiNegocios.Interfaces;
using bdiRepositorio.Contextos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace bdiRepositorio.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly Contexto _context;

        public ContatoRepositorio(Contexto contexto)
        {
            _context = contexto;
        }
        public Contato Adicionar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public bool Deletar(Contato contato)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
            return true;
        }

        public Contato Editar(Contato contatoOld, Contato contato)
        {
            _context.Contatos.Update(contatoOld).CurrentValues.SetValues(contato);
            _context.SaveChanges();
            return contato;
        }

        public List<Contato> ListarTodos()
        {
            return _context.Contatos.AsNoTracking().OrderBy(x => x.Nome).ToList();
        }

        public Contato ObterPorId(int id)
        {
            return _context.Contatos.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Contato ObterPorNome(string nome)
        {
            return _context.Contatos.AsNoTracking().FirstOrDefault(x => x.Nome.ToUpper().Equals(nome.ToUpper()));
        }
    }
}
