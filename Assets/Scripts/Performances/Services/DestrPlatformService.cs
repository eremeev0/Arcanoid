using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class DestrPlatformService: MonoBehaviour, IDestrPlatformService
    {
        private Sprite[] _destroyedPlatforms = GameObject.Find("/ActiveObjects/Platforms/Platform").GetComponents<Sprite>();
        private int _destroyed = 0;
        private bool _isAllDestroyed = false;
        void Start()
        {

        }

        void Update()
        {
            
        }

        public void IncrementDestroyed()
        {
            _destroyed++;
            if (_destroyed >= _destroyedPlatforms.Length)
            {
                _isAllDestroyed = true;
            }
        }

        public bool IsAllDestroyed()
        {
            return _isAllDestroyed;
        }
    }
}