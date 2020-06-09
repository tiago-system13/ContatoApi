using AutoMapper;
using bdiApi.Models;
using bdiApi.Models.DTO;
using bdiEntidades.Entidades;

namespace bdiApi.AutoMapper.Mappaer
{
    public class ContatoMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<ContatoDto, Contato>();

            profile.CreateMap<Contato, ContatoViewModel>();
        }
    }
}
