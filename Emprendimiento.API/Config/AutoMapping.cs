using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using System.Collections.Generic;

namespace Emprendimiento.API
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<Rol, RolDto>();
        }
    }
}
