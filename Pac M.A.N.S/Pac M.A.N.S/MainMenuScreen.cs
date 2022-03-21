/*******************************************************************
 * MainMenuScreen
 * Authors: Andi Fuerst
 * This screen acts as a intermediary before entering the game. 
********************************************************************/
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
	public partial class MainMenuScreen : Form
	{
		/****************************************************************
		 * Initializes the components
		 * *************************************************************/
		public MainMenuScreen()
		{
			InitializeComponent();
		}

		/****************************************************************
		 * when the button is clicked, it will move to controls screen
		 * @param object, EventArgs
		 * *************************************************************/
		private void startButt_Click(object sender, EventArgs e)
		{
			ControlsScreen controls = new ControlsScreen();
			this.Hide();
			controls.Show();
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
