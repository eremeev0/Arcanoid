using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.GameScene
{
    [Serializable]
    public class ConcretePlatform: MonoBehaviour
    {
        public Guid guid;
        public Vector3 position;
        public Color color;
        public int health = 1;
        public int points = 1;

        public void Initialization(Guid guid, Color color)
        {
            this.guid = guid;
            this.color = color;
        }
        public void Initialization(Guid guid, Color color, int health)
        {
            this.guid = guid;
            this.color = color;
            this.health = health;
        }

        //Unity Start Message
        private void Start()
        {
            GetComponent<SpriteRenderer>().color = color;
            position = transform.position;
        }


        public Guid GetGuid() { return guid;}
        public int GetHealth() { return health;}
        
        //Unity Update Message
        private void Update()
        {

        }

    }
}