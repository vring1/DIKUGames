using System;
using DIKUArcade.GUI;

namespace Breakout {
    class Program {
        static void Main(string[] args) {
            var windowArgs = new WindowArgs() { Title = "Breakout" };
            var game = new Game(windowArgs);
            game.Run();
            LevelLoader map = new LevelLoader();
            map.FileToString(Path.Combine("Assets", "Levels", "level1.txt"));
            //Console.WriteLine(map.getmetaString());
            //Console.WriteLine(map.getmapString());
            Console.WriteLine(map.getlegendString());
            //Console.WriteLine(map.GetMetaData("PowerUp"));
        }
    }
}