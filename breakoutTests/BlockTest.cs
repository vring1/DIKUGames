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
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        //LevelLoader.LoadLevel(3);
        //var windowArgs = new WindowArgs() { Title = "Breakout" };
        //var game = new Game(windowArgs);

        //eventBus = new GameEventBus();
        //eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.PlayerEvent });
        //eventBus.Subscribe(GameEventType.PlayerEvent, player);

    }

    [Test]
    public void GetPositionTest() {
        Block block = new Block(
                new StationaryShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.02f)),
                new Image(Path.Combine("Assets", "Images", "grey-block.png")));
        Vec2F somePosition = new Vec2F(0.45f, 0.1f);
        Assert.AreEqual(block.GetPosition().X, somePosition.X);
        Assert.AreEqual(block.GetPosition().Y, somePosition.Y);
    }
}