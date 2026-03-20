using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities
{
    public class CommonEntity<Tkey>
    {
        public required Tkey Id { get; set; }
    }
}
