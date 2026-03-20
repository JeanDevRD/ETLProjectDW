using ETLProjectDW.Core.Application.DTOs;
using ETLProjectDW.Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ETLProject.Infrastructure.Persistence.Extractors.ApiExtractors
{
    public class ApiProductExtractor : IExtractor<ProductDto>
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiProductExtractor> _logger;
        private readonly string _url;

        public ApiProductExtractor(HttpClient httpClient, ILogger<ApiProductExtractor> logger, IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _url = config["ApiUrls:Products"]!;
        }

        public async Task<IEnumerable<ProductDto>> ExtractAsync()
        {
            try
            {
                _logger.LogInformation("Extrayendo productos de API: {url}", _url);

                var response = await _httpClient.GetStringAsync(_url);
                var products = JsonSerializer.Deserialize<IEnumerable<ProductDto>>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _logger.LogInformation("Extraídos {count} productos de API", products!.Count());
                return products!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo productos de API");
                throw;
            }
        }
    }
}