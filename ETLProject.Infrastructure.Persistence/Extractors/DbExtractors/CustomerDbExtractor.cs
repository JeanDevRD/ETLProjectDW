using ETLProjectDW.Core.Application.DTOs;
using ETLProjectDW.Core.Application.Interfaces;
using ETLProject.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETLProject.Infrastructure.Persistence.Extractors.DbExtractors
{
    public class CustomerDbExtractor : IExtractor<CustomerDto>
    {
        private readonly VentasDbContext _context;
        private readonly ILogger<CustomerDbExtractor> _logger;

        public CustomerDbExtractor(VentasDbContext context, ILogger<CustomerDbExtractor> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerDto>> ExtractAsync()
        {
            try
            {
                _logger.LogInformation("Extrayendo customers de VentasDB");

                var customers = await _context.Customers
                    .Include(c => c.City)
                    .ThenInclude(ci => ci!.Country)
                    .Select(c => new CustomerDto
                    {
                        CustomerID = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        Phone = c.Phone,
                        City = c.City!.CityName,
                        Country = c.City.Country!.CountryName
                    })
                    .ToListAsync();

                _logger.LogInformation("Extraídos {count} customers", customers.Count);
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo customers de VentasDB");
                throw;
            }
        }
    }
}