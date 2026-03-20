using ETLProjectDW.Core.Domain.Entities.Fact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Domain.Entities.Dims
{
    public class DimTime : CommonEntity<int>
    {
        public required DateTime FullDate { get; set; }
        public required short Year { get; set; }
        public required byte Month { get; set; }
        public required byte Quarter { get; set; }
        public required string MonthName {  get; set; }
        public required byte DayOfMonth { get; set; }
        public required string DayName {  get; set; }
        public required bool IsWeekend { get; set; }
        public FactSale? FactSales { get; set; }
    }
}
