using ETLProjectDW.Core.Application.CSVs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors.CsvExtractors
{
    public class CustomerCsvExtractor : CsvExtractor<CustomerCsv>
    {
        public CustomerCsvExtractor(IConfiguration config, ILogger<CsvExtractor<CustomerCsv>> logger)
            : base(config, logger, "CsvPaths:Customers")
        {
        }
    }
}