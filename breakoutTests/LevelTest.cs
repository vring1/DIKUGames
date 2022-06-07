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

public class LevelTest {
    LevelLoader level;
    LevelLoader level5;
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        level = new LevelLoader();
        level5 = new LevelLoader();
        var projectPath = FileIO.GetProjectPath();
        level.FileToString(Path.Combine(projectPath, "Assets", "Levels", "level1.txt"));
        level5.FileToString(Path.Combine(projectPath, "Assets", "Levels", "level5.txt"));
    }

    [Test]
    public void TestMetaData() {
        Assert.AreEqual(level.getmetaString(), "\r\nName: LEVEL 1\r\nTime: 300\r\nHardened: #\r\nPowerUp: 2\r\n");
    }

    [Test]
    public void TestLegendData() {
        Assert.AreEqual(level.getlegendString(), "\r\n%) blue-block.png\r\n0) grey-block.png\r\n1) orange-block.png\r\na) purple-block.png\r\n");
    }

    [Test]
    public void TestMapData() {
        Assert.AreEqual(level5.getmapString(), "\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n-----a------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n------------\n");
    }
    [Test]
    public void InvalidatorTrueTest() {
        var projectPath = FileIO.GetProjectPath();
        Assert.True(LevelLoader.Invalidator(Path.Combine(projectPath, "Assets", "Levels", "level1.txt")));
    }
    [Test]
    public void InvalidatorFalseTest() {
        var projectPath = FileIO.GetProjectPath();
        Assert.False(LevelLoader.Invalidator(Path.Combine(projectPath, "Assets", "Levels", "hola.pdf")));
    }
}