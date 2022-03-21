using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
	/// <summary>
	/// An edible power pellet
	/// </summary>
	public class PowerPellet : Food
	{
        /// <summary>
        /// The value of the food
        /// </summary>
        private const int POINTS = 10;

        /// <summary>
        /// Creates a new power pellet
        /// </summary>
        /// <param name="visual">The visual representative</param>
        public PowerPellet (PictureBox visual) : base(visual)
        {
            this.Points = POINTS;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PowerPellet () { }

        /// <summary>
        /// Retrieval of power pellet point amount 
        /// </summary>
        /// <returns>Returns amount for eating a power pellet</returns>
        public int getPoints ()
        {
            return POINTS;
        }

        /// <summary>
        /// Invokes the collide event with specific arguments
        /// </summary>
        /// <param name="sprite">The sprite collided with</param>
        protected override void CollisionDetected (PictureBox sprite)
        {
            CollisionEventArgs args = new CollisionEventArgs(CollisionType.PowerUp, (uint)this.Points);
            this.CollideEvent?.Invoke(this, args);
        }
    }
}
