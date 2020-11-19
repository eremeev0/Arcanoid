using System;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Models.Game;
using UnityEngine;

namespace Assets.Scripts.EventManagment.Provider
{
    public class EventManager: MonoBehaviour
    {
        private GlobalEventManager _globalEventManager;

        void Start()
        {
            _globalEventManager = new GlobalEventManager();
        }

        void Update()
        {

        }

        /// <summary>
        /// Call function by selected Global event
        /// </summary>
        /// <param name="event">Global event</param>
        public void Call(GlobalEvents @event)
        {
            Start();
            switch (@event)
            {
                case GlobalEvents.START_GAME:
                    _globalEventManager.StartGame();
                    break;
                case GlobalEvents.CLOSE_GAME:
                    _globalEventManager.CloseGame();
                    break;
                case GlobalEvents.SAVE_SETTINGS:
                    _globalEventManager.SaveSettings();
                    break;
                case GlobalEvents.RESET_SETTINGS:
                    _globalEventManager.ResetSettings();
                    break;
                case GlobalEvents.RESTART_GAME:
                    _globalEventManager.StartGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        public void Call(GlobalEvents @event, params GameObject[] gameObjects)
        {
            Start();
            switch (@event)
            {
                case GlobalEvents.RESUME_GAME:
                    _globalEventManager.ResumeGame(gameObjects[0], gameObjects[1]);
                    break;
                case GlobalEvents.PAUSE_GAME:
                    _globalEventManager.PauseGame(gameObjects[0], gameObjects[1]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        public LevelN GenerateLevel(LevelN level)
        {
            var a = new GlobalEventManager().GenerateLevel(level);
            return a;
        }
    }
}