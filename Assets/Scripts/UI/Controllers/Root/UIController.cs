using System;
using Assets.Scripts.GameScene;
using Assets.Scripts.MultiOriented;
using Assets.Scripts.MultiOriented.Contracts;
using Assets.Scripts.MultiOriented.StatesManagament.Provider;
using Assets.Scripts.MultiOriented.StatesManagament.States;
using Assets.Scripts.UI.Controllers.Sub;
using UnityEngine;
using LevelStates = Assets.Scripts.GameScene.LevelStates;

namespace Assets.Scripts.UI.Controllers.Root
{
    /// <summary>
    /// class responsible for the logic of the game's user interface
    /// </summary>
    public class UIController: MonoBehaviour
    {
        private MenuController _menu;
        private SettingsController _settings;
        private FailedController _failed;
        private ScoreController _score;
        private SavesController _saves;
        private AudioManager _audioManager;

        public GameObject MenuPanel;
        public GameObject FailedPanel;
        public GameObject ScorePanel;
        public GameObject SettingsPanel;
        public GameObject SavesPanel;

        private EventManager _eventProvider;
        private LevelLoader _level;
        void Start()
        {
            _menu = GetComponentInChildren<MenuController>();
            _settings = GetComponentInChildren<SettingsController>();
            _failed = GetComponentInChildren<FailedController>();
            _score = GetComponentInChildren<ScoreController>();
            _saves = GetComponentInChildren<SavesController>();

            _menu.AddListener(Menu);
            _settings.AddListener(Settings);
            _failed.AddListener(Failed);
            _score.AddListener(Score);
            _saves.AddListener(Saves);

            FailedPanel.SetActive(false);
            ScorePanel.SetActive(false);
            SettingsPanel.SetActive(false);
            SavesPanel.SetActive(false);

            _level = LevelLoader.GetLoader();
            _eventProvider = gameObject.AddComponent<EventManager>();
            _audioManager = gameObject.AddComponent<AudioManager>();
            _audioManager.Play();
        }

        /////////////////////////////////////////////////////////////
        //////////////////////////Menu//////////////////////////////
        void Menu(MenuEvents @event)
        {
            switch (@event)
            {
                case MenuEvents.StartClicked:
                    _audioManager.Stop();
                    //_audioManager.
                    MenuPanel.SetActive(false);
                    ScorePanel.SetActive(true);
                    _eventProvider.Call(GlobalStates.GameStarted);
                    break;
                case MenuEvents.SettingsClicked:
                    MenuPanel.SetActive(false);
                    SettingsPanel.SetActive(true);
                    break;
                case MenuEvents.ExitClicked:
                    _eventProvider.Call(GlobalStates.GameClosed);
                    break;
                case MenuEvents.SavesClicked:
                    MenuPanel.SetActive(false);
                    SavesPanel.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        /////////////////////////////////////////////////////////////
        ////////////////////////Settings////////////////////////////
        void Settings(SettingsEvents @event)
        {
            switch (@event)
            {
                case SettingsEvents.SaveClicked:
                    _eventProvider.Call(SettingsStates.Saved);
                    break;
                case SettingsEvents.ResetClicked:
                    _eventProvider.Call(SettingsStates.Reset);
                    break;
                case SettingsEvents.BackToMenuClicked:
                    SettingsPanel.SetActive(false);
                    MenuPanel.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        /////////////////////////////////////////////////////////////
        //////////////////////////Score/////////////////////////////
        void Score()
        {
            if (SettingsSingleton.GetSettings().IsScoreUpdate)
            {
                _score.UpdateScore();
                _failed.ScoreLabel.text = $"Score {_score.GetScore()}";
                SettingsSingleton.GetSettings().IsScoreUpdate = false;
            }
        }
        /////////////////////////////////////////////////////////////
        /////////////////////////Failed/////////////////////////////
        void Failed(FailedEvent @event)
        {
            switch (@event)
            {
                case FailedEvent.RestartClicked:
                    FailedPanel.SetActive(false);
                    _eventProvider.Call(GlobalStates.GameRestarted);
                    SettingsSingleton.GetSettings().PlayerScore = 0;
                    SettingsSingleton.GetSettings().IsScoreUpdate = true;
                    break;
                case FailedEvent.BackToMenuClicked:
                    FailedPanel.SetActive(false);
                    ScorePanel.SetActive(false);
                    MenuPanel.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        /////////////////////////////////////////////////////////////
        ///////////////////////////Saves////////////////////////////
        void Saves(SavesEvents @event)
        {

            switch (@event)
            {
                case SavesEvents.Load:
                    _level.SaveName = "default";
                    _level.Run(LevelStates.LoadLevel);
                    break;
                case SavesEvents.Delete:
                    break;
                case SavesEvents.BackToMenu:
                    SavesPanel.SetActive(false);
                    MenuPanel.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        // move from update, switch to CallBack
        void Update()
        {
            if (SettingsSingleton.GetSettings().IsLevelFailed)
            {
                FailedPanel.SetActive(true);
                SettingsSingleton.GetSettings().IsLevelFailed = false;
            }
            Score();
        }
    }
}