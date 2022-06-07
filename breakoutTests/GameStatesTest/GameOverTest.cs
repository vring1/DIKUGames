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

public class GameOverTest {


    StateMachine stateMachine;
    //GameEventBus eventBus;
    GameOver gameOver;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        /*eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.GameStateEvent, GameEventType.InputEvent });
        eventBus.Subscribe(GameEventType.InputEvent, stateMachine);
        eventBus.Subscribe(GameEventType.GameStateEvent, stateMachine);*/
        stateMachine = StateMachine.GetInstance();
        gameOver = GameOver.GetInstance();
    }
    /*[Test]
    public void HandleKeyEventTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_OVER"
        });
        gameOver.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Up);
        gameOver.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
    }*/

}