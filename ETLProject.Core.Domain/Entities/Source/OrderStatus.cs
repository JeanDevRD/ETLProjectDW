using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class OrderStatus: CommonEntity<int>
    {
        public required string StatusName { get; set; } 
        public ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}
