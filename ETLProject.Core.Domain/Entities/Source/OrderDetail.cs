using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class OrderDetail : CommonEntity<int>
    {
        public required int OrderID { get; set; }
        public Order? Order { get; set; }

        public required int ProductID { get; set; }
        public Product? Product { get; set; }

        public required int Quantity { get; set; }
        public required decimal TotalPrice { get; set; }
    }
}
