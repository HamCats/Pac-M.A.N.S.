using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
	/// <summary>
	/// This class is abstract, so that all ghosts can extend it.
	/// This class contains the properties and methods that all ghosts will use.
	/// </summary>
	public abstract class GhostBoys
	{
		private const int TOP_INT_REP = 0;
		private const int RIGHT_INT_REP = 1;
		private const int LEFT_INT_REP = 2;
		private const int BOTTOM_INT_REP = 3;
		private const int NONE_INT_REP = 4;
		protected bool collisionUp = false;
		protected bool collisionDown = false;
		protected bool collisionRight = false;
		protected bool collisionLeft = false;
		protected int firstCollision;
		protected int secondCollision;
		protected const int BOUNDS_ADJUSTMENT = 1;
		protected bool atStartingLocation = true;
		protected bool collided = false;
		public int StartingLocationX { get; set; }
		public int StartingLocationY { get; set; }
		public int CurrentLocationX { get; set; }
		public int CurrentLocationY { get; set; }
		public PictureBox Visual { get; protected set; }
		public bool IsEdible { get; set; }

		public GhostBoys() { }

		public abstract void MoveMe(int firstCollision, int secondCollision);
		public abstract void ReturnToStart();
		public abstract void RunAway(int firstCollision, int secondCollision);
		public abstract void ConvertToFood();
		public abstract void ConvertToGhost();
		public abstract void RunGhost(List<PictureBox> walls);

		/// <summary>
		/// This method is used to help set the collision locations.
		/// </summary>
		protected void RunCollision()
		{
			if (collisionUp == true && collisionRight == true)
			{
				firstCollision = TOP_INT_REP;
				secondCollision = RIGHT_INT_REP;
			}
			else if (collisionUp == true && collisionLeft == true)
			{
				firstCollision = TOP_INT_REP;
				secondCollision = LEFT_INT_REP;
			}
			else if (collisionDown == true && collisionRight == true)
			{
				firstCollision = BOTTOM_INT_REP;
				secondCollision = RIGHT_INT_REP;
			}
			else if (collisionDown == true && collisionLeft == true)
			{
				firstCollision = BOTTOM_INT_REP;
				secondCollision = LEFT_INT_REP;
			}
			else if (collisionUp == true)
			{
				firstCollision = TOP_INT_REP;
				secondCollision = NONE_INT_REP;
			}
			else if (collisionRight == true)
			{
				firstCollision = RIGHT_INT_REP;
				secondCollision = NONE_INT_REP;
			}
			else if (collisionLeft == true)
			{
				firstCollision = LEFT_INT_REP;
				secondCollision = NONE_INT_REP;
			}
			else if (collisionDown == true)
			{
				firstCollision = BOTTOM_INT_REP;
				secondCollision = NONE_INT_REP;
			}
			else
			{
				firstCollision = NONE_INT_REP;
				secondCollision = NONE_INT_REP;
			}
		}
	}
}