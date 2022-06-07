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

public class StateTransformerTest {


    [SetUp]
    public void Setup() {

    }

    [Test]
    public void TransformStringToStateTest() {
        Assert.AreEqual(StateTransformer.TransformStringToState("GAME_RUNNING"), GameStateType.GAME_RUNNING);
        Assert.AreEqual(StateTransformer.TransformStringToState("GAME_OVER"), GameStateType.GAME_OVER);
        Assert.AreEqual(StateTransformer.TransformStringToState("GAME_PAUSED"), GameStateType.GAME_PAUSED);
        Assert.AreEqual(StateTransformer.TransformStringToState("MAIN_MENU"), GameStateType.MAIN_MENU);
        Assert.AreEqual(StateTransformer.TransformStringToState("MAIN_MENU"), GameStateType.MAIN_MENU);
        Assert.Throws<ArgumentException>(() => StateTransformer.TransformStringToState("hej"));
    }

    [Test]
    public void TransformStateToStringTest() {
        Assert.AreEqual(StateTransformer.TransformStateToString(GameStateType.GAME_RUNNING), "GAME_RUNNING");
        Assert.AreEqual(StateTransformer.TransformStateToString(GameStateType.GAME_OVER), "GAME_OVER");
        Assert.AreEqual(StateTransformer.TransformStateToString(GameStateType.GAME_PAUSED), "GAME_PAUSED");
        Assert.AreEqual(StateTransformer.TransformStateToString(GameStateType.MAIN_MENU), "MAIN_MENU");
    }




}