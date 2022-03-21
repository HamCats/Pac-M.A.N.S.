using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{

    /// <summary>
    /// An edible fruit
    /// <author> Nick Hein, Andi Fuerst, Melynda Vang</author>
    /// </summary>
	public class Fruit : Food
	{
        /// <summary>
        /// The point value for fruit
        /// </summary>
        private const int CHERRY_POINTS = 100;
        private const int STRAW_POINTS = 300;
        private const int ORANGE_POINTS = 500;
        private const int APPLE_POINTS = 700;
        private const int MIN = 0;
        private const int MAX = 16;
        private const int CHERRY_BOUNDS = 7;
        private const int STRAWBERRY_BOUNDS = 12;
        private const int ORANGE_BOUNDS = 15;
        private Fruit_Type fruit_type;
        /// <summary>
        /// Creates a new fruit. Selects type of fruit. and sets to be not visible
        /// </summary>
        /// <param name="visual">The on-screen <see cref="PictureBox"/></param>
        public Fruit (PictureBox visual) : base(visual)
        {
            fruit_type = selectFruitType();
            if (fruit_type == Fruit_Type.CHERRY)
                this.Points = CHERRY_POINTS;
            else if (fruit_type == Fruit_Type.STRAWBERRY)
                this.Points = STRAW_POINTS;
            else if (fruit_type == Fruit_Type.ORANGE)
                this.Points = ORANGE_POINTS;
            else
                this.Points = APPLE_POINTS;
            this.Visible = false;
            this.Visual.Visible = false;
        }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public Fruit() { }

        /// <summary>
        /// Invokes the collide event with special parameters
        /// </summary>
        /// <param name="sprite">The sprite collided with</param>
        protected override void CollisionDetected (PictureBox sprite)
        {
            CollisionEventArgs args = new CollisionEventArgs(CollisionType.PowerUp, (uint)this.Points);
            this.CollideEvent?.Invoke(this, args);
        }
        /// <summary>
        /// selects the type of fruit
        /// </summary>
        /// <returns>Returns the type of fruit</returns>
        private Fruit_Type selectFruitType()
        {
            Random r = new Random();
            int choice = r.Next(MIN, MAX);
            if (choice < CHERRY_BOUNDS)
                return Fruit_Type.CHERRY;
            else if (choice < STRAWBERRY_BOUNDS)
                return Fruit_Type.STRAWBERRY;
            else if (choice < ORANGE_BOUNDS)
                return Fruit_Type.ORANGE;
            else
                return Fruit_Type.APPLE;
        }

        /// <summary>
        /// Retrieval of fruit type
        /// </summary>
        /// <returns>Returns type of fruit</returns>
        public Fruit_Type getFruitType()
        {
            return this.fruit_type;
        }

        
    }
}
