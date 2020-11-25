using Assets.Scripts.GameScene.Performances.Interfaces;
using Assets.Scripts.GameScene.Performances.Services;
using Assets.Scripts.GameScene.Storage;
using Assets.Scripts.MultiOriented.Contracts;
using Assets.Scripts.MultiOriented.Models;
using Assets.Scripts.MultiOriented.StatesManagament.Provider;
using Assets.Scripts.MultiOriented.StatesManagament.States;
using UnityEngine;

namespace Assets.Scripts.GameScene.Controllers.Root
{
    public class GameController: MonoBehaviour
    {
        public GameObject Player;
        public GameObject Ball;
        public GameObject PlatformsContainer;
        public GameObject EventSender;

        private DataManager _settingsStorage;
        private EventManager _eventManager;
        private LevelN _level;
        private IBallService _ballService;
        private ActionContainer _action;
        private BoundlessLoader _loader;
        private void Start()
        {  
            _ballService = Ball.GetComponent<BallService>();
            _settingsStorage = new DataManager();
            _settingsStorage.Load();
            
            _eventManager = EventSender.GetComponent<EventManager>();
            _action.FreezeObject(Player);
            _action.FreezeObject(Ball);
            _eventManager.Call(GlobalStates.GamePaused);
         
            SettingsSingleton.GetSettings().IsGameStopped = true;
            
            _ballService.destroyedPlatform.OnPlatformDestroyed(UpdatePlatformsList);
            _ballService.destroyedPlatform.OnAllPlatformDestroyed(LevelCompleted);

            _level = new LevelN();
            _level = _action.GenerateLevel(_level);
            _loader = BoundlessLoader.GetLoader();
            //SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
        }

        void StartPlay()
        {
            // _action.PlayGame();
        }

        void LevelCompleted()
        {
            _level = _action.GenerateLevel(_level);
            _action.SpawnObjects(_loader.GetGameObject("platform", "Platform"), _level.PlatformsPosition, PlatformsContainer);
        }

        // Level run
        void LevelInitial()
        {
            if (_level == null)
            {
               _level = _action.LevelInit();
            }
            else
            {
               _level = _action.LoadLevel("default");
            }
        }

        void UpdatePlatformsList(Vector3 removedPlatformPosition)
        {
            _action.UpdatePlatformsList(_level, removedPlatformPosition);
        }
        private void Update()
        {
            if (!SettingsSingleton.GetSettings().IsGameStopped)
            {
                _action.UnFreezeObject(Player);
                _action.UnFreezeObject(Ball);
                _eventManager.Call(GlobalStates.GameResumed);
            }

            /*if (SettingsSingleton.GetSettings().IsLevelComplete)
            {
                _level = _eventManager.GenerateLevel(_level);
               // SpawnPlatforms(level.Platform, level.PlatformsPosition, PlatformsContainer);
                SettingsSingleton.GetSettings().IsLevelComplete = false;

            }

            if (_ballService.destroyedPlatform.IsAllDestroyed())
            {
                SettingsSingleton.GetSettings().IsLevelComplete = true;
            }*/

            if (SettingsSingleton.GetSettings().IsLevelFailed)
            {
                _action.FreezeObject(Player);
                _action.FreezeObject(Ball);
                _eventManager.Call(GlobalStates.GamePaused);
            }
        }

    }
}