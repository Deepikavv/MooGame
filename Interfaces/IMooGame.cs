using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Interfaces
{
    public interface IMooGame
    {
        string CreateGoal();
        string GetUserGuess();
        string CheckBullsCows(string goal, string guess);
        int CountAttempts(string goal);
        string CreateBullsString(int goalLength);
        void UpdateResults();
        void SetMaxGoalLength();
        void GetPlayerName(string userName);
        int GetGoalLength();
    }
}
