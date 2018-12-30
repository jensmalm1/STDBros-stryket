using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Week
    {
        public int WeekNr { get; set; }
        public List<Match> Matches { get; set; }
    }
}
