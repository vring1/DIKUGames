using NUnit.Framework;
using System;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Input; 
using System.IO;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using DIKUArcade.GUI;
using Galaga; 
using DIKUArcade;


namespace GalagaTests
{

[TestFixture]
public class StateMachineTesting {
    private StateMachine stateMachine;

    [SetUp]
    public void InitiateStateMachine() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();        
        // (1) Initialize a GalagaBus with proper GameEventTypes
        var bus = GalagaBus.GetBus();
        // bus.InitializeEventBus(new GameEventType[] { GameEventType.GameStateEvent });

        // (2) Instantiate the StateMachine
        stateMachine = new StateMachine();

        // (3) Subscribe the GalagaBus to proper GameEventTypes
        // and GameEventProcessors
        bus.Subscribe(GameEventType.GameStateEvent, stateMachine); 
    }
    
    [Test]
    public void TestInitialState() {
    Assert.That(stateMachine.ActiveState, Is.InstanceOf<MainMenu>());
    }
    
    [Test]
    public void TestEventGameRunning() {
        GalagaBus.GetBus().RegisterEvent(
            new GameEvent{
                EventType = GameEventType.GameStateEvent,
                Message = "CHANGE_STATE",
                StringArg1 = "GAME_RUNNING"
            }
    );
        GalagaBus.GetBus().ProcessEventsSequentially();
        Assert.That(stateMachine.ActiveState, Is.InstanceOf<GameRunning>());
    }
}
}