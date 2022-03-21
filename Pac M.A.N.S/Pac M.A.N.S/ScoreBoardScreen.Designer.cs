
namespace Pac_M.A.N.S
{
	partial class ScoreBoardScreen
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
			this.topScores = new System.Windows.Forms.Label();
			this.playerNameLabel = new System.Windows.Forms.Label();
			this.playerScoreLabel = new System.Windows.Forms.Label();
			this.player1Name = new System.Windows.Forms.Label();
			this.player2Name = new System.Windows.Forms.Label();
			this.player3Name = new System.Windows.Forms.Label();
			this.player4Name = new System.Windows.Forms.Label();
			this.player5Name = new System.Windows.Forms.Label();
			this.player6Name = new System.Windows.Forms.Label();
			this.player7Name = new System.Windows.Forms.Label();
			this.player8Name = new System.Windows.Forms.Label();
			this.player9Name = new System.Windows.Forms.Label();
			this.player10Name = new System.Windows.Forms.Label();
			this.player1Score = new System.Windows.Forms.Label();
			this.player2Score = new System.Windows.Forms.Label();
			this.player3Score = new System.Windows.Forms.Label();
			this.player4Score = new System.Windows.Forms.Label();
			this.player5Score = new System.Windows.Forms.Label();
			this.player6Score = new System.Windows.Forms.Label();
			this.player7Score = new System.Windows.Forms.Label();
			this.player8Score = new System.Windows.Forms.Label();
			this.player9Score = new System.Windows.Forms.Label();
			this.player10Score = new System.Windows.Forms.Label();
			this.startButt = new System.Windows.Forms.Button();
			this.endGameBttn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// topScores
			// 
			this.topScores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.topScores.AutoSize = true;
			this.topScores.BackColor = System.Drawing.SystemColors.ControlText;
			this.topScores.Font = new System.Drawing.Font("Copperplate Gothic Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.topScores.ForeColor = System.Drawing.Color.Gold;
			this.topScores.Location = new System.Drawing.Point(192, 6);
			this.topScores.Name = "topScores";
			this.topScores.Size = new System.Drawing.Size(404, 53);
			this.topScores.TabIndex = 0;
			this.topScores.Text = "Top 10 Scores";
			// 
			// playerNameLabel
			// 
			this.playerNameLabel.AutoSize = true;
			this.playerNameLabel.BackColor = System.Drawing.SystemColors.ControlText;
			this.playerNameLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.playerNameLabel.ForeColor = System.Drawing.Color.BlueViolet;
			this.playerNameLabel.Location = new System.Drawing.Point(164, 62);
			this.playerNameLabel.Name = "playerNameLabel";
			this.playerNameLabel.Size = new System.Drawing.Size(148, 37);
			this.playerNameLabel.TabIndex = 3;
			this.playerNameLabel.Text = "Player";
			this.playerNameLabel.Click += new System.EventHandler(this.playerNameLabel_Click);
			// 
			// playerScoreLabel
			// 
			this.playerScoreLabel.AutoSize = true;
			this.playerScoreLabel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.playerScoreLabel.ForeColor = System.Drawing.Color.BlueViolet;
			this.playerScoreLabel.Location = new System.Drawing.Point(504, 62);
			this.playerScoreLabel.Name = "playerScoreLabel";
			this.playerScoreLabel.Size = new System.Drawing.Size(132, 37);
			this.playerScoreLabel.TabIndex = 4;
			this.playerScoreLabel.Text = "Score";
			// 
			// player1Name
			// 
			this.player1Name.AutoSize = true;
			this.player1Name.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.player1Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player1Name.ForeColor = System.Drawing.Color.White;
			this.player1Name.Location = new System.Drawing.Point(164, 99);
			this.player1Name.Name = "player1Name";
			this.player1Name.Size = new System.Drawing.Size(155, 32);
			this.player1Name.TabIndex = 5;
			this.player1Name.Text = "Player 1";
			this.player1Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player1Name.Click += new System.EventHandler(this.player1Name_Click);
			this.player1Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player2Name
			// 
			this.player2Name.AutoSize = true;
			this.player2Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player2Name.ForeColor = System.Drawing.Color.White;
			this.player2Name.Location = new System.Drawing.Point(164, 131);
			this.player2Name.Name = "player2Name";
			this.player2Name.Size = new System.Drawing.Size(155, 32);
			this.player2Name.TabIndex = 6;
			this.player2Name.Text = "Player 2";
			this.player2Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player2Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player3Name
			// 
			this.player3Name.AutoSize = true;
			this.player3Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player3Name.ForeColor = System.Drawing.Color.White;
			this.player3Name.Location = new System.Drawing.Point(164, 163);
			this.player3Name.Name = "player3Name";
			this.player3Name.Size = new System.Drawing.Size(155, 32);
			this.player3Name.TabIndex = 7;
			this.player3Name.Text = "Player 3";
			this.player3Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player3Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player4Name
			// 
			this.player4Name.AutoSize = true;
			this.player4Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player4Name.ForeColor = System.Drawing.Color.White;
			this.player4Name.Location = new System.Drawing.Point(164, 195);
			this.player4Name.Name = "player4Name";
			this.player4Name.Size = new System.Drawing.Size(155, 32);
			this.player4Name.TabIndex = 8;
			this.player4Name.Text = "Player 4";
			this.player4Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player4Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player5Name
			// 
			this.player5Name.AutoSize = true;
			this.player5Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player5Name.ForeColor = System.Drawing.Color.White;
			this.player5Name.Location = new System.Drawing.Point(164, 227);
			this.player5Name.Name = "player5Name";
			this.player5Name.Size = new System.Drawing.Size(155, 32);
			this.player5Name.TabIndex = 9;
			this.player5Name.Text = "Player 5";
			this.player5Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player5Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player6Name
			// 
			this.player6Name.AutoSize = true;
			this.player6Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player6Name.ForeColor = System.Drawing.Color.White;
			this.player6Name.Location = new System.Drawing.Point(164, 259);
			this.player6Name.Name = "player6Name";
			this.player6Name.Size = new System.Drawing.Size(155, 32);
			this.player6Name.TabIndex = 10;
			this.player6Name.Text = "Player 6";
			this.player6Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player6Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player7Name
			// 
			this.player7Name.AutoSize = true;
			this.player7Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player7Name.ForeColor = System.Drawing.Color.White;
			this.player7Name.Location = new System.Drawing.Point(164, 291);
			this.player7Name.Name = "player7Name";
			this.player7Name.Size = new System.Drawing.Size(155, 32);
			this.player7Name.TabIndex = 11;
			this.player7Name.Text = "Player 7";
			this.player7Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player7Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player8Name
			// 
			this.player8Name.AutoSize = true;
			this.player8Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player8Name.ForeColor = System.Drawing.Color.White;
			this.player8Name.Location = new System.Drawing.Point(164, 323);
			this.player8Name.Name = "player8Name";
			this.player8Name.Size = new System.Drawing.Size(155, 32);
			this.player8Name.TabIndex = 12;
			this.player8Name.Text = "Player 8";
			this.player8Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player8Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player9Name
			// 
			this.player9Name.AutoSize = true;
			this.player9Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player9Name.ForeColor = System.Drawing.Color.White;
			this.player9Name.Location = new System.Drawing.Point(164, 355);
			this.player9Name.Name = "player9Name";
			this.player9Name.Size = new System.Drawing.Size(155, 32);
			this.player9Name.TabIndex = 13;
			this.player9Name.Text = "Player 9";
			this.player9Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player9Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player10Name
			// 
			this.player10Name.AutoSize = true;
			this.player10Name.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player10Name.ForeColor = System.Drawing.Color.White;
			this.player10Name.Location = new System.Drawing.Point(164, 387);
			this.player10Name.Name = "player10Name";
			this.player10Name.Size = new System.Drawing.Size(177, 32);
			this.player10Name.TabIndex = 14;
			this.player10Name.Text = "Player 10";
			this.player10Name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player10Name.Resize += new System.EventHandler(this.centeredName_SizeChanged);
			// 
			// player1Score
			// 
			this.player1Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player1Score.AutoSize = true;
			this.player1Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player1Score.ForeColor = System.Drawing.Color.White;
			this.player1Score.Location = new System.Drawing.Point(370, 99);
			this.player1Score.Name = "player1Score";
			this.player1Score.Size = new System.Drawing.Size(266, 32);
			this.player1Score.TabIndex = 15;
			this.player1Score.Text = "Player 1 Score";
			this.player1Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player1Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player2Score
			// 
			this.player2Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player2Score.AutoSize = true;
			this.player2Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player2Score.ForeColor = System.Drawing.Color.White;
			this.player2Score.Location = new System.Drawing.Point(370, 131);
			this.player2Score.Name = "player2Score";
			this.player2Score.Size = new System.Drawing.Size(266, 32);
			this.player2Score.TabIndex = 16;
			this.player2Score.Text = "Player 2 Score";
			this.player2Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player2Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player3Score
			// 
			this.player3Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player3Score.AutoSize = true;
			this.player3Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player3Score.ForeColor = System.Drawing.Color.White;
			this.player3Score.Location = new System.Drawing.Point(370, 163);
			this.player3Score.Name = "player3Score";
			this.player3Score.Size = new System.Drawing.Size(266, 32);
			this.player3Score.TabIndex = 17;
			this.player3Score.Text = "Player 3 Score";
			this.player3Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player3Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player4Score
			// 
			this.player4Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player4Score.AutoSize = true;
			this.player4Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player4Score.ForeColor = System.Drawing.Color.White;
			this.player4Score.Location = new System.Drawing.Point(370, 195);
			this.player4Score.Name = "player4Score";
			this.player4Score.Size = new System.Drawing.Size(266, 32);
			this.player4Score.TabIndex = 18;
			this.player4Score.Text = "Player 4 Score";
			this.player4Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player4Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player5Score
			// 
			this.player5Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player5Score.AutoSize = true;
			this.player5Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player5Score.ForeColor = System.Drawing.Color.White;
			this.player5Score.Location = new System.Drawing.Point(370, 227);
			this.player5Score.Name = "player5Score";
			this.player5Score.Size = new System.Drawing.Size(266, 32);
			this.player5Score.TabIndex = 19;
			this.player5Score.Text = "Player 5 Score";
			this.player5Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player5Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player6Score
			// 
			this.player6Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player6Score.AutoSize = true;
			this.player6Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player6Score.ForeColor = System.Drawing.Color.White;
			this.player6Score.Location = new System.Drawing.Point(370, 259);
			this.player6Score.Name = "player6Score";
			this.player6Score.Size = new System.Drawing.Size(266, 32);
			this.player6Score.TabIndex = 20;
			this.player6Score.Text = "Player 6 Score";
			this.player6Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player6Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player7Score
			// 
			this.player7Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player7Score.AutoSize = true;
			this.player7Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player7Score.ForeColor = System.Drawing.Color.White;
			this.player7Score.Location = new System.Drawing.Point(370, 291);
			this.player7Score.Name = "player7Score";
			this.player7Score.Size = new System.Drawing.Size(266, 32);
			this.player7Score.TabIndex = 21;
			this.player7Score.Text = "Player 7 Score";
			this.player7Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player7Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player8Score
			// 
			this.player8Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player8Score.AutoSize = true;
			this.player8Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player8Score.ForeColor = System.Drawing.Color.White;
			this.player8Score.Location = new System.Drawing.Point(370, 323);
			this.player8Score.Name = "player8Score";
			this.player8Score.Size = new System.Drawing.Size(266, 32);
			this.player8Score.TabIndex = 22;
			this.player8Score.Text = "Player 8 Score";
			this.player8Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player8Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player9Score
			// 
			this.player9Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player9Score.AutoSize = true;
			this.player9Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player9Score.ForeColor = System.Drawing.Color.White;
			this.player9Score.Location = new System.Drawing.Point(370, 355);
			this.player9Score.Name = "player9Score";
			this.player9Score.Size = new System.Drawing.Size(266, 32);
			this.player9Score.TabIndex = 23;
			this.player9Score.Text = "Player 9 Score";
			this.player9Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player9Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// player10Score
			// 
			this.player10Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.player10Score.AutoSize = true;
			this.player10Score.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.player10Score.ForeColor = System.Drawing.Color.White;
			this.player10Score.Location = new System.Drawing.Point(348, 387);
			this.player10Score.Name = "player10Score";
			this.player10Score.Size = new System.Drawing.Size(288, 32);
			this.player10Score.TabIndex = 24;
			this.player10Score.Text = "Player 10 Score";
			this.player10Score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.player10Score.Resize += new System.EventHandler(this.centeredScore_SizeChanged);
			// 
			// startButt
			// 
			this.startButt.BackColor = System.Drawing.Color.BlueViolet;
			this.startButt.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.startButt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.startButt.Location = new System.Drawing.Point(12, 12);
			this.startButt.Name = "startButt";
			this.startButt.Size = new System.Drawing.Size(146, 82);
			this.startButt.TabIndex = 25;
			this.startButt.Text = "New Game";
			this.startButt.UseVisualStyleBackColor = false;
			this.startButt.Click += new System.EventHandler(this.startButt_Click);
			// 
			// endGameBttn
			// 
			this.endGameBttn.BackColor = System.Drawing.Color.BlueViolet;
			this.endGameBttn.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.endGameBttn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.endGameBttn.Location = new System.Drawing.Point(642, 12);
			this.endGameBttn.Name = "endGameBttn";
			this.endGameBttn.Size = new System.Drawing.Size(146, 82);
			this.endGameBttn.TabIndex = 26;
			this.endGameBttn.Text = "End Game";
			this.endGameBttn.UseVisualStyleBackColor = false;
			this.endGameBttn.Click += new System.EventHandler(this.endGameBttn_Click);
			// 
			// ScoreBoardScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(800, 430);
			this.Controls.Add(this.endGameBttn);
			this.Controls.Add(this.startButt);
			this.Controls.Add(this.player10Score);
			this.Controls.Add(this.player9Score);
			this.Controls.Add(this.player8Score);
			this.Controls.Add(this.player7Score);
			this.Controls.Add(this.player6Score);
			this.Controls.Add(this.player5Score);
			this.Controls.Add(this.player4Score);
			this.Controls.Add(this.player3Score);
			this.Controls.Add(this.player2Score);
			this.Controls.Add(this.player1Score);
			this.Controls.Add(this.player10Name);
			this.Controls.Add(this.player9Name);
			this.Controls.Add(this.player8Name);
			this.Controls.Add(this.player7Name);
			this.Controls.Add(this.player6Name);
			this.Controls.Add(this.player5Name);
			this.Controls.Add(this.player4Name);
			this.Controls.Add(this.player3Name);
			this.Controls.Add(this.player2Name);
			this.Controls.Add(this.player1Name);
			this.Controls.Add(this.playerScoreLabel);
			this.Controls.Add(this.playerNameLabel);
			this.Controls.Add(this.topScores);
			this.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ScoreBoardScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.ScoreBoardScreen_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label topScores;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label playerScoreLabel;
        private System.Windows.Forms.Label player1Name;
        private System.Windows.Forms.Label player2Name;
        private System.Windows.Forms.Label player3Name;
        private System.Windows.Forms.Label player4Name;
        private System.Windows.Forms.Label player5Name;
        private System.Windows.Forms.Label player6Name;
        private System.Windows.Forms.Label player7Name;
        private System.Windows.Forms.Label player8Name;
        private System.Windows.Forms.Label player9Name;
        private System.Windows.Forms.Label player10Name;
        private System.Windows.Forms.Label player1Score;
        private System.Windows.Forms.Label player2Score;
        private System.Windows.Forms.Label player3Score;
        private System.Windows.Forms.Label player4Score;
        private System.Windows.Forms.Label player5Score;
        private System.Windows.Forms.Label player6Score;
        private System.Windows.Forms.Label player7Score;
        private System.Windows.Forms.Label player8Score;
        private System.Windows.Forms.Label player9Score;
        private System.Windows.Forms.Label player10Score;
        private System.Windows.Forms.Button startButt;
        private System.Windows.Forms.Button endGameBttn;
    }
}

