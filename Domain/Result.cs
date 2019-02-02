using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public List<Set> Sets { get; set;}
        public int TeamOneSets { get; set; }
        public int TeamTwoSets { get; set; }
        public Winner Winner {
            get
            {
                return this.Winner;
            }
            set
            {
                GetWinner(this);
            }
        }
        private Winner GetWinner(Result result)
        {
            return result.TeamOneSets == result.TeamTwoSets ? Winner.Draw :
            result.TeamOneSets > result.TeamTwoSets ? Winner.TeamOne :
            Winner.TeamTwo;
        }
    }
}
