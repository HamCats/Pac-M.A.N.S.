using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pac_M.A.N.S;


namespace Pac_M.A.N.S
{
    /*
     * Class to run Inky, who is one of the 4 ghosts in the game
     */
	class Inky : GhostBoys
	{
        private const int START_X = 221;
        private const int START_Y = 182;
        private const int LEAVE_BOX = 42;
        private const int TOP_RIGHT_X = 383;
        private const int TOP_RIGHT_Y = 68;
        private const int TOP_LEFT_X = 93;
        private const int TOP_LEFT_Y = 68;
        private const int BOTTOM_RIGHT_X = 384;
        private const int BOTTOM_RIGHT_Y = 294;
        private const int BOTTOM_LEFT_X = 93;
        private const int BOTTOM_LEFT_Y = 294;
        private const int FIRST_WALL = 330;
        private const int SECOND_WALL = 260;
        private const int START_DOT_X = 383;
        private const int START_DOT_Y = 260;
        bool startSquare = false;
        bool startingLocation = true;
        

        /*
         *  Constructor: Sets Inky's picture to visible and sets his starting
         *  location. 
         */
        public Inky (PictureBox visual)
        {
            this.Visual = visual;
            this.StartingLocationX = START_X;
            this.StartingLocationY = START_Y;
            this.CurrentLocationX = START_X;
            this.CurrentLocationY = START_Y;
            startingLocation = true;
        }

        /*
         * Returns Inky to his starting position.
         * Will get called if he gets eaten or if the game restarts
         */
        public override void ReturnToStart ()
        {
            this.CurrentLocationX = START_X;
            this.CurrentLocationY = START_Y;
            startingLocation = true;
            startSquare = false;
        }

        /*
         * Method used to move Inky across the game screen
         */
        public override void MoveMe (int firstCollision, int secondCollision)
        {
            if (startingLocation == true)
            {
                this.CurrentLocationY += LEAVE_BOX;
                startingLocation = false;
            }
            else if(startSquare == false)
                getToSquare();
            else
                keepMoving();
        }

        /*
         * Method to keep Inky moving assuming he has not run into anything
         */
        public void keepMoving ()
        {
            if (this.CurrentLocationX == TOP_RIGHT_X && this.CurrentLocationY != TOP_RIGHT_Y)
                this.CurrentLocationY--;
            else if (this.CurrentLocationX == TOP_RIGHT_X && this.CurrentLocationY == TOP_RIGHT_Y)
                this.CurrentLocationX--;
            else if (this.CurrentLocationX != TOP_LEFT_X && this.CurrentLocationY == TOP_LEFT_Y)
                this.CurrentLocationX--;
            else if (this.CurrentLocationX == TOP_LEFT_X && this.CurrentLocationY == TOP_LEFT_Y)
                this.CurrentLocationY++;
            else if (this.CurrentLocationX == BOTTOM_LEFT_X && this.CurrentLocationY != BOTTOM_LEFT_Y)
                this.CurrentLocationY++;
            else if (this.CurrentLocationX == BOTTOM_LEFT_X && this.CurrentLocationY == BOTTOM_LEFT_Y)
                this.CurrentLocationX++;
            else if (this.CurrentLocationX != BOTTOM_RIGHT_X && this.CurrentLocationY == BOTTOM_LEFT_Y)
                this.CurrentLocationX++;
            else if (this.CurrentLocationX == BOTTOM_RIGHT_X && this.CurrentLocationY == BOTTOM_RIGHT_Y)
                this.CurrentLocationY--;
        }

        /*
         * Method to help get Inky to his starting square before he starts on his rounds
         */
        public void getToSquare()
        {
            if (this.CurrentLocationX != FIRST_WALL && this.CurrentLocationY == START_Y + LEAVE_BOX)
                this.CurrentLocationX++;
            else if (this.CurrentLocationX == FIRST_WALL && this.CurrentLocationY != SECOND_WALL)
                this.CurrentLocationY++;
            else if (this.CurrentLocationX != START_DOT_X && this.CurrentLocationY == SECOND_WALL)
                this.CurrentLocationX++;
            else if (this.CurrentLocationX == START_DOT_X && this.CurrentLocationY == START_DOT_Y)
            {
                startSquare = true;
                keepMoving();
            }
                
        }
        /*
         * Method to change the direction that Inky is moving
         * Not being implemented
         */
        public void changeMove (int firstCollision, int secondCollision)
        {
        }

        /*
         * Method to move Inky if he becomes edible during the game.
         */ 
        public override void RunAway (int firstCollision, int secondCollision)
        {
            ConvertToFood();
            MoveMe(firstCollision, secondCollision);
        }

        /*
         * Method to change Inky's sprite to the blue ghost that means he is edible
         */
        public override void ConvertToFood ()
        {
            this.Visual.Image = Properties.Resources.EdibleGhostSprite20x20;
        }

        /*
         * Method to switch Inky back to a normal ghost after he is unable to be eaten
         */
        public override void ConvertToGhost ()
        {
            this.IsEdible = false;
            this.Visual.Image = Properties.Resources.pink_guy;
        }

        /*
         * Method used to help run Inky
         */
        public override void RunGhost(List<PictureBox> walls)
        {
            if (this.IsEdible == true) { ConvertToFood(); }
            
            MoveMe(firstCollision, secondCollision);

            Visual.Location = new Point(CurrentLocationX, CurrentLocationY);
        }
    }
}