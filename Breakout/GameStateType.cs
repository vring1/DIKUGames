using System;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.GUI;
namespace Breakout;
/// <summary>
/// The different states of the game.
/// </summary>
public enum GameStateType {
    GAME_RUNNING,
    GAME_PAUSED,
    MAIN_MENU,
    GAME_OVER
}
/// <summary>
/// Transforms the states.
/// </summary>
public class StateTransformer {
    /// <summary>
    /// Transforms a string into it's corresponding GameStateType.
    /// </summary>
    /// <param name="state">a string in the form of a specific GameStateType</param>
    /// <returns></returns>
    public static GameStateType TransformStringToState(string state) {
        if (state == "GAME_RUNNING") {
            return GameStateType.GAME_RUNNING;
        }
        if (state == "GAME_PAUSED") {
            return GameStateType.GAME_PAUSED;
        }
        if (state == "MAIN_MENU") {
            return GameStateType.MAIN_MENU;
        }
        if (state == "GAME_OVER") {
            return GameStateType.GAME_OVER;
        }
        throw new ArgumentException(String.Format("{0} is not a valid state", state));

    }
    /// <summary>
    /// Transforms a GameStateType into a string.
    /// </summary>
    /// <param name="state">a specific GameStateType to be changed into a string</param>
    /// <returns></returns>
    public static string TransformStateToString(GameStateType state) {
        if (state == GameStateType.GAME_RUNNING) {
            return "GAME_RUNNING";
        }
        if (state == GameStateType.GAME_PAUSED) {
            return "GAME_PAUSED";
        }
        if (state == GameStateType.GAME_OVER) {
            return "GAME_OVER";
        } else {
            return "MAIN_MENU";
        }
    }
}
