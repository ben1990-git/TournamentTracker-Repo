using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchUpModel> SelectedmatchUps = new BindingList<MatchUpModel>();
      
        
        public TournamentViewerForm( TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;
           
            
                tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

                WireUpLists();

                LoadFormData();

                LoadRounds();
            
  
        }

        private void Tournament_OnTournamentComplete(object sender, DateTime e)
        {
            this.Close();
        }

        private void LoadFormData()
        {
            TournamentName.Text = tournament.TournamentName;
        }

        private void LoadRounds()
        {
            

            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;
            foreach (List<MatchUpModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchUpRound>currRound)
                {
                    currRound = matchups.First().MatchUpRound;
                    rounds.Add(currRound);
                }
            }

            LoadMatchups(1);
          
        }

        private void WireUpLists()
        {

            RoundDropBox.DataSource = rounds;
            MatchUpListBox.DataSource = SelectedmatchUps;
            MatchUpListBox.DisplayMember = "DisplayName";

        }


        private void RoundDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RoundDropBox.SelectedItem);
        }

        private void LoadMatchups(int round)
        {          
            foreach (List<MatchUpModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchUpRound == round)
                {
                    SelectedmatchUps.Clear();

                    foreach (MatchUpModel m in matchups)
                    {
                        if (m.Winner==null||!PlayOnlyCheckBox.Checked)
                        {
                            SelectedmatchUps.Add(m);
                        }
                        
                    }
                 
                    
                }
            }
            if (SelectedmatchUps.Count>0)
            {
                LoadMatchup(SelectedmatchUps.First());
            }

            DispalyMatchupInfo();

        }

        private void DispalyMatchupInfo()
        {
            bool isVisible = (SelectedmatchUps.Count > 0);

            TeamOneName.Visible = isVisible;
            TeamOneScoreLable.Visible = isVisible;
            TeamOneTextBox.Visible = isVisible;
            TeamTowLabel.Visible = isVisible;
            TeamTowTextBox.Visible = isVisible;
            ScoreButton.Visible = isVisible;
        }

        private void LoadMatchup(MatchUpModel m)
        {
           

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i==0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        TeamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        TeamOneTextBox.Text = m.Entries[0].Score.ToString();

                        TeamTowLabel.Text = "<bye>";
                        TeamTowTextBox.Text = "0";
                    }
                    else
                    {
                        TeamOneName.Text = "not yet set";
                        TeamOneScoreLable.Text = "";
                    }
                    

                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        TeamTowLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                       TeamTowTextBox.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        TeamTowLabel.Text = "not yet set";
                        TeamTowTextBox.Text = "";
                    }


                }
            }
          
        }

        private void MatchUpListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MatchUpListBox.SelectedItem != null)
            {
                LoadMatchup(MatchUpListBox.SelectedItem as MatchUpModel);
            }
        }

        private void PlayOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RoundDropBox.SelectedItem);
        }

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            string errorMesseage = ValidateDada();
            if (errorMesseage.Length>0)
            {
                MessageBox.Show($"error{errorMesseage}");
                return;
            }
            var m = MatchUpListBox.SelectedItem as MatchUpModel;
            double teamOneScore = 0;
            double teamTwoScore = 0;
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        
                       
                        bool scoreValid = double.TryParse(TeamOneTextBox.Text, out teamOneScore);
                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("please enter vaild score for team 1");
                            return;
                        }
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        
                        
                        bool scoreValid = double.TryParse(TeamTowTextBox.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("please enter vaild score for team 2");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"the app had the fallowing error :{ex.Message}");
                return;
            }

            

            LoadMatchups((int)RoundDropBox.SelectedItem);

            GlobalConfig.Connaction.UpadateMatchup(m);
        }

        private string ValidateDada()
        {
           string output = "";

            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(TeamOneTextBox.Text, out teamOneScore);
            bool scoreTowValid = double.TryParse(TeamTowTextBox.Text, out teamTwoScore);

            if (!scoreOneValid)
            {
                output = "the score one value is not a valid";
            }
           else if (!scoreTowValid)
            {
                output = "the score tow value is not valid";
            }
          else  if (teamOneScore==0&&teamTwoScore==0)
            {
                output = "You did not enter a score for either team";
            }
          else  if (teamOneScore== teamTwoScore)
            {
                output = "we do not allow ties";
            }

            return output;
        }
    }
}
