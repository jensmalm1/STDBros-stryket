using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TippController : ControllerBase
    {
        private readonly TippContext _context;

        public TippController(TippContext context)
        {
            _context = context;
        }

        // GET: api/Tipp
        [HttpGet]
        public IEnumerable<Bro> GetBros()
        {
            return _context.Bros;
        }

        // GET: api/Tipp/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bro = await _context.Bros.FindAsync(id);

            if (bro == null)
            {
                return NotFound();
            }

            return Ok(bro);
        }

        // PUT: api/Tipp/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBro([FromRoute] int id, [FromBody] Bro bro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bro.Id)
            {
                return BadRequest();
            }

            _context.Entry(bro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tipp
        [HttpPost]
        public async Task<IActionResult> PostBro([FromBody] Bro bro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bros.Add(bro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBro", new { id = bro.Id }, bro);
        }

        // DELETE: api/Tipp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bro = await _context.Bros.FindAsync(id);
            if (bro == null)
            {
                return NotFound();
            }

            _context.Bros.Remove(bro);
            await _context.SaveChangesAsync();

            return Ok(bro);
        }

        private bool BroExists(int id)
        {
            return _context.Bros.Any(e => e.Id == id);
        }
    }
}