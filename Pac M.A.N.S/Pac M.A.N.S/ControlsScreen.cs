/*******************************************************************
 * ControlsScreen
 * Authors: Andi Fuerst
 * This screen displays the controls before going into the game.
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
	public partial class ControlsScreen : Form
	{
		/****************************************************************
		 * Initializes the components
		 * *************************************************************/
		public ControlsScreen()
		{
			InitializeComponent();
		}

		/****************************************************************
		 * When a button is pushed, the screen moves to the game screen
		 * @param object, KeyEventArgs
		 * *************************************************************/
		private void ControlsScreen_KeyDown_1(object sender, KeyEventArgs e)
		{
			GameScreen game = new GameScreen();
			this.Hide();
			game.Show();
		}
	}
}
