/*******************************************************************
 * ScoreCalculation
 * Authors: Andi Fuerst & Melynda Vang
 * handles the score information for a game. 
********************************************************************/

namespace Pac_M.A.N.S
{
	/// <summary>
	/// This class calculates the running score total throughout game time
	/// </summary>
	public class ScoreCalculation
	{
		private int totalScore = 0;
		private const int GHOST_POINT_FIRST = 200;
		private const int GHOST_POINT_SEC = 200;
		private const int GHOST_POINT_THIRD = 400;
		private const int GHOST_POINT_FOUR = 800;
		public int ghostCount = 0;

		/// <summary>
		/// Default constructor
		/// </summary>
		public ScoreCalculation() { }

		/// <summary>
		/// Adds the point value based on the food eaten
		/// </summary>
		/// <param name="food">use type of food eaten to retrieve point value</param>
		public void eatFood(Food food)
		{
			if (food.GetType() == typeof(Dot))
			{
				totalScore += food.Points;
			}
			else if (food.GetType() == typeof(Fruit))
			{

				totalScore += food.Points;
			}
			else if (food.GetType() == typeof(PowerPellet))
			{
				totalScore += food.Points;
			}
		}

		/// <summary>
		/// Based on number of ghosts eaten in succession, the total score will update accordingly
		/// </summary>
		public void ghostScore()
		{
			if (ghostCount == 1)
            {
				totalScore += GHOST_POINT_FIRST;

			}
			else if (ghostCount == 2)
            {
				totalScore += GHOST_POINT_SEC;
			}
			else if (ghostCount == 3)
            {
				totalScore += GHOST_POINT_THIRD;
			}
            else
            {
				totalScore += GHOST_POINT_FOUR;
			}
		}

		/// <summary>
		/// Returns the player's total score
		/// </summary>
		/// <returns>int representing total score</returns>
		public int getScore()
		{
			return totalScore;
		}
	}
}