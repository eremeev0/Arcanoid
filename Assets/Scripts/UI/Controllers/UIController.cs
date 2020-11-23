﻿using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.Cross.StatesManagament.Provider;
using Assets.Scripts.EventManagment.States;
using Assets.Scripts.UI.Controllers.Root;
using UnityEngine;

namespace Assets.Scripts.UI.Controllers
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

        public GameObject MenuPanel;
        public GameObject FailedPanel;
        public GameObject ScorePanel;
        public GameObject SettingsPanel;

        private EventManager _eventProvider;
        void Start()
        {
            _menu = GetComponentInChildren<MenuController>();
            _settings = GetComponentInChildren<SettingsController>();
            _failed = GetComponentInChildren<FailedController>();
            _score = GetComponentInChildren<ScoreController>();

            _menu.AddListener(Menu);
            _settings.AddListener(Settings);
            _failed.AddListener(Failed);
            _score.AddListener(Score);

            FailedPanel.SetActive(false);
            ScorePanel.SetActive(false);
            SettingsPanel.SetActive(false);
            
            _eventProvider = gameObject.AddComponent<EventManager>();
        }

        /////////////////////////////////////////////////////////////
        //////////////////////////Menu//////////////////////////////
        void IsShowScore() { }
        void IsShowSettings() { }
        void IsCloseGame() { }
        void Menu()
        {
            if (_menu.IsShowScore)
            {
                MenuPanel.SetActive(false);
                ScorePanel.SetActive(true);
                _eventProvider.Call(GlobalStates.GameStarted);
                _menu.IsShowScore = false;
                // start game
            }
            if (_menu.IsShowSettings)
            {
                MenuPanel.SetActive(false);
                SettingsPanel.SetActive(true);
                _menu.IsShowSettings = false;
            }
            if (_menu.IsCloseGame)
            {
                _eventProvider.Call(GlobalStates.GameClosed);
                // close app
            }
        }
        /////////////////////////////////////////////////////////////
        ////////////////////////Settings////////////////////////////
        void IsShowMenu() { }
        void IsSaveSettings() { }
        void IsResetSettings() { }
        void Settings()
        {
            if (_settings.IsShowMenu)
            {
                SettingsPanel.SetActive(false);
                MenuPanel.SetActive(true);
                _settings.IsShowMenu = false;
            }

            if (_settings.IsSaveSettings)
            {
                _eventProvider.Call(GlobalStates.SAVE_SETTINGS);
                _settings.IsSaveSettings = false;
                // save game settings
            }

            if (_settings.IsResetSettings)
            {
                _eventProvider.Call(GlobalStates.RESET_SETTINGS);
                _settings.IsResetSettings = false;
                // reset game settings
            }
        }
        /////////////////////////////////////////////////////////////
        //////////////////////////Score/////////////////////////////
        void IsScoreUpdate() { }
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
        void IsShowMenu2() { }
        void IsRestartGame() { }
        void IsShowFailed() { }
        void Failed()
        {
            if (_failed.IsShowMenu)
            {
                FailedPanel.SetActive(false);
                ScorePanel.SetActive(false);
                MenuPanel.SetActive(true);
                _failed.IsShowMenu = false;
            }

            if (_failed.IsRestartGame)
            {
                FailedPanel.SetActive(false);
                _eventProvider.Call(GlobalStates.GameRestarted);
                SettingsSingleton.GetSettings().PlayerScore = 0;
                SettingsSingleton.GetSettings().IsScoreUpdate = true;
                _failed.IsRestartGame = false;
                // restart game
            }
            if (SettingsSingleton.GetSettings().IsLevelFailed)
            {
                FailedPanel.SetActive(true);
                SettingsSingleton.GetSettings().IsLevelFailed = false;
            }
        }

        // move from update, switch to CallBack
        void Update()
        { }
    }
}