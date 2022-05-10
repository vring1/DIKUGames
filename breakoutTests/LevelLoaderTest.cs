using NUnit.Framework;
using Breakout;
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
using DIKUArcade.Utilities;


namespace breakoutTests;

public class LevelLoaderTest {
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
    }

    [Test]
    public void LoadLevel1Test() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "level1.txt"));
        Assert.AreEqual(LevelLoader.blockCount, 76);
    }
    [Test]
    public void LoadLevel2Test() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "level2.txt"));
        Assert.AreEqual(LevelLoader.blockCount, 72);
    }
    [Test]
    public void LoadLevel3Test() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "level3.txt"));
        Assert.AreEqual(LevelLoader.blockCount, 76);
    }
    [Test]
    public void LoadLevel5Test() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "level5.txt"));
        Assert.AreEqual(LevelLoader.blockCount, 1);
    }
    [Test]
    public void LoadInvalidLevelTest() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "level1992.txt"));
        Assert.AreEqual(LevelLoader.blockCount, 0);
    }
    [Test]
    public void LoadInvalidFileFormatTest() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "hola.pdf"));
        Assert.AreEqual(LevelLoader.blockCount, 0);
    }
    [Test]
    public void LoadWallTest() {
        var projectPath = FileIO.GetProjectPath();
        LevelLoader.LoadLevel(Path.Combine(projectPath, "Assets", "Levels", "wall.txt"));
        Assert.AreEqual(LevelLoader.blockCount, 144);
    }

}