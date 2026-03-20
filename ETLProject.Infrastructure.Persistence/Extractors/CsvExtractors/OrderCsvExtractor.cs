using ETLProjectDW.Core.Application.CSVs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors.CsvExtractors
{
    public class OrderCsvExtractor : CsvExtractor<OrderCsv>
    {
        public OrderCsvExtractor(IConfiguration config, ILogger<CsvExtractor<OrderCsv>> logger)
            : base(config, logger, "CsvPaths:Orders")
        {
        }
    }
}