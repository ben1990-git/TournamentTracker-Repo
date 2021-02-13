
namespace TrackerUI
{
    partial class CreateTournamentForm
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
            this.HeadLabel = new System.Windows.Forms.Label();
            this.CreateTournametLabel = new System.Windows.Forms.Label();
            this.TournamentNameLabel = new System.Windows.Forms.Label();
            this.EnterTournamentNameTextBox = new System.Windows.Forms.TextBox();
            this.EntryFeeLabel = new System.Windows.Forms.Label();
            this.EntryFeeTextBox = new System.Windows.Forms.TextBox();
            this.SelectTeamLabel = new System.Windows.Forms.Label();
            this.SelectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.CreateTeamLinkLabel = new System.Windows.Forms.LinkLabel();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrizeButton = new System.Windows.Forms.Button();
            this.SelectTournamentTeamsListBox = new System.Windows.Forms.ListBox();
            this.TeamNPlayersLabel = new System.Windows.Forms.Label();
            this.RemoveSelectePlayerButton = new System.Windows.Forms.Button();
            this.RemoveSelectedPrizeButton = new System.Windows.Forms.Button();
            this.prizesLabel = new System.Windows.Forms.Label();
            this.PrizesListBox = new System.Windows.Forms.ListBox();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeadLabel
            // 
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HeadLabel.Location = new System.Drawing.Point(52, 48);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(0, 13);
            this.HeadLabel.TabIndex = 1;
            // 
            // CreateTournametLabel
            // 
            this.CreateTournametLabel.AutoSize = true;
            this.CreateTournametLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CreateTournametLabel.Location = new System.Drawing.Point(71, 69);
            this.CreateTournametLabel.Name = "CreateTournametLabel";
            this.CreateTournametLabel.Size = new System.Drawing.Size(193, 26);
            this.CreateTournametLabel.TabIndex = 2;
            this.CreateTournametLabel.Text = "CreateTournament";
            // 
            // TournamentNameLabel
            // 
            this.TournamentNameLabel.AutoSize = true;
            this.TournamentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TournamentNameLabel.Location = new System.Drawing.Point(71, 130);
            this.TournamentNameLabel.Name = "TournamentNameLabel";
            this.TournamentNameLabel.Size = new System.Drawing.Size(251, 26);
            this.TournamentNameLabel.TabIndex = 3;
            this.TournamentNameLabel.Text = "Enter Tournament Name";
            // 
            // EnterTournamentNameTextBox
            // 
            this.EnterTournamentNameTextBox.Location = new System.Drawing.Point(76, 179);
            this.EnterTournamentNameTextBox.Name = "EnterTournamentNameTextBox";
            this.EnterTournamentNameTextBox.Size = new System.Drawing.Size(246, 20);
            this.EnterTournamentNameTextBox.TabIndex = 4;
            // 
            // EntryFeeLabel
            // 
            this.EntryFeeLabel.AutoSize = true;
            this.EntryFeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EntryFeeLabel.Location = new System.Drawing.Point(71, 242);
            this.EntryFeeLabel.Name = "EntryFeeLabel";
            this.EntryFeeLabel.Size = new System.Drawing.Size(106, 26);
            this.EntryFeeLabel.TabIndex = 5;
            this.EntryFeeLabel.Text = "Entry Fee";
            // 
            // EntryFeeTextBox
            // 
            this.EntryFeeTextBox.Location = new System.Drawing.Point(183, 248);
            this.EntryFeeTextBox.Name = "EntryFeeTextBox";
            this.EntryFeeTextBox.Size = new System.Drawing.Size(93, 20);
            this.EntryFeeTextBox.TabIndex = 6;
            this.EntryFeeTextBox.Text = "0";
            // 
            // SelectTeamLabel
            // 
            this.SelectTeamLabel.AutoSize = true;
            this.SelectTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SelectTeamLabel.Location = new System.Drawing.Point(71, 294);
            this.SelectTeamLabel.Name = "SelectTeamLabel";
            this.SelectTeamLabel.Size = new System.Drawing.Size(112, 26);
            this.SelectTeamLabel.TabIndex = 7;
            this.SelectTeamLabel.Text = "Add Team";
            // 
            // SelectTeamDropDown
            // 
            this.SelectTeamDropDown.FormattingEnabled = true;
            this.SelectTeamDropDown.Location = new System.Drawing.Point(76, 355);
            this.SelectTeamDropDown.Name = "SelectTeamDropDown";
            this.SelectTeamDropDown.Size = new System.Drawing.Size(200, 21);
            this.SelectTeamDropDown.TabIndex = 8;
            // 
            // CreateTeamLinkLabel
            // 
            this.CreateTeamLinkLabel.AutoSize = true;
            this.CreateTeamLinkLabel.Location = new System.Drawing.Point(208, 306);
            this.CreateTeamLinkLabel.Name = "CreateTeamLinkLabel";
            this.CreateTeamLinkLabel.Size = new System.Drawing.Size(68, 13);
            this.CreateTeamLinkLabel.TabIndex = 9;
            this.CreateTeamLinkLabel.TabStop = true;
            this.CreateTeamLinkLabel.Text = "Create Team";
            this.CreateTeamLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateTeamLinkLabel_LinkClicked);
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.Location = new System.Drawing.Point(55, 411);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(232, 23);
            this.AddTeamButton.TabIndex = 10;
            this.AddTeamButton.Text = "Add Team";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // CreatePrizeButton
            // 
            this.CreatePrizeButton.Location = new System.Drawing.Point(55, 451);
            this.CreatePrizeButton.Name = "CreatePrizeButton";
            this.CreatePrizeButton.Size = new System.Drawing.Size(232, 23);
            this.CreatePrizeButton.TabIndex = 11;
            this.CreatePrizeButton.Text = "Create Prize";
            this.CreatePrizeButton.UseVisualStyleBackColor = true;
            this.CreatePrizeButton.Click += new System.EventHandler(this.CreatePrizeButton_Click);
            // 
            // SelectTournamentTeamsListBox
            // 
            this.SelectTournamentTeamsListBox.FormattingEnabled = true;
            this.SelectTournamentTeamsListBox.Location = new System.Drawing.Point(505, 112);
            this.SelectTournamentTeamsListBox.Name = "SelectTournamentTeamsListBox";
            this.SelectTournamentTeamsListBox.Size = new System.Drawing.Size(244, 186);
            this.SelectTournamentTeamsListBox.TabIndex = 12;
            // 
            // TeamNPlayersLabel
            // 
            this.TeamNPlayersLabel.AutoSize = true;
            this.TeamNPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TeamNPlayersLabel.Location = new System.Drawing.Point(500, 69);
            this.TeamNPlayersLabel.Name = "TeamNPlayersLabel";
            this.TeamNPlayersLabel.Size = new System.Drawing.Size(148, 26);
            this.TeamNPlayersLabel.TabIndex = 13;
            this.TeamNPlayersLabel.Text = "teams/playres";
            // 
            // RemoveSelectePlayerButton
            // 
            this.RemoveSelectePlayerButton.Location = new System.Drawing.Point(794, 162);
            this.RemoveSelectePlayerButton.Name = "RemoveSelectePlayerButton";
            this.RemoveSelectePlayerButton.Size = new System.Drawing.Size(75, 52);
            this.RemoveSelectePlayerButton.TabIndex = 14;
            this.RemoveSelectePlayerButton.Text = "remove";
            this.RemoveSelectePlayerButton.UseVisualStyleBackColor = true;
            this.RemoveSelectePlayerButton.Click += new System.EventHandler(this.RemoveSelectePlayerButton_Click);
            // 
            // RemoveSelectedPrizeButton
            // 
            this.RemoveSelectedPrizeButton.Location = new System.Drawing.Point(794, 425);
            this.RemoveSelectedPrizeButton.Name = "RemoveSelectedPrizeButton";
            this.RemoveSelectedPrizeButton.Size = new System.Drawing.Size(75, 52);
            this.RemoveSelectedPrizeButton.TabIndex = 17;
            this.RemoveSelectedPrizeButton.Text = "remove";
            this.RemoveSelectedPrizeButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedPrizeButton.Click += new System.EventHandler(this.RemoveSelectedPrizeButton_Click);
            // 
            // prizesLabel
            // 
            this.prizesLabel.AutoSize = true;
            this.prizesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.prizesLabel.Location = new System.Drawing.Point(500, 318);
            this.prizesLabel.Name = "prizesLabel";
            this.prizesLabel.Size = new System.Drawing.Size(73, 26);
            this.prizesLabel.TabIndex = 16;
            this.prizesLabel.Text = "Prizes";
            // 
            // PrizesListBox
            // 
            this.PrizesListBox.FormattingEnabled = true;
            this.PrizesListBox.Location = new System.Drawing.Point(505, 368);
            this.PrizesListBox.Name = "PrizesListBox";
            this.PrizesListBox.Size = new System.Drawing.Size(244, 186);
            this.PrizesListBox.TabIndex = 15;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.Location = new System.Drawing.Point(328, 617);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(162, 62);
            this.CreateTournamentButton.TabIndex = 18;
            this.CreateTournamentButton.Text = "create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 706);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.RemoveSelectedPrizeButton);
            this.Controls.Add(this.prizesLabel);
            this.Controls.Add(this.PrizesListBox);
            this.Controls.Add(this.RemoveSelectePlayerButton);
            this.Controls.Add(this.TeamNPlayersLabel);
            this.Controls.Add(this.SelectTournamentTeamsListBox);
            this.Controls.Add(this.CreatePrizeButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.CreateTeamLinkLabel);
            this.Controls.Add(this.SelectTeamDropDown);
            this.Controls.Add(this.SelectTeamLabel);
            this.Controls.Add(this.EntryFeeTextBox);
            this.Controls.Add(this.EntryFeeLabel);
            this.Controls.Add(this.EnterTournamentNameTextBox);
            this.Controls.Add(this.TournamentNameLabel);
            this.Controls.Add(this.CreateTournametLabel);
            this.Controls.Add(this.HeadLabel);
            this.Name = "CreateTournamentForm";
            this.Text = "CreateTournamentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label CreateTournametLabel;
        private System.Windows.Forms.Label TournamentNameLabel;
        private System.Windows.Forms.TextBox EnterTournamentNameTextBox;
        private System.Windows.Forms.Label EntryFeeLabel;
        private System.Windows.Forms.TextBox EntryFeeTextBox;
        private System.Windows.Forms.Label SelectTeamLabel;
        private System.Windows.Forms.ComboBox SelectTeamDropDown;
        private System.Windows.Forms.LinkLabel CreateTeamLinkLabel;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrizeButton;
        private System.Windows.Forms.ListBox SelectTournamentTeamsListBox;
        private System.Windows.Forms.Label TeamNPlayersLabel;
        private System.Windows.Forms.Button RemoveSelectePlayerButton;
        private System.Windows.Forms.Button RemoveSelectedPrizeButton;
        private System.Windows.Forms.Label prizesLabel;
        private System.Windows.Forms.ListBox PrizesListBox;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}