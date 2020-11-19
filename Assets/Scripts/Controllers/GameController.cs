using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using Assets.Scripts.Models.Game;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.Performances.Services;
using Assets.Scripts.StorageProvider.Service;
using UnityEngine;

namespace Assets.Scripts.Controllers
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
        {
            _ballService = Ball.GetComponent<BallService>();
            _settingsStorage = new DataManager();
            _settingsStorage.Load();
            
            _eventManager = EventSender.GetComponent<EventManager>();
            _eventManager.Call(@event: GlobalEvents.PAUSE_GAME, Player, Ball);
            SettingsDto.IsGameStopped = true;
            level = new LevelN();
            level = _eventManager.GenerateLevel(level: level);
            
            SpawnPlatforms(sourceGameObject: level.Platform, clonePositions: level.PlatformsPosition, clonesContainer: PlatformsContainer);
        }

        private void Update()
        {
            if (!SettingsDto.IsGameStopped)
            {
                _eventManager.Call(GlobalEvents.RESUME_GAME, Player, Ball);
            }

            if (SettingsDto.IsLevelComplete)
            {
                SettingsDto.IsLevelComplete = false;
                level = _eventManager.GenerateLevel(level);
                SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
            }

            if (SettingsDto.IsLevelFailed)
            {
                _eventManager.Call(GlobalEvents.PAUSE_GAME, Player, Ball);
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