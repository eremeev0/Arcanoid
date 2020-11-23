using System;
using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.Cross.StatesManagament.Provider;
using Assets.Scripts.EventManagment.States;
using Assets.Scripts.UI.Controllers.Sub;
using UnityEngine;

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
        void Menu(MenuEvents @event)
        {
            switch (@event)
            {
                case MenuEvents.StartClicked:
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
                    _eventProvider.Call(GlobalStates.SAVE_SETTINGS);
                    break;
                case SettingsEvents.ResetClicked:
                    _eventProvider.Call(GlobalStates.RESET_SETTINGS);
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