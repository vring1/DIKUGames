/*using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using System;


namespace Breakout;
public class LevelLoaderOld {
    public static List<Block> blocks = new List<Block>();
    public static int blockCount;
    public static void LoadLevel(string filePath) {
        blockCount = 0;
        string fileExt = System.IO.Path.GetExtension(filePath);
        if (File.Exists(filePath) && fileExt == ".txt") {
            Level level = new Level(filePath);
            var lines = level.GetLines();
            Array.Reverse(lines);
            for (int i = lines.Length - 1; i >= 0; i--) {
                var line = lines[i];
                for (int j = line.Length - 1; j >= 0; j--) {
                    if (line[j] != "") {
                        // TODO: Actually load level
                        //Console.WriteLine("ROW: " + i + ", COL: " + j + ", IMAGE-OBJECT: " + line[j]);
                        var blockPicture = new Image(Path.Combine("Assets", "Images", line[j]));
                        var vec1 = new Vec2F((float) j / 12, (float) i / 25);
                        var extent = new Vec2F(0.05f, 0.025f);
                        var shape = new StationaryShape(vec1, extent);
                        var block = new Block(shape, blockPicture);
                        //blocks.Add(block);
                        blocks.Add(block);
                        blockCount++;
                        //System.Console.WriteLine(blockCount);
                        //System.Console.WriteLine(vec1);
                    }
                }
            }

        } else {
            System.Console.WriteLine("Wrong filepath");
        }
    }
}*/