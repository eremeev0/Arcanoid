using UnityEngine;

namespace Assets.Scripts.Contracts
{
    public class ScriptObject: ScriptableObject
    {
        public int num { get; set; } = 10;
        void Start()
        {
            Debug.Log("Start");
        }

        void Update()
        {
            Debug.Log("Update");
        }
    }
}