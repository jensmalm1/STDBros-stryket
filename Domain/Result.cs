using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }
        public List<Set> Sets { get; set; }
        public int SetsCountTeam1 { get; set; }
        public int SetsCountTeam2 { get; set; }
        public Winner Winner { get; set; }
    }
}
