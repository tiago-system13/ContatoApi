using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bdiApi.Models;
using bdiApi.Models.DTO;
using bdiEntidades.Entidades;
using bdiNegocios.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bdiApi.Controllers
{
    [Route("api/contato")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoServico _contatoServico;
        private readonly IMapper _mapper;

        public ContatoController(IContatoServico contatoServico, IMapper mapper)
        {
            _contatoServico = contatoServico;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ContatoViewModel>>> ListarTodos()
        {
            var users = await _contatoServico.ListarContatosAsync().ConfigureAwait(false);

            var response = users.Select(r => _mapper.Map<ContatoViewModel>(r)).ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(int id)
        {
            var user = await _contatoServico.ObterPorIdAsync(id).ConfigureAwait(false);
            return Ok(_mapper.Map<ContatoViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult<ContatoViewModel>> Adicionar([FromBody]ContatoDto contato)
        {

            var userEntity = await _contatoServico.AdicionarAsync(_mapper.Map<Contato>(contato)).ConfigureAwait(false);
            return Ok(_mapper.Map<ContatoViewModel>(userEntity));
        }

        [HttpPut]
        public async Task<ActionResult<ContatoViewModel>> Editar([FromBody]ContatoDto contato)
        {
            var userEtity = await _contatoServico.EditarAsync(_mapper.Map<Contato>(contato)).ConfigureAwait(false);
            return Ok(_mapper.Map<ContatoViewModel>(userEtity));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            var userEntity = await (_contatoServico.DeletarAsync(id)).ConfigureAwait(false);
            return Ok(_mapper.Map<bool>(userEntity));
        }
    }
}