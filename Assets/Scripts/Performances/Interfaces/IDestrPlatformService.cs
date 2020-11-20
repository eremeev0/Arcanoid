using UnityEngine;

namespace Assets.Scripts.Performances.Interfaces
{
    public interface IDestrPlatformService
    {
        void Destroy(GameObject obj);
        bool IsAllDestroyed();
    }
}