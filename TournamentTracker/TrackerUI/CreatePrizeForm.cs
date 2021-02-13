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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void CreatePrizebutton_Click(object sender, EventArgs e)
        {
            if (ValaditForm())
            {
                PrizeModel model = new PrizeModel(
                    PlaceNmaeTextBox.Text,
                    PlaceNumberextBox.Text,
                    PrizeAmountTextBox.Text,
                    PrizePrecntageTextBox.Text);

                GlobalConfig.Connaction.CreatePrize(model);

                callingForm.PrizeComplete(model);

                this.Close();
            
                //PlaceNmaeTextBox.Text = "";
                //    PlaceNumberextBox.Text = "";
                //    PrizeAmountTextBox.Text = "0";
                //    PrizePrecntageTextBox.Text = "0";



            }
            else
                MessageBox.Show("this form has invaild info chack again ");
        }

        private bool ValaditForm()
        {
            bool output = true;
            int placeNUmber = 0;
            bool PlaceNumberValidNumber = int.TryParse(PlaceNumberextBox.Text, out placeNUmber);
            if (!PlaceNumberValidNumber)
            {
                output = false;
            }
            if(placeNUmber<1)
            {
                output = false;
            }
            if (PlaceNmaeTextBox.Text.Length==0)
            {
                output = false;
            }
            decimal PrizeAmount = 0;
            int PrizPreacentage = 0;

            bool PrizeAmountVaild = decimal.TryParse(PrizeAmountTextBox.Text, out PrizeAmount);
            bool prizePresantageVaild = int.TryParse(PrizeAmountTextBox.Text, out PrizPreacentage);

            if (prizePresantageVaild==false|| PrizeAmountVaild==false)
            {
                output = false;
            }
            if (PrizeAmount<=0&& PrizPreacentage<=0)
            {
                output = false;
            }

            if (PrizPreacentage<0|| PrizPreacentage>100)
            {
                output = false;
            }
  


            return output;
        }
    }
}
