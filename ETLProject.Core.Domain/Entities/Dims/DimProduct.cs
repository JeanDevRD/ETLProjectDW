using ETLProjectDW.Core.Domain.Entities.Fact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities.Dims
{
    public class DimProduct : CommonEntity<int>
    { 
        public required string ProductName { get; set; }
        public required string Category {  get; set; }
        public required decimal ListPrice {  get; set; }
        public required int Stock {  get; set; }
        public FactSale? FactSales { get; set; }
    }
}
