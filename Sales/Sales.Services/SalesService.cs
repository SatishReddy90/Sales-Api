using AutoMapper;
using Microsoft.Extensions.Options;
using Sales.API.Common.Settings;
using Sales.API.DataContracts.Responses;
using Sales.Repositories.Contracts;
using Sales.Services.Contracts;
using Sales.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services
{
    public class SalesService : ISalesService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly ISalesRepository _salesRepository;

        public SalesService(IOptions<AppSettings> settings, IMapper mapper, ISalesRepository salesRepository)
        {
            _settings = settings?.Value;
            _mapper = mapper;
            _salesRepository = salesRepository;
        }

        public async Task<SalesResponse> GetSalesDataAsync(string region, string country, string itemType, int page, int limit)
        {
            var result = await this._salesRepository.GetSaleDataAsync(region, country, itemType, page, limit);
            if ((result.Item2?.Any() ?? false))
            {
                return null;
            }

            return new SalesResponse()
            {
                Total = result.Item1,
                Page = page,
                Limit = limit,
                Data = _mapper.Map<List<SaleDetail>>(result.Item2),
            };
        }

        public async Task<List<RegionResponse>> GetRegionsAsync()
        {
            var result = await this._salesRepository.GetRegionsAsync();
            if ((result?.Any() ?? false))
            {
                return null;
            }

            return _mapper.Map<List<RegionResponse>>(result);
        }

        public async Task<List<CountryResponse>> GetCountriesAsync(string region)
        {
            var result = await this._salesRepository.GetCountriesAsync(region);
            if ((result?.Any() ?? false))
            {
                return null;
            }

            return _mapper.Map<List<CountryResponse>>(result);
        }

        public async Task<List<ItemTypeResponse>> GetItemTypesAsync(string region, string country)
        {
            var result = await this._salesRepository.GetItemTypesAsync(region, country);
            if ((result?.Any() ?? false))
            {
                return null;
            }

            return _mapper.Map<List<ItemTypeResponse>>(result);
        }
    }
}
