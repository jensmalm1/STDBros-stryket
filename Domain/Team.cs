using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public List<Bro> Bros { get; set; }
    }
}

