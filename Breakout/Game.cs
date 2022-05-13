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

namespace Breakout;
public class Game : DIKUGame, IGameEventProcessor //DIKUGame 
{
    private Player player;
    private Ball ball;
    private GameEventBus eventBus;
    //private StateMachine stateMachine;
    // switch på StateMachine.Activestate og kør den rette state
    public Game(WindowArgs windowArgs) : base(windowArgs) {
        LevelLoader.LoadLevel(Path.Combine("Assets", "Levels", "level1.txt"));
        player = Player.GetInstance();
        eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });
        window.SetKeyEventHandler(KeyHandler);
        eventBus.Subscribe(GameEventType.InputEvent, this);
        eventBus.Subscribe(GameEventType.InputEvent, player);

        ball = new Ball(
                new DynamicShape(new Vec2F(0.485f, 0.1275f), new Vec2F(0.03f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png")));
    }

    public override void Update() {
        eventBus.ProcessEventsSequentially();
        player.Move();
        ball.MoveBall();
        
    }

    public override void Render() {
        player.Render();
        ball.Render();
        foreach (Block block in LevelLoader.blocks) {
            block.Render();
        }
    }

    private void KeyHandler(KeyboardAction action, KeyboardKey key) {
        if (action == KeyboardAction.KeyPress) {
            KeyPress(key);
        }
        if (action == KeyboardAction.KeyRelease) {
            KeyRelease(key);
        }
    }
    public void KeyPress(KeyboardKey key) {
        switch (key) {
            case KeyboardKey.Left:
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.InputEvent,
                    Message = "Move_Left"
                });
                break;
            case KeyboardKey.Right:
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.InputEvent,
                    Message = "Move_Right"
                });
                break;
            default:
                break;
        }
    }

    public void KeyRelease(KeyboardKey key) {
        switch (key) {
            case KeyboardKey.Left:
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.InputEvent,
                    Message = "Release_Left"
                });
                break;
            case KeyboardKey.Right:
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.InputEvent,
                    Message = "Release_Right"
                });
                break;
            case KeyboardKey.Escape:
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.InputEvent,
                    Message = "Release_Escape"
                });
                break;
            case KeyboardKey.Space:
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.InputEvent,
                    Message = "Release_Space"
                });
                break;
            //Create new shot and add to container 

            default:
                break;

        }
    }

    public void ProcessEvent(GameEvent gameEvent) {
        if (gameEvent.EventType == GameEventType.InputEvent) {
            switch (gameEvent.Message) {
                case "Release_Escape":
                    window.CloseWindow();
                    break;
                /*case "Release_Space":
                    Image powImg = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
                    DynamicShape shotShape = new DynamicShape(player.GetPosition(), PlayerShot.extent, PlayerShot.direction);
                    PlayerShot playerShot = new PlayerShot(shotShape, powImg);
                    playerShots.AddEntity(playerShot);
                    break;*/
                default:
                    break;
            }
        }
    }


}


