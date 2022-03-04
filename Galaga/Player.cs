using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga {
    public class Player {
        float moveLeft = 0.0f;
        float moveRight = 0.0f;
        const float MOVEMENT_SPEED = 0.01f;
        private Entity entity;
        private DynamicShape shape;

        public Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }

        private void UpdateDirection() {

            this.shape.Direction.X = moveRight + moveLeft;

        }

        public void Move() {
            if (this.shape.Direction.X < 500U && this.shape.Direction.Y < 500U && this.shape.Direction.X > 0 && this.shape.Direction.Y > 0) {
                this.shape.Move();
            } else {
                System.Console.WriteLine("CANT FUCKING MOVE OKAY?");
            }

        }

        /* public void Move() {
            if (this.shape.Position.X >= 1 - this.shape.Extent.X) {
                this.shape.Position.X = 1 - this.shape.Extent.X;
            } else if (this.shape.Position.X <= 0) {
                this.shape.Position.X = 0;
            }
            shape.Move(); }*/


        public void SetMoveLeft(bool val) {
            if (val == true) {
                this.moveLeft = this.moveLeft - MOVEMENT_SPEED;
                UpdateDirection();

            } else {
                this.moveLeft = 0;
            }
            // TODO: set moveLeft appropriately and call UpdateMovement()

        }
        public void SetMoveRight(bool val) {
            if (val == true) {
                this.moveRight = this.moveRight + MOVEMENT_SPEED;
                UpdateDirection();

            } else {
                this.moveRight = 0;
            }


            // TODO:set moveRight appropriately and call UpdateMovement()
        }
        public void Render() {
            this.entity.RenderEntity();

        }

    }
}