using System;
using DIKUArcade.GUI;

namespace Breakout {
    class Program {
        static void Main(string[] args) {
            var windowArgs = new WindowArgs() { Title = "Breakout" };
            var game = new Game(windowArgs);
            game.Run();
            Level map = new Level(Path.Combine("Assets", "Levels", "level1.txt"));
            Console.WriteLine(map.GetMetaData("Name"));
            Console.WriteLine(map.GetMetaData("Time"));
            Console.WriteLine(map.GetMetaData("Hardened"));
            Console.WriteLine(map.GetMetaData("PowerUp"));
        }
    }
}