using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.StorageProvider.Service;
using UnityEngine;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;

namespace Assets.Scripts.Controllers
{
    public class GameController: MonoBehaviour
    {
        private GameObject go;
        void Start()
        {
            
           DataManager manager = new DataManager();
            manager.Load();
        }

        void Update()
        {
            // get destroyed platform list
            go = GameObject.Find("/ActiveObjects/Platforms/Platform");
            // if all platforms destroyed go to next level
            if (go == null)
            {
                new EventProvider().SendEvent(GameEvents.GAME_PAUSED);
                // level 2 init here
            }
        }
    }
}