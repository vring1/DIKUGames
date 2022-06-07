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
using Breakout.GameStates;

namespace Breakout;
/// <summary>
/// Game has control over the game loop and the window in general and what's being updated,rendered etc.
/// </summary>
public class Game : DIKUGame, IGameEventProcessor {
    private GameEventBus eventBus;
    private StateMachine stateMachine;

    public Game(WindowArgs windowArgs) : base(windowArgs) {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType>
        { GameEventType.InputEvent,
        GameEventType.PlayerEvent,
        GameEventType.GameStateEvent });

        BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
        BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, Player.GetInstance());


        window.SetKeyEventHandler(HandleKeyEvent);

        stateMachine = StateMachine.GetInstance();
    }
    /// <summary>
    /// Updates each frame of the active state.
    /// </summary>
    public override void Update() {
        BreakoutBus.GetBus().ProcessEventsSequentially();
        stateMachine.ActiveState.UpdateState();
    }
    /// <summary>
    /// Renders the active state to the screen.
    /// </summary>
    public override void Render() {
        stateMachine.ActiveState.RenderState();
    }
    /// <summary>
    /// Handles when a specific key is pressed.
    /// </summary>
    /// <param name="action">the action of pressing key</param>
    /// <param name="key">the specific key that was pressed</param>
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
        stateMachine.ActiveState.HandleKeyEvent(action, key);
    }

    /// <summary>
    /// Processes an event by switching on the message from the registered event.
    /// </summary>
    /// <param name="gameEvent"> a specific registered GameEvent</param>
    public void ProcessEvent(GameEvent gameEvent) {
        if (gameEvent.EventType == GameEventType.InputEvent) {
            switch (gameEvent.Message) {
                case "Release_Escape":
                    window.CloseWindow();
                    break;
                default:
                    break;
            }
        }
    }


}


