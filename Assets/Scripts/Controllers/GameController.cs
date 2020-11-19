using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using Assets.Scripts.Models.Game;
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

        private void Start()
        {
            _settingsStorage = new DataManager();
            _settingsStorage.Load();
            _eventManager = EventSender.GetComponent<EventManager>();
            print("Level 1 init start");
            level = new LevelN();
            print(level.GetType());
            level = _eventManager.GenerateLevel(level);
            print(level.GetType());
            SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
            _eventManager.Call(GlobalEvents.PAUSE_GAME, Player, Ball);
        }

        private void Update()
        {
            if (!SettingsDto.IsGameStopped)
            {
                _eventManager.Call(GlobalEvents.RESUME_GAME, Player, Ball);
            }

            if (SettingsDto.IsLevelComplete)
            {
                level = _eventManager.GenerateLevel(level);
                SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
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