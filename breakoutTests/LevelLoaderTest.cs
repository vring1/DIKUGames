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
     private Breakout.LevelLoader levelTest;
    private EntityContainer<Block> blockContainerTest;
    private EntityContainer<Block> EmptyContainerTest;

    [SetUp]

    public void Setup()
    {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        levelTest = new LevelLoader();
    }

    [Test]
    public void TestFillingBlockContainer()
    {

        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/level2.txt");
        Assert.AreNotEqual(blockContainerTest ,EmptyContainerTest);
    }

    [Test]
    public void TestMetaDataSaved()
    {

        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/levelTest.txt");
        string SavedMetaData = levelTest.getmetaString();
        Console.WriteLine(SavedMetaData);
        Assert.AreEqual(SavedMetaData, levelTest.getmetaString());
    }

    [Test]
    public void TestLegendDataSaved()
    {

        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/levelTest.txt");
        string[] SavedLegendData = levelTest.getlegendStringArray();
        Assert.AreEqual(SavedLegendData, levelTest.getlegendStringArray());
    }

}