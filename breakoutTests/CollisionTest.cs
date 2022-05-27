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

namespace breakoutTests;

public class CollisionTest {
    private Ball ball;
    private CollisionDetect collisionDetection;
    public EntityContainer<Block> blockContainer;
    private Player player;
    public EntityContainer<Ball> ballContainer;
    public LevelLoader level;
    private EntityContainer<Block> TestContainer;
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        player = Player.GetInstance();
        ball = new Ball(
                new DynamicShape(new Vec2F(0.45f, 0.8f), new Vec2F(0.0f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png")));
        collisionDetection = new CollisionDetect();
        level = new LevelLoader();
        EntityContainer<Block> TestContainer = new EntityContainer<Block>();
        TestContainer.AddEntity(new Blocks
                             (new Vec2F(0.0f, 0.0f),
                              new Image(Path.Combine
                            ("Assets", "Images", "grey-block.png")), new Image(Path.Combine("Assets", "Images", "grey-block.png")), 1));
    }

    

    [Test]
    public void TestTopColl() {
        blockContainer = level.AddBlocks(@"Assets/Levels/levelTest.txt");
        EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
        ballContainer.AddEntity(new Ball(
                new DynamicShape(new Vec2F(0.45f, 0.95f), new Vec2F(0.0f, -0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png"))));
        for(int i = 0 ; i < 100; i ++){
            ball.MoveBall();
        }
        collisionDetection.BallDetec(ballContainer, player, ball, blockContainer, new Vec2F(player.GetPositionX(), 0.2f));
        Assert.AreNotEqual(blockContainer, TestContainer);
    }

    [Test]
    public void TestBottomColl() {
        blockContainer = level.AddBlocks(@"Assets/Levels/levelTest.txt");
        EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
        ballContainer.AddEntity(new Ball(
                new DynamicShape(new Vec2F(0.45f, 0.5f), new Vec2F(0.0f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png"))));
        for(int i = 0 ; i < 100; i ++){
            ball.MoveBall();
        }
        collisionDetection.BallDetec(ballContainer, player, ball, blockContainer, new Vec2F(player.GetPositionX(), 0.2f));
        Assert.AreNotEqual(blockContainer, TestContainer);
    }

    [Test]
    public void TestLeftColl() {
        blockContainer = level.AddBlocks(@"Assets/Levels/levelTest.txt");
        EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
        ballContainer.AddEntity(new Ball(
                new DynamicShape(new Vec2F(0.1f, 0.8f), new Vec2F(0.03f, 0.0f)),
                new Image(Path.Combine("Assets", "Images", "ball.png"))));
        for(int i = 0 ; i < 100; i ++){
            ball.MoveBall();
        }
        collisionDetection.BallDetec(ballContainer, player, ball, blockContainer, new Vec2F(player.GetPositionX(), 0.2f));
        Assert.AreNotEqual(blockContainer, TestContainer);
    }

    [Test]
    public void TestRightColl() {
        blockContainer = level.AddBlocks(@"Assets/Levels/levelTest.txt");
        EntityContainer<Ball> ballContainer = new EntityContainer<Ball>();
        ballContainer.AddEntity(new Ball(
                new DynamicShape(new Vec2F(0.8f, 0.8f), new Vec2F(-0.03f, 0.0f)),
                new Image(Path.Combine("Assets", "Images", "ball.png"))));
        for(int i = 0 ; i < 100; i ++){
            ball.MoveBall();
        }
        collisionDetection.BallDetec(ballContainer, player, ball, blockContainer, new Vec2F(player.GetPositionX(), 0.2f));
        Assert.AreNotEqual(blockContainer, TestContainer);
    }
}