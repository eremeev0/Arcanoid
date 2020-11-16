using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.Performances.Services;
using Assets.Scripts.StorageProvider.Service;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController: MonoBehaviour
    {
        void Start()
        {
            ContainerService.TryInitialize();
            ContainerDto.Manager.SendEvent(GameEvents.SPAWN_OBJECTS, ContainerDto.Platform, SpawnerDto.GetSpawner().LVL_1);
            DataManager manager = new DataManager();
            manager.Load();
        }

        void Update()
        {
            // get destroyed platform list
        }
    }
}