using bdiEntidades.Entidades;
using System.Collections.Generic;

namespace bdiNegocios.Interfaces
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);

        Contato Editar(Contato contatoOld, Contato contato);

        Contato ObterPorId(int id);

        Contato ObterPorNome(string nome);

        List<Contato> ListarTodos();

        bool Deletar(Contato contato);
    }
}
