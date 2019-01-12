using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Domain.Enum;

namespace Domain
{
    public class Tip
    {
        [Key]
        public int TipId { get; set; }
        public int BroId { get; set; }
        public int MatchNr { get; set; }
        public Result PlacedTip { get; set; }
    }

}
