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

    public abstract class Block : Entity {
        public Block(Vec2F Position, IBaseImage Image, int HP) : base(new StationaryShape(Position, new Vec2F(0.083f, 0.04f)), Image) { 
        }
        
        public abstract void isHit();
        
        public abstract bool isUnbreakable();

        public abstract void DeleteBlock();
        
        public abstract void Render();
    }
}