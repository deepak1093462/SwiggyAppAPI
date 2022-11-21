using SwiggyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAllOrdersAsync();
    }
}
