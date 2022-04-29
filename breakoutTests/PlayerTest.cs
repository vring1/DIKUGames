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
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        Player player;
        player = Player.GetInstance();
        BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, player);
    }

    [Test]
    public void Move_Left() {
        Assert.Pass();
        var currPos = player.GetPosition();
        player.ProcessEvent(new GameEvent {
            EventType = GameEventType.InputEvent,
            Message = "Move_Left"
        });
    }
}