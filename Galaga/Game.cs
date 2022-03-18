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
        public List<Image> enemyStridesGreen;
        public List<Image> enemyStridesRed;
        
        
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
            eventBus.Subscribe(GameEventType.InputEvent, player);

            var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            const int numEnemies = 8;
            enemies = new EntityContainer<Enemy>(numEnemies);
            for (int i = 0; i < numEnemies; i++) {
                enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, images)
                    ));
            }
            const int numberOfEnemies = 8;
            enemyExplosions = new AnimationContainer(numberOfEnemies);
            explosionStrides = ImageStride.CreateStrides(8,
                Path.Combine("Assets", "Images", "Explosion.png"));

            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));

            enemyStridesGreen = ImageStride.CreateStrides(2, Path.Combine("Assets",
            "Images", "GreenMonster.png"));
            enemyStridesRed = ImageStride.CreateStrides(2, Path.Combine("Assets",
            "Images", "RedMonster.png"));
            //var enemyStridesBlue = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));



            //var Squadron1 = new HeartSquadron(enemies, 8);
            //Squadron1.CreateEnemies(images, enemyStridesGreen);
            //Squadron1.CreateEnemies();
            //Squadron1.Enemies.RenderEntities(); 
            

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
            //Squadron1.Enemies.RednerEntities();
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
                    eventBus.RegisterEvent (new GameEvent{
                        EventType = GameEventType.InputEvent, Message = "Move_Left"
                    });
                    break;
                case KeyboardKey.Right:
                    eventBus.RegisterEvent (new GameEvent{
                        EventType = GameEventType.InputEvent, Message = "Move_Right"
                    });
                    break;
                default:
                    break;

            }
        }
        
        public void KeyRelease(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left:
                    eventBus.RegisterEvent (new GameEvent{
                        EventType = GameEventType.InputEvent, Message = "Release_Left"
                    });
                    break;
                case KeyboardKey.Right:
                    eventBus.RegisterEvent (new GameEvent{
                        EventType = GameEventType.InputEvent, Message = "Release_Right"
                    });
                    break;
                case KeyboardKey.Escape:
                    eventBus.RegisterEvent (new GameEvent{
                        EventType = GameEventType.InputEvent, Message = "Release_Escape"
                    });
                    break;
                case KeyboardKey.Space:
                    eventBus.RegisterEvent (new GameEvent{
                        EventType = GameEventType.InputEvent, Message = "Release_Space"
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

                } 
                else {
                    enemies.Iterate(enemy => {
                        if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(), enemy.Shape).Collision){
                            
                            if (enemy.HitPoints <= 0){
                                shot.DeleteEntity();
                                enemy.DeleteEntity();
                                AddExplosion(enemy.Shape.Position,enemy.Shape.Extent);
                            }
                            else if (enemy.HitPoints > 40){
                                enemy.HitPoints -= 30;
                                ImageStride turnGreen = new ImageStride(8,enemyStridesGreen);
                                enemy.Image = turnGreen;
                            }    
                            else{
                                enemy.HitPoints -= 30;
                                ImageStride turnRed = new ImageStride(8,enemyStridesRed);
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

