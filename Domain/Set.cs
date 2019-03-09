using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Set
    {
        [Key]
        public int SetId { get; set; }
        public int TeamOneGems { get; set; }
        public int TeamTwoGems { get; set; }
        public Winner Winner{ get; set; }
    }
}
