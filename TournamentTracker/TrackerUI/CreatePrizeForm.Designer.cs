
namespace TrackerUI
{
    partial class CreatePrizeForm
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
            this.CreatePrizeLabel = new System.Windows.Forms.Label();
            this.PlaceNumberLabel = new System.Windows.Forms.Label();
            this.PrizeAmountLabel = new System.Windows.Forms.Label();
            this.OrLabel = new System.Windows.Forms.Label();
            this.CreatePrizebutton = new System.Windows.Forms.Button();
            this.PalceNameLabel = new System.Windows.Forms.Label();
            this.PlaceNumberextBox = new System.Windows.Forms.TextBox();
            this.PlaceNmaeTextBox = new System.Windows.Forms.TextBox();
            this.PrizeAmountTextBox = new System.Windows.Forms.TextBox();
            this.PrizePrecntageTextBox = new System.Windows.Forms.TextBox();
            this.PrizePrecntageLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreatePrizeLabel
            // 
            this.CreatePrizeLabel.AutoSize = true;
            this.CreatePrizeLabel.Location = new System.Drawing.Point(73, 56);
            this.CreatePrizeLabel.Name = "CreatePrizeLabel";
            this.CreatePrizeLabel.Size = new System.Drawing.Size(130, 26);
            this.CreatePrizeLabel.TabIndex = 0;
            this.CreatePrizeLabel.Text = "Create prize";
            // 
            // PlaceNumberLabel
            // 
            this.PlaceNumberLabel.AutoSize = true;
            this.PlaceNumberLabel.Location = new System.Drawing.Point(73, 133);
            this.PlaceNumberLabel.Name = "PlaceNumberLabel";
            this.PlaceNumberLabel.Size = new System.Drawing.Size(144, 26);
            this.PlaceNumberLabel.TabIndex = 1;
            this.PlaceNumberLabel.Text = "place number";
            // 
            // PrizeAmountLabel
            // 
            this.PrizeAmountLabel.AutoSize = true;
            this.PrizeAmountLabel.Location = new System.Drawing.Point(73, 253);
            this.PrizeAmountLabel.Name = "PrizeAmountLabel";
            this.PrizeAmountLabel.Size = new System.Drawing.Size(138, 26);
            this.PrizeAmountLabel.TabIndex = 2;
            this.PrizeAmountLabel.Text = "prize amount";
            // 
            // OrLabel
            // 
            this.OrLabel.AutoSize = true;
            this.OrLabel.Location = new System.Drawing.Point(102, 326);
            this.OrLabel.Name = "OrLabel";
            this.OrLabel.Size = new System.Drawing.Size(45, 26);
            this.OrLabel.TabIndex = 3;
            this.OrLabel.Text = "-or-";
            // 
            // CreatePrizebutton
            // 
            this.CreatePrizebutton.Location = new System.Drawing.Point(283, 513);
            this.CreatePrizebutton.Name = "CreatePrizebutton";
            this.CreatePrizebutton.Size = new System.Drawing.Size(192, 97);
            this.CreatePrizebutton.TabIndex = 4;
            this.CreatePrizebutton.Text = "Create prize";
            this.CreatePrizebutton.UseVisualStyleBackColor = true;
            this.CreatePrizebutton.Click += new System.EventHandler(this.CreatePrizebutton_Click);
            // 
            // PalceNameLabel
            // 
            this.PalceNameLabel.AutoSize = true;
            this.PalceNameLabel.Location = new System.Drawing.Point(73, 198);
            this.PalceNameLabel.Name = "PalceNameLabel";
            this.PalceNameLabel.Size = new System.Drawing.Size(125, 26);
            this.PalceNameLabel.TabIndex = 5;
            this.PalceNameLabel.Text = "place name";
            // 
            // PlaceNumberextBox
            // 
            this.PlaceNumberextBox.Location = new System.Drawing.Point(311, 133);
            this.PlaceNumberextBox.Name = "PlaceNumberextBox";
            this.PlaceNumberextBox.Size = new System.Drawing.Size(100, 32);
            this.PlaceNumberextBox.TabIndex = 6;
            // 
            // PlaceNmaeTextBox
            // 
            this.PlaceNmaeTextBox.Location = new System.Drawing.Point(311, 198);
            this.PlaceNmaeTextBox.Name = "PlaceNmaeTextBox";
            this.PlaceNmaeTextBox.Size = new System.Drawing.Size(100, 32);
            this.PlaceNmaeTextBox.TabIndex = 7;
            // 
            // PrizeAmountTextBox
            // 
            this.PrizeAmountTextBox.Location = new System.Drawing.Point(311, 253);
            this.PrizeAmountTextBox.Name = "PrizeAmountTextBox";
            this.PrizeAmountTextBox.Size = new System.Drawing.Size(100, 32);
            this.PrizeAmountTextBox.TabIndex = 8;
            this.PrizeAmountTextBox.Text = "0";
            // 
            // PrizePrecntageTextBox
            // 
            this.PrizePrecntageTextBox.Location = new System.Drawing.Point(311, 383);
            this.PrizePrecntageTextBox.Name = "PrizePrecntageTextBox";
            this.PrizePrecntageTextBox.Size = new System.Drawing.Size(100, 32);
            this.PrizePrecntageTextBox.TabIndex = 9;
            this.PrizePrecntageTextBox.Text = "0";
            // 
            // PrizePrecntageLable
            // 
            this.PrizePrecntageLable.AutoSize = true;
            this.PrizePrecntageLable.Location = new System.Drawing.Point(73, 383);
            this.PrizePrecntageLable.Name = "PrizePrecntageLable";
            this.PrizePrecntageLable.Size = new System.Drawing.Size(179, 26);
            this.PrizePrecntageLable.TabIndex = 10;
            this.PrizePrecntageLable.Text = "Prize Precantage";
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.PrizePrecntageLable);
            this.Controls.Add(this.PrizePrecntageTextBox);
            this.Controls.Add(this.PrizeAmountTextBox);
            this.Controls.Add(this.PlaceNmaeTextBox);
            this.Controls.Add(this.PlaceNumberextBox);
            this.Controls.Add(this.PalceNameLabel);
            this.Controls.Add(this.CreatePrizebutton);
            this.Controls.Add(this.OrLabel);
            this.Controls.Add(this.PrizeAmountLabel);
            this.Controls.Add(this.PlaceNumberLabel);
            this.Controls.Add(this.CreatePrizeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreatePrizeForm";
            this.Text = "place name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CreatePrizeLabel;
        private System.Windows.Forms.Label PlaceNumberLabel;
        private System.Windows.Forms.Label PrizeAmountLabel;
        private System.Windows.Forms.Label OrLabel;
        private System.Windows.Forms.Button CreatePrizebutton;
        private System.Windows.Forms.Label PalceNameLabel;
        private System.Windows.Forms.TextBox PlaceNumberextBox;
        private System.Windows.Forms.TextBox PlaceNmaeTextBox;
        private System.Windows.Forms.TextBox PrizeAmountTextBox;
        private System.Windows.Forms.TextBox PrizePrecntageTextBox;
        private System.Windows.Forms.Label PrizePrecntageLable;
    }
}