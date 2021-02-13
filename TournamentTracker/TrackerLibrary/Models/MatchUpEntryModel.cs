using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
   public class MatchUpEntryModel
    {

        /// <summary>
        /// represants the id of a matchup entry 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// represants one team in the matchup
        /// </summary>
        /// 
        public int TeamCompetingId { get; set; }

        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// represants the score for this team
        /// </summary>
        public double Score { get; set; }


        public  int ParentMatchupId { get; set; }
        /// <summary>
        /// represants match that this team 
        /// came from as the winner
        /// </summary>
        public MatchUpModel ParentMatchUp { get; set; }
    }
}
