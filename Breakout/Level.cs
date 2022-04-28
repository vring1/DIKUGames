using DIKUArcade;
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
using System.Collections;

namespace Breakout;

public class Level {
    private ArrayList MapData = new ArrayList();
    private Dictionary<string, string> MetaData = new Dictionary<string, string>();
    private Dictionary<string, string> LegendData = new Dictionary<string, string>();

    public Level(string filePath) {
        Initialize(filePath);
    }

    private void ReadMapLine(string line) {
        MapData.Add(line);
    }

    private void ReadMetaLine(string line) {
        // hej:med:dig
        string[] arr = line.Split(':');
        string key = arr[0];
        string value = arr[1].Substring(1);
        MetaData[key] = value;
    }

    private void ReadLegendLine(string line) {
        string[] arr = line.Split(')');
        string key = arr[0];
        string value = arr[1].Substring(1);
        LegendData[key] = value;
    }

    private void Initialize(string filePath) {
        LegendData["-"] = "";
        bool isReadingMapData = false;
        bool isReadingMetaData = false;
        bool isReadingLegendData = false;

        string[] lines = System.IO.File.ReadAllLines(filePath);

        foreach (string line in lines) {
            if (line.Length == 0)
                continue;

            switch (line) {
                case "Map:":
                    isReadingMapData = true;
                    continue;
                case "Map/":
                    isReadingMapData = false;
                    continue;
                case "Meta:":
                    isReadingMetaData = true;
                    continue;
                case "Meta/":
                    isReadingMetaData = false;
                    continue;
                case "Legend:":
                    isReadingLegendData = true;
                    continue;
                case "Legend/":
                    isReadingLegendData = false;
                    continue;
            }

            ArrayList mapData = new ArrayList();

            if (isReadingMapData) {
                ReadMapLine(line);
            } else if (isReadingMetaData) {
                ReadMetaLine(line);
            } else if (isReadingLegendData) {
                ReadLegendLine(line);
            }
        }
    }

    public string[][] GetLines() {
        string[][] lines = new string[MapData.Count][];
        int l = 0;
        foreach (string strLine in MapData) {
            lines[l] = new string[12];
            for (int c = 0; c < strLine.Length; c++) {
                string strChar = strLine[c].ToString();
                lines[l][c] = LegendData[strChar];
            }
            lines[l] = lines[l];
            l++;
        }
        return lines;
    }

    public string GetMetaData(string key) {
        if (MetaData.ContainsKey(key)) {
            return MetaData[key];
        } else {
            return "";
        }
    }




}
/*
public class Program {
    public static void Main(string[] args) {
        Level map = new Level("C:\\Users\\Benjamin\\Desktop\\GoCrazy\\CollatzSolution\\level3.txt");
        Console.WriteLine(map.GetMetaData("Name"));
        Console.WriteLine(map.GetMetaData("Time"));
        Console.WriteLine(map.GetMetaData("Hardened"));
        Console.WriteLine(map.GetMetaData("PowerUp"));

    }
}
*/
/*

PS C:\Users\Benjamin\Desktop\GoCrazy\CollatzSolution\collatz> dotnet run      
 LEVEL 3
 180

 #
ROW: 0, COL: 0PNGFILE: yellow-block.png
ROW: 0, COL: 1PNGFILE: yellow-block.png
ROW: 0, COL: 2PNGFILE: yellow-block.png
ROW: 0, COL: 3PNGFILE: yellow-block.png
ROW: 0, COL: 4PNGFILE: yellow-block.png
ROW: 0, COL: 5PNGFILE: yellow-block.png
ROW: 0, COL: 6PNGFILE: yellow-block.png
ROW: 0, COL: 7PNGFILE: yellow-block.png
ROW: 0, COL: 8PNGFILE: yellow-block.png
ROW: 0, COL: 9PNGFILE: yellow-block.png
ROW: 0, COL: 10PNGFILE: yellow-block.png
ROW: 0, COL: 11PNGFILE: yellow-block.png
ROW: 2, COL: 1PNGFILE: green-block.png
ROW: 2, COL: 10PNGFILE: green-block.png
ROW: 3, COL: 2PNGFILE: green-block.png
ROW: 3, COL: 9PNGFILE: green-block.png
ROW: 4, COL: 3PNGFILE: green-block.png
ROW: 4, COL: 8PNGFILE: green-block.png
ROW: 5, COL: 4PNGFILE: green-block.png
ROW: 5, COL: 7PNGFILE: green-block.png
ROW: 8, COL: 3PNGFILE: brown-block.png
ROW: 8, COL: 8PNGFILE: brown-block.png
ROW: 9, COL: 0PNGFILE: orange-block.png
ROW: 9, COL: 1PNGFILE: orange-block.png
ROW: 9, COL: 2PNGFILE: orange-block.png
ROW: 9, COL: 3PNGFILE: brown-block.png
ROW: 9, COL: 8PNGFILE: brown-block.png
ROW: 9, COL: 9PNGFILE: orange-block.png
ROW: 9, COL: 10PNGFILE: orange-block.png
ROW: 9, COL: 11PNGFILE: orange-block.png
ROW: 10, COL: 0PNGFILE: orange-block.png
ROW: 10, COL: 1PNGFILE: orange-block.png
ROW: 10, COL: 2PNGFILE: orange-block.png
ROW: 10, COL: 3PNGFILE: brown-block.png
ROW: 10, COL: 8PNGFILE: brown-block.png
ROW: 10, COL: 9PNGFILE: orange-block.png
ROW: 10, COL: 10PNGFILE: orange-block.png
ROW: 10, COL: 11PNGFILE: orange-block.png
ROW: 11, COL: 0PNGFILE: orange-block.png
ROW: 11, COL: 1PNGFILE: orange-block.png
ROW: 11, COL: 2PNGFILE: orange-block.png
ROW: 11, COL: 3PNGFILE: brown-block.png
ROW: 11, COL: 8PNGFILE: brown-block.png
ROW: 11, COL: 9PNGFILE: orange-block.png
ROW: 11, COL: 10PNGFILE: orange-block.png
ROW: 11, COL: 11PNGFILE: orange-block.png
ROW: 12, COL: 0PNGFILE: orange-block.png
ROW: 12, COL: 1PNGFILE: orange-block.png
ROW: 12, COL: 2PNGFILE: orange-block.png
ROW: 12, COL: 3PNGFILE: brown-block.png
ROW: 12, COL: 5PNGFILE: green-block.png
ROW: 12, COL: 6PNGFILE: green-block.png
ROW: 12, COL: 8PNGFILE: brown-block.png
ROW: 12, COL: 9PNGFILE: orange-block.png
ROW: 12, COL: 10PNGFILE: orange-block.png
ROW: 12, COL: 11PNGFILE: orange-block.png
ROW: 13, COL: 0PNGFILE: orange-block.png
ROW: 13, COL: 1PNGFILE: orange-block.png
ROW: 13, COL: 2PNGFILE: orange-block.png
ROW: 13, COL: 3PNGFILE: brown-block.png
ROW: 13, COL: 8PNGFILE: brown-block.png
ROW: 13, COL: 9PNGFILE: orange-block.png
ROW: 13, COL: 10PNGFILE: orange-block.png
ROW: 13, COL: 11PNGFILE: orange-block.png
ROW: 14, COL: 0PNGFILE: brown-block.png
ROW: 14, COL: 1PNGFILE: brown-block.png
ROW: 14, COL: 2PNGFILE: brown-block.png
ROW: 14, COL: 3PNGFILE: brown-block.png
ROW: 14, COL: 4PNGFILE: darkgreen-block.png
ROW: 14, COL: 5PNGFILE: darkgreen-block.png
ROW: 14, COL: 6PNGFILE: darkgreen-block.png
ROW: 14, COL: 7PNGFILE: darkgreen-block.png
ROW: 14, COL: 8PNGFILE: brown-block.png
ROW: 14, COL: 9PNGFILE: brown-block.png
ROW: 14, COL: 10PNGFILE: brown-block.png
ROW: 14, COL: 11PNGFILE: brown-block.png

*/