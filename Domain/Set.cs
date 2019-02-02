using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Set
    {
        [Key]
        public int SetId { get; set; }
        public int TeamOneGems { get; set; }
        public int TeamTwoGems { get; set; }
        public Winner Winner
        {
            get
            {
                return this.Winner;
            }
            set
            {
                GetWinner(this);
            }
        }

        private static Winner GetWinner(Set set)
        {
            return set.TeamOneGems == set.TeamTwoGems ? Winner.Draw :
                set.TeamOneGems > set.TeamTwoGems ? Winner.TeamOne :
                Winner.TeamTwo;
        }
    }
}
