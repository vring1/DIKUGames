using System;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using System.IO;
using DIKUArcade.State;
using System.Threading.Tasks;
using DIKUArcade.Events;
using System.Timers;
using System.Diagnostics;

namespace Breakout {
    /// <summary>
    /// Handles collisions.
    /// </summary>
    public class CollisionDetect {
        private Life life;
        private PowerUpAbillties PowerUpColl;

        /// <summary>
        /// Detects the ball collides with anything.
        /// </summary>
        /// <param name="ballContainer"> the container with the ball(s)</param>
        /// <param name="player">the player instance</param>
        /// <param name="ball">the ball which collides with the other parameters</param>
        /// <param name="blockContainer">the container with blocks</param>
        /// <param name="powerUpDropsContainer">The container holding the dropped powerups</param>
        /// <param name="pos">The position of the ball(s)</param>
        public void BallDetec(EntityContainer<Ball> ballContainer, Player player, Ball ball, Life life,
            EntityContainer<Block> blockContainer, EntityContainer<PowerUpDrops> powerUpDropsContainer, Vec2F pos) {
            PowerUpColl = new PowerUpAbillties();
            ballContainer.Iterate(ballz => {
                ballz.shape.Move();
                if (ballz.Shape.Position.Y < 0) {
                    ballz.DeleteEntity();
                }
                if (ballz.shape.Position.X > 0.97f) {
                    ballz.shape.Direction.X *= -1;
                    ballz.shape.Position.X = 0.97f;
                }
                if (ballz.shape.Position.X < 0.0f) {
                    ballz.shape.Direction.X *= -1;
                    ballz.shape.Position.X = 0.00f;
                }
                if (ballz.shape.Position.Y > 0.99f) {
                    ballz.shape.Direction.Y *= -1;
                    ballz.shape.Position.Y = 0.99f;
                }
                if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), player.Shape).Collision) {
                    Random rand = new Random();
                    if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), player.Shape).CollisionDir == CollisionDirection.CollisionDirUp) {
                        ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F((float) ball.randy() * 2, 0.015f));

                    } else if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), player.Shape).CollisionDir == CollisionDirection.CollisionDirLeft) {
                        ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F(ballz.Shape.AsDynamicShape().Direction.X * -1,
                            ballz.Shape.AsDynamicShape().Direction.Y * -1));
                    } else if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), player.Shape).CollisionDir == CollisionDirection.CollisionDirRight) {
                        ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F(ballz.Shape.AsDynamicShape().Direction.X * -1,
                            ballz.Shape.AsDynamicShape().Direction.Y * -1));
                    }
                } else {
                    blockContainer.Iterate(block => {
                        if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), block.Shape).CollisionDir == CollisionDirection.CollisionDirDown) {
                            block.isHit();
                            ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F(ballz.Shape.AsDynamicShape().Direction.X, ballz.Shape.AsDynamicShape().Direction.Y * -1));
                            block.DeleteBlock(powerUpDropsContainer);


                        } else if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), block.Shape).CollisionDir == CollisionDirection.CollisionDirUp) {
                            block.isHit();
                            ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F(ballz.Shape.AsDynamicShape().Direction.X, ballz.Shape.AsDynamicShape().Direction.Y * -1));
                            block.DeleteBlock(powerUpDropsContainer);



                        } else if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), block.Shape).CollisionDir == CollisionDirection.CollisionDirLeft) {
                            block.isHit();
                            ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F(ballz.Shape.AsDynamicShape().Direction.X * -1, ballz.Shape.AsDynamicShape().Direction.Y));
                            block.DeleteBlock(powerUpDropsContainer);


                        } else if (CollisionDetection.Aabb(ballz.Shape.AsDynamicShape(), block.Shape).CollisionDir == CollisionDirection.CollisionDirRight) {
                            block.isHit();
                            ballz.Shape.AsDynamicShape().ChangeDirection(new Vec2F(ballz.Shape.AsDynamicShape().Direction.X * -1, ballz.Shape.AsDynamicShape().Direction.Y));
                            block.DeleteBlock(powerUpDropsContainer);



                        }
                    }
                    );
                }
            });
            if (ballContainer.CountEntities() <= 0) {
                if (PowerUpColl.isInvincible = true)
                    ballContainer.AddEntity(new Ball(new DynamicShape(new Vec2F(player.Shape.AsDynamicShape().Position.X + 0.06f,
                    player.Shape.AsDynamicShape().Position.Y + 0.03f), new Vec2F(0.03f, 0.03f)),
                    new Image(Path.Combine("Assets", "Images", "ball.png"))));

                else
                    life = Life.GetInstance();
                    life.DecreaseLife();
                    ballContainer.AddEntity(new Ball(new DynamicShape(new Vec2F(player.Shape.AsDynamicShape().Position.X + 0.06f,
                    player.Shape.AsDynamicShape().Position.Y + 0.03f), new Vec2F(0.03f, 0.03f)),
                    new Image(Path.Combine("Assets", "Images", "ball.png"))));
            }
        }

    }
}