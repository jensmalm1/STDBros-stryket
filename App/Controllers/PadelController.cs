﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Data;
using Domain;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadelController : ControllerBase
    {
        //private readonly PadelContext _context;

        public PadelController(/*PadelContext context*/)
        {
            //_context = context;
        }

        // GET: api/Padel
        [HttpGet]
        public IActionResult GetBros()
        {
            return Ok(PadelDb.GetBros());
            //return _context.Bros;
        }

        [HttpPost]
        public IActionResult AddGame(List<Team> teams, Result result)
        {
            using (var context = new PadelContext())
            {
                var match = new Match
                {
                    Result = result,
                    Teams = teams
                };

                RankCalculator.UpdateRank(match);

                return Ok("Match added");
            }
        }

        [HttpPost("AddBro")]
        public IActionResult AddBro([FromBody] Bro bro)
        {
            using (var context = new PadelContext())
            {
                context.Add(bro);
                context.SaveChanges();
            }

            return Ok("Bro Added");

        }
        //// GET: api/Padel/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBro([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var bro = await _context.Bros.FindAsync(id);

        //    if (bro == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(bro);
        //}

        //// PUT: api/Padel/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBro([FromRoute] int id, [FromBody] Bro bro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != bro.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bro).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BroExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Padel
        //[HttpPost]
        //public async Task<IActionResult> PostBro([FromBody] Bro bro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Bros.Add(bro);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetBro", new { id = bro.Id }, bro);
        //}

        //// DELETE: api/Padel/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBro([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var bro = await _context.Bros.FindAsync(id);
        //    if (bro == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Bros.Remove(bro);
        //    await _context.SaveChangesAsync();

        //    return Ok(bro);
        //}

        //private bool BroExists(int id)
        //{
        //    return _context.Bros.Any(e => e.Id == id);
        //}
    }
}