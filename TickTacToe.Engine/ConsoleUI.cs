using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TickTacToe.Engine
{
    public class ConsoleUI
    {
        private readonly IDictionary<string, IPlayer> players = new Dictionary<string, IPlayer>();
        private readonly IGame game;
        private readonly TextReader input;
        private readonly TextWriter output;

        public ConsoleUI(IGame game, TextReader input, TextWriter output)
        {
            this.game = game;
            this.input = input;
            this.output = output;
        }

        public virtual IPlayer Player(string name)
        {
            return players[name];
        }

        public virtual void SetPlayer(string name, IPlayer player)
        {
            players[name] = player;
        }

        public virtual void Run()
        {
            SetPlayer(PlayerType.PlayerX, new PlayerOne(game));
            SetPlayer(PlayerType.PlayerO, new PlayerTwo(game));
            Play();
            PrintResult();
        }

        public virtual void Play()
        {
            do
            {
                var move = GetNextMove();
                game.MakeMove(move);
            }
            while (!game.IsOver());
        }

        public virtual void PrintResult()
        {
            if (game.IsDraw())
                output.WriteLine("Draw!");
            else
                output.WriteLine("Player {0} Wins!", game.Winner);
        }

        public virtual string GetNextMove()
        {
            output.WriteLine(GetCurrentBoard());
            return GetMoveForPlayer();
        }

        public string GetCurrentBoard()
        {
            var board = @"
| 1 | 2 | 3 |
| 4 | 5 | 6 |
| 7 | 8 | 9 |".Trim();
            board = game.MovesFor(PlayerType.PlayerX).Aggregate(board, (current, move) => current.Replace(move, PlayerType.PlayerX));
            board = game.MovesFor(PlayerType.PlayerO).Aggregate(board, (current, move) => current.Replace(move, PlayerType.PlayerO));
            return board;
        }

        public string GetMoveForPlayer()
        {
            string result;
            do
            {
                output.Write(MovePrompt(game.CurrentPlayer));
                result = input.ReadLine();
                output.WriteLine();
            } while (!game.IsAllowedMove(result));
            return result;
        }

        public string MovePrompt(string currentPlayer)
        {
            return string.Format("Select your move ({0}) for player ({1}): ", string.Join(", ", game.AvailableMoves), currentPlayer);
        }
    }
}
