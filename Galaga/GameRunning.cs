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

namespace Galaga {
    public class GameRunning : IGameState {
        private static GameRunning instance = null;
        private Entity backGroundImage;
        private Text[] menuButtons; 
        private int activeMenuButton;
        private int maxMenuButtons;

        public static GameRunning GetInstance() {
            if (GameRunning.instance == null) {
                GameRunning.instance = new GameRunning();
                GameRunning.instance.InitializeGameState();
            }
            return GameRunning.instance;
        }
        
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key){
            int index = 0;
            if (action == KeyboardAction.KeyPress || action == KeyboardAction.KeyRelease) {
                if (key == KeyboardKey.Up) {
                    if (menuButtons[index+1] == null){
                        // CANNOT MOVE
                        }//Select button above current button
                    else{
                        // SET INDEX 1 active (new Game)
                        // SET COLOR OF NEW GAME
                        activeMenuButton = 1;
                        index++;
                    }
                }
                if (key == KeyboardKey.Down) {
                    //Select button below current button
                    if (menuButtons[index-1] == null){
                        // CANNOT MOVE
                    }
                    else{
                        // SET INDEX 0 active (quit Game)
                        // SET COLOR OF QUIT GAME 
                        activeMenuButton = 0;
                        index--;
                    }
                }

                if (key == KeyboardKey.Enter) {
                    //Register event for currently selected button
                    if (activeMenuButton == 1){
                        GalagaBus.GetBus().RegisterEvent(
                        new GameEvent{
                            EventType = GameEventType.GameStateEvent,
                            Message = "CHANGE_STATE",
                            StringArg1 = "GAME_RUNNING"
                        }
                    );
                    }
                    else{
                        // LUK VINDUET WALLAH
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
        public void RenderState(){
        
        }
        public void ResetState(){

        }
        public void UpdateState(){

        }
        public void InitializeGameState(){
            
        }

    }
}