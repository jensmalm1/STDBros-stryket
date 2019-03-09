using System;
using System.Collections.Generic;

namespace Domain
{
    public class GameInfo
    {
        public List<string> Names { get; set; }
        public List<Tuple<int,int>> Sets { get; set; }
    }
}
