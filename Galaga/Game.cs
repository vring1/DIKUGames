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
using Galaga.Squadron;
using Galaga.MovementStrategy;
using System;

namespace Galaga {
    public class Game : DIKUGame, IGameEventProcessor //DIKUGame 
    {
        private EntityContainer<Enemy> enemies;
        private Player player;
        private GameEventBus eventBus;
        private AnimationContainer enemyExplosions;
        private List<Image> explosionStrides;
        public EntityContainer<PlayerShot> playerShots;
        public IBaseImage playerShotImage;
        public List<Image> enemyStridesRed;
        private MoveDown moveDown;
        private NoMove noMove;
        private ZigZagDown zigZagDown;
        private Score score;
        private static Random rnd = new Random();
        private int snd = rnd.Next(3);
        private ISquadron squadron1;
        private ISquadron squadron2;
        private ISquadron squadron3;
        private const int EXPLOSION_LENGTH_MS = 500;
        private StateMachine stateMachine = new StateMachine();

        public Game(WindowArgs windowArgs) : base(windowArgs) {
            System.Console.WriteLine("START");
            player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png")));
            // TODO: Set key event handler (inherited window field of DIKUGame class)
            //SetKeyHandler();

            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });
            window.SetKeyEventHandler(KeyHandler);
            eventBus.Subscribe(GameEventType.InputEvent, this);
            eventBus.Subscribe(GameEventType.InputEvent, player);


            const int numberOfEnemies = 8;
            enemyExplosions = new AnimationContainer(numberOfEnemies);
            explosionStrides = ImageStride.CreateStrides(8,
                Path.Combine("Assets", "Images", "Explosion.png"));

            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));

            //var enemyStridesBlue = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));

            enemyStridesRed = ImageStride.CreateStrides(2, Path.Combine("Assets",
            "Images", "RedMonster.png"));

            squadron1 = new LineSquadron();


            squadron2 = new ZigZagSquadron();


            squadron3 = new DobbeltFatSquadron();


            moveDown = new MoveDown();
            noMove = new NoMove();
            zigZagDown = new ZigZagDown();

            score = new Score(new Vec2F(0.85f, 0.5f), new Vec2F(0.5f, 0.5f));

            if (snd == 0) {
                enemies = squadron3.Enemies;
            }
            if (snd == 1) {
                enemies = squadron2.Enemies;
            }
            if (snd == 2) {
                enemies = squadron1.Enemies;
            }

            System.Console.WriteLine("FÆRDIG");
        }

        public void NewSpeed() {
            foreach (Enemy elem in enemies) {
                elem.Speed = elem.Speed + 0.002f;
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

        public void NewWave() {
            var a = rnd.Next(3);
            List<Image> blueMonster = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            switch (a) {
                case 0:
                    enemies = squadron1.Enemies;
                    squadron1.CreateEnemies(blueMonster, enemyStridesRed);
                    break;
                case 1:
                    enemies = squadron2.Enemies;
                    squadron2.CreateEnemies(blueMonster, enemyStridesRed);
                    break;
                case 2:
                    enemies = squadron3.Enemies;
                    squadron3.CreateEnemies(blueMonster, enemyStridesRed);
                    break;
            }

        }
        public void DifferentMoves() {
            var a = rnd.Next(3);
            if (a == 0) {
                moveDown.MoveEnemies(enemies);
            }
            if (a == 1) {
                noMove.MoveEnemies(enemies);
            }
            if (a == 2) {
                zigZagDown.MoveEnemies(enemies);
            }
        }
        /*public void DeleteAllEntities(){
            enemies.Iterate(enemy => {
                if (enemy.IsAtBottom()){
                    foreach (Enemy elem in enemies){
                        elem.DeleteEntity();  

                    }
                    
                    
                }
            }); 
        }*/
        public bool GameOver() {
            //DeleteAllEntities();
            foreach (Enemy elem in enemies) {
                if (elem.IsAtBottomOfScreen()) {
                    return true;
                }
            }
            return false;
        }

        public override void Render() {
            if (GameOver() == false) {
                player.Render();
                enemies.RenderEntities();
                playerShots.RenderEntities();
                enemyExplosions.RenderAnimations();
                if (enemies.CountEntities() == 0) {
                    NewWave();
                    NewSpeed();
                }
            }
            DifferentMoves();
            score.RenderScore();
            // TODO: if et eller andet... MainMenu.RenderState();
        }

        public override void Update() {
            eventBus.ProcessEventsSequentially();
            player.Move();
            IterateShots();
            score.UpdateScore();
            // TODO: update state
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
                    case "Release_Space":
                        Image powImg = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
                        DynamicShape shotShape = new DynamicShape(player.GetPosition(), PlayerShot.extent, PlayerShot.direction);
                        PlayerShot playerShot = new PlayerShot(shotShape, powImg);
                        playerShots.AddEntity(playerShot);
                        break;
                    default:
                        break;
                }
            }
        }


        private void IterateShots() {
            playerShots.Iterate(shot => {

                shot.Shape.Move();
                // Moves the shot's shape

                if (shot.Shape.Position.Y > 1) {
                    shot.DeleteEntity();

                } else {
                    enemies.Iterate(enemy => {
                        if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(), enemy.Shape).Collision) {
                            enemy.HitPoints -= 40;
                            if (enemy.HitPoints <= 0) {
                                shot.DeleteEntity();
                                enemy.DeleteEntity();
                                AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                                score.AddPoints();
                            } else if (enemy.IsShot()) {
                                ImageStride turnRed = new ImageStride(8, enemyStridesRed);
                                enemy.Image = turnRed;
                            }

                        }

                    });

                }
            });

        }

        public void AddExplosion(Vec2F position, Vec2F extent) {
            //Add explosion to the AnimationContainer
            StationaryShape statShape = new StationaryShape(position, extent);
            ImageStride imgStride = new ImageStride(EXPLOSION_LENGTH_MS / 8, explosionStrides);
            enemyExplosions.AddAnimation(statShape, EXPLOSION_LENGTH_MS, imgStride);

        }


    }
}

