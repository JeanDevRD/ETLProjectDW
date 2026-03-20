using ETLProjectDW.Core.Application.DTOs;
using ETLProjectDW.Core.Application.Interfaces;
using ETLProject.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors
{
    public class ProductDbExtractor : IExtractor<ProductDto>
    {
        private readonly VentasDbContext _context;
        private readonly ILogger<ProductDbExtractor> _logger;

        public ProductDbExtractor(VentasDbContext context, ILogger<ProductDbExtractor> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> ExtractAsync()
        {
            try
            {
                _logger.LogInformation("Extrayendo products de VentasDB");

                var products = await _context.Products
                    .Include(p => p.Category)
                    .Select(p => new ProductDto
                    {
                        ProductID = p.Id,
                        ProductName = p.ProductName,
                        Category = p.Category!.CategoryName,
                        Price = p.Price,
                        Stock = p.Stock
                    })
                    .ToListAsync();

                _logger.LogInformation("Extraídos {count} products", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo products de VentasDB");
                throw;
            }
        }
    }
}