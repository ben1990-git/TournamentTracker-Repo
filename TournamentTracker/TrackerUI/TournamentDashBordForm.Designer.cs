
namespace TrackerUI
{
    partial class TournamentDashBordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TournamentDashBordLabel = new System.Windows.Forms.Label();
            this.LoadingExistingTourLabel = new System.Windows.Forms.Label();
            this.LoadTournamentButton = new System.Windows.Forms.Button();
            this.CreateTournamnetButton = new System.Windows.Forms.Button();
            this.LoadingExitTourDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TournamentDashBordLabel
            // 
            this.TournamentDashBordLabel.AutoSize = true;
            this.TournamentDashBordLabel.Location = new System.Drawing.Point(365, 124);
            this.TournamentDashBordLabel.Name = "TournamentDashBordLabel";
            this.TournamentDashBordLabel.Size = new System.Drawing.Size(231, 26);
            this.TournamentDashBordLabel.TabIndex = 0;
            this.TournamentDashBordLabel.Text = "Tournamnet DashBord";
            // 
            // LoadingExistingTourLabel
            // 
            this.LoadingExistingTourLabel.AutoSize = true;
            this.LoadingExistingTourLabel.Location = new System.Drawing.Point(331, 218);
            this.LoadingExistingTourLabel.Name = "LoadingExistingTourLabel";
            this.LoadingExistingTourLabel.Size = new System.Drawing.Size(262, 26);
            this.LoadingExistingTourLabel.TabIndex = 1;
            this.LoadingExistingTourLabel.Text = "Loading exitingTournamet";
            // 
            // LoadTournamentButton
            // 
            this.LoadTournamentButton.Location = new System.Drawing.Point(313, 407);
            this.LoadTournamentButton.Name = "LoadTournamentButton";
            this.LoadTournamentButton.Size = new System.Drawing.Size(299, 101);
            this.LoadTournamentButton.TabIndex = 3;
            this.LoadTournamentButton.Text = "Load tournament";
            this.LoadTournamentButton.UseVisualStyleBackColor = true;
            this.LoadTournamentButton.Click += new System.EventHandler(this.LoadTournamentButton_Click);
            // 
            // CreateTournamnetButton
            // 
            this.CreateTournamnetButton.Location = new System.Drawing.Point(313, 580);
            this.CreateTournamnetButton.Name = "CreateTournamnetButton";
            this.CreateTournamnetButton.Size = new System.Drawing.Size(317, 129);
            this.CreateTournamnetButton.TabIndex = 4;
            this.CreateTournamnetButton.Text = "Create tournamnet";
            this.CreateTournamnetButton.UseVisualStyleBackColor = true;
            this.CreateTournamnetButton.Click += new System.EventHandler(this.CreateTournamnetButton_Click);
            // 
            // LoadingExitTourDropDown
            // 
            this.LoadingExitTourDropDown.FormattingEnabled = true;
            this.LoadingExitTourDropDown.Location = new System.Drawing.Point(336, 303);
            this.LoadingExitTourDropDown.Name = "LoadingExitTourDropDown";
            this.LoadingExitTourDropDown.Size = new System.Drawing.Size(257, 33);
            this.LoadingExitTourDropDown.TabIndex = 5;
            // 
            // TournamentDashBordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.LoadingExitTourDropDown);
            this.Controls.Add(this.CreateTournamnetButton);
            this.Controls.Add(this.LoadTournamentButton);
            this.Controls.Add(this.LoadingExistingTourLabel);
            this.Controls.Add(this.TournamentDashBordLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TournamentDashBordForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TournamentDashBordLabel;
        private System.Windows.Forms.Label LoadingExistingTourLabel;
        private System.Windows.Forms.Button LoadTournamentButton;
        private System.Windows.Forms.Button CreateTournamnetButton;
        private System.Windows.Forms.ComboBox LoadingExitTourDropDown;
    }
}