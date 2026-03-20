using ETLProject.Infrastructure.Persistence.Extractors;
using ETLProject.Infrastructure.Persistence.Extractors.ApiExtractors;
using ETLProject.Infrastructure.Persistence.Extractors.CsvExtractors;
using ETLProject.Infrastructure.Persistence.Extractors.DbExtractors;
using System.Text.Json;

namespace Worker
{
    public class ExtractionWorker : BackgroundService
    {
        private readonly ILogger<ExtractionWorker> _logger;
        private readonly IConfiguration _config;
        private readonly CustomerCsvExtractor _customerCsv;
        private readonly ProductCsvExtractor _productCsv;
        private readonly OrderCsvExtractor _orderCsv;
        private readonly CustomerDbExtractor _customerDb;
        private readonly OrderDbExtractor _orderDb;
        private readonly OrderDetailDbExtractor _orderDetailDb;
        private readonly ApiProductExtractor _apiProducts;

        public ExtractionWorker(ILogger<ExtractionWorker> logger, IConfiguration config,
            CustomerCsvExtractor customerCsv, ProductCsvExtractor productCsv, OrderCsvExtractor orderCsv,
            CustomerDbExtractor customerDb, OrderDbExtractor orderDb, OrderDetailDbExtractor orderDetailDb,
            ApiProductExtractor apiProducts)
        {
            _logger = logger;
            _config = config;
            _customerCsv = customerCsv;
            _productCsv = productCsv;
            _orderCsv = orderCsv;
            _customerDb = customerDb;
            _orderDb = orderDb;
            _orderDetailDb = orderDetailDb;
            _apiProducts = apiProducts;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Iniciando extracción ETL: {time}", DateTimeOffset.Now);

            var staging = _config["StagingPath"]!;
            Directory.CreateDirectory(staging);

            try
            {
                _logger.LogInformation("Extrayendo datos de los archivos CSV...");
                await Save(await _customerCsv.ExtractAsync(), Path.Combine(staging, "csv_customers.json"));
                await Save(await _productCsv.ExtractAsync(), Path.Combine(staging, "csv_products.json"));
                await Save(await _orderCsv.ExtractAsync(), Path.Combine(staging, "csv_orders.json"));

                _logger.LogInformation("Extrayendo datos de la base de datos VentasDB...");
                await Save(await _customerDb.ExtractAsync(), Path.Combine(staging, "db_customers.json"));
                await Save(await _orderDb.ExtractAsync(), Path.Combine(staging, "db_orders.json"));
                await Save(await _orderDetailDb.ExtractAsync(), Path.Combine(staging, "db_orderdetails.json"));

                _logger.LogInformation("Extrayendo productos desde la API...");
                await Save(await _apiProducts.ExtractAsync(), Path.Combine(staging, "api_products.json"));

                _logger.LogInformation("Extracción completada, archivos guardados en: {path}", staging);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Algo salió mal durante la extracción");
            }
        }

        private async Task Save<T>(IEnumerable<T> data, string path)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
            _logger.LogInformation("Archivo guardado: {path}", path);
        }
    }
}