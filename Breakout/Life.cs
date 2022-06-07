
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
    /// <summary>
    /// The life of the player.
    /// </summary>
    public class Life {
        private static Life instance = new Life(new Vec2F(0.1f, 0.5f), new Vec2F(0.45f, 0.45f));
        private int count;
        public int Count {
            get {
                return count;
            }
        }
        private Text display;
        public Life(Vec2F position, Vec2F extent) {
            count = 2;
            display = new Text(count.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.Yellow);

        }
        /// <summary>
        /// Increments the count.
        /// </summary>
        public void AddLife() {
            count++;
        }
        /// <summary>
        /// Returns the instance field of the Life class.
        /// </summary>
        /// <returns>the instance of Life.</returns>
        public static Life GetInstance() {
            return instance;
        }
        /// <summary>
        /// Decrements the count.
        /// </summary>
        public void DecreaseLife() {
            if (count > 0) {
                count--;
            }
        }
        /// <summary>
        /// Renders the life to the screen.
        /// </summary>
        public void RenderLife() {
            display.RenderText();
        }
        /// <summary>
        /// Updates the life each frame and changes the color if life hits 1.
        /// </summary>
        public void UpdateLife() {
            display.SetText(count.ToString());
            if (count == 1) {
                display.SetColor(System.Drawing.Color.Red);
            }
        }
        /// <summary>
        /// checks if life equals 0.
        /// </summary>
        /// <returns>false or true depending on wheter life is zero or not</returns>
        public bool LifeIsZero() {
            if (this.count == 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// Resets the count to it's default value.
        /// </summary>
        public void ResetLife() {
            this.count = 1;
        }
    }

}