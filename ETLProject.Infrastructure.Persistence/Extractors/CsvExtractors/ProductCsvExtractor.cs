using ETLProjectDW.Core.Application.CSVs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors.CsvExtractors
{
    public class ProductCsvExtractor : CsvExtractor<ProductCsv>
    {
        public ProductCsvExtractor(IConfiguration config, ILogger<CsvExtractor<ProductCsv>> logger)
            : base(config, logger, "CsvPaths:Products")
        {
        }
    }
}