using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public interface IRankCalculator
    {
        void AddMatchAndRanks(Match match, List<Team> teams);
    }
}
