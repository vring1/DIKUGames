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
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using System;
using Breakout.GameStates;

namespace Breakout {
    /// <summary>
    /// The basic block.
    /// </summary>
    public class Blocks : Block {
        private Score score;
        private IBaseImage image {
            get; set;
        }

        private StationaryShape shape {
            get; set;
        }

        private IBaseImage AltImage {
            get; set;
        }
        public int HP {
            get; set;
        }

        public Blocks(Vec2F Position, IBaseImage Image, IBaseImage altImage, int HP)
                : base(Position, Image, HP) {
            shape = new StationaryShape(Position, new Vec2F(0.083f, 0.04f));
            this.HP = HP;
            image = Image;
            AltImage = altImage;
            score = Score.GetInstance();

        }
        /// <summary>
        /// finds the x-coordinate corresponding to the block's position.
        /// </summary>
        /// <returns>the x-coordiante of the block's position</returns>
        public float GetThisPositionX() {
            return shape.Position.X;
        }
        /// <summary>
        /// finds the y-coordinate corresponding to the block's position.
        /// </summary>
        /// <returns>the y-coordiante of the block's position</returns>
        public float GetThisPositionY() {
            return shape.Position.Y;
        }
        /// <summary>
        /// checks if a block is unbreakable.
        /// </summary>
        /// <returns>true if the block is unbreakable, otherwise false</returns>
        public override bool isUnbreakable() {
            return false;
        }
        /// <summary>
        /// Decrements the HP of the block in an appropriate manor.
        /// </summary>
        public override void isHit() {
            if (HP > 0) {
                HP = HP - 1;
            }
        }
        /// <summary>
        /// Deletes the block.
        /// </summary>
        public override void DeleteBlock(EntityContainer<PowerUpDrops> powerUpDropsContainer) {
            if (HP <= 0) {
                DeleteEntity();
                score.AddPoints();
            }
        }
        /// <summary>
        /// Renders the block.
        /// </summary>
        public override void Render() {
            if (!IsDeleted()) {
                image.Render(shape);
            }
        }
    }
}