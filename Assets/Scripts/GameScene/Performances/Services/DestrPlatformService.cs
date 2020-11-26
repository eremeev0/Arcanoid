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

        private UnityAction<Guid> _getPlatformPosition;
        private UnityAction _isAllPlatformsDestroyed;
        private readonly ObjectsManagement _objectsManagement;

        private DestrPlatformService()
        {
            _objectsManagement = ObjectsManagement.GetManagement();
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
            var guid = obj.GetComponent<GuidComponent>().guid;
            _objectsManagement.RemoveObjectById(guid);
            _getPlatformPosition.Invoke(guid);
        }

        public void OnPlatformDestroyed(UnityAction<Guid> action)
        {
            _getPlatformPosition = action;
        }
    }
}