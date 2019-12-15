using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public List<MatchTeam> MatchTeams { get; set; }
        public List<Player> Bros { get; set; }
    }
}

