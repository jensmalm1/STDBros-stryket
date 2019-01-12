using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Odds
    {
        public int OddsId { get; set; }
        public double HomeWin { get; set; }
        public double Draw { get; set; }
        public double AwayWin { get; set; }
    }
}
