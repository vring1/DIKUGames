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

        public float GetPositionX() {
            return shape.Position.X;
        }
        public void ResetPosition() {
            this.shape.Position.X = 0.45f;
        }

        public float GetPositionY() {
            return shape.Position.Y;
        }

        public void SwitchDirection() {
            shape.Direction.Y = -shape.Direction.Y;
            shape.Direction.X = -shape.Direction.X;
        }

        public void Render() {
            entity.RenderEntity();
        }

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

        public bool IsThisBallDeleted() {
            DeleteEntity();
            ballIsDeleted = true;
            return ballIsDeleted;
        }

        public float randy() { //returns a random float
            int number = rand.Next(-500, 501);
            float numf = (float) number;
            numf = numf / 100000;
            return numf;
        }
    }
}