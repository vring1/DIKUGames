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

public class MainMenuTest {


    StateMachine stateMachine;
    //GameEventBus eventBus;
    MainMenu mainMenu;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        /*eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.GameStateEvent, GameEventType.InputEvent });
        eventBus.Subscribe(GameEventType.InputEvent, stateMachine);
        eventBus.Subscribe(GameEventType.GameStateEvent, stateMachine);*/
        stateMachine = StateMachine.GetInstance();
        mainMenu = MainMenu.GetInstance();
    }

    /*[Test]
    public void HandleKeyEventTest() {
        stateMachine.ProcessEvent(new GameEvent {
            EventType = GameEventType.GameStateEvent,
            Message = "MAIN_MENU"
        });
        mainMenu.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Up);
        mainMenu.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);
        Assert.AreEqual(stateMachine.ActiveState, GameRunning.GetInstance());
    }*/
}
