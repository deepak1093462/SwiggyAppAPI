using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Models
{
    public class ProductModel
    {
        
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public int ProdCost { get; set; }
        public int ProdQuantity { get; set; }


    }
}
