using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 2300, Stock = 40, CreatedDate = DateTime.Now },
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 6500, Stock = 10, CreatedDate = DateTime.Now },
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 4250, Stock = 100, CreatedDate = DateTime.Now }
            });
            var count = await _productWriteRepository.SaveAsync();
        }
    }
}
