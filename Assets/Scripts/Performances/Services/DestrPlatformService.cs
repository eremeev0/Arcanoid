using Assets.Scripts.Contracts;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class DestrPlatformService: IDestrPlatformService
    {
        private readonly GameObject _list;
        private bool _isAllDestroyed;
        public DestrPlatformService()
        {
            _list = ContainerDto.PlatformsList;
            _isAllDestroyed = false;
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