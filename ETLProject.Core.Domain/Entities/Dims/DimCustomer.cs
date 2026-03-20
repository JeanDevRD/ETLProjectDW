using ETLProjectDW.Core.Domain.Entities.Fact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities.Dims
{
    public class DimCustomer : CommonEntity<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }

        public FactSale? FactSales { get; set; }
         
    }
}
