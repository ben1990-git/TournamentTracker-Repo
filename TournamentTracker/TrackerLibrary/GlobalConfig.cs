using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
   public static class GlobalConfig
    {
        // names of files in folders (each text file is represanted as a model by the program)
        public const string PrizesFile = "PrizeModel.csv";
        public const string PeopleFile = "PersonModel.csv";
        public const string TeamFile = "TeamModel.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntriesModels.csv";

        /// <summary>
        /// return the IdataConnaction Type that was chosen
        /// </summary>
        public static IDataConnaction Connaction { get; private set; }

        /// <summary>
        /// create the type of connaction by type of db
        /// </summary>
        /// <param name="db"></param>
        public static void InitializeConnaction(DatabaseType db)
        {


            if(db==DatabaseType.Sql)
            {
                SqlConnactor sql = new SqlConnactor();
                Connaction = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                TextConnactor text = new TextConnactor();
                Connaction = text;
                
            }
        }

        /// <summary>
        /// go to the appConfig file and returns ths selected connacection string
        /// </summary>
        /// <param name="name">name od db to connact to</param>
        /// <returns>connaction string fom the appConfig by name</returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }


        // sense we may transfor envierment where we dont use a app.config file
        //like mongodb or whatever its best to rap the acsses with a function
        //even thow its only raping we will not have access to the way we interact with configuration (ConfigurationManager)
        // so if we cll the defulat func (whats inside the rap) in our code without the rap we will nid to change the func everywhere
          // insted in one place !!!!
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];

        }
    }
}
