using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class Country: CommonEntity<int>
    {
        public required string CountryName { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
