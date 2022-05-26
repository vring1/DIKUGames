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
//using Breakout.GameStates;

namespace Breakout.GameStates;
public class StateMachine : IGameEventProcessor {
    public IGameState ActiveState {
        get; private set;
    }
    //private GameEventBus eventBus;
    private static StateMachine instance = new StateMachine();
    public StateMachine() {
        //eventBus = new GameEventBus();
        //eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });
        /*BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> {
            GameEventType.InputEvent,
            GameEventType.GameStateEvent,
            GameEventType.PlayerEvent
         });*/
        BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
        BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, this);
        //IGameState ActiveState = MainMenu.GetInstance();
        //ActiveState = GameRunning.GetInstance();
        GameRunning.GetInstance();
        GamePaused.GetInstance();
        ActiveState = MainMenu.GetInstance();
    }
    public static StateMachine GetInstance() {
        return instance;
    }
    /*public void RenderState() {
        //eventBus.ProcessEventsSequentially();
        ActiveState.RenderState();
    }
    public void UpdateState() {
        System.Console.WriteLine("hej5");
        //eventBus.ProcessEventsSequentially();
        ActiveState.UpdateState();
        System.Console.WriteLine("hej6");
    }*/

    public void ProcessEvent(GameEvent gameEvent) {
        if (gameEvent.EventType == GameEventType.GameStateEvent) {
            var state = gameEvent.Message;
            //this.SwitchState(StateTransformer.TransformStringToState(state));
            switch (state) {
                case "GAME_RUNNING":
                    SwitchState(StateTransformer.TransformStringToState(state));
                    //ActiveState.ResetState();
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
