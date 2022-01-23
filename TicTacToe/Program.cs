using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTacToe.Engine;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUI(new Game(), Console.In, Console.Out);
            ui.Run();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}