using System;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.IO;
using DIKUArcade.Physics;
using Breakout.GameStates;
using DIKUArcade.Timers;

namespace Breakout
{
    public class PowerUpAbillties : StaticTimer {

        private readonly System.Int64 value;
        private Random rand = new Random();
        public DIKUArcade.Timers.StaticTimer PowerUpTimer;
        public bool isBaller = false;
        public bool isInvincible = false;
        public EntityContainer<PowerUpDrops> powerUpDropsContainer;
        private BreakoutTimer MoretimePower;
        private Life life;
        private int ballcount;


        
        public void RandDirection(EntityContainer<Ball> ballS, Ball ball)
        {
            ballS.Iterate(ballz =>
            {
                ballz.Shape.AsDynamicShape().Direction.Y = ball.randy()*5;
                ballz.Shape.AsDynamicShape().Direction.X = ball.randy();
            });
        }

        public void SplitBalls(EntityContainer<Ball> ballS, Ball ball)
        {
            ballS.Iterate(ballz =>
            {
                ballS.AddEntity(new Ball(new DynamicShape(new Vec2F(ballz.Shape.AsDynamicShape().Position.X, ballz.Shape.AsDynamicShape().Position.Y), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
                ballS.AddEntity(new Ball(new DynamicShape(new Vec2F(ballz.Shape.AsDynamicShape().Position.X, ballz.Shape.AsDynamicShape().Position.Y), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
                RandDirection(ballS, ball);
            });
        }

        //Adds an extra life
        public void ExtraLife()
        {
            life = Life.GetInstance();
            life.AddLife();
        }

        //Spawns and launches a new ball from the player
        public void Invincible()
        {
       
            PowerUpTimer = new DIKUArcade.Timers.StaticTimer();
            int timer = Convert.ToInt32(DIKUArcade.Timers.StaticTimer.GetElapsedSeconds());
            while (timer <= 69);
                isInvincible = true;
            isInvincible = false;
        }

        public void MoreTime()
        {
            MoretimePower = BreakoutTimer.GetInstance();

            MoretimePower.AddMoreTimePowerUp();
        }

        public void Baller()
        {
            PowerUpTimer = new DIKUArcade.Timers.StaticTimer();
            int timer = Convert.ToInt32(DIKUArcade.Timers.StaticTimer.GetElapsedSeconds());
            while (timer <= 0);
               isBaller = true;
            isBaller = false;
        }




        public EntityContainer<PowerUpDrops> DropPowerUp(EntityContainer<PowerUpDrops> powerUpDropsContainer, Vec2F pos)
        {
            powerUpDropsContainer.AddEntity(new PowerUpDrops(pos, new Image(Path.Combine("Assets", "Images", "SplitPowerUp.png"))));
            return powerUpDropsContainer;   
        }

        
        public void Iterate(EntityContainer<PowerUpDrops> powerUpDropsContainer, EntityContainer<Ball> ballContainer,
        Ball ball, Life life, Score score, Player player, int ballcount)
        {
            powerUpDropsContainer.Iterate(powerups =>
            {
                powerups.Shape.Move();
                if (CollisionDetection.Aabb(powerups.Shape.AsDynamicShape(), player.Shape).Collision)
                {
                    
                    switch (rand.Next(1, 3))
                    {
                        case 1:
                            SplitBalls(ballContainer, ball);
                            powerups.DeleteEntity();
                            break;
                        case 4:
                            Invincible();
                            powerups.DeleteEntity();
                            break;
                        case 2:
                            ExtraLife();
                            powerups.DeleteEntity();
                            break;
                        case 3:
                            MoreTime();
                            powerups.DeleteEntity();
                            break;
                        case 5:
                            Baller();
                            powerups.DeleteEntity();
                            break;
                        default:
                            SplitBalls(ballContainer, ball);
                            powerups.DeleteEntity();
                            Console.WriteLine("default");
                            break;
                    }
                }
            });
        }


    }
}