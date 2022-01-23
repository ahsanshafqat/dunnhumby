using System.IO;
using System.Linq;

namespace TickTacToe.Engine
{
    public class PlayerOne : IPlayer
    {
        private readonly IGame game;
        
        public PlayerOne(IGame game)
        {
            this.game = game;
        }

        public string GetOutPutSymbol
        {
            get { return "X"; }
        }
    }
}
