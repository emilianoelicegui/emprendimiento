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
            CreateMap<List<Menu>, List<MenuDto>>();

            CreateMap<Rol, RolDto>();

            CreateMap<Company, CompanyDto>();
            CreateMap<Company, CompanyLoginDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<SaveProductRequest, Product>();

            CreateMap<Provider, ProviderDto>();
            CreateMap<SaveProviderRequest, Provider>();

            CreateMap<SaveSpendingRequest, Spending>();

            CreateMap<Client, ClientDto>();
            CreateMap<SaveClientRequest, Client>();
        }
    }
}
