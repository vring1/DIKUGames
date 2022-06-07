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
    public class Hardened : Block {
        Score score;
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

        public Hardened(Vec2F Position, IBaseImage Image, IBaseImage altImage, int HP)
            : base(Position, Image, HP) {
            shape = new StationaryShape(Position, new Vec2F(0.083f, 0.04f));
            this.AltImage = altImage;
            this.HP = HP * 2;
            score = Score.GetInstance();
        }

        public float GetThisPositionX() {
            return shape.Position.X;
        }

        public float GetThisPositionY() {
            return shape.Position.Y;
        }
        public override bool isUnbreakable() {
            return false;
        }

        public override void isHit() {
            if (HP > 0) {
                HP = HP - 1;
            }
        }

        public override void DeleteBlock() {
            if (HP <= 0) {
                DeleteEntity();
                score.AddPoints();
                score.AddPoints();
            }
        }

        public override void Render() {
            if (!IsDeleted()) {
                image.Render(shape);
            }
        }
        private void ChangeImage() {
            Image = AltImage;
        }

    }
}