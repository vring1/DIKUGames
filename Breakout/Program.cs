using System;
using DIKUArcade.GUI;

namespace Breakout {
    class Program {
        static void Main(string[] args) {
            System.Console.WriteLine("0");
            var windowArgs = new WindowArgs() { Title = "Breakout" };  
            var game = new Game(windowArgs);
            game.Run();
           
        }
    }
}