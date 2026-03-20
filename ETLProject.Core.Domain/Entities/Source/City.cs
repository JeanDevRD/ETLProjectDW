using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class City : CommonEntity<int>
    {
       public required string CityName {  get; set; }
       public required int CountryID {  get; set; }
       public Country? Country { get; set; }
       public ICollection<Customer>? Customers { get; set; }
   
    }
}
