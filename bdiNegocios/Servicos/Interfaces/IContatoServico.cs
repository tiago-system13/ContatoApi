using bdiEntidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bdiNegocios.Servicos.Interfaces
{
    public interface IContatoServico
    {
        Task<Contato> AdicionarAsync(Contato contato);
        Task<Contato> EditarAsync(Contato contato);
        Task<Contato> ObterPorIdAsync(int id);
        Task<List<Contato>> ListarContatosAsync();
        Task<bool> DeletarAsync(int id);
    }
}
