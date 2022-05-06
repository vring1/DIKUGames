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



namespace breakoutTests;

public class LevelTest {
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        //Level testLevel = new Level(Path.Combine("../", "../", "../", "Assets", "Levels", "level1.txt"));
        //Level level3 = new Level(Path.Combine("Assets", "Levels", "level3.txt"));
    }

    [Test]
    public void TestMap() {
        /*Level testLevel = new Level(Path.Combine("../", "../", "../", "Assets", "Levels", "level1.txt"));
        Assert.AreEqual(testLevel.GetLines("Name"), "LEVEL 1");
        Assert.AreEqual(testLevel.GetLines("Time"), "300");*/
    }

    [Test]
    public void TestMeta() {
        //Assert.Pass();
        Level testLevel = new Level(Path.Combine("../", "../", "../", "Assets", "Levels", "level1.txt"));
        Assert.AreEqual(testLevel.GetMetaData("Name"), "LEVEL 1");
        Assert.AreEqual(testLevel.GetMetaData("Time"), "300");
        Assert.AreEqual(testLevel.GetMetaData("Hardened"), "#");
        Assert.AreEqual(testLevel.GetMetaData("PowerUp"), "2");
    }

    [Test]
    public void TestLegend() {
        Level testLevel = new Level(Path.Combine("../", "../", "../", "Assets", "Levels", "level1.txt"));
        Assert.AreEqual(testLevel.GetLegendData("%"), "blue-block.png");
        Assert.AreEqual(testLevel.GetLegendData("0"), "grey-block.png");
        Assert.AreEqual(testLevel.GetLegendData("1"), "orange-block.png");
        Assert.AreEqual(testLevel.GetLegendData("a"), "purple-block.png");
    }



}