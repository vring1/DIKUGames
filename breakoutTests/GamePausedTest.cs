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
using Breakout.GameStates;

namespace breakoutTests;

public class GamePausedTest {


    StateMachine stateMachine;
    //GameEventBus eventBus;
    GamePaused gamePaused;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        /*eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.GameStateEvent, GameEventType.InputEvent });
        eventBus.Subscribe(GameEventType.InputEvent, stateMachine);
        eventBus.Subscribe(GameEventType.GameStateEvent, stateMachine);*/
        stateMachine = StateMachine.GetInstance();
        gamePaused = GamePaused.GetInstance();
    }

    /*[Test]
    public void HandleKeyEventMainMenuTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        gamePaused.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Up);
        gamePaused.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);
        Assert.AreEqual(stateMachine.ActiveState, MainMenu.GetInstance());
    }
    [Test]
    public void HandleKeyEventGameRunningTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_PAUSED"
        });
        gamePaused.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Down);
        gamePaused.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
    }*/
}