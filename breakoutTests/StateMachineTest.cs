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
using Breakout.GameStates;

namespace breakoutTests;

public class StateMachineTest {
    [SetUp]
    public void Setup() {

    }

    [Test]
    public void ProcessEventAndSwitchStateTest() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        Assert.AreEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
    }

    [Test]
    public void ProcessEventAndSwitchStateTest2() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
    }
    [Test]
    public void ProcessEventAndSwitchStateTest3() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        Assert.AreEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
    }
}