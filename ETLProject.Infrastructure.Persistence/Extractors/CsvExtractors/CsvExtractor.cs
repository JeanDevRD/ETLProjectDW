using CsvHelper;
using ETLProjectDW.Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace ETLProject.Infrastructure.Persistence.Extractors.CsvExtractors
{
    public class CsvExtractor<T> : IExtractor<T>
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CsvExtractor<T>> _logger;
        private readonly string _configKey;

        public CsvExtractor(IConfiguration config, ILogger<CsvExtractor<T>> logger, string configKey)
        {
            _config = config;
            _logger = logger;
            _configKey = configKey;
        }

        public Task<IEnumerable<T>> ExtractAsync()
        {
            try
            {
                var filePath = _config[_configKey];
                _logger.LogInformation("Extrayendo CSV: {file}", filePath);

                using var reader = new StreamReader(filePath!);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<T>().ToList();

                _logger.LogInformation("Extraídos {count} registros", records.Count);
                return Task.FromResult<IEnumerable<T>>(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo CSV: {key}", _configKey);
                throw;
            }
        }
    }
}