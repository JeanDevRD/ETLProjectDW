using ETLProjectDW.Core.Domain.Entities.Fact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities.Dims
{
    public class DimOrderStatus : CommonEntity<int>
    {
        public required string StatusName {  get; set; }
        public FactSale? FactSales { get; set; }
    }
}
