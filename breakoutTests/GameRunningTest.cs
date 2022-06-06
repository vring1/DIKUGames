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

public class GameRunningTest {
    StateMachine stateMachine;
    //GameEventBus eventBus;
    GameRunning gameRunning;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        /*eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.GameStateEvent, GameEventType.InputEvent });
        eventBus.Subscribe(GameEventType.InputEvent, stateMachine);
        eventBus.Subscribe(GameEventType.GameStateEvent, stateMachine);*/
        stateMachine = StateMachine.GetInstance();
        gameRunning = GameRunning.GetInstance();
    }

    [Test]
    public void ResetStateTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        Player player;
        player = Player.GetInstance();
        Life life;
        life = Life.GetInstance();
        Score score;
        score = Score.GetInstance();
        gameRunning.ResetState();
        Assert.AreEqual(score.Count, 0);
        Assert.False(life.LifeIsZero());
        Assert.AreEqual(player.GetPositionX(), 0.45f);
        Assert.AreEqual(player.GetPositionY(), 0.1f);
    }

    /*[Test]
    public void UpdateStateLifeIsZeroTest() {
        GameRunning gameRunning;
        gameRunning = GameRunning.GetInstance();
        Life life;
        life = Life.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        life.DecreaseLife();
        gameRunning.UpdateState();
        Assert.True(life.LifeIsZero());
        Assert.AreEqual(stateMachine.ActiveState, GameOver.GetInstance());

    }*/
    /*[Test]
    public void UpdateStateScoreLimitIsReachedTest() {
        GameRunning gameRunning;
        gameRunning = GameRunning.GetInstance();
        Score score;
        score = Score.GetInstance();
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        for (int i = 0; i > 50; i++) {
            score.AddPoints();
        }
        //Assert.AreEqual(score.Count, 50);
        gameRunning.UpdateState();

        Assert.AreEqual(stateMachine.ActiveState, GameOver.GetInstance());

    }*/
    [Test]
    public void AddBallsTest() {
        EntityContainer<Ball> ballContainer;
        ballContainer = gameRunning.AddBalls();
        Assert.AreEqual(ballContainer.CountEntities(), 1);
    }

    [Test]
    public void HandleKeyEventKeyPressKeyReleaseTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        gameRunning.InitializeGameState();
        Player player;
        player = Player.GetInstance();
        var currPos = player.GetPosition();
        gameRunning.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Left);
        gameRunning.UpdateState();
        gameRunning.HandleKeyEvent(KeyboardAction.KeyRelease, KeyboardKey.Left);
        gameRunning.UpdateState();
        gameRunning.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Right);
        gameRunning.UpdateState();
        gameRunning.HandleKeyEvent(KeyboardAction.KeyRelease, KeyboardKey.Right);
        gameRunning.UpdateState();
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
        Assert.AreEqual(player.Shape.Position.X, currPos.X);
    }
    /*[Test]
    public void HandleKeyEventReleaseEscapeTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "GAME_RUNNING"
        });
        gameRunning.InitializeGameState();
        gameRunning.HandleKeyEvent(KeyboardAction.KeyRelease, KeyboardKey.Escape);
        gameRunning.UpdateState();
        Assert.AreEqual(stateMachine.ActiveState, GamePaused.GetInstance());
    }*/
}