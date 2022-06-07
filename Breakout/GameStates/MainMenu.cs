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
    /// A state for when the game is launched.
    /// </summary>
    public class MainMenu : IGameState {
        private static MainMenu? instance = null;
        private Entity backGroundImage;
        private static Text newGame;
        private static Text quitGame;
        private Text[] menuButtons = { newGame, quitGame };
        private int activeMenuButton;
        private int maxMenuButtons;

        public MainMenu() {
            newGame = new Text("New Game", new Vec2F(0.37f, 0.35f), new Vec2F(0.32f, 0.32f));

            quitGame = new Text("Quit Game", new Vec2F(0.35f, 0.2f), new Vec2F(0.4f, 0.35f));
            newGame.SetColor(System.Drawing.Color.Red);
            quitGame.SetColor(System.Drawing.Color.Red);

            backGroundImage = new Entity(new StationaryShape(new Vec2F(0.00f, 0.00f), new Vec2F(1.0f, 1.0f)), new Image(Path.Combine("Assets", "Images", "BreakoutTitleScreen.png")));

            menuButtons = new Text[] { newGame, quitGame };

            maxMenuButtons = menuButtons.Length;
        }
        /// <summary> 
        /// Creates an instance of GameOver if it doesn't already exit 
        /// <summary>
        /// <returns> 
        /// The MainMenu instance. 
        /// <returns>
        public static MainMenu GetInstance() {
            if (MainMenu.instance == null) {
                MainMenu.instance = new MainMenu();
                MainMenu.instance.InitializeGameState();
            }
            return MainMenu.instance;
        }


        /// <summary>
        /// Handles when a specific key is pressed.
        /// </summary>
        /// <param name="action">the action of pressing key</param>
        /// <param name="key">the specific key that was pressed</param>
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                if (key == KeyboardKey.Down) {
                    quitGame.SetColor(System.Drawing.Color.Green);
                    newGame.SetColor(System.Drawing.Color.Red);
                    activeMenuButton = 1;
                }
                if (key == KeyboardKey.Up) {
                    newGame.SetColor(System.Drawing.Color.Green);
                    quitGame.SetColor(System.Drawing.Color.Red);
                    activeMenuButton = 0;
                }
                if (key == KeyboardKey.Enter) {
                    if (activeMenuButton == 0) {
                        GameRunning.GetInstance().ResetState();
                        BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "GAME_RUNNING"
                        }
                    );
                    } else {
                        BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Release_Escape"
                        }
                    );
                    }
                }
            }

        }
        /// <summary>
        /// Renders the acquired buttons and backgroundimage for MainMenu.
        /// </summary>
        public void RenderState() {
            this.backGroundImage.RenderEntity();
            foreach (Text elem in menuButtons) {
                elem.RenderText();

            }
        }
        public void ResetState() {
        }
        public void UpdateState() {

        }
        public void InitializeGameState() {

        }

    }
}