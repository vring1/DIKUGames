using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Timers;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using System;
//using DIKUArcade.EventBus;



namespace Breakout;
public class BreakoutTimer : StaticTimer {

    public DIKUArcade.Timers.StaticTimer breakoutStaticTimer;

    private Text display;

    private int moreTime = 15;


    private int currint;
    public int currTimer;
    public int gameTime;

    /// <summary>
    /// Keeps time for the game.
    /// </summary>
    /// <param name="instance"> The instance of the timer</param>
    /// <param name="breakoutStaticTimer">A static timer counting up</param>
    /// <param name="gameTime">The total amount of time for a level</param>
    /// <param name="currTimer">The current timer</param>
    /// <param name="moreTime">Holds a value of 15 seconds</param>
    /// <param name="currint">The timers time in seconds</param>

    private static BreakoutTimer instance = new BreakoutTimer(new Vec2F(0.5f, 0.5f), new Vec2F(0.45f, 0.45f));

    public BreakoutTimer(Vec2F position, Vec2F extent) {
        display = new Text(currTimer.ToString(), position, extent);
        display.SetColor(System.Drawing.Color.White);
    }

    public static BreakoutTimer GetInstance() {
        return instance;
    }

    public void SetBreakoutTimer(int time) {
        breakoutStaticTimer = new DIKUArcade.Timers.StaticTimer();
        gameTime = time;
        currTimer = time;

    }
    public int CountTimer(int gameTime) {
        currint = Convert.ToInt32(DIKUArcade.Timers.StaticTimer.GetElapsedSeconds());
        currTimer = gameTime - currint;
        if (currTimer < 0) {
            currTimer = 0;
        }
        return currTimer;
    }
    public bool TimerRunOut() {
        if (currTimer != 0) {
            return false;
        } else {
            return true;
        }
    }
    public void AddMoreTimePowerUp() {
        currTimer += moreTime;
    }
    public void RenderTimer() {
        display.RenderText();
    }

    public void UpdateTimer() {
        CountTimer(gameTime);
        display.SetText((currTimer).ToString());
    }
}