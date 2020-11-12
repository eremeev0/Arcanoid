using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.Performances.Services;
using Assets.Scripts.StorageProvider.Service;
using UnityEngine;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;

namespace Assets.Scripts.Controllers
{
    public class GameController: MonoBehaviour
    {
        private GameObject go;
        private IDestrPlatformService _destrService;
        void Start()
        {
            _destrService = gameObject.AddComponent<DestrPlatformService>(); 
            DataManager manager = new DataManager();
            manager.Load();
        }

        void Update()
        {
            // get destroyed platform list
            
        }
    }
}