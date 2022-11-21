using Microsoft.AspNetCore.JsonPatch;
using SwiggyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel> GetCustomersDetailsByIdAsync(int customerId);

        Task<int> AddCustomersDetailsAsync(CustomerModel customerModel);

        Task UpdateCustomerDetailsByIdAsync(int customerId, CustomerModel customerModel);

        Task UpdateCustomerPatchAsync(int customerId, JsonPatchDocument customerModel);

        Task DeleteCustomersDetailsByIdAsync(int customerId);

        // came from customerrepository
        // after adding here go to the 
        // CustomerController and create action method there
    }
}
