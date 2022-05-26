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
public class TransactionController : ControllerBase
    {
        private GeneralStoreDBContext _db;
        public TransactionController(GeneralStoreDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromForm]TransactionEdit newTransaction)
        {
            var transaction =  new DevTransaction
            {
            ProductId = newTransaction.ProductId,
            CustomerId = newTransaction.CustomerId,
            
            };

            _db.DevTransactions.Add(transaction);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _db.DevTransactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromForm] TransactionEdit model, [FromRoute] int id)
        {
            var oldTransaction = await _db.DevTransactions.FindAsync(id);
            if (oldTransaction == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            var transaction = await _db.DevTransactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            _db.DevTransactions.Remove(transaction);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
