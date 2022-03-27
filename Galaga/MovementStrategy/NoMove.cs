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


namespace Galaga.MovementStrategy {
    public class NoMove : IMovementStrategy{
        public void MoveEnemy (Enemy enemy) {
            enemy.Shape.Position.Y = enemy.Shape.Position.Y;
        }
        public void MoveEnemies (EntityContainer<Enemy> enemies){
            foreach (Enemy elem in enemies){
                MoveEnemy(elem);
            }
        }
    }  
}