using Domain;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class RankCalculator
    {
        public static void UpdateRank(Match match)
        {
            var winningTeam = match.Result.Winner;
            var impactPoints = CalcImpactPoints(match);

            var setDiff = match.Result.TeamOneSets - match.Result.TeamTwoSets;

            var gemDiff = 0;
            match.Result.Sets.ForEach(x => gemDiff += (x.TeamOneGems - x.TeamTwoGems));

            if (winningTeam == Winner.TeamTwo)
            {
                setDiff *= -1;
                gemDiff *= -1;
            }

            var changePoints = new List<decimal>();

            match.Teams.First().Bros.First().Ranks.Add(new Rank { Ranking=changePoints[0] });
            match.Teams.First().Bros.Last().Ranks.Add(new Rank { Ranking = changePoints[1] });
            match.Teams.Last().Bros.First().Ranks.Add(new Rank { Ranking = changePoints[2] });
            match.Teams.Last().Bros.Last().Ranks.Add(new Rank { Ranking= changePoints[3] });

            for (int i = 0; i <= 3; i++)
                changePoints[i] = impactPoints[i] * gemDiff * Constants.GemMultiplier * setDiff * Constants.SetMultiplier;
        }

        public static List<decimal> CalcTierPoints(Match match)
        {
            var ownProportion = Constants.OwnProportion;

            var broOne = match.Teams.First().Bros.First();
            var broTwo = match.Teams.First().Bros.Last();
            var broThree = match.Teams.Last().Bros.First();
            var broFour = match.Teams.Last().Bros.First();

            var teamOneAverageRank = match.Teams.First().Bros.Select(x => x.Ranks.Last().Ranking).Average();
            var teamTwoAverageRank = match.Teams.Last().Bros.Select(x => x.Ranks.Last().Ranking).Average();

            var tierPoints = new List<decimal>
            {
                broOne.Ranks.Last().Ranking * ownProportion + broTwo.Ranks.Last().Ranking * (1 - ownProportion) / teamOneAverageRank,
                broTwo.Ranks.Last().Ranking * ownProportion + broOne.Ranks.Last().Ranking * (1 - ownProportion) / teamOneAverageRank,
                broThree.Ranks.Last().Ranking * ownProportion + broFour.Ranks.Last().Ranking * (1 - ownProportion) / teamTwoAverageRank,
                broFour.Ranks.Last().Ranking * ownProportion + broThree.Ranks.Last().Ranking * (1 - ownProportion) / teamTwoAverageRank
            };

            return tierPoints;
        }

        public static List<decimal> CalcImpactPoints(Match match)
        {
            var tierPoints=CalcTierPoints(match);

            var impactPoints = new List<decimal>();
            if (match.Result.Winner == Winner.TeamOne)
            {
                impactPoints[0] = 1 / tierPoints[0];
                impactPoints[1] = 1 / tierPoints[1];
                impactPoints[2] = tierPoints[1];
                impactPoints[3] = tierPoints[1];
            }
            else
            {
                impactPoints[0] = tierPoints[0];
                impactPoints[1] = tierPoints[1];
                impactPoints[2] = 1 / tierPoints[1];
                impactPoints[3] = 1 / tierPoints[1];
            }

            return impactPoints;
        }
    }
}
