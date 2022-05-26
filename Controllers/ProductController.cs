using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
    {
        private GeneralStoreDBContext _db;
        public ProductController(GeneralStoreDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductEdit newProduct)
        {
            var product =  new DevProduct      
            {
            Name = newProduct.Name,
            Price = newProduct.Price,
            QuantityInStock = newProduct.Quantity,
            };

            _db.DevProducts.Add(product);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _db.DevProducts.ToListAsync();
            return Ok(products);
        }
    }
