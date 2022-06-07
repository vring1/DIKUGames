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
using DIKUArcade.Events;
using System;
using DIKUArcade.Utilities;


namespace breakoutTests;

public class LevelLoaderTest {
    LevelLoader levelTest;
    EntityContainer<Block> blockContainerTest = new EntityContainer<Block>();

    [SetUp]

    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        levelTest = new LevelLoader();
    }

    [Test]
    public void TestFillingBlockContainer() {
        var projectPath = FileIO.GetProjectPath();
        blockContainerTest = levelTest.AddBlocks(Path.Combine(projectPath, "Assets", "Levels", "level2.txt"));
        Assert.AreEqual(blockContainerTest.CountEntities(), 72);
    }
    [Test]
    public void LoadFileThatDoesntExistTest() {
        var projectPath = FileIO.GetProjectPath();
        blockContainerTest = levelTest.AddBlocks(Path.Combine(projectPath, "Assets", "Levels", "level19921.txt"));
        Assert.AreEqual(blockContainerTest.CountEntities(), 0);
    }
    [Test]
    public void LoadInvalidFileFormatTest() {
        var projectPath = FileIO.GetProjectPath();
        blockContainerTest = levelTest.AddBlocks(Path.Combine(projectPath, "Assets", "Levels", "hola.pdf"));
        Assert.AreEqual(blockContainerTest.CountEntities(), 0);
    }
    [Test]
    public void LoadWallTest() {
        var projectPath = FileIO.GetProjectPath();
        blockContainerTest = levelTest.AddBlocks(Path.Combine(projectPath, "Assets", "Levels", "wall.txt"));
        Assert.AreEqual(blockContainerTest.CountEntities(), 144);
    }
    [Test]
    public void LoadUnbreakableLevel() {
        var projectPath = FileIO.GetProjectPath();
        blockContainerTest = levelTest.AddBlocks(Path.Combine(projectPath, "Assets", "Levels", "level4.txt"));
        Assert.AreEqual(blockContainerTest.CountEntities(), 16);
    }
    [Test]
    public void LoadHardenedLevel() {
        var projectPath = FileIO.GetProjectPath();
        blockContainerTest = levelTest.AddBlocks(Path.Combine(projectPath, "Assets", "Levels", "level6.txt"));
        Assert.AreEqual(blockContainerTest.CountEntities(), 76);
    }

}