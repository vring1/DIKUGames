using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Security.Principal;
using System.Collections.Generic;
//using DIKUArcade.EventBus;
using DIKUArcade.Events;
using DIKUArcade.State;

namespace Galaga {
    public static class GalagaBus {
        private static GameEventBus eventBus;
        public static GameEventBus GetBus() {
            return GalagaBus.eventBus ?? (GalagaBus.eventBus = new GameEventBus());
        }
    }
}