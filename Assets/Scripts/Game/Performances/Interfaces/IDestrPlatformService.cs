using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game.Performances.Interfaces
{
    public interface IDestrPlatformService
    {
        void AddListener(UnityAction<Vector3> action);
        void AddListener(UnityAction action);
        void Destroy(GameObject obj);
        bool IsAllDestroyed();
    }
}