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
using System;
using DIKUArcade.State;

namespace Breakout {

    public enum StateGame {
        GameRunning,
        GamePaused,
        MainMenu,
        GameOver
    }

    public class ProcessStates : IGameState {

        public void ResetState() {

        }
        public void UpdateState() {

        }
        public void RenderState() {

        }
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {

        }
    }
}

