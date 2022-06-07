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

public class BallTest {
    private Ball ball;
    [SetUp]
    public void Setup() {
        DIKUArcade.GUI.Window.CreateOpenGLContext();
        ball = new Ball(
                new DynamicShape(new Vec2F(0.485f, 0.1275f), new Vec2F(0.03f, 0.03f)),
                new Image(Path.Combine("Assets", "Images", "ball.png")));
    }

    [Test]
    public void GetPositionBallTest() {
        float posY = ball.GetPositionY();
        float posX = ball.GetPositionX();

        Assert.AreEqual(ball.GetPositionX(), posX);
        Assert.AreEqual(ball.GetPositionY(), posY);
    }

    [Test]
    public void DeleteBallBottomTest() {
        ball.shape.Direction.X = 0.0f;
        ball.shape.Direction.Y = -1.0f;
        ball.MoveBall();
        Assert.IsTrue(ball.IsThisBallDeleted());
    }

    [Test]
    public void SwitchDirectionTest() {
        ball.MoveBall();
        Assert.IsTrue(ball.IsThisBallDeleted());
    }

    [Test]
    public void VerticalDirectionBallTest() {
        float posY = ball.GetPositionY();
        float posX = ball.GetPositionX();
        ball.shape.Direction.X = 0.0f;
        ball.shape.Direction.Y = 0.01f;
        ball.MoveBall();
        ball.MoveBall();
        Assert.AreEqual(posX, ball.shape.Position.X);
        Assert.IsFalse(ball.shape.Position.Y < 0.14f);
    }
}