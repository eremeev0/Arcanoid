using Assets.Scripts.GameScene.Performances.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameScene.Performances.Services
{
    public class DestrPlatformService: IDestrPlatformService
    {
        private bool _isAllDestroyed;
        private UnityAction<Vector3> _getPlatfromPosition;
        private UnityAction _isAllPlatfromsDestroyed;
        public DestrPlatformService()
        {
            //_list = ContainerDto.PlatformsList;
            _isAllDestroyed = false;
        }

        public void OnAllPlatformDestroyed(UnityAction action)
        {
            _isAllPlatfromsDestroyed = action;
        }

        public void Destroy(GameObject obj)
        {
            if (obj.transform.parent.childCount == 1)
            {
                _isAllPlatfromsDestroyed.Invoke();
                //_isAllDestroyed = true;
            }
            // use guid
            _getPlatfromPosition.Invoke(obj.transform.position);
            Object.Destroy(obj);
        }

        public bool IsAllDestroyed()
        {
            return _isAllDestroyed;
        }

        public void OnPlatformDestroyed(UnityAction<Vector3> action)
        {
            _getPlatfromPosition = action;
        }
    }
}