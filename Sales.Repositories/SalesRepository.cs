using Microsoft.EntityFrameworkCore;
using Sales.Repositories.Contracts;
using Sales.Repositories.Data;
using Sales.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly SalesContext _context;
        public SalesRepository(SalesContext context)
        {
            this._context = context;
        }

        public async Task<(long count, List<SaleRecord>)> GetSaleDataAsync(string region, string country, string itemType, int page, int limit)
        {
            var skip = page > 0 ? (page - 1) * limit : 0;
            IQueryable<SaleRecord> query = this._context.SaleRecords.AsQueryable<SaleRecord>();
            if (!string.IsNullOrEmpty(region))
            {
                query = query.Where(x => x.Region == region);
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(x => x.Country == country);
            }

            if (!string.IsNullOrEmpty(itemType))
            {
                query = query.Where(x => x.ItemType == itemType);
            }
            // TBD: orderby logic

            var count = await query.LongCountAsync();
            var saleRecords = await query.Skip(skip).Take(limit).ToListAsync();
            
            
            return (count, saleRecords);
        }
    }
}
