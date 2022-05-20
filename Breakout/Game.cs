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

namespace Breakout;
public class Game : DIKUGame, IGameEventProcessor //DIKUGame 
{
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

        System.Console.WriteLine("eyyy");
        stateMachine = StateMachine.GetInstance();
    }
    public override void Update() {
        BreakoutBus.GetBus().ProcessEventsSequentially();
        //eventBus.ProcessEventsSequentially();
        stateMachine.ActiveState.UpdateState();
    }
    public override void Render() {
        stateMachine.ActiveState.RenderState();
        /*player.Render();
        foreach (Block block in LevelLoader.blocks) {
            block.Render();
        }*/
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
        stateMachine.ActiveState.HandleKeyEvent(action, key);
    }


    public void ProcessEvent(GameEvent gameEvent) {
        System.Console.WriteLine("escape");
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


