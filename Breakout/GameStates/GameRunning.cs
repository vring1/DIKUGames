using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.State;

namespace Breakout.GameStates {
    /// <summary>
    /// A state for when the game is running.
    /// </summary>
    public class GameRunning : IGameState {
        private Player player;
        private static GameRunning instance = null;
        private Score score;
        private Life life;
        private Ball ball;
        private EntityContainer<Ball> ballContainer;
        private int ballCount;
        private LevelLoader level;
        private EntityContainer<Block> blockContainer;
        private EntityContainer<PowerUpDrops> powerUpDropsContainer;

        private CollisionDetect collisionDetection;

        private BreakoutTimer timerGame;
        private PowerUpAbillties powerUpAbillties;

        public GameRunning() {
            score = Score.GetInstance();
            life = Life.GetInstance();
            timerGame = BreakoutTimer.GetInstance();
        }
        /// <summary> 
        /// Creates an instance of GameRunning if it doesn't already exit 
        /// <summary>
        /// <returns> 
        /// The GamePaused instance. 
        /// <returns>
        public static GameRunning GetInstance() {
            if (GameRunning.instance == null) {
                GameRunning.instance = new GameRunning();
                GameRunning.instance.InitializeGameState();
            }
            return GameRunning.instance;
        }
        /// <summary>
        /// Renders the aquired objects for when game is running.
        /// </summary>
        public void RenderState() {
            player.Render();
            blockContainer.RenderEntities();
            ballContainer.RenderEntities();
            score.RenderScore();
            life.RenderLife();
            timerGame.RenderTimer();
            powerUpDropsContainer.RenderEntities();
        }
        /// <summary>
        /// Resets the state of GameRunning.
        /// </summary>
        public void ResetState() {
            player.ResetPosition();
            life.ResetLife();
            score.ResetScore();
            InitializeGameState();
        }
        /// <summary>
        /// Updates every frame such that what is being rendered is correct.
        /// </summary>
        public void UpdateState() {
            ball.MoveBall();
            collisionDetection.BallDetec(ballContainer, player, ball, life, blockContainer, powerUpDropsContainer, new Vec2F(player.GetPositionX(), 0.2f));
            player.Move();
            score.UpdateScore();
            life.UpdateLife();
            timerGame.UpdateTimer();
            powerUpDropsContainer.RenderEntities();
            powerUpAbillties.Iterate(powerUpDropsContainer, ballContainer, ball, life, score, player, ballCount);
            if (life.LifeIsZero()) {
                BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "GAME_OVER"
                        }
                    );
            }
            if (score.Count == 50) {
                Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "GAME_OVER"
                });
            }
            if (blockContainer.CountEntities() == 0) {
                int count = 2;
                if (count < 6) {
                    string file = (@"Assets/Levels/level" + count.ToString() + ".txt");
                    blockContainer = level.AddBlocks(file);
                    count++;
                } else {
                    Breakout.BreakoutBus.GetBus().RegisterEvent(new GameEvent {
                        EventType = GameEventType.GameStateEvent,
                        Message = "GAME_OVER"
                    });
                }
            }
        }
        /// <summary>
        /// Adds balls to an EntityContainer<Ball>.
        /// </summary>
        /// <returns> EntityContainer with the desired balls.</returns>
        public EntityContainer<Ball> AddBalls() {
            EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
            ballContainer.AddEntity(new Ball(new DynamicShape(new Vec2F(0.45f, 0.2f), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
            ballCount++;
            return ballContainer;
        }
        /// <summary>
        /// Initializes the state of GameRunning.
        /// </summary>
        public void InitializeGameState() {
            powerUpAbillties = new PowerUpAbillties();
            player = Player.GetInstance();
            collisionDetection = new CollisionDetect();
            level = new LevelLoader();
            powerUpDropsContainer = new EntityContainer<PowerUpDrops>();
            blockContainer = level.AddBlocks(@"Assets/Levels/level1.txt");
            ball = new Ball(
                new DynamicShape(new Vec2F(0.485f, 0.1275f), new Vec2F(0.03f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png")));
            ballContainer = AddBalls();
        }
        /// <summary>
        /// Handles when a specific key is pressed.
        /// </summary>
        /// <param name="action">the action of pressing key</param>
        /// <param name="key">the specific key that was pressed</param>
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                KeyPress(key);
            }
            if (action == KeyboardAction.KeyRelease) {
                KeyRelease(key);
            }
        }
        /// <summary>
        /// Handles the event for when a button is pressed.
        /// </summary>
        /// <param name="key">the specific key that was pressed</param>
        private void KeyPress(KeyboardKey key) {
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
        /// <summary>
        /// Handles the event for when a button is released.
        /// </summary>
        /// <param name="key">the specific key that was pressed</param>
        private void KeyRelease(KeyboardKey key) {
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
                default:
                    break;

            }
        }


    }
}