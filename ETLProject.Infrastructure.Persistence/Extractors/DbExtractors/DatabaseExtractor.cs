using ETLProjectDW.Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace ETLProject.Infrastructure.Persistence.Extractors.DbExtractors
{
    public abstract class DatabaseExtractor<T> : IExtractor<T>
    {
        private readonly IConfiguration _config;
        protected readonly ILogger<DatabaseExtractor<T>> _logger;

        public DatabaseExtractor(IConfiguration config, ILogger<DatabaseExtractor<T>> logger)
        {
            _config = config;
            _logger = logger;
        }

        protected abstract string Query { get; }

        protected abstract T Map(SqlDataReader reader);

        public async Task<IEnumerable<T>> ExtractAsync()
        {
            var results = new List<T>();
            var connectionString = _config.GetConnectionString("VentasDB");

            try
            {
                _logger.LogInformation("Extrayendo de BD: {type}", typeof(T).Name);

                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand(Query, connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    results.Add(Map(reader));
                }

                _logger.LogInformation("Extraídos {count} registros de BD", results.Count);
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extrayendo de BD: {type}", typeof(T).Name);
                throw;
            }
        }
    }
}