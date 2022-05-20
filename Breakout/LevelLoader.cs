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


namespace Breakout;
public class LevelLoader {

    private string mapString;
    private string metaString;
    private string[] metaStringArray;
    private string[] legendStringArray;
    private string legend;
    public int time;
    Dictionary<string, string> metaDict = new Dictionary<string, string>();
    Dictionary<string, string> metaTimeDict = new Dictionary<string, string>();

    public static void GetLines(string path) {
        // Calling the ReadAllLines() function
        string[] readText = File.ReadAllLines(path);
        foreach (string s in readText) {
            // Printing the string array containing
            // all lines of the file.
        }
    }

    public static bool Invalidator(string path) {
        string readText = File.ReadAllText(path);
        if (readText.Contains("Map:") && readText.Contains("Map/")
        && readText.Contains("Meta:") && readText.Contains("Meta/")
        && readText.Contains("Legend:") && readText.Contains("Legend/")) {
            return true;
        }
        return false;
    }

    public void FileToString(string path) {
        string levelPath = Path.Combine(DIKUArcade.Utilities.FileIO.GetProjectPath(), path);

        mapString = File.ReadAllText(levelPath).Split("Map:",
        StringSplitOptions.RemoveEmptyEntries)[0];
        mapString = mapString.Split("Map/", StringSplitOptions.None)[0];

        metaString = File.ReadAllText(levelPath).Split("Meta:", StringSplitOptions.None)[1];
        metaString = metaString.Split("Meta/", StringSplitOptions.None)[0];
        metaStringArray = metaString.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        legend = File.ReadAllText(levelPath).Split("Legend:", StringSplitOptions.None)[1];
        legend = legend.Split("Legend/", StringSplitOptions.None)[0];
        legendStringArray = legend.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        MakeDictionary(metaDict);
    }

    public string getmapString() {
        return mapString;
    }

    public string getmetaString() {
        return metaString;
    }

    public string[] getlegendStringArray() {
        return legendStringArray;
    }

    public void MakeDictionary(Dictionary<string, string> dict) {
        for (int j = 1; j < metaStringArray.Length; j++) {
            string[] tempString = metaStringArray[j].Split(": ", StringSplitOptions.RemoveEmptyEntries);
            metaDict.Add(tempString[0], tempString[1][0].ToString());
        }
    }

    public EntityContainer<Block> AddBlocks(string path) {
        FileToString(path);

        EntityContainer<Block> blockContainer = new EntityContainer<Block>();
        float xPos = -(2 / 12f);
        float yPos = (24 / 24f);

        for (int i = 0; i < mapString.Length; i++) {
            for (int j = 1; j < legendStringArray.Length; j++) {
                if (mapString[i] == legendStringArray[j][0]) {
                    string imageFile;
                    string DamagedImageFile;
                    imageFile = legendStringArray[j].Split(") ", StringSplitOptions.RemoveEmptyEntries)[1];
                    imageFile = imageFile.Remove(imageFile.Length - 1);
                    DamagedImageFile = imageFile.Remove(imageFile.Length - 4, 4) + "-damaged.png";

                    blockContainer.AddEntity(new Blocks
                                            (new Vec2F(xPos, yPos),
                                             new Image(Path.Combine
                                            ("Assets", "Images", imageFile)), new Image(Path.Combine("Assets", "Images", DamagedImageFile)), 1));


                }
            }
            if (xPos > 10 / 12f) {
                xPos = -(2 / 12f);
                yPos -= (1 / 24f);
            } else {
                xPos += (1 / 12f);
            }
        }
        return blockContainer;
    }


}