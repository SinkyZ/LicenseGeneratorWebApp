using LicenseGeneratorWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenseGeneratorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult>AddNewProduct([FromBody]ProductList productRequest)
        {
            productRequest.IdProdus = Guid.NewGuid();

            await _context.Products.AddAsync(productRequest);
            await _context.SaveChangesAsync();

            return Ok(productRequest); 
        }

    }
}
