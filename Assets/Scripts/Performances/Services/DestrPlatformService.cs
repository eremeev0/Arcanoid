using Assets.Scripts.Contracts;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class DestrPlatformService: IDestrPlatformService
    {
        private bool _isAllDestroyed;
        public DestrPlatformService()
        {
            //_list = ContainerDto.PlatformsList;
            _isAllDestroyed = false;
        }
        
        public void Destroy(GameObject obj)
        {
            if (obj.transform.parent.childCount == 1)
            {
                _isAllDestroyed = true;
            }
            Object.Destroy(obj);
        }

        public bool IsAllDestroyed()
        {
            return _isAllDestroyed;
        }
    }
}