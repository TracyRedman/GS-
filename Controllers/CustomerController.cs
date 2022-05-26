using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private GeneralStoreDBContext _db;
        public CustomerController(GeneralStoreDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromForm] CustomerEdit newCustomer)
        {
            var customer = new DevCustomer(){

            Email = newCustomer.Email,
            Name = newCustomer.Name
            };
            await _db.AddAsync(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _db.DevCustomers.ToListAsync();
            return Ok(customers);
        }
    }
