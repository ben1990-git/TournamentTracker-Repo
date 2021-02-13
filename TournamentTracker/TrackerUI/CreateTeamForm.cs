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
    public partial class CreateTeamForm : Form
    {

        private IteamRequster callingForm;

        private List<PersonModel> avilableTeamMembers = GlobalConfig.Connaction.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm(IteamRequster caller)
        {
            InitializeComponent();
            callingForm = caller;
         //   CreateSampleData();
            WireUpList();
        }

        private void WireUpList()
        {
            selectTeamMembersDropDown.DataSource = null;
            selectTeamMembersDropDown.DataSource = avilableTeamMembers;
            selectTeamMembersDropDown.DisplayMember = "FullName";

            TeamMambersListBox.DataSource = null;
            TeamMambersListBox.DataSource = selectedTeamMembers;
            TeamMambersListBox.DisplayMember = "FullName";
        }

        //private void CreateSampleData()
        //{
        //    avilableTeamMembers.Add(new PersonModel { FirstName = "test1", LastName = "test1" });
        //    avilableTeamMembers.Add(new PersonModel { FirstName = "test2", LastName = "test2" });

        //    selectedTeamMembers.Add(new PersonModel { FirstName = "test3", LastName = "tesr3" });
        //    selectedTeamMembers.Add(new PersonModel { FirstName = "test4", LastName = "tesr4" });
        //}



        private void CreateMamberButton_Click(object sender, EventArgs e)
        {
            PersonModel P = new PersonModel();
            P.FirstName = FirstNameTextBox.Text;
            P.LastName = LastNameTextBox.Text;
            P.EmailAddress = EmailTextBox.Text;
            P.CellPhoneNumber = CellPhoneTeaxBox.Text;

            PersonValidator PersonValidator = new PersonValidator();
            var result = PersonValidator.Validate(P);
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


            }
            else
            {
                GlobalConfig.Connaction.CreatePerson(P);
                selectedTeamMembers.Add(P);
                WireUpList();

                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                EmailTextBox.Text = "";
                CellPhoneTeaxBox.Text = "";
            }



        }


        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMembersDropDown.SelectedItem;

            if (p != null)
            {
                avilableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);
                WireUpList();
            }

        }

        private void RemoveSelectedButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TeamMambersListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                avilableTeamMembers.Add(p);
                WireUpList();

            }

        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel T = new TeamModel();

            T.TeamName = TeameNameTextBox.Text;
            T.TeamMembers = selectedTeamMembers;

            TeamValidator TeamValidator = new TeamValidator();

            var result = TeamValidator.Validate(T);
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

            GlobalConfig.Connaction.CreateTeam(T);

            callingForm.TeamComplete(T);

            this.Close();

        }
    }
}
