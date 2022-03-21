
namespace Pac_M.A.N.S
{
	partial class GameOverScreen
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreWord = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.btnSubmitName = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScore.ForeColor = System.Drawing.Color.Indigo;
            this.lblScore.Location = new System.Drawing.Point(414, 179);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 35);
            this.lblScore.TabIndex = 9;
            // 
            // lblScoreWord
            // 
            this.lblScoreWord.AutoSize = true;
            this.lblScoreWord.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScoreWord.ForeColor = System.Drawing.Color.Indigo;
            this.lblScoreWord.Location = new System.Drawing.Point(280, 179);
            this.lblScoreWord.Name = "lblScoreWord";
            this.lblScoreWord.Size = new System.Drawing.Size(111, 35);
            this.lblScoreWord.TabIndex = 8;
            this.lblScoreWord.Text = "Score:";
            // 
            // tbxName
            // 
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.Font = new System.Drawing.Font("Segoe UI Mono", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxName.Location = new System.Drawing.Point(414, 263);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(251, 38);
            this.tbxName.TabIndex = 7;
            this.tbxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.Indigo;
            this.lblName.Location = new System.Drawing.Point(131, 263);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(277, 35);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Enter Your Name:";
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGameOver.ForeColor = System.Drawing.Color.Indigo;
            this.lblGameOver.Location = new System.Drawing.Point(160, 32);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(478, 98);
            this.lblGameOver.TabIndex = 5;
            this.lblGameOver.Text = "GAME OVER";
            // 
            // btnSubmitName
            // 
            this.btnSubmitName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSubmitName.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSubmitName.ForeColor = System.Drawing.Color.Indigo;
            this.btnSubmitName.Location = new System.Drawing.Point(349, 352);
            this.btnSubmitName.Name = "btnSubmitName";
            this.btnSubmitName.Size = new System.Drawing.Size(110, 36);
            this.btnSubmitName.TabIndex = 10;
            this.btnSubmitName.Text = "Submit";
            this.btnSubmitName.UseVisualStyleBackColor = false;
            this.btnSubmitName.Click += new System.EventHandler(this.btnSubmitName_Click);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblErrorMessage.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Gold;
            this.lblErrorMessage.Location = new System.Drawing.Point(215, 314);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 26);
            this.lblErrorMessage.TabIndex = 11;
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnSubmitName);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblScoreWord);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGameOver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOverScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pac M.A.N.S";
            this.Load += new System.EventHandler(this.GameOverScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreWord;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Button btnSubmitName;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}

