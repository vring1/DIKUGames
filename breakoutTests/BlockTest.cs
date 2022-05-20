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

public class BlockTest {
     private Breakout.Blocks block;

    [SetUp]
    public void Setup()
    {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        
        block = (new Blocks
                (new Vec2F(0.5f, 0.5f),
                 new Image(Path.Combine
                ("Assets", "Images", "blue-block.png")), new Image(Path.Combine("Assets", "Images", "blue-block.png")), 2));
    }

    [Test]
    public void TestGetBlockPosition()
    {
        
        Vec2F blockPosition = new Vec2F(0.5f, 0.5f);
        Assert.AreEqual(block.GetThisPositionX(), blockPosition.X);
        Assert.AreEqual(block.GetThisPositionY(), blockPosition.Y);
    }

    [Test]
    public void TestBlockHP()
    {   
        int currHP = block.HP;
        block.isHit();
        Assert.AreNotEqual(block.HP , currHP);
        
    }
}