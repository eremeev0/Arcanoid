using UnityEngine;

namespace Assets.Scripts
{
    public class GameLogic: MonoBehaviour
    {
        private GameObject go;
        void Start()
        {
           // DataManager manager = gameObject.AddComponent<DataManager>();
           // manager.Load();
        }

        void Update()
        {
            // get destroyed platform list
            go = GameObject.Find("/ActiveObjects/Platforms/Platform");
            // if all platforms destroyed go to next level
            if (go == null)
            { 
                // level 2 init here
            }
        }
    }
}