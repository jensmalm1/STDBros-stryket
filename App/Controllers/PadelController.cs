using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Data;
using Domain;
using System;
using System.Linq;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadelController : ControllerBase
    {
        private readonly PadelContext _context;
        private readonly IRankCalculator _rankCalculator;

        public PadelController(PadelContext context, IRankCalculator rankCalculator)
        {
            _context = context;
            _rankCalculator = rankCalculator;
        }

        // GET: api/Padel       
        [HttpGet]
        public IActionResult GetBros()
        {

            var response = _context.Bros.ToList();
            var hej=response.Select(b => new { b.Name, b.Ranks.ToList().LastOrDefault().Ranking});
            
            return Ok(response);
        }

        [HttpPost("AddGame")]
        public IActionResult AddGame([FromBody] GameInfo gameInfo)
        {
            var inputSets = new Tuple<int, int>(1, 2);

            var broDb = _context.Bros.ToList();

            var bros = new List<Bro>();
            foreach (var name in gameInfo.Names)
            {
                bros.Add(broDb.Find(x => x.Name.Contains(name)));
            }

            var teams = new List<Team>();
            var team1=_context.Teams.Where(t => t.Bros.Contains(bros[0]) && t.Bros.Contains(bros[1])).FirstOrDefault();
            if (team1==null)
            {
                team1=_context.Add(new Team
                {
                    Bros = new List<Bro>
                    {
                       bros[0],
                       bros[1]
                    },
                }).Entity;
                _context.SaveChanges();
            }
            teams.Add(team1);

            var team2 = _context.Teams.Where(t => t.Bros.Contains(bros[2]) && t.Bros.Contains(bros[3])).FirstOrDefault();
            if (team2 == null)
            {
                team2=_context.Add(new Team
                {
                    Bros = new List<Bro>
                    {
                       bros[2],
                       bros[3]
                    },
                }).Entity;
                _context.SaveChanges();
            }
            teams.Add(team2);

            var sets = new List<Set>();

                foreach (var set in gameInfo.Sets)
                {
                var thisSet=_context.Add(
                    new Set
                    {
                        TeamOneGems = set.Item1,
                        TeamTwoGems = set.Item2,
                        Winner = GetSetWinner(set)
                    });
                _context.SaveChanges();
                sets.Add(thisSet.Entity);
                }
                var setsCount = GetSetsCount(sets);

                
                var result = _context.Add(new Result
                {
                    Sets = sets,
                    SetsCountTeam1 = setsCount.Item1,
                    SetsCountTeam2 = setsCount.Item2,
                    Winner = GetMatchWinner(sets)
                }).Entity;


                var match =new Match
                {
                    Result = result
                };

                    _rankCalculator.AddMatchAndRanks(match,teams);

                //foreach (var team in teams)
                //{
                //    var participant = new Participant
                //    {
                //        Team = team,
                //        Match = match
                //    };
                //    _context.Add(participant);
                //}
                //_context.SaveChanges();

            return Ok("Match added");
        }
        private static Winner GetSetWinner(Tuple<int, int> set)
        {
            return set.Item1 == set.Item2 ? Winner.Draw :
                set.Item1 > set.Item2 ? Winner.TeamOne :
                Winner.TeamTwo;
        }

        public static Tuple<int, int> GetSetsCount(List<Set> sets)
        {
            var setsTeam1 = 0;
            var setsTeam2 = 0;

            foreach (var set in sets)
            {
                if (set.Winner == Winner.TeamOne)
                    setsTeam1++;
            }

            foreach (var set in sets)
            {
                if (set.Winner == Winner.TeamTwo)
                    setsTeam2++;
            }

            return Tuple.Create(setsTeam1, setsTeam2);
        }

        public static Winner GetMatchWinner(List<Set> sets)
        {
            var team1Sets = 0;
            var team2Sets = 0;
            foreach (var set in sets)
            {
                if (set.Winner == Winner.TeamOne)
                    team1Sets++;
                if (set.Winner == Winner.TeamTwo)
                    team2Sets++;
            }

            return team1Sets > team2Sets ? Winner.TeamOne :
                team2Sets > team1Sets ? Winner.TeamTwo :
                Winner.Draw;
        }

        [HttpPost("AddBro")]
        public IActionResult AddBro([FromBody] Bro bro)
        {

                _context.Add(bro);
                _context.SaveChanges();
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