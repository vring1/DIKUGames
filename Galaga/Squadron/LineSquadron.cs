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


namespace Galaga.Squadron {
    public class LineSquadron : ISquadron {

        public EntityContainer<Enemy> Enemies {get;}
        public int MaxEnemies {get;}

    
        public LineSquadron () {
            MaxEnemies = 8;
            Enemies = new EntityContainer<Enemy>(MaxEnemies);
        }
        
        public void CreateEnemies (List<Image> enemyStride,
            List<Image> alternativeEnemyStride){
            //var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            for (int i = 0; i < MaxEnemies; i++) {
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0f
                ));
            }
            
        }



          
}
}