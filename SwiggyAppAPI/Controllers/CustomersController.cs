using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SwiggyAppAPI.Models;
using SwiggyAppAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // it will enables us to write secure all the action method means it will first authorize the user.
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        // action method started here
        // get action method to get all cutomers details
        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return Ok(customers);
        }

        // 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersDetailsById([FromRoute]int id)
        {
            var customer = await _customerRepository.GetCustomersDetailsByIdAsync(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewCustomer([FromBody]CustomerModel customerModel)
        {
            var id = await _customerRepository.AddCustomersDetailsAsync(customerModel);
            return CreatedAtAction(nameof(GetCustomersDetailsById), new { id = id, controller = "customers"}, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerModel customerModel, [FromRoute]int id)
        {
            await _customerRepository.UpdateCustomerDetailsByIdAsync(id, customerModel);
            return Ok();
        }

        // updatecustomerpatch means it will update some properties of the customer
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomerPatch([FromBody] JsonPatchDocument customerModel, [FromRoute] int id)
        {
            await _customerRepository.UpdateCustomerPatchAsync(id, customerModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerRepository.DeleteCustomersDetailsByIdAsync(id);
            return Ok();
        }

        // to add any new action method first go to the customerRepository

    }
}
