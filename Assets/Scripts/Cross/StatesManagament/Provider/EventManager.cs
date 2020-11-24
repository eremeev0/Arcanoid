using System;
using Assets.Scripts.Cross.StatesManagament.ActionsContainer;
using Assets.Scripts.EventManagment.States;
using UnityEngine;

namespace Assets.Scripts.Cross.StatesManagament.Provider
{
    public class EventManager: MonoBehaviour
    {
        private GlobalActionContainer _globalAction;

        void Start()
        {
            _globalAction = new GlobalActionContainer();
        }
        
        /// <summary>
        /// Call function by selected Global event
        /// </summary>
        /// <param name="states">Global state</param>
        public void Call(GlobalStates states)
        {
            Start();
            switch (states)
            {
                case GlobalStates.GameStarted:
                    _globalAction.StartGame();
                    break;
                case GlobalStates.GameClosed:
                    _globalAction.CloseGame();
                    break;
                case GlobalStates.SAVE_SETTINGS:
                    _globalAction.SaveSettings();
                    break;
                case GlobalStates.RESET_SETTINGS:
                    _globalAction.ResetSettings();
                    break;
                case GlobalStates.GameRestarted:
                    _globalAction.StartGame();
                    break;
                case GlobalStates.GameResumed:
                    _globalAction.ResumeGame();
                    break;
                case GlobalStates.GamePaused:
                    _globalAction.PauseGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }
    }
}