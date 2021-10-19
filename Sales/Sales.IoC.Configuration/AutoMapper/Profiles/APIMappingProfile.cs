using AutoMapper;
using DC = Sales.API.DataContracts;
using S = Sales.Services.Model;

namespace Sales.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.Address, S.Address>().ReverseMap();
            CreateMap<S.SaleDataDomain, DC.Responses.SaleDetail>();
        }
    }
}
