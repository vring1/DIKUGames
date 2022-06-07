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
using DIKUArcade.Events;
using System;
using Breakout.GameStates;

namespace breakoutTests;

public class ScoreTest {
    Score score;

    [SetUp]
    public void Setup() {
        score = Score.GetInstance();
    }

    [Test]
    public void AddPointsTest() {
        score.ResetScore();
        score.AddPoints();
        Assert.AreEqual(score.Count, 1);
    }

    [Test]
    public void DecreasePointsTest() {
        score.ResetScore();
        score.AddPoints();
        score.DecreasePoints();
        Assert.AreEqual(score.Count, 0);
    }
    [Test]
    public void ScoreWillAlwaysBePositiveTest() {
        score.DecreasePoints();
        score.DecreasePoints();
        score.DecreasePoints();
        Assert.AreEqual(score.Count, 0);
    }

    [Test]
    public void ResetScoreTest() {
        score.ResetScore();
        Assert.AreEqual(score.Count, 0);
    }

}