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

public class UnbreakableTest {
    private Breakout.Unbreakable block;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();

        block = (new Unbreakable
                (new Vec2F(0.5f, 0.5f),
                 new Image(Path.Combine
                ("Assets", "Images", "blue-block.png")), new Image(Path.Combine("Assets", "Images", "blue-block.png")), 1));
    }

    [Test]
    public void TestGetBlockPosition() {
        Vec2F blockPosition = new Vec2F(0.5f, 0.5f);
        Assert.AreEqual(block.GetThisPositionX(), blockPosition.X);
        Assert.AreEqual(block.GetThisPositionY(), blockPosition.Y);
    }

    [Test]
    public void IsUnbreakableTest() {
        Assert.True(block.isUnbreakable());
    }
    [Test]
    public void IsHitTest() {
        block.isHit();
        Assert.AreEqual(block.HP, 1);
    }
    [Test]
    public void CantDeleteBlockTest() {
        block.isHit();
        block.isHit();
        block.isHit();
        block.isHit();
        block.isHit();
        block.isHit();
        block.DeleteBlock();
        Assert.False(block.IsDeleted());
    }
    [Test]
    public void HPWillAlwaysBePositiveTest() {
        block.isHit();
        block.isHit();
        block.isHit();
        Assert.AreEqual(block.HP, 1);
    }
}