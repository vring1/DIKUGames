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

public class PowerUpTest {
    private Breakout.PowerupBlock block;
    private EntityContainer<PowerUpDrops> powerUpDropsContainer;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        powerUpDropsContainer = new EntityContainer<PowerUpDrops>();

        block = (new PowerupBlock
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
        Assert.False(block.isUnbreakable());
    }
    [Test]
    public void IsHitTest() {
        block.isHit();
        Assert.AreEqual(block.HP, 0);
    }
    [Test]
    public void DeleteBlockTest() {
        block.isHit();
        block.isHit();
        block.isHit();
        block.DeleteBlock(powerUpDropsContainer);
        Assert.True(block.IsDeleted());
    }
    [Test]
    public void BlockIsOnlyDeletedWhenHpIs0Test() {
        block.DeleteBlock(powerUpDropsContainer);
        Assert.False(block.IsDeleted());
    }
    [Test]
    public void HPWillAlwaysBePositiveTest() {
        block.isHit();
        block.isHit();
        block.isHit();
        Assert.AreEqual(block.HP, 0);
    }
}