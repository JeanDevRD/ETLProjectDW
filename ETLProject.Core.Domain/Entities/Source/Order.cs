using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class Order : CommonEntity<int>
    {

        public required int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public required DateTime OrderDate { get; set; }

        public required int StatusID { get; set; }
        public OrderStatus? Status { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
