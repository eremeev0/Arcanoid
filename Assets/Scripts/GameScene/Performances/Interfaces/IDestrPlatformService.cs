using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameScene.Performances.Interfaces
{
    public interface IDestrPlatformService
    {
        void OnPlatformDestroyed(UnityAction<Vector3> action);
        void OnAllPlatformDestroyed(UnityAction action);
        void Destroy(GameObject obj);
        bool IsAllDestroyed();
    }
}