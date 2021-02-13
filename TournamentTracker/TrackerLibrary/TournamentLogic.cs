using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
   public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamModel(model.EnterdTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));
            CreateOtherRounds(model, rounds);
           


        }

        public static void UpdateTournamentResults (TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchUpModel> toScore = new List<MatchUpModel>();

            foreach (List<MatchUpModel> round in model.Rounds)
            {
                foreach (MatchUpModel rm in round)
                {
                    //rm.Entries.Count==1 chacks for byes entry in matchup
                    //rm.Entries.Any(x=>x.Score!=0 => we dont do ties in tourenamet there for one team at least have a score 
                    // of score!=0 in a match up !
                    if (rm.Winner==null && (rm.Entries.Any(x=>x.Score!=0)|| rm.Entries.Count==1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

             MarkWinnewrsInMatchup(toScore);

             AdvancedWinners(toScore,model);

            //shorter code 
            //foreach (var x in toScore)
            //{
            //    GlobalConfig.Connaction.UpadateMatchup(x));

            //}
            toScore.ForEach(x => GlobalConfig.Connaction.UpadateMatchup(x));
            int endingRound = model.CheckCurrentRound();

            if(endingRound>startingRound)
            {
                model.AlertUsersToNewRound();
            }
        }

        public   static void AlertUsersToNewRound( this TournamentModel model)
        {
            int currentRoundNumber = model.CheckCurrentRound();
            List<MatchUpModel> currentRound = model.Rounds.Where(x => x.First().MatchUpRound == currentRoundNumber).First();

            foreach (MatchUpModel matchup in currentRound)
            {
                foreach (MatchUpEntryModel me in matchup.Entries)
                {
                    foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries
                            .Where(x => x.TeamCompeting != me.TeamCompeting)
                            .FirstOrDefault());
                    }
                }
            }
        }

        private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchUpEntryModel competitor)
        {

            if (p.EmailAddress==null)
            {
                return;
            }
            
                if (p.EmailAddress.Length == 0 )
                {
                    return;
                }
            
          

            string toAdress = "";
            string subject = "";
            StringBuilder body = new StringBuilder();

            if (competitor!=null)
            {
                subject= $"You have a new matchup with {competitor.TeamCompeting.TeamName}";

                body.AppendLine("<h1>you have a new matchup</h>");
                body.Append("<strong>Competetitor:<strong> ");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("have a great time!");
                body.AppendLine("tournamet tracker");
            }
            else
            {
                subject = "you have a bye week this round";

                body.AppendLine("injoy your round off");
                body.AppendLine("tournamet tracker");
            }

            toAdress=p.EmailAddress;
           
            
                EmailLogic.SendEmail(toAdress, subject, body.ToString());
            
        }

        private static void AdvancedWinners(List<MatchUpModel> models ,TournamentModel tournament)
        {
            foreach (MatchUpModel m in models)
            {
                foreach (List<MatchUpModel> round in tournament.Rounds)
                {
                    foreach (MatchUpModel rm in round)
                    {
                        foreach (MatchUpEntryModel me in rm.Entries)
                        {
                            if (me.ParentMatchUp != null)
                            {
                                if (me.ParentMatchUp.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connaction.UpadateMatchup(rm);
                                }
                            }

                        }
                    }
                }
            }
         
        }

        private static void CreateOtherRounds(TournamentModel model,int Rounds)
        {
            int round = 2;
            List<MatchUpModel> previousRound = model.Rounds[0];
            List<MatchUpModel> currRound = new List<MatchUpModel>();
            MatchUpModel currMatchUp = new MatchUpModel();

            while (round<=Rounds)
            {
                foreach (MatchUpModel match   in previousRound)
                {
                    currMatchUp.Entries.Add(new MatchUpEntryModel { ParentMatchUp = match });

                    if (currMatchUp.Entries.Count>1)
                    {
                        currMatchUp.MatchUpRound = round;
                        currRound.Add(currMatchUp);
                        currMatchUp = new MatchUpModel();
                    }
                }

                model.Rounds.Add(currRound);
                previousRound = currRound;
                currRound = new List<MatchUpModel>();
                round += 1;

            }
        }

        private static int NumberOfByes(int rounds,int numberOfTeams)
        {
            int output = 0;

            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;

            return output;
        }

        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val<teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;



        }

        private static List<TeamModel> RandomizeTeamModel(List<TeamModel> teams)
        {
            return teams.OrderBy(x=> Guid.NewGuid()).ToList();
        }

        private static List<MatchUpModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchUpModel> output = new List<MatchUpModel>();
            MatchUpModel curr = new MatchUpModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchUpEntryModel { TeamCompeting = team });

                if (byes>0||curr.Entries.Count>1)
                {
                    curr.MatchUpRound = 1;
                    output.Add(curr);
                    curr = new MatchUpModel();

                    if (byes>=0)
                    {
                        byes -= 1;
                    }
                }
            }

            return output;
        }

        private static void MarkWinnewrsInMatchup(List<MatchUpModel> models)
        {
            //geater or lasser
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            
            foreach (MatchUpModel m in models)
            {
                // chacks for byes entry
                if (m.Entries.Count==1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                // 0 means falls or low score wins
                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if(m.Entries[1].Score < m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("we do not alow ties in this app ");
                    }
                }
                else
                {
                    // 1 mean true or high score wins
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[1].Score > m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("we do not alow ties in this app ");
                    }
                }
            }
            //if (teamOneScore > teamTwoScore)
            //{
            //    m.Winner = m.Entries[0].TeamCompeting;
            //}
            //else if (teamOneScore < teamTwoScore)
            //{
            //    m.Winner = m.Entries[1].TeamCompeting;
            //}
            //else
            //{
            //    MessageBox.Show("i do not handel tie games");
            //}
        }

        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;

            foreach (List<MatchUpModel> round in model.Rounds)
            {
                if (round.All(x => x.Winner != null))
                {
                    output += 1;
                }
                else
                    return output;
            }


            // tournament is complete
            CompleteTournament(model);

            return output-1;
        }

        private static void CompleteTournament(TournamentModel model)
        {


            TeamModel winners = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerPrize = 0;

            if (model.Prizes.Count > 0)
            {
                decimal totalIncome = model.EnterdTeams.Count * model.EntryFee;

                PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();

                PrizeModel SecendPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if (firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrizePayout(totalIncome);
                }
                if (SecendPlacePrize != null)
                {
                    runnerPrize = SecendPlacePrize.CalculatePrizePayout(totalIncome);
                }

            }
                string subject = "";
                StringBuilder body = new StringBuilder();

              
                
                    subject = $"in {model.TournamentName}. {winners.TeamName} has won";

                    body.AppendLine("<h1>we have a winner</h>");
                    body.AppendLine("<p>congratulations to our winner.</p> ");
                    body.AppendLine("<br/>");

                if (winnerPrize > 0)
                {

                    body.AppendLine($"<p> {winners.TeamName} will receive {winnerPrize}</p>");

                }
                if (runnerPrize>0)
                {
                    body.AppendLine($"<p> {runnerUp.TeamName} will receive {runnerPrize}</p>");

                }

                body.AppendLine("<p>thanks for a great tounrnament</p>");
                body.AppendLine("tournamet tracker");


                List<string> bcc = new List<string>();

                foreach (TeamModel t in model.EnterdTeams)
                {
                    foreach (PersonModel p in t.TeamMembers)
                    {
                        if (p.EmailAddress.Length>0)
                        {
                            bcc.Add(p.EmailAddress);
                        }
                    }
                }

                EmailLogic.SendEmail(new List<string>(),bcc ,subject, body.ToString());

                // complete tounrament
                model.CompleteTounrnament();


            
            
        }

        private static decimal CalculatePrizePayout(this PrizeModel prize, decimal totalIncome)
        {
            decimal output = 0;
            if (prize.PrizeAmount>0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome, Convert.ToDecimal(prize.PrizePercentage / 100));
            }

            return output;
        }
    }
}
