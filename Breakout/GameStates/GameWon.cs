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
    public class GameWon : IGameState {
        private static GameWon? instance = null;
        private Entity backGroundImage;
        private static Text gameWon;
        private static Text newGame; //= new Text("New Game",new Vec2F(0.1f,0.1f),new Vec2F(0.1f,0.1f) );
        private static Text exit; //= new Text("Quit Game",new Vec2F(0.2f,0.2f),new Vec2F(0.1f,0.1f) );
        private Text[] menuButtons = { newGame, exit };
        private int activeMenuButton;
        private int maxMenuButtons;
        //private StationaryShape shape;
        /*public gameWon(StationaryShape shape, IBaseImage image) {
            backGroundImage = new Entity(shape, image);
            this.shape = shape;
        }*/
        //private static GameRunning? gameRunning;

        public GameWon() {
            gameWon = new Text("CONGRATULATIONS", new Vec2F(0.31f, 0.30f), new Vec2F(0.43f, 0.43f));

            newGame = new Text("Player Again", new Vec2F(0.325f, 0.25f), new Vec2F(0.32f, 0.32f));

            exit = new Text("Exit", new Vec2F(0.435f, 0.1f), new Vec2F(0.4f, 0.35f));
            newGame.SetColor(System.Drawing.Color.Red);
            exit.SetColor(System.Drawing.Color.Red);
            gameWon.SetColor(System.Drawing.Color.Orange);

            backGroundImage = new Entity(new StationaryShape(new Vec2F(0.00f, 0.00f), new Vec2F(1.0f, 1.0f)), new Image(Path.Combine("Assets", "Images", "BreakoutTitleScreen.png")));

            menuButtons = new Text[] { newGame, exit, gameWon };

            maxMenuButtons = menuButtons.Length;
        }

        public static GameWon GetInstance() {
            if (GameWon.instance == null) {
                GameWon.instance = new GameWon();
                //new StationaryShape(new Vec2F(0.5f, 0.5f), new Vec2F(0.9f, 0.9f)),
                //new Image(Path.Combine("Assets", "Images", "TitleImage.png")));
                //new Image(Path.GetFullPath(Path.Combine("Assets", "Images", "TitleImage.png")).Replace("galagaTest", "Galaga")));
                //new Image(Path.Combine("../", "Assets", "Images", "TitleImage.png")));
                GameWon.instance.InitializeGameState();
            }
            return GameWon.instance;
        }



        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress /*|| action == KeyboardAction.KeyRelease*/) {
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
                        // RESET STATE FOR GAME RUNNING
                        GameRunning.GetInstance().ResetState();
                        BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "MAIN_MENU"
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
        public void RenderState() {
            this.backGroundImage.RenderEntity();
            foreach (Text elem in menuButtons) {
                elem.RenderText();

            }

            //Render "TitleImage.png" - Image for menu 
            //Render buttons 
            //the selected menu button should be indicated by the color of the text (a menu button should be of the type DIKUArcade.Graphics.Text) and there should be the two 
            //buttons New Game and Quit.

        }
        public void ResetState() {
            instance = null;
            menuButtons = new Text[] { };
        }
        public void UpdateState() {

        }
        public void InitializeGameState() {

        }

    }
}