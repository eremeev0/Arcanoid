using UnityEngine;

namespace Assets.Scripts.Game.Performances.Interfaces
{
    public interface IDestrPlatformService
    {
        void Destroy(GameObject obj);
        bool IsAllDestroyed();
    }
}