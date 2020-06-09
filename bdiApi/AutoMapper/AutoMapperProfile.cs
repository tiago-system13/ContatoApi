using AutoMapper;
using bdiApi.AutoMapper.Mappaer;

namespace bdiApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ContatoMapper.Map(this);
        }
    }
}
