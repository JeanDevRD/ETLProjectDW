using ETLProject.Infrastructure.Persistence.Extractors;
using ETLProjectDW.Core.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ETLProjectDW.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbExtractor _extractor;

        public ProductsController(ProductDbExtractor extractor)
        {
            _extractor = extractor;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _extractor.ExtractAsync();
        }
    }
}