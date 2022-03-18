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


namespace Galaga.Squadron {
    public interface ISquadron {
        EntityContainer<Enemy> Enemies {get;}
        int MaxEnemies {get;}
        void CreateEnemies (List<Image> enemyStride,
        List<Image> alternativeEnemyStride);
}
}