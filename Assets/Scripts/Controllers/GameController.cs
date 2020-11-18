using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
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
        void Start()
        {
            _settingsStorage = new DataManager();
            _settingsStorage.Load();
            _eventManager = EventSender.GetComponent<EventManager>();

            _eventManager.Call(GlobalEvents.PAUSE_GAME, Player, Ball);
        }

        void Update()
        {
            if (!SettingsDto.IsGameStopped)
            {
                _eventManager.Call(GlobalEvents.RESUME_GAME, Player, Ball);
            }
        }
    }
}