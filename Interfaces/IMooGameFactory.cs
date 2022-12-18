using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Interfaces
{
    public interface IMooGameFactory
    {
        IMooGame CreateGame(string userInput);
    }
}
