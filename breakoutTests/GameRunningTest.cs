using NUnit.Framework;
using Breakout;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
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
using Breakout.GameStates;

namespace breakoutTests;

public class GameRunningTest {


    [SetUp]
    public void Setup() {

    }
    /*public void ResetState() {
                player.ResetPosition();
                life.ResetLife();
                score.ResetScore();
                InitializeGameState();
                //this.blockContainer.ClearContainer();
                //ball.ResetPosition();
            }*/
    [Test]
    public void ResetStateTest() {
        GameRunning gameRunning;
        gameRunning = GameRunning.GetInstance();
        Player player;
        player = Player.GetInstance();
        Life life;
        life = Life.GetInstance();
        Score score;
        score = Score.GetInstance();
        gameRunning.ResetState();
        Assert.AreEqual(score.Count, 0);
        Assert.False(life.LifeIsZero());
        Assert.AreEqual(player.GetPositionX(), 0.45f);
        Assert.AreEqual(player.GetPositionY(), 0.1f);
    }
    [Test]
    public void InitializeGameStateTest() {

    }
    [Test]
    public void UpdateState() {

    }


}