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
    public partial class TournamentDashBordForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connaction.GetTournament_All();
        public TournamentDashBordForm()
        {
            InitializeComponent();
            WireUpLists();
        }
        private void WireUpLists()
        {
            LoadingExitTourDropDown.DataSource = tournaments;
            LoadingExitTourDropDown.DisplayMember = "TournamentName";
        }

        private void CreateTournamnetButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.Show();
        }

        private void LoadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)LoadingExitTourDropDown.SelectedItem;
            if (tm!=null)
            {
                TournamentViewerForm frm = new TournamentViewerForm(tm);
                frm.Show();
            }
           
        }
    }

   
}
