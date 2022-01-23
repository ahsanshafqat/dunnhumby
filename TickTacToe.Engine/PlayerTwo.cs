using System;

namespace TickTacToe.Engine
{
    public class PlayerTwo : IPlayer
    {
        private readonly IGame game;

        public PlayerTwo(IGame game)
        {
            this.game = game;
        }

        public string GetOutPutSymbol
        {
            get { return PlayerType.PlayerO; }
        }

      
    }
}
