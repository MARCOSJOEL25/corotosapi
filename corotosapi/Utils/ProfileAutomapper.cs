using AutoMapper;
using corotosapi.Models;
using corotosapi.Models.Dto;

namespace corotosapi.Utils
{
    public class ProfileAutomapper : Profile
    {
        public ProfileAutomapper()
        {
            CreateMap<DtoProducto, Producto>().ReverseMap();
        }
    }
}
