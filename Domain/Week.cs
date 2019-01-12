using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Week
    {
        [Key]
        public int WeekId { get; set; }
        public List<Match> Matches { get; set; }
    }
}
