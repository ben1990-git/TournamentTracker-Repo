using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnactor : IDataConnaction
    {
        public void CompleteTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile
          .FullFilePath()
          .LoadFile()
          .ConvertToTournmanetModles();

            tournaments.Remove(model);

            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResults(model);
        }

        public void CreatePerson(PersonModel model)
        {
            //load text file
            //convert text file to list of PersoeModel
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvetToPersonModels();

            // finds max id
            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }


            model.Id = currentId;

            // add a new record with the new id (max+1)
            people.Add(model);

            //Convert the person to list <string>
            //save thr list<string> to the next file

            people.SaveToPeopleFile();

            
        }

        public void CreatePrize(PrizeModel model)
        {
            //load text file
            //convert text file to list of prizeModel
          List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvetToPrizeModel();

            // finds max id
            int currentId = 1;
            if (prizes.Count>0)
            {
                currentId = prizes.OrderByDescending(x => x.id).First().id + 1;
            }
                
                
            model.id = currentId;

            // add a new record with the new id (max+1)
            prizes.Add(model);

            //Convert the prizes to list <string>
            //save thr list<string> to the next file

            prizes.saveToPrizeFile();

           


        }

        public void CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            // finds max id
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }


            model.Id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile();

           
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournmanetModles();

            int correntId = 1;

            if (tournaments.Count>0)
            {
                correntId = tournaments.OrderByDescending(x => x.Id).First().Id+1;
            }

            model.Id = correntId;

            model.SaveRoundToFile();

            tournaments.Add(model);

            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResults(model);
        }

        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvetToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
         return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public List<TournamentModel> GetTournament_All()
        {
             List < TournamentModel > tournaments = GlobalConfig.TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournmanetModles();

            return tournaments;
        }

        public void UpadateMatchup(MatchUpModel model)
        {
            model.UpdateMatchupToFile();
        }
    }
}
