using System;
using Assets.Scripts.Cross.Models;
using Assets.Scripts.Cross.StatesManagament.ActionsContainer;
using Assets.Scripts.EventManagment.States;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Cross.StatesManagament.Provider
{
    public class EventManager: MonoBehaviour
    {
        private GlobalActionContainer _globalAction;
        private LevelActionsContainer _levelActions;
        private SettingsActionsContainer _settingsActions;
        void Start()
        {
            _globalAction = new GlobalActionContainer();
            _levelActions = new LevelActionsContainer();
            _settingsActions = new SettingsActionsContainer();
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="states"></param>
        /// <param name="gameObjects"></param>
        public void Call(GlobalStates states, params GameObject[] gameObjects)
        {
            Start();
            switch (states)
            {
                case GlobalStates.GameResumed:
                    _globalAction.ResumeGame(gameObjects[0], gameObjects[1]);
                    break;
                case GlobalStates.GamePaused:
                    _globalAction.PauseGame(gameObjects[0], gameObjects[1]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="states"></param>
        /// <param name="level"></param>
        /// <param name="jsonString"></param>
        public void Call(LevelStates states, LevelN level, [CanBeNull]string jsonString)
        {
            switch (states)
            {
                case LevelStates.Loaded:
                    _levelActions.LoadLevel(level, jsonString);
                    break;
                case LevelStates.Saved:
                    _levelActions.SaveLevel(level, jsonString);
                    break;
                case LevelStates.Generated:
                    _levelActions.GenerateLevel(level);
                    break;
                case LevelStates.PlatformsListUpdated:
                    _levelActions.RemovePositionFromList(level, JsonUtility.FromJson<Vector3>(jsonString));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="states"></param>
        public void Call(SettingsStates states)
        {
            switch (states)
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
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }


        public LevelN GenerateLevel(LevelN level)
        {
            var a = new GlobalActionContainer().GenerateLevel(level);
            return a;
        }
    }
}