using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Shared.Layer;
using System.Collections.Generic;
using System.Linq;

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

            CreateMap<Product, ProductDto>()
                .ForPath(dest => dest.Money, opt => opt.MapFrom(src => src.MoneyToLongString()))
                .ForPath(dest => dest.Price, opt => opt.MapFrom(src => $"{src.MoneyToShortString()} {src.Price}"));
            CreateMap<SaveProductRequest, Product>();

            CreateMap<Provider, ProviderDto>();
            CreateMap<SaveProviderRequest, Provider>();

            CreateMap<SaveSpendingRequest, Spending>();

            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientListDto>()
                .ForPath(dest => dest.NameCompany, opt => opt.MapFrom(src => src.Company.NameFantasy))
                .ForPath(dest => dest.PhoneComplete, opt => opt.MapFrom(src => $"{src.CodArea} {src.Phone}"));
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
            CreateMap<Sale, SaleListDto>()
                .ForPath(dest => dest.NameClient, opt => opt.MapFrom(src => $"{src.Client.Name} {src.Client.Surname}"))
                .ForPath(dest => dest.NameCompany, opt => opt.MapFrom(src => $"{src.Company.NameFantasy}"))
                .ForPath(dest => dest.MethodPaymentDesc, opt => opt.MapFrom(src => src.MethodPayment.GetNameEnum()));

            CreateMap<ItemSaleDto, ItemSale>()
                .ForMember(src => src.Sale, opt => opt.Ignore());
            CreateMap<ItemSale, ItemSaleListDto>()
                .ForMember(src => src.NameProduct, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(src => src.PriceProduct, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(src => src.TotalPrice, opt => opt.MapFrom(src => src.Product.Price * src.Units));

            CreateMap<Payment, PaymentDto>();
            CreateMap<SavePaymentRequest, Payment>()
                .ForMember(src => src.Client, opt => opt.Ignore());
            CreateMap<Payment, PaymentListDto>()
                .ForMember(src => src.IdClient, opt => opt.MapFrom(src => src.Client.Id))
                .ForMember(src => src.NameClient, opt => opt.MapFrom(src => $"{src.Client.Name}, {src.Client.Surname}"))
                .ForMember(src => src.IdCompany, opt => opt.MapFrom(src => src.Client.Company.Id))
                .ForMember(src => src.NameCompany, opt => opt.MapFrom(src => src.Client.Company.NameFantasy));

            CreateMap<SaveStockRequest, Stock>();

            CreateMap<Client, DebtorListDto>()
                .ForMember(src => src.Amount, opt => opt.MapFrom(src => src.Sales.Where(x => x.MethodPayment == MethodPayment.CurrentAccount)
                                                        .Sum(x => x.Amount) - src.Payments.Sum(x => x.Amount)))
                .ForMember(src => src.Sales, opt => opt.MapFrom(src => src.Sales))
                .ForMember(src => src.Payments, opt => opt.MapFrom(src => src.Payments));
        }
    }
}
