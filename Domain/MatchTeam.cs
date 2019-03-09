using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MatchTeam
    {
        public int TeamId { get; set; }
        public int MatchId { get; set; }
        public Team Team { get; set; }
        public Match Match { get; set; }
    }
}
