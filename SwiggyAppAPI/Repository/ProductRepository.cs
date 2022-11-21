using Microsoft.EntityFrameworkCore;
using SwiggyAppAPI.Data;
using SwiggyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            // var records = await _context.Orders.Select()
            var records = await _context.Products.Select(x => new ProductModel()
            {
                Id = x.Id,
                ProdCost=x.ProdCost,
                ProdDescription = x.ProdDescription,
                ProdName = x.ProdName,
                ProdQuantity = x.ProdQuantity
            }).ToListAsync();

            return records;
        }
    }
}
