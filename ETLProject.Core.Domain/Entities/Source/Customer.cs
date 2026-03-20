using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class Customer : CommonEntity<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required int CityID { get; set; }
        public City? City { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
