namespace TickTacToe.Engine
{
    public interface IGame
    {
        string[] AvailableMoves { get; }
        string CurrentPlayer { get; }
        string Winner { get; }

        bool IsAllowedMove(string move);
        bool IsDraw();
        bool IsOver();
        void MakeMove(string move);
        string[] MovesFor(string player);
    }
}