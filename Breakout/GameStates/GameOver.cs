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
    /// A state for when the game has ended.
    /// </summary>
    public class GameOver : IGameState {
        private static GameOver? instance = null;
        private Entity backGroundImage;
        private static Text gameOver;
        private static Text newGame;
        private static Text exit;
        private Text[] menuButtons = { newGame, exit };
        private int activeMenuButton;
        private int maxMenuButtons;

        public GameOver() {
            gameOver = new Text("GAME OVER", new Vec2F(0.31f, 0.30f), new Vec2F(0.43f, 0.43f));

            newGame = new Text("Start New Game", new Vec2F(0.325f, 0.25f), new Vec2F(0.32f, 0.32f));

            exit = new Text("Exit", new Vec2F(0.435f, 0.1f), new Vec2F(0.4f, 0.35f));
            newGame.SetColor(System.Drawing.Color.Red);
            exit.SetColor(System.Drawing.Color.Red);
            gameOver.SetColor(System.Drawing.Color.Orange);

            backGroundImage = new Entity(new StationaryShape(new Vec2F(0.00f, 0.00f), new Vec2F(1.0f, 1.0f)), new Image(Path.Combine("Assets", "Images", "BreakoutTitleScreen.png")));

            menuButtons = new Text[] { newGame, exit, gameOver };

            maxMenuButtons = menuButtons.Length;
        }

        /// <summary> 
        /// Creates an instance of GameOver if it doesn't already exit 
        /// <summary>
        /// <returns> 
        /// The GameOver instance. 
        /// <returns>
        public static GameOver GetInstance() {
            if (GameOver.instance == null) {
                GameOver.instance = new GameOver();
                GameOver.instance.InitializeGameState();
            }
            return GameOver.instance;
        }

        /// <summary>
        /// Handles when a specific key is pressed.
        /// </summary>
        /// <param name="action">the action of pressing key</param>
        /// <param name="key">the specific key that was pressed</param>
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                if (key == KeyboardKey.Down) {
                    exit.SetColor(System.Drawing.Color.Green);
                    newGame.SetColor(System.Drawing.Color.Red);
                    activeMenuButton = 1;
                }
                if (key == KeyboardKey.Up) {
                    newGame.SetColor(System.Drawing.Color.Green);
                    exit.SetColor(System.Drawing.Color.Red);
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
        /// Renders the acquired buttons and backgroundimage for GameOver.
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