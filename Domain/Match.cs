using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public List<MatchTeam> MatchTeams { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public Result Result { get; set; }
    }
}

