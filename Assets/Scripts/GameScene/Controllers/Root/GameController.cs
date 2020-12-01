using System;
using System.Collections.Generic;
using Assets.Scripts.GameScene.Performances.Services;
using Assets.Scripts.MultiOriented;
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

        private EventManager _eventManager;
        private LevelN _level;
        private PlatformService _platformService;
        private ActionContainer _action;
        private BoundlessLoader _loader;
        private LevelLoader _levelLoader;

        private void Start()
        {
            Initialization();
            PostInitialization();
        }

        //////////////////////////////////////////////////////////////
        //////////////////Initialization objects/////////////////////
        void Initialization()
        {
            //Singletons
            _levelLoader = LevelLoader.GetLoader();
            _loader = BoundlessLoader.GetLoader();
            //PlatformService (Manager)
            _platformService = PlatformsContainer.GetComponent<PlatformService>(); 
            //Event manager
            _eventManager = EventSender.GetComponent<EventManager>();
            //Actions
            _action = new ActionContainer();
            //Level
            //_level = _levelLoader.Level;
            _level = new LevelN();
            _level = _action.GenerateLevel(_level);
            print(_level.Platforms);
        }

        //////////////////////////////////////////////////////////////
        ////////////Post Initialization(set initial data)////////////
        void PostInitialization()
        {
            //Load user settings
            _eventManager.Call(SettingsStates.Loaded);
            //Pause game
            _action.FreezeObject(Player);
            _action.FreezeObject(Ball);
            _eventManager.Call(GlobalStates.GamePaused);
            SettingsSingleton.GetSettings().IsGameStopped = true;
            //Set callback methods
            _platformService.OnPlatformDestroyed(RemovePlatformFromLevel);
            _platformService.OnAllPlatformDestroyed(LevelCompleted);
            //Set parent for spawned platforms
            _action.SetParent(_level, PlatformsContainer);
        }
        //////////////////////////////////////////////////////////////
        ///////////////////////Callback methods//////////////////////
        void LevelCompleted()
        {
            // AssetBoundle cashing
            _level = _action.GenerateLevel(_level);
        }

        void RemovePlatformFromLevel(Guid guid)
        {
            _action.RemovePlatformFromLevel(_level, guid);
        }
        //////////////////////////////////////////////////////////////
        /////////////////////////Game events/////////////////////////
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