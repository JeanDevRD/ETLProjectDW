using ETLProjectDW.Core.Application.DTOs;
using ETLProjectDW.Core.Application.Interfaces;
using ETLProject.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors
{
    public class OrderDetailDbExtractor : IExtractor<OrderDetailDto>
    {
        private readonly VentasDbContext _context;
        private readonly ILogger<OrderDetailDbExtractor> _logger;

        public OrderDetailDbExtractor(VentasDbContext context, ILogger<OrderDetailDbExtractor> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderDetailDto>> ExtractAsync()
        {
            try
            {
                _logger.LogInformation("Extrayendo order details de VentasDB");

                var orderDetails = await _context.OrderDetails
                    .Select(od => new OrderDetailDto
                    {
                        OrderID = od.OrderID,
                        ProductID = od.ProductID,
                        Quantity = od.Quantity,
                        TotalPrice = od.TotalPrice
                    })
                    .ToListAsync();

                _logger.LogInformation("Extraídos {count} order details", orderDetails.Count);
                return orderDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo order details de VentasDB");
                throw;
            }
        }
    }
}