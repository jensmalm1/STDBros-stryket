using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace App
{
    public class RankCalculator : IRankCalculator
    {
        private readonly PadelContext _context;
        public RankCalculator(PadelContext context)
        {
            _context = context;
        }
        public void AddMatchAndRanks(Match match, List<Team> teams)
        {
            var winningTeam = match.Result.Winner;
            var tierPoints = CalcTierPoints(match, teams);
            var impactPoints = CalcImpactPoints(match, tierPoints);

            var setDiff = Math.Abs(match.Result.SetsCountTeam1 - match.Result.SetsCountTeam2);
            var gemDiff = 0;
            match.Result.Sets.ForEach(x => gemDiff += (x.TeamOneGems - x.TeamTwoGems));
            gemDiff = Math.Abs(gemDiff);
            if (winningTeam == Winner.TeamOne && gemDiff < 0)
                gemDiff = gemDiff * -1;
            if (winningTeam == Winner.TeamTwo && gemDiff > 0)
                gemDiff = gemDiff * -1;

            var changePoints = new List<decimal>();
            changePoints.Add(impactPoints[0] + impactPoints[0] * (gemDiff * Constants.GemMultiplier * setDiff * Constants.SetMultiplier));
            changePoints.Add(impactPoints[1] + impactPoints[1] * (gemDiff * Constants.GemMultiplier * setDiff * Constants.SetMultiplier));
            changePoints.Add(impactPoints[2] + impactPoints[2] * (gemDiff * Constants.GemMultiplier * setDiff * Constants.SetMultiplier));
            changePoints.Add(impactPoints[3] + impactPoints[3] * (gemDiff * Constants.GemMultiplier * setDiff * Constants.SetMultiplier));


            if (winningTeam == Winner.TeamOne)
            {
                changePoints[2] = changePoints[2] * -1;
                changePoints[3] = changePoints[3] * -1;
            }
            else
            {
                changePoints[0] = changePoints[0] * -1;
                changePoints[1] = changePoints[1] * -1;
            }
            var dej = _context.Bros.Where(b => b.Name == teams.First().Bros.First().Name).FirstOrDefault();
            _context.Bros.Where(b => b.Name == teams.First().Bros.First().Name).FirstOrDefault().Ranks.Add(new Rank { Ranking = teams.First().Bros.First().Ranks.LastOrDefault().Ranking + changePoints[0] });
            _context.Bros.Where(b => b.Name == teams.First().Bros.Last().Name).FirstOrDefault().Ranks.Add(new Rank { Ranking = teams.First().Bros.Last().Ranks.LastOrDefault().Ranking + changePoints[1] });
            _context.Bros.Where(b => b.Name == teams.Last().Bros.First().Name).FirstOrDefault().Ranks.Add(new Rank { Ranking = teams.Last().Bros.First().Ranks.LastOrDefault().Ranking + changePoints[2] });
            _context.Bros.Where(b => b.Name == teams.Last().Bros.Last().Name).FirstOrDefault().Ranks.Add(new Rank { Ranking = teams.Last().Bros.Last().Ranks.LastOrDefault().Ranking + changePoints[3] });
            _context.SaveChanges();
            var matchDb=_context.Add(match).Entity;
            var matchTeam1 = new MatchTeam
            {

                TeamId = teams[0].TeamId,
                MatchId = matchDb.MatchId
            };
            var matchTeam2 = new MatchTeam
            {
                TeamId = teams[1].TeamId,
                MatchId = matchDb.MatchId
            };
            _context.Add(matchTeam1);
            _context.Add(matchTeam2);
            _context.SaveChanges();
        }

        public static List<decimal> CalcTierPoints(Match match, List<Team> teams)
        {

            var broOne = teams.First().Bros.First();
            var broTwo = teams.First().Bros.Last();
            var broThree = teams.Last().Bros.First();
            var broFour = teams.Last().Bros.First();

            var teamOneAverageRank = teams.First().Bros.Select(x => x.Ranks.Last().Ranking).Average();
            var teamTwoAverageRank = teams.Last().Bros.Select(x => x.Ranks.Last().Ranking).Average();

            var tierPoints = new List<decimal>
            {
                (broOne.Ranks.Last().Ranking * Constants.OwnProportion + broTwo.Ranks.Last().Ranking * (1 - Constants.OwnProportion)) / teamOneAverageRank,
                (broTwo.Ranks.Last().Ranking * Constants.OwnProportion + broOne.Ranks.Last().Ranking * (1 - Constants.OwnProportion)) / teamOneAverageRank,
                (broThree.Ranks.Last().Ranking * Constants.OwnProportion + broFour.Ranks.Last().Ranking * (1 - Constants.OwnProportion)) / teamTwoAverageRank,
                (broFour.Ranks.Last().Ranking * Constants.OwnProportion + broThree.Ranks.Last().Ranking * (1 - Constants.OwnProportion)) / teamTwoAverageRank
            };

            return tierPoints;
        }

        public static List<decimal> CalcImpactPoints(Match match, List<decimal> tierPoints)
        {


            var impactPoints = new List<decimal>();
            if (match.Result.Winner == Winner.TeamOne)
            {
                impactPoints.Add(1 / tierPoints[0]);
                impactPoints.Add(1 / tierPoints[1]);
                impactPoints.Add(tierPoints[2] / 1);
                impactPoints.Add(tierPoints[3] / 1);
            }
            else
            {
                impactPoints.Add(tierPoints[0] / 1);
                impactPoints.Add(tierPoints[1] / 1);
                impactPoints.Add(1 / tierPoints[1]);
                impactPoints.Add(1 / tierPoints[1]);
            }

            return impactPoints;
        }
    }
}
