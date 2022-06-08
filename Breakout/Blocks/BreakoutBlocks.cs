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

namespace Breakout {
    /// <summary>
    /// Abstract class that the different blocks should inherit from.
    /// </summary>
    public abstract class Block : Entity {
        public Block(Vec2F Position, IBaseImage Image, int HP) : base(new StationaryShape(Position, new Vec2F(0.083f, 0.04f)), Image) {
        }
        /// <summary>
        /// Decrements the HP of the block in an appropriate manor.
        /// </summary>
        public abstract void isHit();
        /// <summary>
        /// checks if a block is unbreakable.
        /// </summary>
        /// <returns>true if the block is unbreakable, otherwise false</returns>
        public abstract bool isUnbreakable();
        /// <summary>
        /// Deletes the block.
        /// </summary>
        public abstract void DeleteBlock(EntityContainer<PowerUpDrops> powerUpDropsContainer);
        /// <summary>
        /// Renders the block.
        /// </summary>
        public abstract void Render();
    }
}