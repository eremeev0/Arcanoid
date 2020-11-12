using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class DestrPlatformService: MonoBehaviour, IDestrPlatformService
    {
        private GameObject _list;
        private int _destroyed = 0;
        private bool _isAllDestroyed;
        void Start()
        {
            _list = GameObject.Find("/ActiveObjects/Platforms");
            print(_list.transform.childCount);
            _isAllDestroyed = false;
        }

        void Update()
        {
            //print(_list.GetComponentsInChildren<Sprite>());
            //print(_list);
        }

        public void Destroy()
        {
            print(_list.transform.childCount);
            if (_list.transform.childCount == 1)
            {
                _isAllDestroyed = true;
            }
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