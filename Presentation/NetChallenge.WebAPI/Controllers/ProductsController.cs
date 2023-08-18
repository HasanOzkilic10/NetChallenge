using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Add(string productName , int unitPrice, short unitsInStock, int companyId ) //View Model kullanılabilir.
        {
            
            var product = new Product() { ProductName = productName, UnitPrice = unitPrice, UnitsInStock = unitsInStock, CompanyId = companyId };
           var result =  _productService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
