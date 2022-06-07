using System;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.IO;
using DIKUArcade.Events;
using DIKUArcade.Physics;

namespace Breakout {
    /// <summary>
    /// The ball for the game.
    /// </summary>
    public class Ball : Entity {
        public DynamicShape shape;
        private Entity entity;
        public Vec2F startPosition;
        private bool ballIsDeleted = false;
        private Random rand = new Random();

        public Ball(DynamicShape shape, IBaseImage image) : base(shape, image) {
            entity = new Entity(shape, image);
            this.startPosition = Shape.Position;
            this.shape = shape;
            shape.Direction.Y = 0.01f;
            shape.Direction.X = -0.01f;
        }
        /// <summary>
        /// finds the x-coordinate corresponding to the ball's position.
        /// </summary>
        /// <returns>the x-coordiante of the ball's position</returns>
        public float GetPositionX() {
            return shape.Position.X;
        }
        /// <summary>
        /// Resets the position of the ball to the default place.
        /// </summary>
        public void ResetPosition() {
            this.shape.Position.X = 0.45f;
        }
        /// <summary>
        /// finds the y-coordinate corresponding to the ball's position.
        /// </summary>
        /// <returns>the y-coordiante of the ball's position</returns>
        public float GetPositionY() {
            return shape.Position.Y;
        }
        /// <summary>
        /// Switches the direction of which the ball moves
        /// </summary>
        public void SwitchDirection() {
            shape.Direction.Y = -shape.Direction.Y;
            shape.Direction.X = -shape.Direction.X;
        }
        /// <summary>
        /// Renders the ball to the screen.
        /// </summary>
        public void Render() {
            entity.RenderEntity();
        }
        /// <summary>
        /// Moves the ball.
        /// </summary>
        public void MoveBall() {
            if (shape.Position.X > 1.0f) {
                shape.Direction.X *= -1.0f;
                shape.Position.X = 0.95F;
            }
            if (shape.Position.X < 0.0f) {
                shape.Direction.X *= -1.0f;
                shape.Position.X = 0;
            }
            if (shape.Position.Y > 1.0f) {
                shape.Direction.Y *= -1.0f;
                shape.Position.Y = 1;
            }

            if (shape.Position.Y <= 0)
                DeleteEntity();

            shape.Move(shape.Direction.X, shape.Direction.Y);
        }
        /// <summary>
        /// Checks if a ball is deleted.
        /// </summary>
        /// <returns>true if ball is deleted</returns>
        public bool IsThisBallDeleted() {
            DeleteEntity();
            ballIsDeleted = true;
            return ballIsDeleted;
        }
        /// <summary>
        /// Generates random number.
        /// </summary>
        /// <returns>the float randomly generated</returns>
        public float randy() {
            int number = rand.Next(-500, 501);
            float numf = (float) number;
            numf = numf / 100000;
            return numf;
        }
    }
}