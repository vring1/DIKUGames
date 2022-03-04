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
            if (this.shape.Position.X <= 0) {
                this.shape.Position.X = 0;
            }
            if (this.shape.Position.X >= 1 - this.shape.Extent.X) {
                this.shape.Position.X = 1 - this.shape.Extent.X;
            }
            shape.Move();
        }


        public void SetMoveLeft(bool val) {
            if (val == true) {
                this.moveLeft = -MOVEMENT_SPEED;

            } else {
                this.moveLeft = 0.0f;
            }
            UpdateDirection();
            // TODO: set moveLeft appropriately and call UpdateMovement()

        }
        public void SetMoveRight(bool val) {
            if (val == true) {
                this.moveRight = MOVEMENT_SPEED;
            } else {
                this.moveRight = 0.0f;
            }
            UpdateDirection();


            // TODO:set moveRight appropriately and call UpdateMovement()
        }
        public void Render() {
            this.entity.RenderEntity();

        }

        public Vec2F GetPosition() {
            return this.shape.Position;
        }


    }


}