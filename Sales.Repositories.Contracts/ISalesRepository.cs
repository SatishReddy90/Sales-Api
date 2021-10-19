using Sales.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repositories.Contracts
{
    public interface ISalesRepository
    {
        public Task<(long count, List<SaleRecord>)> GetSaleDataAsync(string region, string country, string itemType, int page, int limit);
        public Task<List<Region>> GetRegionsAsync();
        public Task<List<Country>> GetCountriesAsync(string region);
        public Task<List<ItemType>> GetItemTypesAsync(string region, string country);
    }
}
