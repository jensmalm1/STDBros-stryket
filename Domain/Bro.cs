using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain
{
    public class Bro
    {
        [Key]
        public int BroId { get; set; }
        public string Name { get; set; }
        public List<Rank> Ranks { get; set; }
    }

    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        public decimal Ranking { get; set; }
    }
}
