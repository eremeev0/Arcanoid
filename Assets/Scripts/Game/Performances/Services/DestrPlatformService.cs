using Assets.Scripts.Game.Performances.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game.Performances.Services
{
    public class DestrPlatformService: IDestrPlatformService
    {
        private bool _isAllDestroyed;
        private UnityAction<Vector3> _action;
        private UnityAction _action2;
        public DestrPlatformService()
        {
            //_list = ContainerDto.PlatformsList;
            _isAllDestroyed = false;
        }

        public void AddListener(UnityAction action)
        {
            _action2 = action;
        }

        public void Destroy(GameObject obj)
        {
            if (obj.transform.parent.childCount == 1)
            {
                _action2.Invoke();
                //_isAllDestroyed = true;
            }
            _action.Invoke(obj.transform.position);
            Object.Destroy(obj);
        }

        public bool IsAllDestroyed()
        {
            return _isAllDestroyed;
        }

        public void AddListener(UnityAction<Vector3> action)
        {
            _action = action;
        }
    }
}