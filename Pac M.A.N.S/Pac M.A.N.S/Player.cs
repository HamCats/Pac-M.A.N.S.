using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
	/*
	 * Class to run the players information, 
	 * in this case this class works with Pac Man
	 */
	class Player
	{
		int startingLocationX = 238;
		int startingLocationY = 294;
		int currentLocationX = 238;
		int currentLocationY = 294;
		int lives = 3;
		PictureBox currentPicP;
		private Direction currentDirection = Direction.Right;

		public int CurrentX { get { return currentLocationX; } }
		public int CurrentY { get { return currentLocationY; } }
		public Direction CurrentDirection { get { return currentDirection; } }

		/*
		 * Constructor
		 */
		public Player (PictureBox currentPic)
        {
			currentPicP = currentPic;
			currentPicP.Visible = true;
		}

		/*
		* Method used to move Pac Man around the maze based on what the user inputs for the 
		* directions they want Pac Man to go. 
		*/
		public Point movePac(bool moveUP, bool moveDown, bool moveLeft, bool moveRight)
        {
			if (moveUP)
			{
				currentLocationY--;
				currentDirection = Direction.Up;
			}
			else if (moveDown)
			{
				currentLocationY++;
				currentDirection = Direction.Down;
			}
			else if (moveLeft)
			{
				if (currentLocationX == 0)
					currentLocationX = 482;
				else
					currentLocationX--;
				currentDirection = Direction.Left;
			}
			else if (moveRight)
			{
				if (currentLocationX == 482)
					currentLocationX = 0;
				else
					currentLocationX++;
				currentDirection = Direction.Right;
			}

			return new Point(currentLocationX, currentLocationY);
        }

		/*
		* Method to return Pac Man to the start when he collides with a ghost.
		* This will eventually become void and Pac Man will be returned to start from 
		* this class and not from the GUI. 
		 */
		public Point returnToStart()
        {
			currentLocationX = startingLocationX;
			currentLocationY = startingLocationY;
			this.currentPicP.BringToFront();
			return new Point(startingLocationX, startingLocationY);
        }

		/*
		* Method to lose a life once Pac Man runs into a ghost.
		*/
		public void byeByeLives()
        {
			lives--;
        }

		/*
		 * Method to return the number of lives Pac Man currently has
		*/
		public int getLives()
        {
			return lives;
        }

		/*
		 * Method to return the current Pac Man image
		 */
		public PictureBox getPic()
		{
			return currentPicP;
		}
	}
}