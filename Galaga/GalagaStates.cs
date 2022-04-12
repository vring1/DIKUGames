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
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        public StateMachine() {
            GalagaBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            GalagaBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            IGameState ActiveState = MainMenu.GetInstance();
            //GameRunning.GetInstance();
        }
        public void ProcessEvent(GameEvent gameEvent){
            if (gameEvent.EventType == GameEventType.GameStateEvent){
                var state = gameEvent.Message;
                this.SwitchState(StateTransformer.TransformStringToState(state));
                switch(state) {
                    case "GAME_RUNNING":
                        ActiveState.RenderState();
                        break;
                    case "MAIN_MENU":
                        ActiveState.RenderState();
                        break;
                    default:
                        break;
                }
            }
        }
        private void SwitchState(GameStateType stateType) {
            switch (stateType)  {
                case GameStateType.GameRunning:
                    ActiveState = GameRunning.GetInstance();
                    break;
                case GameStateType.MainMenu:
                    ActiveState = MainMenu.GetInstance();
                    break;
                default:
                    break; 
                
                //SwitchState should change the ActiveState field to the IGameState matching the input GameStateType. '
                //As hinted by the fact that the StateMachine class implements the IGameEventProcessor interface, another method needs to be implemented as well.
            }
        }
    }
}