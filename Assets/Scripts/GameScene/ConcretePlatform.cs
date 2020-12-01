using System;
using Assets.Scripts.MultiOriented;
using UnityEngine;

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

        private ParticleManager _particles;
        
        public void BeforeDestroy()
        {
            _particles.Play();
        }

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
            _particles = gameObject.AddComponent<ParticleManager>();
            GetComponent<SpriteRenderer>().color = color;
            position = transform.position;
        }

        public Guid GetGuid() { return guid;}
        public int GetHealth() { return health;}
    }
}