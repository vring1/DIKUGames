using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.State;

namespace Breakout;
/// <summary>
/// The bus that confirms different events.
/// </summary>
public static class BreakoutBus {
    private static GameEventBus eventBus;
    public static GameEventBus GetBus() {
        return BreakoutBus.eventBus ?? (BreakoutBus.eventBus = new GameEventBus());
    }
}