using AutoMapper;
using Sales.Services.Model;

namespace Sales.IoC.Configuration.AutoMapper.Profiles
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            // complete with business and repository mappings
            CreateMap<SaleRecord, SaleDataDomain>();

        }
    }
}
