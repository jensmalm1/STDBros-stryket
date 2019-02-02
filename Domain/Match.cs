using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public List<Team> Teams { get; set; }
        public Result Result { get; set; }
    }
}

