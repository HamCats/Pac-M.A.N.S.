using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
    public partial class ScoreBoardScreen : Form
	{
        Scores top10 = new Scores();

        /*
         * Method to set the name and scores
         */
        public void retrieveNameAndScores(String name, int score)
        {
            top10.addInfo(name, score);
        }

        /*
         * Constructor
         */
        public ScoreBoardScreen()
		{
            InitializeComponent();
            top10.LoadScores();
        }

        /*
         * Method to load the screen and set the label values. 
         */
        private void ScoreBoardScreen_Load(object sender, EventArgs e)
        {
            // Player Names
            player1Name.Text = top10.nameToSend(0);
            player2Name.Text = top10.nameToSend(1);
            player3Name.Text = top10.nameToSend(2);
            player4Name.Text = top10.nameToSend(3);
            player5Name.Text = top10.nameToSend(4);
            player6Name.Text = top10.nameToSend(5);
            player7Name.Text = top10.nameToSend(6);
            player8Name.Text = top10.nameToSend(7);
            player9Name.Text = top10.nameToSend(8);
            player10Name.Text = top10.nameToSend(9);

            // Player Scores
            player1Score.Text = top10.scoreToSend(0).ToString();
            player2Score.Text = top10.scoreToSend(1).ToString();
            player3Score.Text = top10.scoreToSend(2).ToString();
            player4Score.Text = top10.scoreToSend(3).ToString();
            player5Score.Text = top10.scoreToSend(4).ToString();
            player6Score.Text = top10.scoreToSend(5).ToString();
            player7Score.Text = top10.scoreToSend(6).ToString();
            player8Score.Text = top10.scoreToSend(7).ToString();
            player9Score.Text = top10.scoreToSend(8).ToString();
            player10Score.Text = top10.scoreToSend(9).ToString();
        }

        const int SCORE_CENTER = 617;
        private void centeredScore_SizeChanged (object sender, EventArgs e)
        {
            if (!(sender is Label))
                return;
            Label label = (Label)sender;
            label.Left = SCORE_CENTER - (label.Width / 2);
        }

        const int NAME_CENTER = 266;
        private void centeredName_SizeChanged (object sender, EventArgs e)
        {
            if (!(sender is Label))
                return;
            Label label = (Label)sender;
            label.Left = NAME_CENTER - (label.Width / 2);
        }

        private void startButt_Click (object sender, EventArgs e)
        {
            GameScreen game = new GameScreen();
            this.Hide();
            game.Show();
        }

        private void endGameBttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void playerNameLabel_Click(object sender, EventArgs e)
		{

		}

		private void player1Name_Click(object sender, EventArgs e)
		{

		}
	}
}