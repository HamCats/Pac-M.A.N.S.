using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Xml;
using System.IO;
using Pac_M.A.N.S;

namespace Pac_M.A.N.S
{
	/*
	 * Class to keep track of the scores and names of all of the players. 
	 */
	public class Scores
	{
		const int SCORE_LIST_COUNT = 20;
		int[] playerScores = new int[SCORE_LIST_COUNT];
		String[] playerNames = new String[SCORE_LIST_COUNT];
		int final;
		int defFinal = 404;
		String defName = "No Player Found";
		int place = 0;
		string play;

		const string XML_FILE = "Scores.xml";
		
		/*
		 * Default constructor 
		 */
		public Scores () 
		{
		}

		public void LoadScores()
        {
			if (!File.Exists(XML_FILE))
				return;

			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(XML_FILE);
			} 
			catch (Exception)
            {
				File.Delete(XML_FILE);
				return;
            }
			XmlNode scoresNode = doc.DocumentElement;
			XmlNodeList scoresNodeList = scoresNode.SelectNodes("score");

			place = scoresNodeList.Count;
			if (place > SCORE_LIST_COUNT)
				place = SCORE_LIST_COUNT;

			for (int i = 0; i < place; i++)
            {
				XmlNode score = scoresNodeList.Item(i);
				XmlAttribute nameAttr = score.Attributes["name"];
				playerNames[i] = nameAttr.Value;
				XmlAttribute valueAttr = score.Attributes["value"];
				playerScores[i] = int.Parse(valueAttr.Value);
            }

			sortHighest();
        }

		public void SaveScores()
        {
			if (File.Exists(XML_FILE))
				File.Delete(XML_FILE);
			File.Create(XML_FILE).Close();

			XmlDocument doc = new XmlDocument();
			XmlNode scoresNode = doc.CreateElement("scores");

			for (int i = 0; i < place; i++)
            {
				XmlNode scoreNode = doc.CreateElement("score");
				XmlAttribute nameNode = doc.CreateAttribute("name");
				nameNode.Value = playerNames[i];
				scoreNode.Attributes.Append(nameNode);
				XmlAttribute valueNode = doc.CreateAttribute("value");
				valueNode.Value = playerScores[i].ToString();
				scoreNode.Attributes.Append(valueNode);
				scoresNode.AppendChild(scoreNode);
            }

			doc.AppendChild(scoresNode);
			doc.Save(XML_FILE);
        }

		/*
		 * Method to add in the information for each player. 
		 */
		public void addInfo(String name, int score)
        {
			if (place > SCORE_LIST_COUNT - 1)
				place = SCORE_LIST_COUNT - 1;

			playerScores[place] = score;
			playerNames[place] = name;

			place++;

			sortHighest();
			SaveScores();
        }

		/*
		 * Method to sort the player scores/names from highest to lowest. 
		 */
		public void sortHighest()
        {
			// Bubble sort (for convenience)
			// (1, 2, 3, 4, 5)
			// place = 5

			for (int i = 0; i < place - 1; i++)
            {
				for (int j = 0; j < place - 1 - i; j++)
                {
					if (playerScores[j] < playerScores[j + 1])
                    {
						int tempScore = playerScores[j];
						playerScores[j] = playerScores[j + 1];
						playerScores[j + 1] = tempScore;
						string tempName = playerNames[j];
						playerNames[j] = playerNames[j + 1];
						playerNames[j + 1] = tempName;
                    }
                }
            }
        }

		/*
		 * Method to return the score of the player based off of which place 
		 * has been called. 
		 */
		public int scoreToSend (int placement)
		{
			final = playerScores[placement];
			String temp = playerNames[placement];

			if (temp == null)
				return defFinal;
			else
				return final;
        }

		/*
		 * Method to return the name of the player based off of which
		 * place has been called. 
		 */
		public string nameToSend (int placement)
        {
			play = playerNames[placement];
			if (play == null)
				return defName;
			else
				return play;
        }
	}
} 