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

namespace Breakout;

public class Block : Entity {

    private StationaryShape shape;
    private Entity entity;
    private int HP { get; set; } = 1;
    public void isHit() {
        HP--;
    }
    public Block(StationaryShape shape, IBaseImage image) : base(shape, image) {
        entity = new Entity(shape, image);
        this.shape = shape;
    }

    public void Render() {
        this.entity.RenderEntity();
    }

    public Vec2F GetPosition() {
        return this.shape.Position;
    }

}
