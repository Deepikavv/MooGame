using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.GameFactory
{
    // Declaring Delegate responsible for resolving MooGame service conflicts
    public delegate IMooGame GameServiceResolver(string userInput);
    public class MooGameFactory : IMooGameFactory
    {
        // Create dependency on GameServiceResolver delegate
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
