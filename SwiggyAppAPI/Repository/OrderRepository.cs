using Microsoft.EntityFrameworkCore;
using SwiggyAppAPI.Data;
using SwiggyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            // var records = await _context.Orders.Select()
            var records = await _context.Orders.Select(x => new OrderModel() { 
                Id = x.Id,
                OrderCost = x.OrderCost,
                OrderAddress = x.OrderAddress,
                OrderQuantity=x.OrderQuantity

            }).ToListAsync();
            
            return records;
        }


    }
}
