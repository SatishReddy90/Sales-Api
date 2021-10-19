using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Model
{
    public partial class SaleRecord
    {
        public long Id { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ItemType { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public DateTime? OrderDate { get; set; }
        public long? OrderId { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? UnitsSold { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalProfit { get; set; }
    }
}
