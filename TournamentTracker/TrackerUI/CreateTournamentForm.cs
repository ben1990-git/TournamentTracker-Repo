using FluentValidation.Results;
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
using TrackerUI.Validators;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, IteamRequster
    {
        List<TeamModel> avilabelTeams = GlobalConfig.Connaction.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> SelectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpList();
        }

        private void WireUpList()
        {
            SelectTeamDropDown.DataSource = null;
            SelectTeamDropDown.DataSource = avilabelTeams;
            SelectTeamDropDown.DisplayMember = "TeamName";

            SelectTournamentTeamsListBox.DataSource = null;
            SelectTournamentTeamsListBox.DataSource = selectedTeams;
            SelectTournamentTeamsListBox.DisplayMember = "TeamName";

            PrizesListBox.DataSource = null;
            PrizesListBox.DataSource = SelectedPrizes;
            PrizesListBox.DisplayMember = "PlaceName";


        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {

            TeamModel t = (TeamModel)SelectTeamDropDown.SelectedItem;

            if (t != null)
            {
                avilabelTeams.Remove(t);
                selectedTeams.Add(t);

                WireUpList();
            }
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm form = new CreatePrizeForm(this);
            form.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            SelectedPrizes.Add(model);
            WireUpList();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpList();
        }

        private void CreateTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm teamForm = new CreateTeamForm(this);
            teamForm.Show();
        }

        private void RemoveSelectePlayerButton_Click(object sender, EventArgs e)
        {

            TeamModel team = (TeamModel)SelectTournamentTeamsListBox.SelectedItem;

            if (team != null)
            {
                selectedTeams.Remove(team);
                avilabelTeams.Add(team);
                WireUpList();
            }

        }

        private void RemoveSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)PrizesListBox.SelectedItem;

            if (p != null)
            {
                SelectedPrizes.Remove(p);

                WireUpList();
            }

        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {

            TournamentModel tm = new TournamentModel();

            decimal fee = 0;
            bool FeeAccaptable = decimal.TryParse(EntryFeeTextBox.Text, out fee);
            tm.TournamentName = EnterTournamentNameTextBox.Text;
            tm.EntryFee = fee;
            tm.Prizes = SelectedPrizes;
            tm.EnterdTeams = selectedTeams;

            TournamentValidator validation = new TournamentValidator();
            var result = validation.Validate(tm);
            string message = "";

            if (!result.IsValid)
            {
                foreach (ValidationFailure res in result.Errors)
                {
                    message += $"{res}\n";
                }
                MessageBox.Show(message,
                  "error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (!FeeAccaptable)
            {
                MessageBox
                    .Show( "entry fee is not a valid number ", "error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }



            TournamentLogic.CreateRounds(tm);

            GlobalConfig.Connaction.CreateTournament(tm);

            tm.AlertUsersToNewRound();


            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
            this.Close();
        }
    }
}
