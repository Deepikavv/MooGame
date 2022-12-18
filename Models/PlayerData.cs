using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Models
{
    public class PlayerData : IPlayerData
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;

        public PlayerData()
        {

        }
        public PlayerData(string name, int guesses)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }

        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public void SaveGameData(string playerName, int attempts)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            StreamWriter output = new StreamWriter((filePath + "GameResult.txt"), append: true);
            output.WriteLine(playerName + "#&#" + attempts);
            output.Close();
        }

        public void ShowTopList()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            StreamReader input = new StreamReader((filePath + "GameResult.txt"));
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int position = results.IndexOf(pd);
                if (position < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[position].Update(guesses);
                }
            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }
}
