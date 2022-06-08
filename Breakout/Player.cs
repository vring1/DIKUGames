using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.GUI;

namespace Breakout {
    /// <summary>
    /// The player controlled by the user in the game.
    /// </summary>
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
        private PowerUpAbillties PowerUpInfinite;

        private Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }
        /// <summary>
        /// Returns the instance field of the Player class.
        /// </summary>
        /// <returns> the instance of the Player</returns>
        public static Player GetInstance() {
            return instance;
        }
        /// <summary>
        /// Resets the position of the player to the default place.
        /// </summary>
        public void ResetPosition() {
            this.shape.Position.X = 0.45f;
        }
        /// <summary>
        /// Updates the direction in which the player is able to move.
        /// </summary>
        private void UpdateDirection() {
            this.shape.Direction.X = moveRight + moveLeft;
        }
        /// <summary>
        /// Moves the player in the direction from UpdateDirection().
        /// </summary>
        public void Move() {
            shape.Move();
            if (this.shape.Position.X <= 0) {
                this.shape.Position.X = 0;
            }
            if (this.shape.Position.X >= 1 - this.shape.Extent.X) {
                this.shape.Position.X = 1 - this.shape.Extent.X;
            }
        }

        /// <summary>
        /// Sets the field moveLeft to a specific value depending on a bool.
        /// </summary>
        /// <param name="val"> bool for setting the moveLeft field.</param>
        private void SetMoveLeft(bool val) {
            if (val == true) {
                this.moveLeft = -MOVEMENT_SPEED;
            } else {
                this.moveLeft = 0.0f;
            }
            UpdateDirection();
        }
        /// <summary>
        /// Sets the field moveRight to a specific value depending on a bool.
        /// </summary>
        /// <param name="val"> bool for setting the moveRight field.</param>
        private void SetMoveRight(bool val) {
            if (val == true) {
                this.moveRight = MOVEMENT_SPEED;
            } else {
                this.moveRight = 0.0f;
            }
            UpdateDirection();
        }
        /// <summary>
        /// Renders the player.
        /// </summary>
        public void Render() {
            this.entity.RenderEntity();

        }
        /// <summary>
        /// Returns the position of the player at the moment.
        /// </summary>
        /// <returns>the position of the player</returns>
        public Vec2F GetPosition() {
            return this.shape.Position;
        }
        /// <summary>
        /// finds the x-coordinate corresponding to the player's position.
        /// </summary>
        /// <returns>the x-coordiante of the player's position</returns>
        public float GetPositionX() {
            return this.shape.Position.X;
        }
        /// <summary>
        /// finds the y-coordinate corresponding to the player's position.
        /// </summary>
        /// <returns>the y-coordiante of the player's position</returns>
        public float GetPositionY() {
            return this.shape.Position.Y;
        }
        /// <summary>
        /// Processes an event by switching on the message from the registered event.
        /// </summary>
        /// <param name="gameEvent"> a specfic registered GameEvent</param>
        public void ProcessEvent(GameEvent gameEvent) {
            PowerUpInfinite = new PowerUpAbillties();

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
                    //case "Release_Space":
                        //if (PowerUpInfinite.isInfinite = true)
                            //ballContainer.AddEntity(new Ball(new DynamicShape(new Vec2F(player.Shape.AsDynamicShape().Position.X + 0.06f,
                            //player.Shape.AsDynamicShape().Position.Y + 0.03f), new Vec2F(0.03f, 0.03f)),
                            //new Image(Path.Combine("Assets", "Images", "ball.png"))));
                        //break;
                    default:
                        break;
                }
            }
        }
    }

}