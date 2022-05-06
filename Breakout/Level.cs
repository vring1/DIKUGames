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

            //ArrayList mapData = new ArrayList();

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
    public string GetLegendData(string key) {
        if (LegendData.ContainsKey(key)) {
            return LegendData[key];
        } else {
            return "";
        }
    }


}
/*
public class Program {
    public static void Main(string[] args) {
        Level map = new Level(");
        Console.WriteLine(map.GetMetaData("Name"));
        Console.WriteLine(map.GetMetaData("Time"));
        Console.WriteLine(map.GetMetaData("Hardened"));
        Console.WriteLine(map.GetMetaData("PowerUp"));

    }
}
*/
