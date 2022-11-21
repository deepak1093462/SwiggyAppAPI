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
    public class OrdersController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        // action method started here
        // get action method to get all cutomers details
        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _orderRepository.GetAllOrdersAsync();
            return Ok(customers);
        }

    }
}
