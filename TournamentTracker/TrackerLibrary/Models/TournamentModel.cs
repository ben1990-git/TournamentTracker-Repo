using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
  public  class TournamentModel
    {
        public int Id { get; set; }
        public string TournamentName { get; set; }
        public decimal EntryFee { get; set; }

        public List<TeamModel> EnterdTeams { get; set; } = new List<TeamModel>();

        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        public List<List<MatchUpModel>> Rounds { get; set; } = new List<List<MatchUpModel>>();

        public event EventHandler<DateTime> OnTournamentComplete;

        public void CompleteTounrnament()
        {
            OnTournamentComplete?.Invoke(this, DateTime.Now);
        }
    }
}
