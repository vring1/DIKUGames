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

public class LifeTest {
    Life life;

    [SetUp]
    public void Setup() {
        life = Life.GetInstance();
    }

    [Test]
    public void AddLifeTest() {
        life.AddLife();
        Assert.AreEqual(life.Count, 2);
    }

    [Test]
    public void DecreaseLifeTest() {
        life.DecreaseLife();
        life.DecreaseLife();
        Assert.AreEqual(life.Count, 0);
    }
    [Test]
    public void LifeCanNeverBeNegativeTest() {
        life.DecreaseLife();
        life.DecreaseLife();
        life.DecreaseLife();
        life.DecreaseLife();
        life.DecreaseLife();
        Assert.AreEqual(life.Count, 0);
    }

    [Test]
    public void LifeIsZeroTest() {
        life.AddLife();
        Assert.False(life.LifeIsZero());
        life.DecreaseLife();
        Assert.True(life.LifeIsZero());
    }
    [Test]
    public void ResetLifeTest() {
        life.ResetLife();
        Assert.AreEqual(life.Count, 1);
    }


}