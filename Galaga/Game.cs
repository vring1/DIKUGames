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

namespace Galaga {
    public class Game : DIKUGame, IGameEventProcessor //DIKUGame 
    {
        private Player player;
        private GameEventBus eventBus;
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



        }

        private void KeyHandler(KeyboardAction action, KeyboardKey key) {
        } // TODO: Outcomment
        public override void Render() {
            player.Render();
        }

        public override void Update() {
            window.PollEvents();
            window.Clear();
            eventBus.ProcessEventsSequentially();
            player.Move();

            //throw new System.NotImplementedException("Galaga game has no entities to update yet.");
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
            // TODO: switch on key string and set the player's move direction
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

                default:
                    System.Console.WriteLine("You are stupid");
                    break;

            }
            // TODO: switch on key string and disable the player's move direction
            // TODO: Close window if escape is pressed
        }
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.WindowEvent) {
                switch (gameEvent.Message) {
                    // TODO: Implement
                    default:
                        break;
                }
            }
        }










    }

}
