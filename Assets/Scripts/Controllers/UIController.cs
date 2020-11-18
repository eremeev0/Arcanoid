using Assets.Scripts.Contracts;
using Assets.Scripts.Contracts.Service;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
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

            FailedPanel.SetActive(false);
            ScorePanel.SetActive(false);
            SettingsPanel.SetActive(false);
            _eventProvider = gameObject.AddComponent<EventManager>();
        }

        void Update()
        {
            /////////////////////////////////////////////////////////////
            //////////////////////////Menu//////////////////////////////
            if (_menu.IsShowScore)
            {
                _menu.IsShowScore = false;
                MenuPanel.SetActive(false);
                ScorePanel.SetActive(true);
                _eventProvider.Call(GlobalEvents.START_GAME);
                // start game
            }

            if (_menu.IsShowSettings)
            {
                _menu.IsShowSettings = false;
                MenuPanel.SetActive(false);
                SettingsPanel.SetActive(true);
            }

            if (_menu.IsCloseGame)
            {
                _eventProvider.Call(GlobalEvents.CLOSE_GAME);
                // close app
            }

            /////////////////////////////////////////////////////////////
            ////////////////////////Settings////////////////////////////
            if (_settings.IsShowMenu)
            {
                _settings.IsShowMenu = false;
                SettingsPanel.SetActive(false);
                MenuPanel.SetActive(true);
            }

            if (_settings.IsSaveSettings)
            {
                _settings.IsSaveSettings = false;
                _eventProvider.Call(GlobalEvents.SAVE_SETTINGS);
                // save game settings
            }

            if (_settings.IsResetSettings)
            {
                _settings.IsResetSettings = false;
                _eventProvider.Call(GlobalEvents.RESET_SETTINGS);
                // reset game settings
            }

            /////////////////////////////////////////////////////////////
            /////////////////////////Failed/////////////////////////////
            if (_failed.IsShowMenu)
            {
                _failed.IsShowMenu = false;
                FailedPanel.SetActive(false);
                ScorePanel.SetActive(false);
                MenuPanel.SetActive(true);
            }

            if (_failed.IsRestartGame)
            {
                _failed.IsRestartGame = false;
                _eventProvider.Call(GlobalEvents.RESTART_GAME);
                // restart game
            }

            /////////////////////////////////////////////////////////////
            //////////////////////////Score/////////////////////////////
            if (_score.IsScoreUpdate)
            {
                _score.IsScoreUpdate = false;
                _failed.ScoreLabel.text = $"Score {_score.GetScore()}";
            }

            /////////////////////////////////////////////////////////////
        }
    }
}