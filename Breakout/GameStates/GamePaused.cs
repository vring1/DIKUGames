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
    /// A state for when the game is paused.
    /// </summary>
    public class GamePaused : IGameState {
        private static GamePaused? instance = null;
        private Entity backGroundImage;
        private static Text resume;
        private static Text mainMenu;
        private Text[] menuButtons = { resume, mainMenu };
        private int activeMenuButton;
        private int maxMenuButtons;

        public GamePaused() {
            resume = new Text("Continue", new Vec2F(0.40f, 0.35f), new Vec2F(0.32f, 0.32f));

            mainMenu = new Text("MainMenu", new Vec2F(0.36f, 0.2f), new Vec2F(0.4f, 0.35f));
            resume.SetColor(System.Drawing.Color.Red);
            mainMenu.SetColor(System.Drawing.Color.Red);

            menuButtons = new Text[] { resume, mainMenu };

            backGroundImage = new Entity(new StationaryShape(new Vec2F(0.00f, 0.00f), new Vec2F(1.0f, 1.0f)), new Image(Path.Combine("Assets", "Images", "BreakoutTitleScreen.png")));

        }
        /// <summary> 
        /// Creates an instance of GameOver if it doesn't already exit 
        /// <summary>
        /// <returns> 
        /// The GamePaused instance. 
        /// <returns>

        public static GamePaused GetInstance() {
            if (GamePaused.instance == null) {
                GamePaused.instance = new GamePaused();
                GamePaused.instance.InitializeGameState();

            }
            return GamePaused.instance;
        }
        /// <summary>
        /// Handles when a specific key is pressed.
        /// </summary>
        /// <param name="action">the action of pressing key</param>
        /// <param name="key">the specific key that was pressed</param>
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                if (key == KeyboardKey.Down) {
                    mainMenu.SetColor(System.Drawing.Color.Green);
                    resume.SetColor(System.Drawing.Color.Red);
                    activeMenuButton = 1;
                }
                if (key == KeyboardKey.Up) {
                    resume.SetColor(System.Drawing.Color.Green);
                    mainMenu.SetColor(System.Drawing.Color.Red);
                    activeMenuButton = 0;
                }
                if (key == KeyboardKey.Enter) {
                    if (activeMenuButton == 0) {
                        BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "GAME_RUNNING"
                        }
                    );
                    } else {
                        BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "MAIN_MENU"
                        }
                    );
                    }
                }
            }
        }

        /// <summary>
        /// Renders the acquired buttons and backgroundimage for GamePaused.
        /// </summary>
        public void RenderState() {
            backGroundImage.RenderEntity();
            foreach (Text menuButton in this.menuButtons) {
                menuButton.RenderText();
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
