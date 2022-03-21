using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
    /// <summary>
    /// This class extends the GhostBoys abstract class and contains
    /// properties and methods needed to move Clyde.
    /// </summary>
    public class Clyde : GhostBoys
    {
        private const int STARTING_LOCATION_COORDINATE_X = 255, STARTING_LOCATION_COORDINATE_Y = 182;
        private const int JUMP_OUT_OF_BOX = 35;
        private const int LEFT_AISLE = 0, RIGHT_AISLE = 500;
        private const int UPMOST_BOUNDARY = 4, MID_UPMOST_BOUNDARY = 5, BELOW_UPMOST_BOUNDARY = 6;
        private const int JUST_ABOVE_RIGHT_AISLE = 264;
        private const int LEFTMOST_RIGHTMOST_VERTICAL_AISLE = 379, LEFT_OF_RIGHTMOST_VERTICAL_AISLE = 380;
        private const int MID_OF_RIGHTMOST_VERTICAL_AISLE = 386, RIGHTMOST_VERTICAL_AISLE = 388;
        private const int RIGHT_DECIDING_POINT = 186, LEFT_DECIDING_POINT = 185;
        private const int BOTTOM_TOP_CORNER = 112;
        private const int WALL_BEFORE_RIGHT_AISLE = 258;
        private const int LEFT_INTERSECTION_POINT_X = 98, LEFT_INTERSECTION_POINT_Y = 184;
        private const int MIDLEFT_CORNER = 211;
        private const int BOTTOM_SECTION = 257;
        private const int MID_BOTTOM_HALF = 295;
        private const int TOP_MAIN_ROW = 62, BOTTOM_OF_TOP_MAIN_ROW = 68;
        private const int LEFT_OF_PAC_MAN_AISLE = 292, PAC_MAN_AISLE = 299;
        private const int RIGHT_SIDE_OF_MAP = 266;
        private const int BOTTOM_RIGHT_OF_CORNER = 91;
        private const int TOP_RIGHT_OUT_GHOST_BOX = 144;
        private const int TOP = 0, RIGHT = 1, LEFT = 2, BOTTOM = 3;
        private const int DIVISOR = 2, EVEN_RESULT = 0;
        private int rightRoundNum = 0, leftRoundNum = 0;

        /// <summary>
        /// This is the constructor for Clyde. Sets properties with starting values needed.
        /// </summary>
        /// <param name="visual">The <see cref="PictureBox"/> representing Clyde</param>
        public Clyde(PictureBox visual)
        {
            this.Visual = visual;
            this.StartingLocationX = STARTING_LOCATION_COORDINATE_X;
            this.StartingLocationY = STARTING_LOCATION_COORDINATE_Y;
            this.CurrentLocationX = this.StartingLocationX;
            this.CurrentLocationY = this.StartingLocationY;
            this.IsEdible = false;
            this.atStartingLocation = true;
        }

        /// <summary>
        /// This method converts Clyde to edible and changes its sprite.
        /// </summary>
        public override void ConvertToFood()
        {
            this.Visual.Image = Properties.Resources.EdibleGhostSprite20x20;
        }

        /// <summary>
        /// This method converts Clyde to non-edible and changes sprite
        /// back to original one.
        /// </summary>
        public override void ConvertToGhost()
        {
            this.IsEdible = false;
            this.Visual.Image = Properties.Resources.yellow_guy;
        }

        /// <summary>
		/// This is the main method to run Clyde and place him in his next location.
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
            Visual.Location = new Point(CurrentLocationX, CurrentLocationY);
        }

        /// <summary>
        /// This method contains Clyde's movement.
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
        /// This method contains Clyde's movements when no collision has occurred.
        /// </summary>
        private void NonCollisionMove()
        {
            if (CurrentLocationX == LEFT_AISLE)
            {
                CurrentLocationX = RIGHT_AISLE;
            }
            else if (this.CurrentLocationX == RIGHTMOST_VERTICAL_AISLE && ((this.CurrentLocationY < JUST_ABOVE_RIGHT_AISLE
                && this.CurrentLocationY > UPMOST_BOUNDARY)))
            {
                if (this.CurrentLocationY == RIGHT_DECIDING_POINT)
                {
                    rightRoundNum++;
                    if (CheckIfEven(rightRoundNum) == false)
                    {
                        this.CurrentLocationX--;
                    }
                    else
                    {
                        this.CurrentLocationY--;
                    }
                }
                else
                {
                    this.CurrentLocationY--;
                }
            }
            else if (this.CurrentLocationY != LEFT_DECIDING_POINT && (this.CurrentLocationY < WALL_BEFORE_RIGHT_AISLE))
            {
                if (this.CurrentLocationY == BOTTOM_TOP_CORNER)
                {
                    this.CurrentLocationX++;
                }
                else
                {
                    if (this.CurrentLocationX == LEFT_INTERSECTION_POINT_X && this.CurrentLocationY == LEFT_INTERSECTION_POINT_Y)
                    {
                        leftRoundNum++;
                        if (CheckIfEven(leftRoundNum) == true)
                        {
                            this.CurrentLocationY++;
                        }
                        else
                        {
                            this.CurrentLocationX--;
                        }
                    }
                    else
                    {
                        this.CurrentLocationX--;
                    }
                }
            }
            else
            {
                this.CurrentLocationX++;
            }
        }

        /// <summary>
        /// This method contains Clyde's movement when collision has occurred.
        /// </summary>
        /// <param name="firstCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        /// <param name="secondCollision"> If collision happens on 0 top, 1 right, 2 left, 3 bottom, 4 none </param>
        private void CollisionMove(int firstCollision, int secondCollision)
        {
            if (this.CurrentLocationX == MIDLEFT_CORNER && (this.CurrentLocationY < MID_BOTTOM_HALF
                && this.CurrentLocationY > WALL_BEFORE_RIGHT_AISLE))
            {
                this.CurrentLocationY++;
            }
            else if ((this.CurrentLocationX == RIGHTMOST_VERTICAL_AISLE) && ((this.CurrentLocationY < JUST_ABOVE_RIGHT_AISLE
                && this.CurrentLocationY > RIGHT_DECIDING_POINT) || (this.CurrentLocationY <= RIGHT_DECIDING_POINT
                && this.CurrentLocationY > UPMOST_BOUNDARY)))
            {
                this.CurrentLocationY--;
            }
            else
            {
                if (firstCollision == TOP && secondCollision == RIGHT)
                {
                    this.CurrentLocationY++;
                }
                else if (firstCollision == TOP && secondCollision == LEFT)
                {
                    this.CurrentLocationY++;
                }
                else if (firstCollision == TOP)
                {
                    this.CurrentLocationY++;
                    this.CurrentLocationX--;
                }
                else if (firstCollision == BOTTOM && secondCollision == RIGHT)
                {
                    this.CurrentLocationY++;
                }
                else if (firstCollision == BOTTOM && secondCollision == LEFT)
                {
                    this.CurrentLocationY++;
                }
                else if (firstCollision == BOTTOM)
                {
                    this.CurrentLocationY--;
                    this.CurrentLocationX++;
                }
                else if (firstCollision == RIGHT)
                {
                    if (this.CurrentLocationX == RIGHTMOST_VERTICAL_AISLE)
                    {
                        this.CurrentLocationY--;
                    }
                    else
                    {
                        this.CurrentLocationY++;
                    }
                }
                else if (firstCollision == LEFT)
                {
                    this.CurrentLocationX++;
                    this.CurrentLocationY++;
                }
            }
        }

        /// <summary>
        /// This method checks if passed in value is even. If even, Clyde moves
        /// one way, if not, moves another way.
        /// </summary>
        /// <param name="round"> value to check if even </param>
        /// <returns> true if even, false if odd </returns>
        private bool CheckIfEven(int round)
        {
            if (round % DIVISOR == EVEN_RESULT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns Clyde to starting position
        /// </summary>
        public override void ReturnToStart()
        {
            this.CurrentLocationX = this.StartingLocationX;
            this.CurrentLocationY = this.StartingLocationY - JUMP_OUT_OF_BOX;
        }

        /// <summary>
        /// This method calls other methods based on collision for Clyde's run away movement.
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
                CollisionMoveToCorner(firstCollision, secondCollision);
                collided = false;
            }
        }

        /// <summary>
        /// This method contains Clyde's movements to his corner when no collision has occurred.
        /// </summary>
        private void NonCollisionMoveToCorner()
        {
            if (this.CurrentLocationX == RIGHT_AISLE)
            {
                this.CurrentLocationX = LEFT_AISLE;
            }
            else if (this.CurrentLocationX == LEFT_INTERSECTION_POINT_X && this.CurrentLocationY == BOTTOM_TOP_CORNER)
            {
                this.CurrentLocationY--;
            }
            else if (this.CurrentLocationY == BOTTOM_TOP_CORNER)
            {
                if (this.CurrentLocationX >= LEFT_OF_RIGHTMOST_VERTICAL_AISLE && this.CurrentLocationX <= MID_OF_RIGHTMOST_VERTICAL_AISLE)
                {
                    this.CurrentLocationY--;
                }
                else
                {
                    this.CurrentLocationX++;
                }
            }
            else if (this.CurrentLocationX == LEFT_INTERSECTION_POINT_X)
            {
                if (this.CurrentLocationY == TOP_MAIN_ROW)
                {
                    this.CurrentLocationX--;
                }
                else if (this.CurrentLocationY < TOP_MAIN_ROW)
                {
                    this.CurrentLocationY++;
                }
                else
                {
                    this.CurrentLocationY--;
                }
            }
            else if (this.CurrentLocationY == MID_UPMOST_BOUNDARY)
            {
                if (this.CurrentLocationX >= RIGHT_SIDE_OF_MAP)
                {
                    this.CurrentLocationY++;
                }
                else
                {
                    this.CurrentLocationX++;
                }
            }
            else if (this.CurrentLocationY == LEFT_INTERSECTION_POINT_Y)
            {
                if (this.CurrentLocationX > LEFT_INTERSECTION_POINT_X)
                {
                    this.CurrentLocationX--;
                }
                else
                {
                    this.CurrentLocationX++;
                }
            }
            else if ((this.CurrentLocationX >= LEFT_OF_RIGHTMOST_VERTICAL_AISLE && this.CurrentLocationX <= MID_OF_RIGHTMOST_VERTICAL_AISLE)
                && this.CurrentLocationY == BOTTOM_OF_TOP_MAIN_ROW)
            {
                this.CurrentLocationX--;
            }
            else if (this.CurrentLocationX >= LEFT_OF_RIGHTMOST_VERTICAL_AISLE && this.CurrentLocationX <= MID_OF_RIGHTMOST_VERTICAL_AISLE
                && this.CurrentLocationY > BELOW_UPMOST_BOUNDARY)
            {
                this.CurrentLocationY--;
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
        private void CollisionMoveToCorner(int firstCollision, int secondCollision)
        {
            if (firstCollision == TOP && secondCollision == RIGHT)
            {
                if (this.CurrentLocationX == LEFT_INTERSECTION_POINT_X && this.CurrentLocationY <= LEFT_OF_PAC_MAN_AISLE
                    && this.CurrentLocationY > TOP_MAIN_ROW)
                {
                    this.CurrentLocationY--;
                }
                else
                {
                    this.CurrentLocationX--;
                }
            }
            else if (firstCollision == TOP && secondCollision == LEFT)
            {
                if (this.CurrentLocationX == LEFTMOST_RIGHTMOST_VERTICAL_AISLE)
                {
                    this.CurrentLocationX++;
                    this.CurrentLocationY--;
                }
                else
                {
                    this.CurrentLocationY++;
                }
            }
            else if (firstCollision == TOP)
            {
                if (this.CurrentLocationY == UPMOST_BOUNDARY)
                {
                    if (this.CurrentLocationX == MID_UPMOST_BOUNDARY)
                    {
                        this.CurrentLocationX++;
                    }
                }
                else
                {
                    this.CurrentLocationX--;
                }
                this.CurrentLocationY++;
            }
            else if (firstCollision == BOTTOM && secondCollision == RIGHT)
            {
                if (this.CurrentLocationX == LEFT_INTERSECTION_POINT_X && this.CurrentLocationY <= TOP_MAIN_ROW)
                {
                    this.CurrentLocationY++;
                }
                else
                {
                    this.CurrentLocationY--;
                }
            }
            else if (firstCollision == BOTTOM && secondCollision == LEFT)
            {
                this.CurrentLocationY--;
            }
            else if (firstCollision == BOTTOM)
            {
                this.CurrentLocationY--;
                this.CurrentLocationX--;
            }
            else if (firstCollision == RIGHT)
            {
                if (this.CurrentLocationX == LEFT_INTERSECTION_POINT_X && this.CurrentLocationY <= TOP_MAIN_ROW)
                {
                    this.CurrentLocationY++;
                }
                else if (this.CurrentLocationY == LEFT_DECIDING_POINT)
                {
                    this.CurrentLocationX--;
                }
                else
                {
                    this.CurrentLocationY--;
                }
            }
            else if (firstCollision == LEFT)
            {
                if (this.CurrentLocationX == RIGHT_SIDE_OF_MAP || this.CurrentLocationX == BOTTOM_RIGHT_OF_CORNER
                    || this.CurrentLocationX == TOP_RIGHT_OUT_GHOST_BOX || this.CurrentLocationY >= BOTTOM_SECTION)
                {
                    if (this.CurrentLocationY > LEFT_INTERSECTION_POINT_Y)
                    {
                        if (this.CurrentLocationY >= BOTTOM_SECTION && this.CurrentLocationY < PAC_MAN_AISLE)
                        {
                            this.CurrentLocationY++;
                        }
                        else
                        {
                            this.CurrentLocationY--;
                        }
                    }
                    else
                    {
                        this.CurrentLocationY++;
                    }
                }
                else if (this.CurrentLocationY != MID_UPMOST_BOUNDARY)
                {
                    this.CurrentLocationY--;
                }
                else
                {
                    this.CurrentLocationY++;
                }
                this.CurrentLocationX++;
            }
        }
    }
}