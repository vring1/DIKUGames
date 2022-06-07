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
    public void CantSwitchFromGameRunningToMainMenuDirectly() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }

    [Test]
    public void SwitchStateFromGameRunningToGamePaused() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void CantSwitchStateFromGamePausedToGameOverDirectly() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void SwitchStateFromGamePausedToMainMenu() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void CantSwitchStateFromGameOverToMainMenu() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void SwitchStateFromGameRunningToGameOver() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void CantSwitchStateFromGameOverToGamePaused() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void SwitchStateFromGameOverToGameRunning() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void SwitchStateFromMainMenuToGameRunning() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void CantSwitchStateFromMainMenuToGamePaused() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void CantSwitchStateFromMainMenuToGameOver() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
    [Test]
    public void SwitchStateFromGamePausedToGameRunning() {
        StateMachine stateMachine;
        stateMachine = StateMachine.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        Assert.AreNotEqual(stateMachine.ActiveState, GamePaused.GetInstance());
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, MainMenu.GetInstance());
        Assert.AreNotEqual(stateMachine.ActiveState, GameOver.GetInstance());
    }
}