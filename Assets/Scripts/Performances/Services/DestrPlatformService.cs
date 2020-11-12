using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class DestrPlatformService: MonoBehaviour, IDestrPlatformService
    {
        private Sprite _destroyedPlatforms;
        private int _destroyed = 0;
        private bool _isAllDestroyed = false;
        void Start()
        {
            //_destroyedPlatforms = GameObject.Find("/ActiveObjects/Platforms").GetComponentInChildren<Sprite>();
        }

        void Update()
        {
            
        }

        public void Destroy()
        {
            /*Destroy(_destroyedPlatforms);
            _destroyedPlatforms = GameObject.Find("/ActiveObjects/Platforms").GetComponentInChildren<Sprite>();
            if (_destroyedPlatforms == null)
            {
                _isAllDestroyed = true;
            }*/
        }

        public bool IsAllDestroyed()
        {
            return _isAllDestroyed;
        }
    }
}