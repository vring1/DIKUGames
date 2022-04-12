using System;
using NUnit.Framework;
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
using Galaga; 

namespace galagaTests {

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GameRunningTransformStringToState()
    {
        Assert.IsTrue(StateTransformer.TransformStringToState("GAME_RUNNING") == GameStateType.GameRunning);
        
    }
    
    [Test]
    public void GamePausedTransformStringToState(){
        Assert.IsTrue(StateTransformer.TransformStringToState("GAME_PAUSED") == GameStateType.GamePaused);    
    }

    [Test]
    public void MainMenuTransformStringToState(){
        Assert.IsTrue(StateTransformer.TransformStringToState("MAIN_MENU") == GameStateType.MainMenu);   
    }
    
    [Test]
    public void WrongInputTransformStringToState(){
        Assert.Throws<ArgumentException>(delegate {
            StateTransformer.TransformStringToState("blab");
        });
    }

    [Test]
    public void GameRunningTransformStateToString(){
        Assert.IsTrue(StateTransformer.TransformStateToString(GameStateType.GameRunning) == "GAME_RUNNING");
    }

    [Test]
    public void GamePausedTransformStateToString(){
        Assert.IsTrue(StateTransformer.TransformStateToString(GameStateType.GamePaused) == "GAME_PAUSED");

    }
    
    [Test]
    
    public void MainMenuTransformStateToString(){
        Assert.IsTrue(StateTransformer.TransformStateToString(GameStateType.MainMenu) == "MAIN_MENU");
    }

}
}








