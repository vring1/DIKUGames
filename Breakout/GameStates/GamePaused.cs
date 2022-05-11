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

namespace Breakout.GameStates {
    public class GamePaused : IGameState {
        private static GamePaused? instance = null;
        private Entity backGroundImage;
        private Text[] menuButtons;
        private int activeMenuButton = 0;
        private int maxMenuButtons;

        public static GamePaused GetInstance() {
            if (GamePaused.instance == null) {
                GamePaused.instance = new GamePaused();
                GamePaused.instance.InitializeGameState();
            }
            return GamePaused.instance;
        }

        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
        }
        public void RenderState() {

        }
        public void ResetState() {

        }
        public void UpdateState() {

        }
        public void InitializeGameState() {
            RenderState();
            UpdateState();
        }
    }
}