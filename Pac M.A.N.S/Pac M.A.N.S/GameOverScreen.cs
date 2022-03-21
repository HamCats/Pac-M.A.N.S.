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
    /// <summary>
    /// This form appears when the player loses and shows their scores
    /// and asks for the user to enter their name.
    /// </summary>
	public partial class GameOverScreen : Form
	{
        private const int MAX_LENGTH = 3;
        int scoreCalc;
        String name;

        /// <summary>
        /// Intializes the components of the form
        /// </summary>
		public GameOverScreen()
		{
			InitializeComponent();
            tbxName.MaxLength = MAX_LENGTH;
            btnSubmitName.FlatStyle = FlatStyle.Flat;
            btnSubmitName.FlatAppearance.BorderColor = Color.Indigo;
            btnSubmitName.FlatAppearance.BorderSize = 2;
        }

        /// <summary>
        /// This method retrieves the player's score.
        /// </summary>
        /// <param name="score"> player's final score </param>
		public void RetrieveScore(int score)
        {
            scoreCalc = score;
        }
        
        /// <summary>
        /// This method retrieves the player's name from the
        /// textbox on the form.
        /// </summary>
        /// <returns> Returns player's name </returns>
        public String getPlayerName()
        {
            name = tbxName.Text;
            return name;
        }

        /// <summary>
        /// This method prints the score onto the label upon the form loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            lblScore.Text = scoreCalc.ToString();
        }

        /// <summary>
        /// When the submit button is clicked, the player's name and score
        /// are sent to scoreboard and shows that form while hiding this one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text))
            {
                lblErrorMessage.Text = "Error: Enter at least 1 character.";
                tbxName.Clear();
            }
            else
            {
                ScoreBoardScreen scoreboard = new ScoreBoardScreen();
                getPlayerName();
                scoreboard.retrieveNameAndScores(name, scoreCalc);
                this.Hide();
                scoreboard.Show();
            }
        }
    }
}