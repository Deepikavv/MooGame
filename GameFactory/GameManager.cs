using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.GameFactory
{
    public class GameManager
    {
        // Create dependency on IMooGameFactory
        private readonly IMooGameFactory _mooGameFactory;
        public GameManager(IMooGameFactory mooGameFactory)
        {
            _mooGameFactory = mooGameFactory;
        }

        public IMooGame CreateMooGame(string userSelection)
        {
            return _mooGameFactory.CreateGame(userSelection);
        }
    }
}
