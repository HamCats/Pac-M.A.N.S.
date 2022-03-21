using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
	/// <summary>
	/// Generic class for all things edible
	/// </summary>
	public abstract class Food
	{
		/// <summary>
		/// Initialize a new food item with an on-screen visual
		/// </summary>
		/// <param name="visual">The <see cref="PictureBox"/> representing the food</param>
		public Food (PictureBox visual)
        {
			this.Visual = visual;
        }

		public Food()
		{ }

		/// <summary>
		/// The <see cref="PictureBox"/> representing the food
		/// </summary>
		public PictureBox Visual { get; private set; }

		/// <summary>
		/// The point value for collecting the food
		/// </summary>
		public int Points { get; protected set; } = 0;

		/// <summary>
		/// Whether or not the item is visible.
		/// </summary>
		public bool Visible { get; protected set; } = true;

		/// <summary>
		/// The event for when the food is collected
		/// </summary>
		/// <remarks>
		/// Should be listened to by the collector
		/// </remarks>
		public EventHandler<CollisionEventArgs> CollideEvent;

		/// <summary>
		/// Internally implemented by the inheritor for when the item is collected
		/// </summary>
		/// <param name="sprite">The collecting sprite</param>
		protected abstract void CollisionDetected (PictureBox sprite);

		/// <summary>
		/// Check whether a collision has occurred with this item
		/// </summary>
		/// <param name="sprite">The sprite doing the colliding</param>
		public void CheckCollision (PictureBox sprite)
        {
			if (this.Visible && this.Visual.Bounds.IntersectsWith(sprite.Bounds))
            {
				CollisionDetected(sprite);
				this.Visible = false;
				this.Visual.Visible = false;
            }
        }

		/// <summary>
		/// Resets the food to be collected again
		/// </summary>
		public virtual void Reset ()
        {
			this.Visible = true;
			this.Visual.Visible = true;
        }
	}
}
