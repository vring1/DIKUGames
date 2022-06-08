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
using DIKUArcade.Utilities;
using DIKUArcade.Timers;


namespace breakoutTests;

public class BreakoutTimerTest {
    public Breakout.BreakoutTimer timerTest;

    [SetUp]

    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        timerTest = BreakoutTimer.GetInstance();
    }

    [Test]
    public void TestSetTimer() {
        timerTest.SetBreakoutTimer(100);
        Assert.AreEqual(timerTest.gameTime, 100);

    }

    [Test]
    public void TestConutTimer() {

        timerTest.SetBreakoutTimer(100);
        for (int i = 0; i < 2; i++) {
            timerTest.CountTimer(timerTest.gameTime);
            System.Threading.Thread.Sleep(1000);
        }
        Assert.AreEqual(timerTest.currTimer, 99);

    }

    [Test]
    public void TestTimerRunOutTrue() {
        timerTest.SetBreakoutTimer(1);
        for (int i = 0; i < 2; i++) {
            timerTest.CountTimer(timerTest.gameTime);
            System.Threading.Thread.Sleep(1000);
        }
        System.Console.WriteLine(timerTest.currTimer);
        Assert.IsTrue(timerTest.TimerRunOut());

    }

    [Test]
    public void TestTimerRunOutFalse() {
        timerTest.SetBreakoutTimer(10);
        for (int i = 0; i < 2; i++) {
            timerTest.CountTimer(timerTest.gameTime);
            System.Threading.Thread.Sleep(1000);
        }
        System.Console.WriteLine(timerTest.currTimer);
        Assert.IsFalse(timerTest.TimerRunOut());

    }

    [Test]
    public void TestTimerAddTime() {
        timerTest.SetBreakoutTimer(10);
        timerTest.AddMoreTimePowerUp();
        Assert.AreEqual(timerTest.currTimer, 25);

    }
}