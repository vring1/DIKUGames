// assert that the player is in fact inside of the boundaries, before testing that the playe rcant leave them..

// test any function that has conditions and loops
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


using NUnit.Framework;

namespace breakoutTests;

public class PlayerTest {
    Player player;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        player = Player.GetInstance();
    }
    [Test]
    public void GetPositionTest() {
        Vec2F somePosition = new Vec2F(0.45f, 0.1f);
        Assert.AreEqual(player.GetPosition().X, somePosition.X);
        Assert.AreEqual(player.GetPosition().Y, somePosition.Y);
    }
    [Test]
    public void ResetPositionTest() {
        player.ResetPosition();
        Vec2F somePosition = new Vec2F(0.45f, 0.1f);
        Assert.AreEqual(player.GetPosition().X, somePosition.X);
        Assert.AreEqual(player.GetPosition().Y, somePosition.Y);
    }
    [Test]
    public void MoveLeftTest() {
        var currPos = player.GetPosition();
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Move_Left"
        });
        player.Move();
        Assert.Less(player.Shape.Position.X, currPos.X);
        Assert.AreEqual(currPos.Y, player.Shape.Position.Y);
    }
    [Test]
    public void MoveRightTest() {
        var currPos = player.GetPosition();
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Move_Right"
        });
        player.Move();
        Assert.AreEqual(currPos.Y, player.Shape.Position.Y);
        Assert.AreEqual(player.Shape.Position.X, currPos.X);
    }

    [Test]
    public void OutOfBoundsToTheLeftTest() {
        player.Shape.SetPosition(new Vec2F(0.0f, 0.1f));
        var newPos = player.GetPosition();
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Move_Left"
        });
        for (int i = 0; i < 3; i++) {
            player.Move();
        }
        Assert.AreEqual(player.Shape.Position.X, newPos.X);
        Assert.AreEqual(player.Shape.Position.Y, newPos.Y);
    }
    public void OutOfBoundsToTheRightTest() {
        player.Shape.SetPosition(new Vec2F(1.0f, 0.1f));
        var newPos = player.GetPosition();
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Move_"
        });
        for (int i = 0; i < 3; i++) {
            player.Move();
        }
        Assert.AreEqual(player.Shape.Position.X, newPos.X);
        Assert.AreEqual(player.Shape.Position.Y, newPos.Y);
    }

    [Test]
    public void GetInstanceTest() {
        var playerInstance = Player.GetInstance();
        var playerInstancePos = playerInstance.Shape.Position;
        var currPos = player.GetPosition();
        Assert.AreEqual(playerInstancePos.X, currPos.X);
        Assert.AreEqual(playerInstancePos.Y, currPos.Y);
    }

    [Test]
    public void ProcessEventTest() {
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Release_Right"
        });
        Assert.Less(player.Shape.Direction.X, -0.001f);
    }
    [Test]
    public void ReleaseKeyTest() {
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Release_Left"
        });
        Assert.AreEqual(player.Shape.Direction.X, 0.0f);

    }

}

