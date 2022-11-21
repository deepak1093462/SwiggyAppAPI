using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SwiggyAppAPI.Data;
using SwiggyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(CustomerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerModel>> GetAllCustomersAsync()
        {
            var records = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerModel>>(records);


            //var records = await _context.Customers.Select(x => new CustomerModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Address = x.Address,
            //    MobileNo = x.MobileNo
            //}).ToListAsync();
            //return records;
        }

        public async Task<CustomerModel> GetCustomersDetailsByIdAsync(int customerId)
        {

            var customer = await _context.Customers.FindAsync(customerId);
            return _mapper.Map<CustomerModel>(customer);


            //var records = await _context.Customers.Where(x => x.Id == customerId).Select(x => new CustomerModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Address = x.Address,
            //    MobileNo = x.MobileNo
            //}).FirstOrDefaultAsync();
            //return records;
        }

        public async Task<int> AddCustomersDetailsAsync(CustomerModel customerModel)
        {
            var customer = new Customers()
            {
                Name = customerModel.Name,
                Address = customerModel.Address,
                MobileNo = customerModel.MobileNo
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task UpdateCustomerDetailsByIdAsync(int customerId, CustomerModel customerModel)
        {
            //var customer = await _context.Customers.FindAsync(customerId);
            //if(customer != null)
            //{
            //    customer.Name = customerModel.Name;
            //    customer.Address = customerModel.Address;
            //    customer.MobileNo = customerModel.MobileNo;

            //    await _context.SaveChangesAsync();
            //}

            var customer = new Customers()
            {
                Id = customerId,
                Name = customerModel.Name,
                Address = customerModel.Address,
                MobileNo = customerModel.MobileNo
            };
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            // return records;
        }


        public async Task UpdateCustomerPatchAsync(int customerId, JsonPatchDocument customerModel)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if(customer != null)
            {
                customerModel.ApplyTo(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomersDetailsByIdAsync(int customerId)
        {
            // var customer = _context.Customers.Where(x => x.Name == "").FirstOrDefault(); // we can use this if we do not hav the primary key
            var customer = new Customers() { Id = customerId };
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

           // return customer.Id;
        }

        // create a method here to perform an operation then go to the
        // ICustomerRepository to add it.

    }
}
