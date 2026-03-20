using ETLProjectDW.Core.Domain.Entities.Dims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities.Fact
{
    public class FactSale : CommonEntity<int>
    {
        public required int TimeID { get; set; }
        public required int ProductID { get; set; }
        public required int CustomerID { get; set; }
        public required int StatusID { get; set; }
        public required int OrderID { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public required decimal Discount { get; set; }
        public required decimal TotalAmount { get; set; }

        public DimTime? Time { get; set; } 
        public DimProduct? Product { get; set; }
        public DimCustomer? Customer { get; set; }
        public DimOrderStatus? Status { get; set; } 


    }
}
