/*******************************************************************
 * GameScreen
 * Authors: Andi Fuerst, Melynda Vang, Nick Hein
 * This screen runs the game. It handles the ghosts movement and 
 * pacman movement. Handles dots and pellets and fruits. 
********************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Pac_M.A.N.S
{
	public partial class GameScreen : Form
	{
		private const int BOUNDS_ADJUSTMENT = 1;
		private const int BLUE_GHOST_SECONDS = 5;
		private Player player;
		private List<PictureBox> walls = new List<PictureBox>();
		private List<Food> foods = new List<Food>();
		private List<Food> invisibleFood = new List<Food>();
		private Clyde clyde;
		private Blinky blinky;
		private Inky inky;
		private Pinky pinky;
		Stopwatch edibleGhostStopwatch;
		private ScoreCalculation scoreCalc;
		private bool moveUp = false;
		private bool moveDown = false;
		private bool moveRight = false;
		private bool moveLeft = false;
		private int score = 0;
		private Random random = new Random();
		private bool fruitInsert = false;

		//private Stopwatch testWatch = new Stopwatch();

		/****************************************************************
		 * Initializes the components. adds elements to lists
		 * *************************************************************/
		public GameScreen()
		{
			InitializeComponent();
			this.Show();
			edibleGhostStopwatch = new Stopwatch();
			scoreCalc = new ScoreCalculation();
			KeyDown += new KeyEventHandler(GameScreen_KeyDown);
			player = new Player(pacMan);
			clyde = new Clyde(pbxClyde);
			blinky = new Blinky(pbxBlinky);
			inky = new Inky(pbxInky);
			pinky = new Pinky(pbxPinky, player);
			clyde.ConvertToGhost();
			blinky.ConvertToGhost();
			inky.ConvertToGhost();
			pinky.ConvertToGhost();
			foreach (Control ctrl in gamebox.Controls)
            {
				if (!(ctrl.Tag is string) || !(ctrl is PictureBox))
					continue;

				if ((string)ctrl.Tag == "dot")
				{
					Food dot = new Dot((PictureBox)ctrl);
					dot.CollideEvent += collision_Handle;
					foods.Add(dot);
				}
				else if ((string)ctrl.Tag == "wall")
				{
					walls.Add((PictureBox)ctrl);
				}
				else if ((string)ctrl.Tag == "pellet")
				{
					Food pellet = new PowerPellet((PictureBox)ctrl);
					pellet.CollideEvent += collision_Handle;
					foods.Add(pellet);
				}
			}

			// FOR TIMING TESTS
			 //testWatch.Start();
		}

		/****************************************************************
		 * when pacman loses a life, ghosts and pacman go to starting
		 * location
		 * *************************************************************/
		private void rebootLevel()
		{
			player.getPic().Location = player.returnToStart();
			if (clyde.IsEdible || blinky.IsEdible || inky.IsEdible|| pinky.IsEdible)
            {
				clyde.ConvertToGhost();
				blinky.ConvertToGhost();
				inky.ConvertToGhost();
				pinky.ConvertToGhost();
            }
			clyde.ReturnToStart();
			blinky.ReturnToStart();
			inky.ReturnToStart();
			pinky.ReturnToStart();
			if (player.getLives() == 2)
				Lives2.Visible = false;
			else
				Lives1.Visible = false;
		}

		/****************************************************************
		 * when pacman has eaten all the food on the screen, ghosts, and
		 * pacman go to starting position. dots and pellets all reappear
		 * *************************************************************/
		private void rebootGame()
		{
			//return all sprites to original location and place all dots and pellets
			player.getPic().Location = player.returnToStart();
			if (clyde.IsEdible || blinky.IsEdible || inky.IsEdible || pinky.IsEdible)
			{
				clyde.ConvertToGhost();
				blinky.ConvertToGhost();
				inky.ConvertToGhost();
				pinky.ConvertToGhost();
			}
			clyde.ReturnToStart();
			blinky.ReturnToStart();
			inky.ReturnToStart();
			pinky.ReturnToStart();
			foreach (Food food in foods)
			{
				if (food.GetType() == typeof(Dot))
				{
					food.Reset();
				}
				else if (food.GetType() == typeof(Fruit))
				{
					food.Reset();
				}
				else if (food.GetType() == typeof(PowerPellet))
				{
					food.Reset();
				}
			}
			invisibleFood.Clear();
		}

		/// <summary>
		/// when button pressed move in that direction, and select 
		/// correct image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameScreen_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				moveUp = true;
				player.getPic().Image = Properties.Resources.Up;
			}
			else if (e.KeyCode == Keys.Left)
			{
				moveLeft = true;
				player.getPic().Image = Properties.Resources.left;
			}
			else if (e.KeyCode == Keys.Right)
			{
				moveRight = true;
				player.getPic().Image = Properties.Resources.right;
			}
			else if (e.KeyCode == Keys.Down)
			{
				moveDown = true;
				player.getPic().Image = Properties.Resources.down;
			}	
		}

		private void collision_Handle(object sender, CollisionEventArgs e)
        {

        }

		/// <summary>
		/// Handles the running of ghosts and pacman, handles collisions,
		/// main timer to run game
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			// FOR TIMING TESTS
			//long testStart = testWatch.ElapsedMilliseconds;

			//TO DO:: CLEAN THIS UP
			clyde.RunGhost(walls);
			blinky.RunGhost(walls);
			inky.RunGhost(walls);
			pinky.RunGhost(walls);
			score = scoreCalc.getScore();

			scoreLb.Text = "Score: " + score;
			if (edibleGhostStopwatch.Elapsed.TotalSeconds >= BLUE_GHOST_SECONDS)
            {
				edibleGhostStopwatch.Reset();
				clyde.ConvertToGhost();
				blinky.ConvertToGhost();
				inky.ConvertToGhost();
				pinky.ConvertToGhost();
				scoreCalc.ghostCount = 0;
			}
			if ((player.getPic().Bounds.IntersectsWith(clyde.Visual.Bounds) && !clyde.IsEdible)
				|| (player.getPic().Bounds.IntersectsWith(blinky.Visual.Bounds) && !blinky.IsEdible)
				|| (player.getPic().Bounds.IntersectsWith(inky.Visual.Bounds) && !inky.IsEdible)
				|| (player.getPic().Bounds.IntersectsWith(pinky.Visual.Bounds) && !pinky.IsEdible))
			{
				player.byeByeLives();
				if (player.getLives() > 0)
					rebootLevel();
				else
				{
					GameOverScreen gOS = new GameOverScreen();
					timer1.Enabled = false;
					gOS.RetrieveScore(score);
					gOS.Show();
					
					this.Hide();
				}
			}
			else if (player.getPic().Bounds.IntersectsWith(clyde.Visual.Bounds) && clyde.IsEdible)
			{
				clyde.ConvertToGhost();
				clyde.ReturnToStart();
				scoreCalc.ghostCount++;
				scoreCalc.ghostScore();
			}
			else if (player.getPic().Bounds.IntersectsWith(blinky.Visual.Bounds) && blinky.IsEdible)
			{
				blinky.ConvertToGhost();
				blinky.ReturnToStart();
				scoreCalc.ghostCount++;
				scoreCalc.ghostScore();
			}
			else if (player.getPic().Bounds.IntersectsWith(inky.Visual.Bounds) && inky.IsEdible)
			{
				inky.ConvertToGhost();
				inky.ReturnToStart();
				scoreCalc.ghostCount++;
				scoreCalc.ghostScore();
			}
			else if (player.getPic().Bounds.IntersectsWith(pinky.Visual.Bounds) && pinky.IsEdible)
            {
				pinky.ConvertToGhost();
				pinky.ReturnToStart();
				scoreCalc.ghostCount++;
				scoreCalc.ghostScore();
            }
			if (fruitInsert && invisibleFood.Count > 0)
			{
				Fruit fruit = new Fruit(fruitPB);
				switch (fruit.getFruitType())
				{
					case Fruit_Type.APPLE:
						fruit.Visual.Image = Properties.Resources.pacManApple;
						break;
					case Fruit_Type.CHERRY:
						fruit.Visual.Image = Properties.Resources.Cherry1;
						break;
					case Fruit_Type.ORANGE:
						fruit.Visual.Image = Properties.Resources.pacManOrange;
						break;
					case Fruit_Type.STRAWBERRY:
						fruit.Visual.Image = Properties.Resources.pacManStrawberry;
						break;
				}
				fruit.Visual.Location = (invisibleFood.ElementAt(random.Next(0, invisibleFood.Count - 1)).Visual.Location);
				fruit.CollideEvent += collision_Handle;
				foods.Add(fruit);
				fruit.Reset();
				fruitInsert = false;
			}
			foreach (PictureBox a in walls)
			{
				if (player.getPic().Bounds.IntersectsWith(a.Bounds))
				{
					if (player.getPic().Top + BOUNDS_ADJUSTMENT == a.Bottom)
						moveUp = false;
					if (player.getPic().Right - BOUNDS_ADJUSTMENT == a.Left)
						moveRight = false;
					if (player.getPic().Left + BOUNDS_ADJUSTMENT == a.Right)
						moveLeft = false;
					if (player.getPic().Bottom - BOUNDS_ADJUSTMENT == a.Top)
						moveDown = false;
				}
			}
			player.getPic().Location = player.movePac(moveUp, moveDown, moveLeft, moveRight);

			foreach (Food food in foods)
			{
				if (food.Visible == true && player.getPic().Bounds.IntersectsWith(food.Visual.Bounds))
				{
					food.CheckCollision(player.getPic());
					if (food.GetType() == typeof(Dot))
					{
						scoreCalc.eatFood(food);
					}
					else if (food.GetType() == typeof(PowerPellet))
					{
						scoreCalc.eatFood(food);
						clyde.IsEdible = true;
						blinky.IsEdible = true;
						inky.IsEdible = true;
						pinky.IsEdible = true;
					}
					else if (food.GetType() == typeof(Fruit))
					{
						scoreCalc.eatFood(food);
						fruitTimer.Enabled = true;
					}
					invisibleFood.Add(food);
				}
			}
			if (clyde.IsEdible && blinky.IsEdible && inky.IsEdible && pinky.IsEdible && !edibleGhostStopwatch.IsRunning)
			{
				clyde.ConvertToFood();
				blinky.ConvertToFood();
				inky.ConvertToFood();
				pinky.ConvertToFood();

				edibleGhostStopwatch.Start();
			}
			if (invisibleFood.Count == foods.Count)
				rebootGame();

			// FOR TIMING TESTS
			//Debug.WriteLine("Tick: " + (testWatch.ElapsedMilliseconds - testStart));

		}

		/// <summary>
		/// When timer is up insert a fruit and disable self
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fruitTimer_Tick(object sender, EventArgs e)
		{
			fruitInsert = true;
			fruitTimer.Enabled = false;
		}

		/// <summary>
		/// When they stop pressing a key, stop going in that direction
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameScreen_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
				moveUp = false;
			else if (e.KeyCode == Keys.Left)
				moveLeft = false;
			else if (e.KeyCode == Keys.Right)
				moveRight = false;
			else if (e.KeyCode == Keys.Down)
				moveDown = false;
		}
	}
}