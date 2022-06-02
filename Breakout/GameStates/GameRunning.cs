using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using DIKUArcade.State;

namespace Breakout.GameStates {
    public class GameRunning : IGameState/*, IGameEventProcessor*/ {
        private Player player;
        private static GameRunning instance = null;
        private Score score;
        private Life life;
        private GameEventBus eventBus;
        public Ball ball;
        public EntityContainer<Ball> ballContainer;
        public int ballCount;
        public LevelLoader level;
        public EntityContainer<Block> blockContainer;

        private CollisionDetect collisionDetection;

        public GameRunning() {
            //score = new Score(new Vec2F(0.9f, 0.5f), new Vec2F(0.45f, 0.45f));
            score = Score.GetInstance();
            life = Life.GetInstance();
            //eventBus = new GameEventBus();
            //eventBus = new GameEventBus();
            //eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });



            //BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            //eventBus.Subscribe(GameEventType.PlayerEvent, player);


            //BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            //BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
        }
        //public void ProcessEvent(GameEvent gameEvent) {}
        public static GameRunning GetInstance() {
            if (GameRunning.instance == null) {
                GameRunning.instance = new GameRunning();
                GameRunning.instance.InitializeGameState();
            }
            return GameRunning.instance;
        }
        public void RenderState() {
            player.Render();
            /*foreach (Block block in LevelLoader.blocks) {
                block.Render();
            }*/
            blockContainer.RenderEntities();
            ballContainer.RenderEntities();
            score.RenderScore();
            life.RenderLife();
        }
        public void ResetState() {
            player.ResetPosition();
            life.ResetLife();
            score.ResetScore();
            //this.blockContainer.ClearContainer();
            //ball.ResetPosition();
        }
        public void UpdateState() {
            //BreakoutBus.GetBus().ProcessEventsSequentially();
            ball.MoveBall();
            collisionDetection.BallDetec(ballContainer, player, ball, blockContainer, new Vec2F(player.GetPositionX(), 0.2f));
            player.Move();
            score.UpdateScore();
            life.UpdateLife();
            if (life.LifeIsZero()) {
                BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "GAME_OVER"
                        }
                    );
            }
            if (blockContainer.CountEntities() == 0) {
                int count = 2;
                var blockContainer2 = new EntityContainer<Block>();
                //blockContainer.ClearContainer();
                string file = (@"Assets/Levels/level" + count.ToString() + ".txt");
                blockContainer2 = level.AddBlocks(file);
                blockContainer = blockContainer2;
                count++;
                //InitializeGameState();
            }
        }
        public EntityContainer<Ball> AddBalls() {
            EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
            ballContainer.AddEntity(new Ball(new DynamicShape(new Vec2F(0.45f, 0.2f), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
            ballCount++;
            return ballContainer;
        }
        public void InitializeGameState() {
            player = Player.GetInstance();
            //BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            //BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, player);
            collisionDetection = new CollisionDetect();
            level = new LevelLoader();
            blockContainer = level.AddBlocks(@"Assets/Levels/level1.txt");
            ball = new Ball(
                new DynamicShape(new Vec2F(0.485f, 0.1275f), new Vec2F(0.03f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png")));
            ballContainer = AddBalls();
            //LevelLoader.LoadLevel(Path.Combine("Assets", "Levels", "level4.txt"));
        }
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            System.Console.WriteLine("HandleKeyEvent");
            if (action == KeyboardAction.KeyPress) {
                System.Console.WriteLine("keypress");
                KeyPress(key);
            }
            if (action == KeyboardAction.KeyRelease) {
                KeyRelease(key);
            }
        }
        public void KeyPress(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left:
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                        EventType = GameEventType.InputEvent,
                        Message = "Move_Left"
                    });
                    break;
                case KeyboardKey.Right:
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
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
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                        EventType = GameEventType.InputEvent,
                        Message = "Release_Left"
                    });
                    break;
                case KeyboardKey.Right:
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                        EventType = GameEventType.InputEvent,
                        Message = "Release_Right"
                    });
                    break;
                case KeyboardKey.Escape:
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                        EventType = GameEventType.GameStateEvent,
                        Message = "GAME_PAUSED"
                    });
                    break;
                case KeyboardKey.Space:
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                        EventType = GameEventType.InputEvent,
                        Message = "Release_Space"
                    });
                    break;
                //Create new shot and add to container 

                default:
                    break;

            }
        }


    }
}