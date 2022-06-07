
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.GUI;

namespace Breakout {
    /// <summary>
    /// Is used for keeping track at the score in the game.
    /// </summary>
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
        /// <summary>
        /// Increments the count.
        /// </summary>
        public void AddPoints() {
            count++;
        }
        /// <summary>
        /// Returns the instance field of the Score class.
        /// </summary>
        /// <returns>the instance of Score.</returns>
        public static Score GetInstance() {
            return instance;
        }
        /// <summary>
        /// Decrements the count.
        /// </summary>
        public void DecreasePoints() {
            if (count > 0) {
                count--;
            }
        }
        /// <summary>
        /// Renders the score to the screen.
        /// </summary>
        public void RenderScore() {
            display.RenderText();
        }
        /// <summary>
        /// Updates the score each frame.
        /// </summary>
        public void UpdateScore() {
            display.SetText(count.ToString());
        }
        /// <summary>
        /// Resets the score to it's default value.
        /// </summary>
        public void ResetScore() {
            this.count = 0;
        }

    }

}