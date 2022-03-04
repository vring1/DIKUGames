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

namespace Galaga {
    public class Game : DIKUGame, IGameEventProcessor //DIKUGame 
    {
        private EntityContainer<Enemy> enemies;
        private Player player;
        private GameEventBus eventBus;
        private EntityContainer<PlayerShot> playerShots;
        private IBaseImage playerShotImage;
        private AnimationContainer enemyExplosions;
        private List<Image> explosionStrides;
        private const int EXPLOSION_LENGTH_MS = 500;

        public Game(WindowArgs windowArgs) : base(windowArgs) {
            player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png")));
            // TODO: Set key event handler (inherited window field of DIKUGame class)
            //SetKeyHandler();

            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });

            window.SetKeyEventHandler(KeyHandler);

            eventBus.Subscribe(GameEventType.InputEvent, this);

            var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            const int numEnemies = 8;
            enemies = new EntityContainer<Enemy>(numEnemies);
            for (int i = 0; i < numEnemies; i++) {
                enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, images)));
            }
            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));

            enemyExplosions = new AnimationContainer(numEnemies);
            explosionStrides = ImageStride.CreateStrides(8,
                Path.Combine("Assets", "Images", "Explosion.png"));

        }

        private void KeyHandler(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                KeyPress(key);
            }
            if (action == KeyboardAction.KeyRelease) {
                KeyRelease(key);
            }
        }



        public override void Render() {
            player.Render();
            enemies.RenderEntities();
            playerShots.RenderEntities();
            enemyExplosions.RenderAnimations();

        }

        public override void Update() {
            window.PollEvents();
            window.Clear();
            eventBus.ProcessEventsSequentially();
            player.Move();
            IterateShots();
        }

        public void KeyPress(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left:
                    player.SetMoveLeft(true);
                    break;
                case KeyboardKey.Right:
                    player.SetMoveRight(true);
                    break;
                default:
                    System.Console.WriteLine("You are stupid");
                    break;

            }
        }
        public void KeyRelease(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left:
                    player.SetMoveLeft(false);
                    break;
                case KeyboardKey.Right:
                    player.SetMoveRight(false);
                    break;
                case KeyboardKey.Escape:
                    window.CloseWindow();
                    break;
                case KeyboardKey.Space:
                    Image powImg = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));
                    DynamicShape shotShape = new DynamicShape(player.GetPosition(), PlayerShot.extent, PlayerShot.direction);
                    PlayerShot playerShot = new PlayerShot(shotShape, powImg);
                    playerShots.AddEntity(playerShot);
                    break;
                //Create new shot and add to container 

                default:
                    System.Console.WriteLine("You are stupid");
                    break;

            }
        }
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.WindowEvent) {
                switch (gameEvent.Message) {
                    // Not implemented
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

                } 
                else {
                    enemies.Iterate(enemy => {
                        if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(), enemy.Shape).Collision){
                            shot.DeleteEntity();
                            enemy.DeleteEntity();
                            AddExplosion(enemy.Shape.Position,enemy.Shape.Extent);
                        }
                        // If collision; shot and enemy -> delete both
                        

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

