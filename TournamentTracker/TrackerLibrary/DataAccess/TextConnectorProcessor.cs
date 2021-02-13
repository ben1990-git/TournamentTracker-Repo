using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// expect to get a string that represents an existing file 
        /// </summary>
        /// <param name="fileName">name of file</param>
        /// <returns> returns a string that represants the full file path</returns>
        public static string FullFilePath(this string fileName)
        {
            // get a partial filepath (directoryPath from configuration and add the file name to the string 
            return $"{ConfigurationManager.AppSettings["filePath"] }\\{fileName}";
        }

        /// <summary>
        /// gets a string that represnts a fullFilePath
        /// </summary>
        /// <param name="file"></param>
        /// <returns> returns the data in that file as a list of strings
        /// each item represants a row in the text file</returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                 return new List<string>();
                
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// convert a list of strings to a PrizeModel
        /// </summary>
        /// <param name="lines">a list of strings</param>
        /// <returns> an new instance of the model populated with the data from the list </returns>
        /// 
        public static List<PrizeModel> ConvetToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();

                p.id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// convert a list of strings to a PersoneModel
        /// </summary>
        /// <param name="lines">a list of strings</param>
        /// <returns> an new instance of the model populated with the data from the list </returns>
        /// 
        public static List<PersonModel> ConvetToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellPhoneNumber = cols[4];

                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// convert a list of strings to a TeamModel.
        /// 
        /// </summary>
        /// <param name="lines">a list of strings</param>
        ///  <param name="peopleFileName">name of file with people data</param>
        /// <returns> an new instance of the model populated with the data from the list </returns>
        /// 
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {
       
            List<TeamModel> output = new List<TeamModel>();

            // gets the people data in order to get the  to populate the teamMembers in TeamModel by id
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvetToPersonModels();

            if (lines.Count!=0)
            {
                foreach (string Line in lines)
                {
                    string[] cols = Line.Split(',');

                    TeamModel t = new TeamModel();

                    t.Id = int.Parse(cols[0]);
                    t.TeamName = cols[1];

                    string[] PersonIds = cols[2].Split('|');

                    foreach (string id in PersonIds)
                    {
                        t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                    }
                    output.Add(t);
                }
            }


            return output;


        }

        public static List<TournamentModel> ConvertToTournmanetModles(this List<string> lines)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvetToPrizeModel();
            List<MatchUpModel> matchUps = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvetToMatchupModels();

            foreach (var line in lines)
            {

                string[] cols = line.Split(',');
                TournamentModel tm = new TournamentModel();
                
                
                    
                    tm.Id = int.Parse(cols[0]);
                    tm.TournamentName = cols[1];
                    tm.EntryFee = decimal.Parse(cols[2]);

                    string[] teamIds = cols[3].Split('|');

                 
                    
                        foreach (var id in teamIds)
                        {
                            tm.EnterdTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                        }
                    


                    if (cols[4].Length > 0)
                    {
                        string[] prizeIds = cols[4].Split('|');

                        foreach (string id in prizeIds)
                        {
                            tm.Prizes.Add(prizes.Where(x => x.id == int.Parse(id)).First());
                        }
                    }

                    // Capture round info
                    string[] rounds = cols[5].Split('|');

                    
                    
                        foreach (string round in rounds)
                        {
                            string[] msText = round.Split('^');

                            List<MatchUpModel> ms = new List<MatchUpModel>();

                            foreach (string matchupModelTextId in msText)
                            {
                                ms.Add(matchUps.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
                            }

                            tm.Rounds.Add(ms);
                        }
                   
                    output.Add(tm);   
            }

            return output;
        }

        public static void saveToPrizeFile(this List<PrizeModel> models)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.id},{ p.PlaceNumber},{ p.PlaceName},{ p.PrizeAmount},{ p.PrizePercentage}");
            }

            File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
        }

        public static void SaveToPeopleFile(this List<PersonModel> models)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellPhoneNumber}");
            }

            File.WriteAllLines(GlobalConfig.PeopleFile.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamModel> models)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add($"{t.Id},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");
            }

            File.WriteAllLines(GlobalConfig.TeamFile.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models)
        {
            List<string> lines = new List<string>();

            foreach (var tm in models)
            {
                lines.Add($"{tm.Id },{tm.TournamentName},{ tm.EntryFee},{ ConvertTeamListToString(tm.EnterdTeams)},{ ConvertPrizesListToString(tm.Prizes)},{ ConvertRoundListToString(tm.Rounds)}");
            }

            File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
        }

        public static void SaveRoundToFile(this TournamentModel model)
        {
            foreach (List<MatchUpModel> round in model.Rounds)
            {
                foreach (MatchUpModel matchup in round)
                {
                    matchup.SaveMatchupToFile();        
                }
            }
        }

        public static void SaveMatchupToFile(this MatchUpModel matchup)
        {

            List<MatchUpModel> matchUps = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvetToMatchupModels();

            int currentId = 1;

            if (matchUps.Count>0)
            {
                currentId = matchUps.OrderByDescending(x => x.Id).First().Id + 1;
            }

            matchup.Id = currentId;

            matchUps.Add(matchup);


            foreach (MatchUpEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile();
            }
            // save file 
            List<string> lines = new List<string>();

            //id=0,entries=1(pipe delimited by id), winner=2, matchupRound=3
            foreach (MatchUpModel m  in matchUps)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchUpRound}");               
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static void SaveEntryToFile(this MatchUpEntryModel entry)
        {
            List<MatchUpEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            int currentId = 1;
            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.id).First().id + 1;
            }

            entry.id = currentId;
            entries.Add(entry);

            List<string> lines = new List<string>();

            foreach (MatchUpEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchUp != null)
                {
                    parent = e.ParentMatchUp.Id.ToString();
                }

                string teamCopmeting = "";
                if (e.TeamCompeting != null)
                {
                    teamCopmeting = e.TeamCompeting.Id.ToString();
                }
                lines.Add($"{e.id},{teamCopmeting},{e.Score},{parent}");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }


        public static List<MatchUpModel> ConvetToMatchupModels(this List<string> lines)
        {
            List<MatchUpModel> output = new List<MatchUpModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchUpModel mu = new MatchUpModel();

                mu.Id = int.Parse(cols[0]);
                mu.Entries = ConvertStringToMatchupEntryModel(cols[1]);
                if (cols[2].Length==0)
                {
                    mu.Winner = null;
                }
                else
                {
                    mu.Winner = LookTeamById(int.Parse(cols[2]));
                }
                
                mu.MatchUpRound = int.Parse(cols[3]);               
                output.Add(mu);
            }

            return output;
        }

        private static List<MatchUpEntryModel> ConvertStringToMatchupEntryModel(string input)
        {
            string[] Ids = input.Split('|');
            List<MatchUpEntryModel> output = new List<MatchUpEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach (string id in Ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');

                    if (cols[0]==id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntryModels();

            return output;
        }

        private static TeamModel LookTeamById(int id )
        {
            List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();

            foreach (string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0]==id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels().First();
                }
            }

            return null;
        }

     
        public static List<MatchUpEntryModel> ConvertToMatchupEntryModels(this List<string> input)
        {
            List<MatchUpEntryModel> output = new List<MatchUpEntryModel>();

            foreach (string line in input)
            {
                string[] cols = line.Split(',');

                MatchUpEntryModel me = new MatchUpEntryModel();
                me.id = int.Parse(cols[0]);
                if (cols[1].Length==0)
                {
                    me.TeamCompeting = null;
                }
                else
                {
                    me.TeamCompeting = LookTeamById(int.Parse(cols[1]));
                }
                
                me.Score = double.Parse(cols[2]);

                int parentId = 0;

                if (int.TryParse(cols[3],out parentId))
                {
                    me.ParentMatchUp = LookupMatchupModelById(parentId);
                }
                else
                {
                    me.ParentMatchUp = null;
                }

                output.Add(me);

            }
            return output;
        }

        private static MatchUpModel LookupMatchupModelById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');

                if (cols[0]==id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvetToMatchupModels().First();
                }
            }

            return null;
        }

        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (TeamModel t in teams)
            {
                output += $"{t.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if (people.Count == 0)
            {
                return "";
            }

            foreach (PersonModel p in people)
            {
                output += $"{p.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPrizesListToString(List<PrizeModel> prizes)
        {

            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (PrizeModel p in prizes)
            {
                output += $"{p.id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertRoundListToString(List<List<MatchUpModel>> rounds)
        {

            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<MatchUpModel> r in rounds)
            {
                output += $"{ConvertMatchUpToString(r)}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertMatchUpToString(List<MatchUpModel> matchups)
        {
            string output = "";

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (MatchUpModel m in matchups)
            {
                output += $"{m.Id}^";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertMatchupEntryListToString(List<MatchUpEntryModel> entries)
        {

            string output = "";

            if (entries.Count == 0)
            {
                return "";
            }

            foreach (MatchUpEntryModel e in entries)
            {
                output += $"{e.id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static void UpdateMatchupToFile(this MatchUpModel matchup)
        {
            List<MatchUpModel> matchUps = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvetToMatchupModels();

            MatchUpModel oldMatchup=new MatchUpModel();
            foreach (MatchUpModel m in matchUps)
            {
                if (m.Id==matchup.Id)
                {
                    oldMatchup = m;
                }
            }
            matchUps.Remove(oldMatchup);

            matchUps.Add(matchup);


            foreach (MatchUpEntryModel entry in matchup.Entries)
            {
                entry.UpdateEntryToFile();
            }
            // save file 
            List<string> lines = new List<string>();

            //id=0,entries=1(pipe delimited by id), winner=2, matchupRound=3
            foreach (MatchUpModel m in matchUps)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchUpRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static void UpdateEntryToFile(this MatchUpEntryModel entry)
        {
            List<MatchUpEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            MatchUpEntryModel oldEntry = new MatchUpEntryModel();

            foreach (MatchUpEntryModel e in entries)
            {
                if (e.id==entry.id)
                {
                    oldEntry = e;
                }
            }
            entries.Remove(oldEntry);

            entries.Add(entry);

            List<string> lines = new List<string>();

            foreach (MatchUpEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchUp != null)
                {
                    parent = e.ParentMatchUp.Id.ToString();
                }

                string teamCopmeting = "";
                if (e.TeamCompeting != null)
                {
                    teamCopmeting = e.TeamCompeting.Id.ToString();
                }
                lines.Add($"{e.id},{teamCopmeting},{e.Score},{parent}");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }



    }
}






