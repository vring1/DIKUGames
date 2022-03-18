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


namespace Galaga {
    public class HeartSquadron : ISquadron {

        public EntityContainer<Enemy> Enemies {get;}
        public int MaxEnemies {get;}
    
    

        public HeartSquadron (EntityContainer<Enemy> Enemies, int MaxEnemies) {
            Enemies = this.Enemies;
            MaxEnemies = this.MaxEnemies;
        }
        
        public void CreateEnemies (List<Image> enemyStride,
        List<Image> alternativeEnemyStride){
            //var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            const int numEnemies = 8;
            for (int i = 0; i < numEnemies; i++) {
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.5f + (float) i * 0.4f, 0.3f), new Vec2F(0.6f, 0.8f)),
                    new ImageStride(80, enemyStride)/*, new ImageStride(80,alternativeEnemyStride)*/
                    ));
            }
            
        }



          
}
}