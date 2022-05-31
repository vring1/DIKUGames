
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
            count = 1;
            display = new Text(count.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
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

        public bool IsLifeZero(Life currentlife){
            if(currentlife.count != 0 && currentlife.count !<0){
                return false;
            }else{
                return true;
            }
        }
        public void RenderLife() {
            display.RenderText();
        }

        public void UpdateLife() {
            display.SetText(count.ToString());
        }
    }

}