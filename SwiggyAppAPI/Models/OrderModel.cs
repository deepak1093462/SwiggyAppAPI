using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderAddress { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderCost { get; set; }

    }
}
