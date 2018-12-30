using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Match
    {
        public int MatchNr { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public ResultEnum Result { get; set; }
        
    }
}

