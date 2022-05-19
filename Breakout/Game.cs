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
    public Ball ball;
    private GameEventBus eventBus;
    public EntityContainer<Ball> ballContainer;
    public int ballCount;

    public LevelLoader level;
    public EntityContainer<Block> blockContainer;

    private CollisionDetect collisionDetection;
    //private StateMachine stateMachine;
    // switch på StateMachine.Activestate og kør den rette state
    public Game(WindowArgs windowArgs) : base(windowArgs) {
        level = new LevelLoader();

        blockContainer = level.AddBlocks(@"Assets/Levels/level1.txt");

        player = Player.GetInstance();
        eventBus = new GameEventBus();
        eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });
        window.SetKeyEventHandler(KeyHandler);
        eventBus.Subscribe(GameEventType.InputEvent, this);
        eventBus.Subscribe(GameEventType.InputEvent, player);
        collisionDetection = new CollisionDetect();

        ball = new Ball(
                new DynamicShape(new Vec2F(0.485f, 0.1275f), new Vec2F(0.03f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png")));
        ballContainer = AddBalls();
    }

     public EntityContainer<Ball> AddBalls()
        {
            EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
            ballContainer.AddEntity(new Ball(new DynamicShape(new Vec2F(0.45f, 0.2f), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
            ballCount++;
            return ballContainer;
        }

    public override void Update() {
        eventBus.ProcessEventsSequentially();
        player.Move();
        ball.MoveBall();
        collisionDetection.BallDetec(ballContainer,player,ball,blockContainer,new Vec2F(player.GetPositionX(),0.2f));
    }

    public override void Render() {
        player.Render();
        blockContainer.RenderEntities();
        ballContainer.RenderEntities();
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


