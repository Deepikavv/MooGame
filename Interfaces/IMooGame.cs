using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Interfaces
{
    public interface IMooGame
    {
        int GoalLength { get; set; }
        int MaxRange { get; set; }
        string CreateGoal(int goalLength, int maxRange);
        string GetUserGuess();
        string CheckBullsCows(string goal, string guess);
        int CountAttempts(string goal);
        string CreateBullsString(int goalLength);
        void UpdateResults();
        void SetMaxGoalLength();
        void GetPlayerName(string userName);
        int GetGoalLength();
        void SetMaxRange();
    }
}
