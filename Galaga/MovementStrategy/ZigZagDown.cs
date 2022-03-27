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
using Galaga.Squadron; 
using Galaga.MovementStrategy;
using System;


namespace Galaga.MovementStrategy {
    public class ZigZagDown: IMovementStrategy{
        private float amplitude = 0.05f;
        private float posDif = 0.045f;
        public void MoveEnemy (Enemy enemy){
            enemy.Shape.Position.Y = enemy.Shape.Position.Y - enemy.Speed;
            enemy.Shape.Position.X = enemy.x0 - amplitude* (float) Math.Sin((2*Math.PI*(enemy.y0-enemy.Shape.Position.Y))/posDif);
        }
        public void MoveEnemies (EntityContainer<Enemy> enemies) {
            foreach (Enemy elem in enemies){
                MoveEnemy(elem);
            }
        }
    }  
}        
