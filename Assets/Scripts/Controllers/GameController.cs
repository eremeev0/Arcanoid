using Assets.Scripts.Initializers;
using Assets.Scripts.StorageProvider.Service;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController: MonoBehaviour
    {
        private Initializer _initializer;
        void Start()
        {
            _initializer = new Initializer();
            _initializer.UIObjectsInitialization();
            //ContainerService.TryInitialize();
            //ContainerDto.Manager.SendEvent(GameEvents.SPAWN_OBJECTS, ContainerDto.Platform, SpawnerDto.GetSpawner().LVL_1);
            DataManager manager = new DataManager();
            manager.Load();
        }

        void Update()
        {
            // get destroyed platform list
        }
    }
}