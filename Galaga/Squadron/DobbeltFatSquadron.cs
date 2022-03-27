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


namespace Galaga.Squadron {
    public class DobbeltFatSquadron : ISquadron {

        public EntityContainer<Enemy> Enemies {get;}
        public int MaxEnemies {get;}

    
        public DobbeltFatSquadron () {
            MaxEnemies = 12;
            Enemies = new EntityContainer<Enemy>(MaxEnemies);
        }
        
        public void CreateEnemies (List<Image> enemyStride,
            List<Image> alternativeEnemyStride){
            //var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 0 * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 0 * 0.1f, 0.7f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 2 * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 2 * 0.1f, 0.7f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 4 * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 4 * 0.1f, 0.7f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 6 * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                Enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float) 6 * 0.1f, 0.7f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, enemyStride), new ImageStride(80,alternativeEnemyStride), 0.0015f
                ));
                
            
        }



          
}
}