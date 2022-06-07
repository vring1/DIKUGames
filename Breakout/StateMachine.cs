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
using DIKUArcade.State;

namespace Breakout.GameStates;
/// <summary>
/// Controls the state flow and switches between states.
/// </summary>
public class StateMachine : IGameEventProcessor {
    public IGameState ActiveState {
        get; private set;
    }
    private static StateMachine instance = new StateMachine();
    public StateMachine() {
        BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
        ActiveState = MainMenu.GetInstance();
    }
    /// <summary>
    /// Returns the instance field from the Statemachine class.
    /// </summary>
    /// <returns> The instance of Statemachine</returns>
    public static StateMachine GetInstance() {
        return instance;
    }
    /// <summary>
    /// Processes an event by switching on the message from the registered event.
    /// </summary>
    /// <param name="gameEvent"> a specific registered GameEvent</param>

    public void ProcessEvent(GameEvent gameEvent) {
        if (gameEvent.EventType == GameEventType.GameStateEvent) {
            var state = gameEvent.Message;
            switch (state) {
                case "GAME_RUNNING":
                    SwitchState(StateTransformer.TransformStringToState(state));
                    break;
                case "MAIN_MENU":
                    if (ActiveState == GamePaused.GetInstance()) {
                        SwitchState(StateTransformer.TransformStringToState(state));
                    }
                    break;
                case "GAME_PAUSED":
                    if (ActiveState == GameRunning.GetInstance()) {
                        SwitchState(StateTransformer.TransformStringToState(state));
                    }
                    break;
                case "GAME_OVER":
                    if (ActiveState == GameRunning.GetInstance()) {
                        SwitchState(StateTransformer.TransformStringToState(state));
                    }
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Updates the ActiveState to the instance equivalent to the GameStateType.
    /// </summary>
    /// <param name="stateType"> a specific GameStateType</param>
    private void SwitchState(GameStateType stateType) {
        switch (stateType) {
            case GameStateType.MAIN_MENU:
                ActiveState = MainMenu.GetInstance();
                break;
            case GameStateType.GAME_RUNNING:
                ActiveState = GameRunning.GetInstance();
                break;
            case GameStateType.GAME_PAUSED:
                ActiveState = GamePaused.GetInstance();
                break;
            case GameStateType.GAME_OVER:
                ActiveState = GameOver.GetInstance();
                break;
            default:
                break;
        }
    }
}
