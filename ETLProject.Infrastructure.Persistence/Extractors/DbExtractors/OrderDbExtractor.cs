using ETLProjectDW.Core.Application.DTOs;
using ETLProjectDW.Core.Application.Interfaces;
using ETLProject.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors
{
    public class OrderDbExtractor : IExtractor<OrderDto>
    {
        private readonly VentasDbContext _context;
        private readonly ILogger<OrderDbExtractor> _logger;

        public OrderDbExtractor(VentasDbContext context, ILogger<OrderDbExtractor> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderDto>> ExtractAsync()
        {
            try
            {
                _logger.LogInformation("Extrayendo orders de VentasDB");

                var orders = await _context.Orders
                    .Include(o => o.Status)
                    .Select(o => new OrderDto
                    {
                        OrderID = o.Id,
                        CustomerID = o.CustomerID,
                        OrderDate = o.OrderDate,
                        Status = o.Status!.StatusName
                    })
                    .ToListAsync();

                _logger.LogInformation("Extraídos {count} orders", orders.Count);
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo orders de VentasDB");
                throw;
            }
        }
    }
}