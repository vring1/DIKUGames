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
    public class MainMenu : IGameState {
        private static MainMenu? instance = null;
        private Entity backGroundImage;
        private static Text newGame; //= new Text("New Game",new Vec2F(0.1f,0.1f),new Vec2F(0.1f,0.1f) );
        private static Text quitGame; //= new Text("Quit Game",new Vec2F(0.2f,0.2f),new Vec2F(0.1f,0.1f) );
        private Text[] menuButtons = { newGame, quitGame };
        private int activeMenuButton;
        private int maxMenuButtons;
        //private StationaryShape shape;
        /*public MainMenu(StationaryShape shape, IBaseImage image) {
            backGroundImage = new Entity(shape, image);
            this.shape = shape;
        }*/
        //private static GameRunning? gameRunning;

        public MainMenu() {
            newGame = new Text("New Game", new Vec2F(0.37f, 0.35f), new Vec2F(0.32f, 0.32f));

            quitGame = new Text("Quit Game", new Vec2F(0.35f, 0.2f), new Vec2F(0.4f, 0.35f));
            newGame.SetColor(System.Drawing.Color.Red);
            quitGame.SetColor(System.Drawing.Color.Red);

            backGroundImage = new Entity(new StationaryShape(new Vec2F(0.00f, 0.00f), new Vec2F(1.0f, 1.0f)), new Image(Path.Combine("Assets", "Images", "BreakoutTitleScreen.png")));

            menuButtons = new Text[] { newGame, quitGame };

            maxMenuButtons = menuButtons.Length;
        }

        public static MainMenu GetInstance() {
            if (MainMenu.instance == null) {
                MainMenu.instance = new MainMenu();
                //new StationaryShape(new Vec2F(0.5f, 0.5f), new Vec2F(0.9f, 0.9f)),
                //new Image(Path.Combine("Assets", "Images", "TitleImage.png")));
                //new Image(Path.GetFullPath(Path.Combine("Assets", "Images", "TitleImage.png")).Replace("galagaTest", "Galaga")));
                //new Image(Path.Combine("../", "Assets", "Images", "TitleImage.png")));
                MainMenu.instance.InitializeGameState();
            }
            return MainMenu.instance;
        }



        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress /*|| action == KeyboardAction.KeyRelease*/) {
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
                        // RESET STATE FOR GAME RUNNING
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
                // else: do nothing... 
            }

            //if "New Game" button is selected, the event to register should be (THIS CODE):

            //GalagaBus.GetBus().RegisterEvent(
            //new GameEvent{
            //EventType = GameEventType.GameStateEvent,
            //Message = "CHANGE_STATE",
            //StringArg1 = "GAME_RUNNING"
            //}
            // );

            //This method will be called from the state machine 

            //Assume that action will equal KeyboardAction.KeyPress or KeyboardAction.KeyRelease

            //Depending on the key, perform some action
            //KeyboardKey.Up - Select button above currently selected button.
            //KeyboardKey.Down - Select button below currently selected button.
            //KeyboardKey.Enter - Register an event appropriate for the currently selected button.

            //Do nothing if the key is invalid in the MainMenu state.

            //If "New Game" button is selected, the event to register should be (THIS CODE):

            //GalagaBus.GetBus().RegisterEvent(
            //new GameEvent{
            //EventType = GameEventType.GameStateEvent,
            //Message = "CHANGE_STATE",
            //StringArg1 = "GAME_RUNNING"
            //}
            // );



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