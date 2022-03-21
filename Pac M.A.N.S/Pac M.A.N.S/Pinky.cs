using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
    class Pinky : GhostBoys
    {
        private const int STARTING_LOCATION_COORDINATE_X = 185, STARTING_LOCATION_COORDINATE_Y = 182;
        private const int JUMP_OUT_OF_BOX = 35;

        private const int MY_WIDTH = 20;
        private const int MY_HEIGHT = 20;

        private const int MY_SPEED = 1;

        private const int TILE_SIZE = 20;
        private const int TILES_IN_FRONT = 4;
        private const int PIXELS_IN_FRONT = TILE_SIZE * TILES_IN_FRONT;

        private Player pacman;

        private int targetX;
        private int targetY;

        private bool canChangeDir = true;
        private Direction currentDir = Direction.Up;

        public Pinky (PictureBox visual, Player player)
        {
            this.Visual = visual;
            this.StartingLocationX = STARTING_LOCATION_COORDINATE_X;
            this.StartingLocationY = STARTING_LOCATION_COORDINATE_Y;
            this.CurrentLocationX = this.StartingLocationX;
            this.CurrentLocationY = this.StartingLocationY;
            this.IsEdible = false;
            this.pacman = player;
        }

        public override void ConvertToFood ()
        {
            this.Visual.Image = Properties.Resources.EdibleGhostSprite20x20;
        }

        public override void ConvertToGhost ()
        {
            this.IsEdible = false;
            this.Visual.Image = Properties.Resources.pink_guy;
        }

        public override void MoveMe (int firstCollision, int secondCollision)
        {
            int pacX = pacman.CurrentX;
            int pacY = pacman.CurrentY;
            Direction pacDir = pacman.CurrentDirection;

            switch (pacDir)
            {
                case Direction.Up:
                    targetX = pacX - PIXELS_IN_FRONT; // Fun fact: this is a bug included in the original game.  It should be "targetX = pacX"
                    targetY = pacY - PIXELS_IN_FRONT;
                    break;
                case Direction.Down:
                    targetX = pacX;
                    targetY = pacY + PIXELS_IN_FRONT;
                    break;
                case Direction.Right:
                    targetX = pacX + PIXELS_IN_FRONT;
                    targetY = pacY;
                    break;
                case Direction.Left:
                    targetX = pacX - PIXELS_IN_FRONT;
                    targetY = pacY;
                    break;
            }
        }

        public override void ReturnToStart ()
        {
            this.CurrentLocationX = this.StartingLocationX;
            this.CurrentLocationY = this.StartingLocationY - JUMP_OUT_OF_BOX;
        }

        public override void RunAway (int firstCollision, int secondCollision)
        {
            int pacX = pacman.CurrentX;
            int pacY = pacman.CurrentY;

            int myX = this.CurrentLocationX;
            int myY = this.CurrentLocationY;

            targetX = 2 * myX - pacX;
            targetY = 2 * myY - pacY;
        }

        public override void RunGhost (List<PictureBox> walls)
        {
            if (atStartingLocation)
            {
                ReturnToStart();
                atStartingLocation = false;
                return;
            }

            if (this.IsEdible)
                this.RunAway(0, 0);
            else
                this.MoveMe(0, 0);

            this.seekTarget(walls);
        }

        private void seekTarget(List<PictureBox> walls)
        {
            int myX = this.CurrentLocationX;
            int myY = this.CurrentLocationY;

            // Find how far I need to move in any direction to hit target
            int dx = targetX - myX;
            int dy = targetY - myY;
            // Find out which direction is more important to move in
            int adx = Math.Abs(dx);
            int ady = Math.Abs(dy);

            // Calculate how far I can theoretically move, and I'll take into account if I'm already committed to a direction
            int wantMoveX = dx >= 0 ? MY_SPEED : (-1 * MY_SPEED);
            int wantMoveY = dy >= 0 ? MY_SPEED : (-1 * MY_SPEED);
            int moveX, moveY;
            if (currentDir == Direction.Up || currentDir == Direction.Down) 
            {
                moveY = currentDir == Direction.Down ? MY_SPEED : (-1 * MY_SPEED);
                moveX = 0;
            }
            else
            {
                moveX = currentDir == Direction.Right ? MY_SPEED : (-1 * MY_SPEED);
                moveY = 0;
            }

            // Check if I can safely move in either direction without hitting a wall
            bool safeX = !IsCollision(walls, myX, myY, moveX, 0);
            bool safeY = !IsCollision(walls, myX, myY, 0, moveY);

            // I want to commit to a direction once I choose one, I only want to change direction if I hit a wall
            //canChangeDir = (!safeY && (currentDir == Direction.Up || currentDir == Direction.Down))
            //            || (!safeX && (currentDir == Direction.Right || currentDir == Direction.Left));
            canChangeDir = (!safeY && (currentDir == Direction.Up || currentDir == Direction.Down))
                        || (!safeX && (currentDir == Direction.Right || currentDir == Direction.Left));

            if (canChangeDir) // If I'm not committed to a direction...
            {
                safeX = !IsCollision(walls, myX, myY, wantMoveX, 0);
                safeY = !IsCollision(walls, myX, myY, 0, wantMoveY);

                bool outOfXFavorites = false;
                bool outOfYFavorites = false;
                if (adx >= ady) // Want to move along X more than Y
                {
                    if (safeX) // If it's safe to move in the direction I want, do it
                        this.currentDir = wantMoveX >= 0 ? Direction.Right : Direction.Left;
                    else if (safeY) // If it's safe to move in my second favorite direction, do it
                        this.currentDir = wantMoveY >= 0 ? Direction.Down : Direction.Up;
                    else // Not safe to move either favorite direction, try flipping both in order
                    {
                        // Trying the opposite of my 2nd favorite direction is my 3rd favorite direction
                        wantMoveY = -1 * wantMoveY;
                        safeY = !IsCollision(walls, myX, myY, 0, wantMoveY);

                        if (safeY) // If I'm safe to move in my 3rd favorite direction, do it
                            this.currentDir = wantMoveY >= 0 ? Direction.Down : Direction.Up;
                        else
                        {
                            wantMoveX = -1 * wantMoveX;
                            safeX = !IsCollision(walls, myX, myY, wantMoveX, 0);

                            if (safeX)
                                this.currentDir = wantMoveX >= 0 ? Direction.Right : Direction.Left;
                            else
                                outOfXFavorites = true;
                        }
                    }
                }
                if (ady > adx || outOfXFavorites) // Want to move along Y more than X OR I've tried all of the X favorites
                {
                    // Similar comments as above for X favorites
                    if (safeY)
                        this.currentDir = wantMoveY >= 0 ? Direction.Down : Direction.Up;
                    else if (safeX)
                        this.currentDir = wantMoveX >= 0 ? Direction.Right : Direction.Left;
                    else
                    {
                        wantMoveX = -1 * wantMoveX;
                        safeX = !IsCollision(walls, myX, myY, wantMoveX, 0);

                        if (safeX)
                            this.currentDir = wantMoveX >= 0 ? Direction.Right : Direction.Left;
                        else
                        {
                            wantMoveY = -1 * wantMoveY;
                            safeY = !IsCollision(walls, myX, myY, 0, wantMoveY);

                            if (safeY)
                                this.currentDir = wantMoveY >= 0 ? Direction.Down : Direction.Up;
                            else
                                outOfYFavorites = true;
                        }
                    }
                }
                if (outOfXFavorites && outOfYFavorites) // If I can't move in any direction, I'm mad.  I'll break the game
                {
                    Debug.WriteLine("Pinky says: AAAAAAAAAAAHHHHHHHHHHHHHHHHH!!!!!!!");
                    //throw new Exception("Pinky is trapped!");
                    return;
                }

                // I found a direction.  Now, I'm gonna commit to it until I hit a wall.
                this.canChangeDir = false;
            }

            // Now, let's actually move the direction we want.
            switch (currentDir)
            {
                case Direction.Up:
                    this.CurrentLocationY -= MY_SPEED;
                    break;
                case Direction.Down:
                    this.CurrentLocationY += MY_SPEED;
                    break;
                case Direction.Left:
                    this.CurrentLocationX -= MY_SPEED;
                    break;
                case Direction.Right:
                    this.CurrentLocationX += MY_SPEED;
                    break;
            }
            Visual.Location = new Point(this.CurrentLocationX, this.CurrentLocationY);
        }

        private bool IsCollision(List<PictureBox> walls, int x, int y, int dx, int dy)
        {
            int rectWidth = MY_WIDTH + Math.Abs(dx);
            int rectHeight = MY_HEIGHT + Math.Abs(dy);

            int rectX = dx >= 0 ? x : x + dx;
            int rectY = dy >= 0 ? y : y + dy;

            Rectangle me = new Rectangle(rectX, rectY, rectWidth, rectHeight);
            foreach (PictureBox wall in walls)
            {
                if (me.IntersectsWith(wall.Bounds))
                    return true;
            }
            return false;
        }
    }
}
