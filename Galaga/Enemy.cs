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
using Galaga.MovementStrategy;


namespace Galaga {

    public class Enemy : Entity{

        private int hitPoints = 60;

        public int HitPoints{
            get{return hitPoints;}
            set{hitPoints = value;}
        }

        //private IBaseImage currentStride;
        private IBaseImage alternativeStride;
        private float speed = 0.005f;
        public float Speed{
            get{return speed;}
            set{speed = value;}
        }
        public float y0;
        public float x0;
        
        public Enemy(DynamicShape shape, IBaseImage currentStride, IBaseImage alternativeStride, float speed)
        : base(shape, currentStride) {
            //this.currentStride = currentStride;
            this.alternativeStride = alternativeStride;
            this.speed = speed;
            y0 = this.Shape.Position.Y;
            x0 = this.Shape.Position.X;
        }
        

        public bool IsShot(){
            if (this.HitPoints < 31) {
                //speed sættes op
                //this.Image = alternativeStride;
                return true;
            }
            return false;
            
        }

        public bool IsAtBottomOfScreen(){
            if (this.Shape.Position.Y <= 0.1){
                return true;
            }
            return false;
        }
        

    }

}