
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

    public class Life {
        private static Life instance = new Life(new Vec2F(0.1f, 0.5f), new Vec2F(0.45f, 0.45f));
        private int count;
        private Text display;
        public Life(Vec2F position, Vec2F extent) {
            count = 2;
            display = new Text(count.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.Yellow);

        }
        public void AddLife() {
            count++;
        }
        public static Life GetInstance() {
            return instance;
        }

        public void DecreaseLife() {
            if (count > 0) {
                count--;
            }
        }

        public void RenderLife() {
            display.RenderText();
        }

        public void UpdateLife() {
            display.SetText(count.ToString());
            if (count == 1) {
                display.SetColor(System.Drawing.Color.Red);
            }
        }
        public bool LifeIsZero() {
            if (this.count == 0) {
                return true;
            } else {
                return false;
            }
        }

        public void ResetLife() {
            this.count = 1;
        }
    }

}