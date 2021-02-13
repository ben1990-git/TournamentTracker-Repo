using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    // no logic here only the way to acsses the db and avoid pit falls that could crash the app 
    // all the code is input and output to the db by the models represantaion no buisness logic (may look like some buissness logic in implaed,
    // thats becuse busissnes logic exist in the db by choice, we dont inplament BL here we only exacute it !
    public class SqlConnactor : IDataConnaction
    {
        private const string db = "Tournaments";
        public void CreatePerson(PersonModel model)
        {
            using (IDbConnection connaction = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellPhoneNumber", model.CellPhoneNumber);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connaction.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@Id");

                

            }

        }

        public void CreatePrize(PrizeModel model)
        {
            using (IDbConnection connaction = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@placeNumber", model.PlaceNumber);
                p.Add("@placeName", model.PlaceName);
                p.Add("@prizeAmount", model.PrizeAmount);
                p.Add("@prizePrecentage", model.PrizePercentage);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connaction.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@Id");

                
            }
        }

        public void CreateTeam(TeamModel model)
        {
            using (IDbConnection connaction = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                // in the db there are 3 tables "Teams","People","TeamMembers".
                // "TeamMambers" is A "COMPOSIT KEY" that connacets the 2 other tables "Teams","People" by id.
                //(FK+FK=PK)
                // there is no TeamMambersModel in our lib its a porp in TeamModel and a Table by itself in the db.


                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);

                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connaction.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@Id");

                // populate the "TeamMembers" table in db

                foreach (PersonModel tm in model.TeamMembers)
                {
                    p = new DynamicParameters();

                    p.Add("@TeamId", model.Id);
                    p.Add("@PersonId", tm.Id);

                    connaction.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

                
            }


        }

        public void CreateTournament(TournamentModel model)
        {
            // tournamet table has a lot of FK so we break down the populate opration for this table to saparate oprations
            //in order to populate the db coractly
            using (IDbConnection connaction = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {

                SaveTournament(connaction, model);

                SaveTournamentPrizes(connaction, model);

                SaveTournamentEntries(connaction, model);

                SaveTournamentRounds(connaction, model);

                TournamentLogic.UpdateTournamentResults(model);
            }
        }


        // private helper funcs to break down the emplmention of CreateTournament()
        // it is a  comlpex opertion there for we break it down to smaller pisces


        private void SaveTournamentRounds(IDbConnection connaction, TournamentModel model)
        {
            // rounds is not a table in the db or a model.
            //rounds is a data member in TournamentModel 
            // it is a list of a list of matchups and every matchup has a list of matchupEntry

            foreach (List<MatchUpModel> round in model.Rounds)
            {
                foreach (MatchUpModel matchup in round)
                {
                    var p = new DynamicParameters();
                    p.Add("@TournamentId", model.Id);
                    p.Add("@MatchupRound", matchup.MatchUpRound);
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connaction.Execute("dbo.spMatchup_Insert", p, commandType: CommandType.StoredProcedure);

                    matchup.Id = p.Get<int>("@id");

                    foreach (MatchUpEntryModel entry in matchup.Entries)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupId", matchup.Id);

                        if (entry.ParentMatchUp == null)
                        {
                            p.Add("@ParentMatchupId", null);
                        }
                        else
                        {
                            p.Add("@ParentMatchupId", entry.ParentMatchUp.Id);
                        }
                        if (entry.TeamCompeting == null)
                        {
                            p.Add("@TeamCompetingId", null);
                        }
                        else
                        {
                            p.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                        }

                        p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connaction.Execute("dbo.spMatchupEntries_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        private void SaveTournament(IDbConnection connaction, TournamentModel model)
        {
            var p = new DynamicParameters();
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@EntryFee", model.EntryFee);
            p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connaction.Execute("dbo.spTournament_Insert", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@Id");
        }

        private void SaveTournamentPrizes(IDbConnection connaction, TournamentModel model)
        {
            foreach (PrizeModel pz in model.Prizes)
            {
                var p = new DynamicParameters();

                p.Add("@TournamentId", model.Id);
                p.Add("@PrizeId", pz.id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connaction.Execute("dbo.spTournamentPrizes_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentEntries(IDbConnection connaction, TournamentModel model)
        {
            foreach (TeamModel tm in model.EnterdTeams)
            {
                var p = new DynamicParameters();

                p.Add("@TournamentId", model.Id);
                p.Add("@TeamId", tm.Id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connaction.Execute("dbo.spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }





        public List<PersonModel> GetPerson_All()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();

                return output;
            }


        }

        public List<TeamModel> GetTeam_All()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
               List<TeamModel> output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();


                foreach (TeamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamId", team.Id);
                   
                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam",
                        p, commandType: CommandType.StoredProcedure).ToList();

                }

                return output;
            }
        }

        public List<TournamentModel> GetTournament_All()
        {
            List<TournamentModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                 output = connection.Query<TournamentModel>("dbo.spTournament_GetAll").ToList();
                 var p = new DynamicParameters();

                //populate
                foreach (TournamentModel t in output)
                {
                    // prizes
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.Prizes = connection.Query<PrizeModel>("dbo.spPrizes_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    // teams
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.EnterdTeams = connection.Query<TeamModel>("dbo.spTeam_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (TeamModel team in t.EnterdTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("@TeamId", team.Id);

                        team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam",
                            p, commandType: CommandType.StoredProcedure).ToList();
                    }

                    //rounds
                     p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    List<MatchUpModel> matchups = connection.Query<MatchUpModel>("dbo.spMatchup_GetByTournamet"
                        , p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (MatchUpModel m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupId", m.Id);

                        m.Entries = connection.Query<MatchUpEntryModel>("dbo.spMatchupEntries_GetByMatchup"
                        , p, commandType: CommandType.StoredProcedure).ToList();

                        // populate each entry (2models)
                        // populate each matchup (1 model)
                        List<TeamModel> allTeams = GetTeam_All();

                        if (m.WinnerId>0)
                        {
                            m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                        }

                        foreach (MatchUpEntryModel me in m.Entries)
                        {
                            if (me.TeamCompetingId>0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                            }

                            if (me.ParentMatchupId>0)
                            {
                                me.ParentMatchUp = matchups.Where(x => x.Id == me.ParentMatchupId).First();
                            }
                        }
                    }

                    //list<list<matcupModel>>
                    List<MatchUpModel> currRow = new List<MatchUpModel>();
                    int currRound = 1;

                    foreach (MatchUpModel m in matchups)
                    {
                        if (m.MatchUpRound>currRound)
                        {
                            t.Rounds.Add(currRow);
                            currRow = new List<MatchUpModel>();

                            currRound += 1;
                            
                        }

                        currRow.Add(m);
                    }
                    t.Rounds.Add(currRow);
                }

            }

            return output;
        }

        public void UpadateMatchup(MatchUpModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                if (model.Winner!=null)
                {
                    p.Add("@Id", model.Id);
                    p.Add("@WinnerId", model.Winner.Id);
                    connection.Execute("dbo.spMatchups_Update", p, commandType: CommandType.StoredProcedure);
                }
                

                foreach (MatchUpEntryModel me in model.Entries)
                {
                    if (me.TeamCompeting!=null)
                    {
                        p = new DynamicParameters();
                        p.Add("@Id", me.id);
                        p.Add("@TeamCompetingId", me.TeamCompeting.Id);
                        p.Add("@Score", me.Score);
                        connection.Execute("dbo.spMatchupEntries_Update", p, commandType: CommandType.StoredProcedure);
                    }
                
                }
            }

           

        }

        public void CompleteTournament(TournamentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                     p.Add("@id", model.Id);
                    
                    connection.Execute("dbo.spTournamet_Complate", p, commandType: CommandType.StoredProcedure);

            }
        }
    }
     
}
