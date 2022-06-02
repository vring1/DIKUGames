
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

    public class Score {
        private static Score instance = new Score(new Vec2F(0.9f, 0.5f), new Vec2F(0.45f, 0.45f));
        private int count;
        public int Count {
            get {
                return count;
            }
        }
        private Text display;
        public Score(Vec2F position, Vec2F extent) {
            count = 0;
            display = new Text(count.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
        }
        public void AddPoints() {
            count++;
        }
        public static Score GetInstance() {
            return instance;
        }

        public void DecreasePoints() {
            if (count > 0) {
                count--;
            }
        }
        public void RenderScore() {
            display.RenderText();
        }

        public void UpdateScore() {
            display.SetText(count.ToString());
        }
        public void ResetScore() {
            this.count = 0;
        }

    }

}