using Sales.API.DataContracts.Responses;
using Sales.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Services.Contracts
{
    public interface ISalesService
    {
        Task<SalesResponse> GetSalesDataAsync(string region, string country, string itemType, int page, int limit);
        Task<List<RegionResponse>> GetRegionsAsync();
        Task<List<CountryResponse>> GetCountriesAsync(string region);
        Task<List<ItemTypeResponse>> GetItemTypesAsync(string region, string country);
    }
}
