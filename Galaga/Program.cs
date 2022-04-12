using System;
using DIKUArcade.GUI;

namespace Galaga {
    class Program {
        static void Main(string[] args) {
            System.Console.WriteLine("0");
            var windowArgs = new WindowArgs() { Title = "Galaga v0.1" };  
            System.Console.WriteLine("1");       
            var game = new Game(windowArgs);
            System.Console.WriteLine("2");
            game.Run();
            System.Console.WriteLine("3");
        }
    }
}