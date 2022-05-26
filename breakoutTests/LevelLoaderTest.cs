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

    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        levelTest = new LevelLoader();
    }

    [Test]
    public void TestFillingBlockContainer() {
        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/level2.txt");
        Assert.AreNotEqual(blockContainerTest, EmptyContainerTest);
    }
    [Test]
    public void LoadInvalidLevelTest() {
        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/level1992.txt");
        Assert.AreEqual(blockContainerTest.CountEntities(), 0);
    }
    [Test]
    public void LoadInvalidFileFormatTest() {
        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/hola.txt");
        Assert.AreEqual(blockContainerTest.CountEntities(), 0);
    }
    [Test]
    public void LoadWallTest() {
        blockContainerTest = levelTest.AddBlocks(@"Assets/Levels/wall.txt");
        Assert.AreNotEqual(blockContainerTest, EmptyContainerTest);
    }


}