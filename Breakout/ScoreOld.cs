/*using DIKUArcade.Entities;
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

    public class ScoreOld {
        private static int score;
        private Text display;
        public Score(Vec2F position, Vec2F extent) {
            score = 0;
            display = new Text(score.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
        }
        public void AddPoints() {
            score++;
        }

        public void DecreasePoints() {
            if (score > 0) {
                score--;
            }
        }
        public void RenderScore() {
            display.RenderText();
        }

        public void UpdateScore() {
            display.SetText(score.ToString());
        }
    }

}*/