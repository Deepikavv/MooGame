using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Interfaces
{
    public interface IPlayerData
    {
        void Update(int guesses);
        double Average();
        void SaveGameData(string playerName, int attempts);
        void ShowTopList();
    }
}
