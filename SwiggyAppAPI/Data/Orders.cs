using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Data
{
    public class Orders
    {
        public int Id { get; set; }
        public string OrderAddress { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderCost { get; set; }

    }
}
