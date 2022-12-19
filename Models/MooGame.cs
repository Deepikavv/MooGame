using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Models
{
    public class MooGame
    {
        public string? GameType { get; set; }
        public string? Goal { get; set; }
        public int MaxGoalLength { get; set; }
        public string? Guess { get; set; }
        public string? TargetBulls { get; set; }
        public int NoOfGuesses { get; set; }
        public string? PlayerName { get; set; }

        public PlayerData playerData = new PlayerData();
    }
}
