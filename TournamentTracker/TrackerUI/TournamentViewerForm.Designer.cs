
namespace TrackerUI
{
    partial class TournamentViewerForm
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
            this.TournamentName = new System.Windows.Forms.Label();
            this.RoundLabel = new System.Windows.Forms.Label();
            this.RoundDropBox = new System.Windows.Forms.ComboBox();
            this.PlayOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.MatchUpListBox = new System.Windows.Forms.ListBox();
            this.TeamOneName = new System.Windows.Forms.Label();
            this.TeamTowLabel = new System.Windows.Forms.Label();
            this.TeamTowScoreLable = new System.Windows.Forms.Label();
            this.TeamOneScoreLable = new System.Windows.Forms.Label();
            this.TeamOneTextBox = new System.Windows.Forms.TextBox();
            this.TeamTowTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeadLabel
            // 
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HeadLabel.Location = new System.Drawing.Point(66, 52);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(129, 30);
            this.HeadLabel.TabIndex = 0;
            this.HeadLabel.Text = "Tournament:";
            // 
            // TournamentName
            // 
            this.TournamentName.AutoSize = true;
            this.TournamentName.Enabled = false;
            this.TournamentName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TournamentName.Location = new System.Drawing.Point(187, 52);
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.Size = new System.Drawing.Size(88, 30);
            this.TournamentName.TabIndex = 1;
            this.TournamentName.Text = "<none>";
            // 
            // RoundLabel
            // 
            this.RoundLabel.AutoSize = true;
            this.RoundLabel.Location = new System.Drawing.Point(66, 101);
            this.RoundLabel.Name = "RoundLabel";
            this.RoundLabel.Size = new System.Drawing.Size(73, 30);
            this.RoundLabel.TabIndex = 2;
            this.RoundLabel.Text = "Round";
            // 
            // RoundDropBox
            // 
            this.RoundDropBox.FormattingEnabled = true;
            this.RoundDropBox.Location = new System.Drawing.Point(145, 93);
            this.RoundDropBox.Name = "RoundDropBox";
            this.RoundDropBox.Size = new System.Drawing.Size(296, 38);
            this.RoundDropBox.TabIndex = 3;
            this.RoundDropBox.SelectedIndexChanged += new System.EventHandler(this.RoundDropBox_SelectedIndexChanged);
            // 
            // PlayOnlyCheckBox
            // 
            this.PlayOnlyCheckBox.AutoSize = true;
            this.PlayOnlyCheckBox.Location = new System.Drawing.Point(145, 152);
            this.PlayOnlyCheckBox.Name = "PlayOnlyCheckBox";
            this.PlayOnlyCheckBox.Size = new System.Drawing.Size(139, 34);
            this.PlayOnlyCheckBox.TabIndex = 4;
            this.PlayOnlyCheckBox.Text = "UnPlayOnly";
            this.PlayOnlyCheckBox.UseVisualStyleBackColor = true;
            this.PlayOnlyCheckBox.CheckedChanged += new System.EventHandler(this.PlayOnlyCheckBox_CheckedChanged);
            // 
            // MatchUpListBox
            // 
            this.MatchUpListBox.FormattingEnabled = true;
            this.MatchUpListBox.ItemHeight = 30;
            this.MatchUpListBox.Location = new System.Drawing.Point(71, 207);
            this.MatchUpListBox.Name = "MatchUpListBox";
            this.MatchUpListBox.Size = new System.Drawing.Size(370, 184);
            this.MatchUpListBox.TabIndex = 5;
            this.MatchUpListBox.SelectedIndexChanged += new System.EventHandler(this.MatchUpListBox_SelectedIndexChanged);
            // 
            // TeamOneName
            // 
            this.TeamOneName.AutoSize = true;
            this.TeamOneName.Location = new System.Drawing.Point(475, 207);
            this.TeamOneName.Name = "TeamOneName";
            this.TeamOneName.Size = new System.Drawing.Size(157, 30);
            this.TeamOneName.TabIndex = 6;
            this.TeamOneName.Text = "TeamOneName";
            // 
            // TeamTowLabel
            // 
            this.TeamTowLabel.AutoSize = true;
            this.TeamTowLabel.Location = new System.Drawing.Point(479, 359);
            this.TeamTowLabel.Name = "TeamTowLabel";
            this.TeamTowLabel.Size = new System.Drawing.Size(147, 30);
            this.TeamTowLabel.TabIndex = 7;
            this.TeamTowLabel.Text = "TeamTowLabel";
            // 
            // TeamTowScoreLable
            // 
            this.TeamTowScoreLable.AutoSize = true;
            this.TeamTowScoreLable.Location = new System.Drawing.Point(479, 406);
            this.TeamTowScoreLable.Name = "TeamTowScoreLable";
            this.TeamTowScoreLable.Size = new System.Drawing.Size(64, 30);
            this.TeamTowScoreLable.TabIndex = 8;
            this.TeamTowScoreLable.Text = "Score";
            // 
            // TeamOneScoreLable
            // 
            this.TeamOneScoreLable.AutoSize = true;
            this.TeamOneScoreLable.Location = new System.Drawing.Point(475, 248);
            this.TeamOneScoreLable.Name = "TeamOneScoreLable";
            this.TeamOneScoreLable.Size = new System.Drawing.Size(64, 30);
            this.TeamOneScoreLable.TabIndex = 9;
            this.TeamOneScoreLable.Text = "Score";
            // 
            // TeamOneTextBox
            // 
            this.TeamOneTextBox.Location = new System.Drawing.Point(545, 248);
            this.TeamOneTextBox.Name = "TeamOneTextBox";
            this.TeamOneTextBox.Size = new System.Drawing.Size(100, 35);
            this.TeamOneTextBox.TabIndex = 10;
            // 
            // TeamTowTextBox
            // 
            this.TeamTowTextBox.Location = new System.Drawing.Point(549, 403);
            this.TeamTowTextBox.Name = "TeamTowTextBox";
            this.TeamTowTextBox.Size = new System.Drawing.Size(100, 35);
            this.TeamTowTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 30);
            this.label1.TabIndex = 12;
            this.label1.Text = "-vs-";
            // 
            // ScoreButton
            // 
            this.ScoreButton.Location = new System.Drawing.Point(320, 487);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(160, 48);
            this.ScoreButton.TabIndex = 13;
            this.ScoreButton.Text = "score";
            this.ScoreButton.UseVisualStyleBackColor = true;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 547);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TeamTowTextBox);
            this.Controls.Add(this.TeamOneTextBox);
            this.Controls.Add(this.TeamOneScoreLable);
            this.Controls.Add(this.TeamTowScoreLable);
            this.Controls.Add(this.TeamTowLabel);
            this.Controls.Add(this.TeamOneName);
            this.Controls.Add(this.MatchUpListBox);
            this.Controls.Add(this.PlayOnlyCheckBox);
            this.Controls.Add(this.RoundDropBox);
            this.Controls.Add(this.RoundLabel);
            this.Controls.Add(this.TournamentName);
            this.Controls.Add(this.HeadLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "TournamentViewerForm";
            this.Text = "TournamentViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label TournamentName;
        private System.Windows.Forms.Label RoundLabel;
        private System.Windows.Forms.ComboBox RoundDropBox;
        private System.Windows.Forms.CheckBox PlayOnlyCheckBox;
        private System.Windows.Forms.ListBox MatchUpListBox;
        private System.Windows.Forms.Label TeamOneName;
        private System.Windows.Forms.Label TeamTowLabel;
        private System.Windows.Forms.Label TeamTowScoreLable;
        private System.Windows.Forms.Label TeamOneScoreLable;
        private System.Windows.Forms.TextBox TeamOneTextBox;
        private System.Windows.Forms.TextBox TeamTowTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ScoreButton;
    }
}

