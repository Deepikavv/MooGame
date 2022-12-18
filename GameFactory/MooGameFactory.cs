using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.GameFactory
{
    public delegate IMooGame GameServiceResolver(string userInput);
    public class MooGameFactory : IMooGameFactory
    {
        private readonly GameServiceResolver _gameServiceResolver;

        public MooGameFactory(GameServiceResolver gameServiceResolver)
        {
            _gameServiceResolver = gameServiceResolver;
        }
        public IMooGame CreateGame(string userInput)
        {
            return _gameServiceResolver(userInput);

        }
    }
}
