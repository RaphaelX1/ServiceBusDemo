using AutoMapper;
using ServiceBus.DTO;
using ServiceBus.Models;

namespace ServiceBus.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
