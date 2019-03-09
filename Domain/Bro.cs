using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain
{
    public class Bro
    {
        public Bro()
        {
            Ranks = new List<Rank>();
            Ranks.Add(new Rank { Ranking = Constants.StartingRank });
        }

        [Key]
        public int BroId { get; set; }
        public string Name { get; set; }
        public List<Rank> Ranks { get; set; }
    }

    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        public int BroId { get; set; }
        public Bro Bro { get; set; }
        public decimal Ranking { get; set; }
    }
}
