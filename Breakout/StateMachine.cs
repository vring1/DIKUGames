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
using DIKUArcade.State;
using Breakout.GameStates;

namespace Breakout;
public class StateMachine : IGameEventProcessor {
    public IGameState ActiveState {
        get; private set;
    }
    public StateMachine() {
        BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
        BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
        IGameState ActiveState = MainMenu.GetInstance();
        GameRunning.GetInstance();
        GamePaused.GetInstance();
    }
    public void ProcessEvent(GameEvent gameEvent) {
        if (gameEvent.EventType == GameEventType.GameStateEvent) {
            var state = gameEvent.Message;
            //this.SwitchState(StateTransformer.TransformStringToState(state));
            switch (state) {
                case "GAME_RUNNING":
                    SwitchState(StateTransformer.TransformStringToState(state));
                    break;
                case "MAIN_MENU":
                    SwitchState(StateTransformer.TransformStringToState(state));
                    break;
                case "GAME_PAUSED":
                    SwitchState(StateTransformer.TransformStringToState(state));
                    break;
                default:
                    break;
            }
        }
    }
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
            default:
                break;

                //SwitchState should change the ActiveState field to the IGameState matching the input GameStateType. '
                //As hinted by the fact that the StateMachine class implements the IGameEventProcessor interface, another method needs to be implemented as well.
        }
    }
}
