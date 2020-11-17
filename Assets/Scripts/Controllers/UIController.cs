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
        private EventManager _eventProvider;
        void Start()
        {
            _menu = GetComponentInChildren<MenuController>();
            _settings = GetComponentInChildren<SettingsController>();
            _failed = GetComponentInChildren<FailedController>();
            _score = GetComponentInChildren<ScoreController>();

            _settings.gameObject.SetActive(false);
            _score.gameObject.SetActive(false);
            _failed.gameObject.SetActive(false);
        }

        void Update()
        {
            if (_menu._showScore)
            {
                _menu._showScore = false;
                _menu.gameObject.SetActive(false);
                _score.gameObject.SetActive(true);
            }

            if (_settings._showMenu)
            {
                _settings._showMenu = false;
                _settings.gameObject.SetActive(false);
                _menu.gameObject.SetActive(true);
            }

            if (_failed._showMenu)
            {
                _failed._showMenu = false;
                _failed.gameObject.SetActive(false);
                _score.gameObject.SetActive(false);
                _menu.gameObject.SetActive(true);
            }
        }
    }
}