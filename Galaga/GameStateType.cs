using System;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Input; 
using System.IO;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using DIKUArcade.GUI;
//using DIKUArcade;

namespace Galaga
{
    
public enum GameStateType {
    GameRunning,
    GamePaused,
    MainMenu
}

public class StateTransformer{
    public static GameStateType TransformStringToState(string state){
        if (state == "GAME_RUNNING"){
            return GameStateType.GameRunning;
        }
        if (state == "GAME_PAUSED"){
            return GameStateType.GamePaused;
        }
        if (state == "MAIN_MENU"){
            return GameStateType.MainMenu;
        }
        throw new ArgumentException(String.Format("{0} is not a valid state", state));
        
    }   

    public static string TransformStateToString(GameStateType state) {
        if (state == GameStateType.GameRunning){
            return "GAME_RUNNING";
        }
        if (state == GameStateType.GamePaused){
            return "GAME_PAUSED";
        }
        else { 
            return "MAIN_MENU";
        }
        //throw new ArgumentException(String.Format("{0} is not a valid state", state));
    }
}

}