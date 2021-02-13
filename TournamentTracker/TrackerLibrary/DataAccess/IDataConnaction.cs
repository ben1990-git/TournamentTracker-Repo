using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
   public interface IDataConnaction
    {
        /// <summary>
        /// create a person in a storage medium
        /// </summary>
        /// <param name="model">PrizeModel type object</param>
        /// <returns></returns>
        void CreatePrize(PrizeModel model);

        void CreatePerson(PersonModel model);

        void CreateTeam(TeamModel model);

        void CreateTournament(TournamentModel model);

        void UpadateMatchup(MatchUpModel model);

        List<PersonModel> GetPerson_All();

        List<TeamModel> GetTeam_All();

        List<TournamentModel> GetTournament_All();

        void CompleteTournament(TournamentModel model);

        


    }
}
