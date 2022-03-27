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

namespace Galaga.MovementStrategy {
public interface IMovementStrategy {
    void MoveEnemy (Enemy enemy);
    void MoveEnemies (EntityContainer<Enemy> enemies);
}
}