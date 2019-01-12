using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Domain.Enum;

namespace Domain
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public List<Odds> Odds { get; set; }
        public Result Result { get; set; } = Result.NotPlayedYet;
    }
}

