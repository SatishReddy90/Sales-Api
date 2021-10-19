using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Model
{
    public class SaleDataDomain
    {
        public long Total { get; set; }
        public long? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ItemType { get; set; }
        public int? UnitsSold { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
