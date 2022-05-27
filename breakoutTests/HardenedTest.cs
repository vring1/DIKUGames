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

namespace breakoutTests;

public class HardenedTest {
    private Breakout.Hardened hard;

    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();

        hard = (new Hardened
                (new Vec2F(0.5f, 0.5f),
                 new Image(Path.Combine
                ("Assets", "Images", "blue-block.png")), new Image(Path.Combine("Assets", "Images", "blue-block.png")), 1));
    }



    [Test]
    public void TestBlockHP() {
        int currHP = hard.HP;
        hard.isHit();
        Assert.AreNotEqual(hard.HP, currHP);

    }
}