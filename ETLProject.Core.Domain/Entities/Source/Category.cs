using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class Category: CommonEntity<int>
    {
        public required string CategoryName { get; set; } 

        public ICollection<Product>? Products { get; set; }
    }
}
