using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.Cross.Models;
using Assets.Scripts.Cross.StatesManagament.Provider;
using Assets.Scripts.EventManagment.States;
using Assets.Scripts.Game.Performances.Interfaces;
using Assets.Scripts.Game.Performances.Services;
using Assets.Scripts.Game.Storage;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Game.Controllers.Root
{
    public class GameController: MonoBehaviour
    {
        public GameObject Player;
        public GameObject Ball;
        public GameObject PlatformsContainer;
        public GameObject EventSender;

        private DataManager _settingsStorage;
        private EventManager _eventManager;
        private LevelN level;
        private IBallService _ballService;

        private void Start()
        {;
            _ballService = Ball.GetComponent<BallService>();
            _settingsStorage = new DataManager();
            _settingsStorage.Load();
            
            _eventManager = EventSender.GetComponent<EventManager>();
            _eventManager.Call(GlobalStates.GamePaused, Player, Ball);
            SettingsSingleton.GetSettings().IsGameStopped = true;
            level = new LevelN();
            level = _eventManager.GenerateLevel(level);
            
            //SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
        }

        private void Update()
        {
            if (!SettingsSingleton.GetSettings().IsGameStopped)
            {
                _eventManager.Call(GlobalStates.GameResumed, Player, Ball);
            }

            if (SettingsSingleton.GetSettings().IsLevelComplete)
            {
                level = _eventManager.GenerateLevel(level);
               // SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
                SettingsSingleton.GetSettings().IsLevelComplete = false;

            }

            if (SettingsSingleton.GetSettings().IsLevelFailed)
            {
                _eventManager.Call(GlobalStates.GamePaused, Player, Ball);
            }

            if (_ballService.destroyedPlatform.IsAllDestroyed())
            {
                SettingsSingleton.GetSettings().IsLevelComplete = true;
            }
        }

        private static void SpawnPlatforms(GameObject sourceGameObject, Vector3[] clonePositions, GameObject clonesContainer = null)
        {
            GameObject clone;
            foreach (var clonePosition in clonePositions)
            {
                clone = Object.Instantiate(sourceGameObject, clonePosition, Quaternion.identity);
                clone.name = "Platform";
                clone.transform.parent = clonesContainer.transform;
            }
        }
    }
}