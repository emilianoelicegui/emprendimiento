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

            CreateMap<Spending, SpendingDto>();
            CreateMap<Spending, SpendingListDto>()
                .ForPath(dest => dest.IdSpendingType, opt => opt.MapFrom(src => src.SpendingType.Id))
                .ForPath(dest => dest.NameSpendingType, opt => opt.MapFrom(src => src.SpendingType.Description))
                .ForPath(dest => dest.IdCompany, opt => opt.MapFrom(src => src.Company.Id))
                .ForPath(dest => dest.NameCompany, opt => opt.MapFrom(src => src.Company.NameFantasy));

            CreateMap<DolarResponse, DolarBlueValue>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.LastUpdate, opt => opt.Ignore())
                .ForPath(dest => dest.Date, opt => opt.MapFrom(src => src.d.Date))
                .ForPath(dest => dest.Value, opt => opt.MapFrom(src => src.v));

            CreateMap<Sale, SaleDto>();
            CreateMap<SaveSaleRequest, Sale>()
                .ForMember(src => src.Client, opt => opt.Ignore())
                .ForMember(src => src.Company, opt => opt.Ignore());

            CreateMap<ItemSaleDto, ItemSale>()
                .ForMember(src => src.Sale, opt => opt.Ignore());
        }
    }
}
