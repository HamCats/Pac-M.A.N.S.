using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
    /// <summary>
    /// This class extends the GhostBoys abstract class and contains
    /// properties and methods needed to move Blinky.
    /// </summary>
    public class Blinky : GhostBoys
    {
        private const int STARTING_LOCATION_COORDINATE_X = 290;
        private const int STARTING_LOCATION_COORDINATE_Y = 182;
        private const int JUMP_OUT_OF_BOX = 35;
        private const int BELOW_BOTTOM_SECTION_MID = 331;
        private const int ABOVE_BOTTOM_BORDER_AISLE = 372, BOTTOM_BORDER_AISLE = 374;
        private const int LEFT_OF_MAIN_LEFT_AISLE = 92, MAIN_LEFT_AISLE = 98, RIGHT_OF_MAIN_LEFT_AISLE = 99;
        private const int TOP_OF_BOTTOM_LEFT_CORNER = 335;
        private const int PAC_MAN_AISLE = 299;
        private const int MIDDLE_OF_TOP_SECTION = 103;
        private const int TOP_BELOW_GHOST_BOX = 221, MID_BELOW_GHOST_BOX = 222, BOTTOM_BELOW_GHOST_BOX = 224;
        private const int RIGHT_GHOST_BOX = 327, TOP_LEFT_GHOST_BOX = 144;
        private const int MIDDLE = 186;
        private const int RIGHTMOST_BORDER = 476;
        private const int LEFT_OF_UP_TO_CORNER = 44, UP_TO_CORNER = 46;
        private const int UPMOST_BOUNDARY = 5;
        private const int BOTTOM_SECTION = 257;
        private const int LEFT_OF_RIGHT_SIDE_OF_MAP = 264, RIGHT_SIDE_OF_MAP = 266;
        private const int TOP = 0, RIGHT = 1, LEFT = 2, BOTTOM = 3;

        /// <summary>
        /// This is the constructor for Blinky. Sets properties with starting values needed.
        /// </summary>
        /// <param name="visual">The <see cref="PictureBox"/> representing Blinky</param>
        public Blinky(PictureBox visual)
        {
            this.Visual = visual;
            this.StartingLocationX = STARTING_LOCATION_COORDINATE_X;
            this.StartingLocationY = STARTING_LOCATION_COORDINATE_Y;
            this.CurrentLocationX = this.StartingLocationX;
            this.CurrentLocationY = this.StartingLocationY;
            this.IsEdible = false;
        }

        /// <summary>
        /// This method converts Blinky to edible and changes its sprite.
        /// </summary>
        public override void ConvertToFood()
        {
            this.Visual.Image = Properties.Resources.EdibleGhostSprite20x20;
        }

        /// <summary>
        /// This method converts Blinky to non-edible and changes sprite
        /// back to original one.
        /// </summary>
        public override void ConvertToGhost()
        {
            this.IsEdible = false;
            this.Visual.Image = Properties.Resources.red_guy;
        }

        /// <summary>
		/// This is the main method to run Blinky and place him in his next location.
		/// It also mainly takes care of collisions that he has with walls.
		/// </summary>
        /// <param name="walls"> walls in the game screen</param>
        public override void RunGhost(List<PictureBox> walls)
        {
            foreach (PictureBox pbx in walls)
            {
                if (Visual.Bounds.IntersectsWith(pbx.Bounds))
                {
                    if (Visual.Top + BOUNDS_ADJUSTMENT == pbx.Bottom)
                    {
                        collisionUp = true;
                    }
                    else
                    {
                        collisionUp = false;
                    }
                    if (Visual.Bottom - BOUNDS_ADJUSTMENT == pbx.Top)
                    {
                        collisionDown = true;
                    }
                    else
                    {
                        collisionDown = false;
                    }
                    if (Visual.Right - BOUNDS_ADJUSTMENT == pbx.Left)
                    {
                        collisionRight = true;
                    }
                    else
                    {
                        collisionRight = false;
                    }
                    if (Visual.Left + BOUNDS_ADJUSTMENT == pbx.Right)
                    {
                        collisionLeft = true;
                    }
                    else
                    {
                        collisionLeft = false;
                    }
                    if (collisionUp == true || collisionRight == true || collisionLeft == true || collisionDown == true)
                    {
                        this.collided = true;
                    }
                }
            }
            if (this.collided == true)
            {
                RunCollision();
            }
            if (this.IsEdible)
            {
                RunAway(firstCollision, secondCollision);
            }
            else
            {
                MoveMe(firstCollision, secondCollision);
            }
            Visual.Location = new Point(this.CurrentLocationX, this.CurrentLocationY);
        }

        /// <summary>
        /// This method contains Blinky's movement.
        /// </summary>
        /// <param name="firstCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        /// <param name="secondCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none  </param>
        public override void MoveMe(int firstCollision, int secondCollision)
        {
            if (atStartingLocation == true)
            {
                this.CurrentLocationY -= JUMP_OUT_OF_BOX;
                atStartingLocation = false;
            }
            else
            {
                if (collided == false)
                {
                    NonCollisionMove();
                }
                else
                {
                    CollisionMove(firstCollision, secondCollision);
                    collided = false;
                }
            }
        }

        /// <summary>
        /// This method contains Blinky's movements when no collision has occurred.
        /// </summary>
        public void NonCollisionMove()
        {
            if (this.CurrentLocationY == MIDDLE || this.CurrentLocationY == TOP_OF_BOTTOM_LEFT_CORNER || this.CurrentLocationY == PAC_MAN_AISLE)
            {
                this.CurrentLocationX++;
            }
            else if ((this.CurrentLocationX == MAIN_LEFT_AISLE && this.CurrentLocationY == BOTTOM_BORDER_AISLE)
                || this.CurrentLocationY == BOTTOM_BORDER_AISLE)
            {
                this.CurrentLocationX--;
            }
            else
            {
                this.CurrentLocationY++;
            }
        }

        /// <summary>
        /// This method contains Blinky's movement when collision has occurred.
        /// </summary>
        /// <param name="firstCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        /// <param name="secondCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        public void CollisionMove(int firstCollision, int secondCollision)
        {
            if (firstCollision == TOP && (this.CurrentLocationY == MIDDLE_OF_TOP_SECTION || this.CurrentLocationY == TOP_BELOW_GHOST_BOX))
            {
                this.CurrentLocationX++;
            }
            else if (firstCollision == BOTTOM && secondCollision == RIGHT && this.CurrentLocationY == PAC_MAN_AISLE)
            {
                this.CurrentLocationX++;
            }
            else if (firstCollision == BOTTOM && secondCollision == RIGHT)
            {
                this.CurrentLocationX--;
            }
            else if (firstCollision == RIGHT && this.CurrentLocationX == RIGHT_OF_MAIN_LEFT_AISLE)
            {
                this.CurrentLocationY--;
            }
            else if (firstCollision == RIGHT && this.CurrentLocationX == RIGHTMOST_BORDER && this.CurrentLocationY == BOTTOM_BORDER_AISLE)
            {
                this.CurrentLocationX--;
            }
            else if (firstCollision == RIGHT && this.CurrentLocationX == RIGHTMOST_BORDER)
            {
                this.CurrentLocationY++;
            }
            else if (firstCollision == RIGHT || secondCollision == RIGHT)
            {
                this.CurrentLocationY++;
            }
            else if (firstCollision == BOTTOM && this.CurrentLocationY == PAC_MAN_AISLE)
            {
                this.CurrentLocationX++;
            }
            else if (firstCollision == BOTTOM)
            {
                this.CurrentLocationX--;
            }
            else if (firstCollision == LEFT && this.CurrentLocationY <= BOTTOM_BORDER_AISLE && this.CurrentLocationY > TOP_OF_BOTTOM_LEFT_CORNER)
            {
                this.CurrentLocationY--;
            }
            else if (firstCollision == LEFT && this.CurrentLocationY == TOP_OF_BOTTOM_LEFT_CORNER)
            {
                this.CurrentLocationX++;
            }
            else
            {
                this.CurrentLocationX--;
            }
        }

        /// <summary>
        /// Returns Blinky to starting position
        /// </summary>
        public override void ReturnToStart()
        {
            this.CurrentLocationX = this.StartingLocationX;
            this.CurrentLocationY = this.StartingLocationY - JUMP_OUT_OF_BOX;
        }

        /// <summary>
        /// This method calls other methods based on collision for Blinky's run away movement.
        /// </summary>
        /// <param name="firstCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none  </param>
        /// <param name="secondCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none  </param>
        public override void RunAway(int firstCollision, int secondCollision)
        {
            if (collided == false)
            {
                NonCollisionMoveToCorner();
            }
            else
            {
                collisionMoveToCorner(firstCollision, secondCollision);
                collided = false;
            }
        }

        /// <summary>
        /// This method contains Blinky's movements to his corner when no collision has occurred.
        /// </summary>
        private void NonCollisionMoveToCorner()
        {
            if ((this.CurrentLocationY == BOTTOM_SECTION && this.CurrentLocationX < RIGHT_SIDE_OF_MAP)
                || (this.CurrentLocationY == TOP_OF_BOTTOM_LEFT_CORNER && this.CurrentLocationX < LEFT_OF_UP_TO_CORNER))
            {
                this.CurrentLocationX++;
            }
            else if ((this.CurrentLocationX >= LEFT_OF_UP_TO_CORNER && this.CurrentLocationX <= UP_TO_CORNER)
                || this.CurrentLocationX == UPMOST_BOUNDARY || this.CurrentLocationX == RIGHT_GHOST_BOX)
            {
                if (this.CurrentLocationY >= MID_BELOW_GHOST_BOX && this.CurrentLocationY <= BOTTOM_BELOW_GHOST_BOX)
                {
                    this.CurrentLocationX--;
                }
                this.CurrentLocationY--;
            }
            else if (this.CurrentLocationX == MAIN_LEFT_AISLE && this.CurrentLocationY < TOP_OF_BOTTOM_LEFT_CORNER)
            {
                this.CurrentLocationY++;
            }
            else
            {
                this.CurrentLocationX--;
            }
        }

        /// <summary>
        /// This method contains Clyde's movements to his corner when collision has occurred.
        /// </summary>
        /// <param name="firstCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        /// <param name="secondCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        private void collisionMoveToCorner(int firstCollision, int secondCollision)
        {
            if (firstCollision == TOP && secondCollision == RIGHT)
            {
                this.CurrentLocationY++;
            }
            else if (firstCollision == TOP && secondCollision == LEFT)
            {
                if (this.CurrentLocationY == BELOW_BOTTOM_SECTION_MID)
                {
                    this.CurrentLocationX++;
                }
                else
                {
                    this.CurrentLocationY++;
                }
            }
            else if (firstCollision == TOP)
            {
                if (this.CurrentLocationY == BELOW_BOTTOM_SECTION_MID)
                {
                    this.CurrentLocationX++;
                }
                else
                {
                    this.CurrentLocationX--;
                }
            }
            else if (firstCollision == BOTTOM && secondCollision == RIGHT)
            {
                this.CurrentLocationY++;
            }
            else if (firstCollision == BOTTOM && secondCollision == LEFT)
            {
                if (this.CurrentLocationX == TOP_LEFT_GHOST_BOX)
                {
                    this.CurrentLocationY++;
                }
                else
                {
                    this.CurrentLocationY--;
                }
            }
            else if (firstCollision == BOTTOM)
            {
                this.CurrentLocationY--;
                this.CurrentLocationX--;
            }
            else if (firstCollision == RIGHT)
            {
                if (this.CurrentLocationX == RIGHTMOST_BORDER && this.CurrentLocationY == ABOVE_BOTTOM_BORDER_AISLE)
                {
                    this.CurrentLocationX--;
                }
                else
                {
                    this.CurrentLocationY++;
                }
            }
            else if (firstCollision == LEFT)
            {
                if (this.CurrentLocationX == LEFT_OF_MAIN_LEFT_AISLE || this.CurrentLocationX == TOP_LEFT_GHOST_BOX
                    || this.CurrentLocationX == TOP_LEFT_GHOST_BOX
                    || (this.CurrentLocationX >= LEFT_OF_RIGHT_SIDE_OF_MAP && this.CurrentLocationX <= RIGHT_SIDE_OF_MAP))
                {
                    this.CurrentLocationY++;
                }
                else if (this.CurrentLocationY == BOTTOM_SECTION)
                {
                    this.CurrentLocationX++;
                }
                else
                {
                    this.CurrentLocationY--;
                    this.CurrentLocationX++;
                }
            }
        }
    }
}