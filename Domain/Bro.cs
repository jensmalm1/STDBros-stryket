using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Bro
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Week> Weeks { get; set; }
    }
}
