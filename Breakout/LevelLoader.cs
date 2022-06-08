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
using DIKUArcade.Events;
using System;


namespace Breakout;
/// <summary>
/// Used for reading the levelfiles and adding the right blocks to a usable container.
/// </summary>
public class LevelLoader {

    private LevelLoader level;
    private BreakoutTimer timer;
    private string mapString;
    private string metaString;
    private string[] metaStringArray;
    private string[] legendStringArray;
    private string legend;
    public int time;
    Dictionary<string, string> metaDict = new Dictionary<string, string>();
    Dictionary<string, string> metaTimeDict = new Dictionary<string, string>();
    EntityContainer<Block> blockContainer = new EntityContainer<Block>();
    /// <summary>
    /// Checks if a certain file actually has the required aspects of being a level.
    /// </summary>
    /// <param name="path">a filepath</param>
    /// <returns></returns>
    public static bool Invalidator(string path) {
        string readText = File.ReadAllText(path);
        if (readText.Contains("Map:") && readText.Contains("Map/")
        && readText.Contains("Meta:") && readText.Contains("Meta/")
        && readText.Contains("Legend:") && readText.Contains("Legend/")) {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Given a filepath, the different fields will be filled with a string containing the information corresponding.
    /// </summary>
    /// <param name="path">a filepath</param>
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
        MakeDictionaryTime(metaTimeDict);
    }
    /// <summary>
    /// returns the field which was filled in FileToString().
    /// </summary>
    /// <returns>the map data as a string</returns>
    public string getmapString() {
        return mapString;
    }
    /// <summary>
    /// returns the field which was filled in FileToString().
    /// </summary>
    /// <returns>the meta data as a string</returns>
    public string getmetaString() {
        return metaString;
    }
    /// <summary>
    /// returns the field which was filled in FileToString().
    /// </summary>
    /// <returns>the legend data as a string</returns>
    public string getlegendString() {
        return legend;
    }
    /// <summary>
    /// returns the field which was filled in FileToString().
    /// </summary>
    /// <returns>the legend data as a string array</returns>
    public string[] getlegendStringArray() {
        return legendStringArray;
    }
    /// <summary>
    /// Fills a dictionary with corresponding data.
    /// </summary>
    /// <param name="dict">the dictionary to be filled</param>
    public void MakeDictionary(Dictionary<string, string> dict) {
        timer = BreakoutTimer.GetInstance();
        metaDict.Clear();
        for (int j = 1; j < metaStringArray.Length; j++) {
            string[] tempString = metaStringArray[j].Split(": ", StringSplitOptions.RemoveEmptyEntries);
            metaDict.Add(tempString[0], tempString[1][0].ToString());
        }
    }

    /// <summary>
    /// Fills a dictionary with corresponding data, with the purpos of time.
    /// </summary>
    /// <param name="dictT">the dictionary to be filled</param>
    public void MakeDictionaryTime(Dictionary<string, string> dictT) {
        timer = BreakoutTimer.GetInstance();
        metaTimeDict.Clear();
        for (int j = 1; j < metaStringArray.Length; j++) {
            string[] tempString = metaStringArray[j].Split(": ", StringSplitOptions.RemoveEmptyEntries);
            metaTimeDict.Add(tempString[0], tempString[1].ToString());
        }
    }
    /// <summary>
    /// Adds blocks to a EntityContainer given a filepath.
    /// </summary>
    /// <param name="path">the filepath</param>
    /// <returns></returns>
    public EntityContainer<Block> AddBlocks(string path) {
        string fileExt = System.IO.Path.GetExtension(path);
        if (File.Exists(path) && fileExt == ".txt") {

            FileToString(path);
            if (metaString.Contains("Time")) {
                int time = Int32.Parse(metaTimeDict["Time"]);
                timer.SetBreakoutTimer(time);
            }

            float xPos = -(2 / 12f);
            float yPos = (24 / 24f);


            for (int i = 0; i < mapString.Length; i++) {
                for (int j = 1; j < legendStringArray.Length; j++) {
                    if (mapString[i] == legendStringArray[j][0]) {
                        string imageFile;
                        string DamagedImageFile;
                        imageFile = legendStringArray[j].Split(") ", StringSplitOptions.RemoveEmptyEntries)[1];
                        imageFile = imageFile.Remove(imageFile.Length);
                        var imageFile2 = imageFile.Remove(imageFile.Length - 1);
                        string fileExtimg = System.IO.Path.GetExtension(imageFile);
                        string fileExtimg2 = System.IO.Path.GetExtension(imageFile2);

                        if (fileExtimg2 == ".png") {
                            imageFile = imageFile.Remove(imageFile.Length - 1);
                        } else {
                            imageFile = imageFile.Remove(imageFile.Length);
                        }

                        DamagedImageFile = imageFile.Remove(imageFile.Length - 4, 4) + "-damaged.png";
                        bool Unbreakable = false;
                        bool Hardened = false;
                        bool PowerUp = false;


                        foreach (KeyValuePair<string, string> kvp in metaDict) {

                            if (kvp.Value == mapString[i].ToString()) {
                                if (kvp.Key == "Unbreakable") {
                                    Unbreakable = true;
                                }
                                if (kvp.Key == "Hardened") {
                                    Hardened = true;
                                }
                                if (kvp.Key == "PowerUp") {
                                    PowerUp = true;
                                }
                            }
                        }

                        if (Unbreakable) {
                            blockContainer.AddEntity(new Unbreakable
                                                    (new Vec2F(xPos, yPos),
                                                    new Image(Path.Combine
                                                    ("Assets", "Images", imageFile)), new Image(Path.Combine("Assets", "Images", DamagedImageFile)), 1));

                        } else if (Hardened) {
                            blockContainer.AddEntity(new Hardened
                                                    (new Vec2F(xPos, yPos),
                                                    new Image(Path.Combine
                                                    ("Assets", "Images", imageFile)), new Image(Path.Combine("Assets", "Images", DamagedImageFile)), 1));
                        } else if (PowerUp) {
                            blockContainer.AddEntity(new PowerupBlock
                                                    (new Vec2F(xPos, yPos),
                                                    new Image(Path.Combine
                                                    ("Assets", "Images", imageFile)), new Image(Path.Combine("Assets", "Images", DamagedImageFile)), 1));

                        } else {
                            blockContainer.AddEntity(new Blocks
                                                    (new Vec2F(xPos, yPos),
                                                    new Image(Path.Combine
                                                    ("Assets", "Images", imageFile)), new Image(Path.Combine("Assets", "Images", DamagedImageFile)), 1));

                        }

                    }
                }
                if (xPos > 10 / 12f) {
                    xPos = -(2 / 12f);
                    yPos -= (1 / 24f);
                } else {
                    xPos += (1 / 12f);
                }
            }
        }

        return blockContainer;
    }

}