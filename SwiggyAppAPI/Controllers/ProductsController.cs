using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiggyAppAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        // action method started here
        // get action method to get all cutomers details
        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _productRepository.GetAllProductsAsync();
            return Ok(customers);
        }

    }
}
