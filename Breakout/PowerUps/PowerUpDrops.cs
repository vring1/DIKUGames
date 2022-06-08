using System;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout {
    public class PowerUpDrops : Entity {
        private static Vec2F extent = new Vec2F(0.05f, 0.05f);
        private static Vec2F direction = new Vec2F(0.0f, -0.01f);
        public PowerUpDrops(Vec2F pos, IBaseImage img) :
            base(new DynamicShape(pos, extent, direction), img) {
        }
    }
}