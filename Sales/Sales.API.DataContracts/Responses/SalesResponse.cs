using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.API.DataContracts.Responses
{
    public class SalesResponse
    {
        public long Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public List<SaleDetail> Data { get; set; }
    }

    public class SaleDetail
    {
        public long? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ItemType { get; set; }
        public int? UnitsSold { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
