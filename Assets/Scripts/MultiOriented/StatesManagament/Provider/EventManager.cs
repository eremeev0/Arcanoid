using System;
using Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer;
using Assets.Scripts.MultiOriented.StatesManagament.States;
using UnityEngine;

namespace Assets.Scripts.MultiOriented.StatesManagament.Provider
{
    public class EventManager: MonoBehaviour
    {
        private GlobalActionContainer _globalAction;
        private SettingsActionsContainer _settingsActions;
        void Start()
        {
            _globalAction = new GlobalActionContainer();
            _settingsActions = new SettingsActionsContainer();
        }
        
        /// <summary>
        /// Call function by selected Global event
        /// </summary>
        /// <param name="state">Global state</param>
        public void Call(GlobalStates state)
        {
            Start();
            switch (state)
            {
                case GlobalStates.GameStarted:
                    _globalAction.StartGame();
                    break;
                case GlobalStates.GameClosed:
                    _globalAction.CloseGame();
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
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public void Call(SettingsStates state)
        {
            Start();
            switch (state)
            {
                case SettingsStates.Loaded:
                    _settingsActions.LoadSettings();
                    break;
                case SettingsStates.Saved:
                    _settingsActions.SaveSettings();
                    break;
                case SettingsStates.Reset:
                    _settingsActions.ResetSettings();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}