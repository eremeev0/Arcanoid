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
        void Start()
        {
            _settingsStorage = new DataManager();
            _settingsStorage.Load();
        }

        void Update()
        {

        }
    }
}