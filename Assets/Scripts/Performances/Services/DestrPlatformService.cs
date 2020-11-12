using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class DestrPlatformService: MonoBehaviour, IDestrPlatformService
    {
        private GameObject _list;
        private bool _isAllDestroyed;
        void Start()
        {
            _list = GameObject.Find("/ActiveObjects/Platforms");
            _isAllDestroyed = false;
        }

        void Update()
        {

        }

        public void Destroy()
        {
            if (_list.transform.childCount == 1)
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