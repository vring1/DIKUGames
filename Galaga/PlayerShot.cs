using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;

namespace Galaga {
    public class PlayerShot : Entity {
        public static Vec2F direction = new Vec2F(0.0f, 0.1f);
        public static Vec2F extent = new Vec2F(0.008f, 0.021f);
        public PlayerShot(DynamicShape shape, IBaseImage image) : base(shape, image) {

        }

    }







}