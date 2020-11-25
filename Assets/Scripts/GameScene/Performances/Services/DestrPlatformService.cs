using System;
using Assets.Scripts.GameScene.Performances.Interfaces;
using Assets.Scripts.MultiOriented;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Assets.Scripts.GameScene.Performances.Services
{
    public class DestrPlatformService
    {
        private static DestrPlatformService _platformService;

        private UnityAction<Vector3> _getPlatformPosition;
        private UnityAction _isAllPlatformsDestroyed;
        private ObjectsManagement _management;

        private DestrPlatformService()
        {
            _management = ObjectsManagement.GetManagement();
        }

        public static DestrPlatformService GetPlatformService()
        {
            return _platformService ?? (_platformService = new DestrPlatformService());
        }

        public void OnAllPlatformDestroyed(UnityAction action)
        {
            _isAllPlatformsDestroyed = action;
        }

        public void Destroy(GameObject obj)
        {
            if (obj.transform.parent.childCount == 1)
            {
                _isAllPlatformsDestroyed.Invoke();
                //_isAllDestroyed = true;
            }
            // use guid
            // class.Remove(id)
            _management.Remove(new Guid());
            _getPlatformPosition.Invoke(obj.transform.position);
            Object.Destroy(obj);
        }

        public void OnPlatformDestroyed(UnityAction<Vector3> action)
        {
            _getPlatformPosition = action;
        }
    }
}