using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using DIKUArcade.GUI;
//using DIKUArcade;




namespace Breakout {
    public class Player : IGameEventProcessor {

        private static Player instance = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.02f)),
                new Image(Path.Combine("Assets", "Images", "player.png")));
        float moveLeft = 0.0f;
        float moveRight = 0.0f;
        const float MOVEMENT_SPEED = 0.015f;
        private Entity entity;
        private DynamicShape shape;
        public DynamicShape Shape {
            get {
                return shape;
            }
        }

        private Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }

        public static Player GetInstance() {
            return instance;
        }
        public void ResetPosition() {
            this.shape.Position.X = 0.45f;
        }
        private void UpdateDirection() {
            this.shape.Direction.X = moveRight + moveLeft;
        }

        public void Move() {
            shape.Move();
            if (this.shape.Position.X <= 0) {
                this.shape.Position.X = 0;
            }
            if (this.shape.Position.X >= 1 - this.shape.Extent.X) {
                this.shape.Position.X = 1 - this.shape.Extent.X;
            }
        }


        private void SetMoveLeft(bool val) {
            if (val == true) {
                this.moveLeft = -MOVEMENT_SPEED;
            } else {
                this.moveLeft = 0.0f;
            }
            UpdateDirection();
            // TODO: set moveLeft appropriately and call UpdateMovement()

        }
        private void SetMoveRight(bool val) {
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

        public float GetPositionX() {
            return this.shape.Position.X;
        }

        public float GetPositionY() {
            return this.shape.Position.Y;
        }

        public void ProcessEvent(GameEvent gameEvent) {

            if (gameEvent.EventType == GameEventType.InputEvent) {
                switch (gameEvent.Message) {
                    case "Move_Left":
                        this.SetMoveLeft(true);
                        break;
                    case "Move_Right":
                        this.SetMoveRight(true);
                        break;
                    case "Release_Left":
                        this.SetMoveLeft(false);
                        break;
                    case "Release_Right":
                        this.SetMoveRight(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }

}