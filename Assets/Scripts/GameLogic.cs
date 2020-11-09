using UnityEngine;

namespace Assets.Scripts
{
    public class GameLogic: MonoBehaviour
    {
        private GameObject go;
        void Start()
        {

        }

        void Update()
        {
            go = GameObject.Find("/ActiveObjects/Platforms/Platform");
            if (go == null)
            { 
                // player win
            }
        }
    }
}