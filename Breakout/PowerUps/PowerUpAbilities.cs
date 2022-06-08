using System;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.IO;
using DIKUArcade.Physics;
using Breakout.GameStates;
using DIKUArcade.Timers;

namespace Breakout {
    public class PowerUpAbillties : StaticTimer {

        private readonly System.Int64 value;
        private Random rand = new Random();
        public DIKUArcade.Timers.StaticTimer PowerUpTimer;
        public bool isInfinite = false;
        public bool isInvincible = false;
        public EntityContainer<PowerUpDrops> powerUpDropsContainer;
        private BreakoutTimer MoretimePower;
        private Life life;
        private int ballcount;


        /// <summary>
        /// Gives the balls a random direction.
        /// </summary>
        /// <param name="ballS">An entitycontainer that contains the balls</param>
        /// <param name="ball">The ball class</param>

        public void RandDirection(EntityContainer<Ball> ballS, Ball ball) {
            ballS.Iterate(ballz => {
                ballz.Shape.AsDynamicShape().Direction.Y = ball.randy() * 5;
                ballz.Shape.AsDynamicShape().Direction.X = ball.randy();
            });
        }

        /// <summary>
        /// Splits every ball into three versions of itself.
        /// </summary>
        /// <param name="ballS">An entitycontainer that contains the balls</param>
        /// <param name="ball">The ball class</param>
        public void SplitBalls(EntityContainer<Ball> ballS, Ball ball) {
            ballS.Iterate(ballz => {
                ballS.AddEntity(new Ball(new DynamicShape(new Vec2F(ballz.Shape.AsDynamicShape().Position.X, ballz.Shape.AsDynamicShape().Position.Y), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
                ballS.AddEntity(new Ball(new DynamicShape(new Vec2F(ballz.Shape.AsDynamicShape().Position.X, ballz.Shape.AsDynamicShape().Position.Y), new Vec2F(0.03f, 0.03f)), new Image(Path.Combine("Assets", "Images", "ball.png"))));
                RandDirection(ballS, ball);
            });
        }

        /// <summary>
        /// Adds an extra life.
        /// </summary>
        public void ExtraLife() {
            life = Life.GetInstance();
            life.AddLife();
        }

        /// <summary>
        /// Makes it so that during a time period you dont lose a life.
        /// </summary>
        public void Invincible() {

            PowerUpTimer = new DIKUArcade.Timers.StaticTimer();
            int timer = Convert.ToInt32(DIKUArcade.Timers.StaticTimer.GetElapsedSeconds());
            while (timer <= 69)
                ;
            isInvincible = true;
            isInvincible = false;
        }

        /// <summary>
        /// Adds more time.
        /// </summary>
        public void MoreTime() {
            MoretimePower = BreakoutTimer.GetInstance();

            MoretimePower.AddMoreTimePowerUp();
        }

        /// <summary>
        /// Makes it so that during a time period can spawn a new ball at the player.
        /// </summary>
        public void Infinite() {
            PowerUpTimer = new DIKUArcade.Timers.StaticTimer();
            int timer = Convert.ToInt32(DIKUArcade.Timers.StaticTimer.GetElapsedSeconds());
            while (timer <= 0)
                ;
            isInfinite = true;
            isInfinite = false;
        }



        /// <summary>
        /// Adds a PowerUp entity to the PowerUpDrops container.
        /// </summary>
        /// <param name="powerUpDropsContainer">An entitycontainer that contains the powerUps</param>
        /// <param name="Vec2F">Is a vector</param>
        public EntityContainer<PowerUpDrops> DropPowerUp(EntityContainer<PowerUpDrops> powerUpDropsContainer, Vec2F pos) {
            powerUpDropsContainer.AddEntity(new PowerUpDrops(pos, new Image(Path.Combine("Assets", "Images", "SplitPowerUp.png"))));
            return powerUpDropsContainer;
        }

        /// <summary>
        /// Iterates through PowerUpDrops container to check for collisions between powerups and the player and calls the corresponding powerUp.
        /// </summary>
        /// <param name="powerUpDropsContainer">An entitycontainer that contains the powerUps</param>
        /// <param name="ballContainer">Is a vector</param>
        /// <param name="ball">The ball class</param>
        /// <param name="life">The life class</param>
        /// <param name="score">The score class</param>
        /// <param name="player">The player class</param>
        /// <param name="ballcount">An intiger for the amount of balls</param>

        public void Iterate(EntityContainer<PowerUpDrops> powerUpDropsContainer, EntityContainer<Ball> ballContainer,
        Ball ball, Life life, Score score, Player player, int ballcount) {
            powerUpDropsContainer.Iterate(powerups => {
                powerups.Shape.Move();
                if (CollisionDetection.Aabb(powerups.Shape.AsDynamicShape(), player.Shape).Collision) {

                    switch (rand.Next(1, 3)) {
                        case 1:
                            SplitBalls(ballContainer, ball);
                            powerups.DeleteEntity();
                            break;
                        case 2:
                            MoreTime();
                            powerups.DeleteEntity();
                            break;
                        case 3:
                            ExtraLife();
                            powerups.DeleteEntity();
                            break;
                        case 4:
                            Invincible();
                            powerups.DeleteEntity();
                            break;
                        case 5:
                            Infinite();
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