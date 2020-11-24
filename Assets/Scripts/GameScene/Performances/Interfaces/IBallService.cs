using UnityEngine;

namespace Assets.Scripts.GameScene.Performances.Interfaces
{
    public interface IBallService
    {
        // remove 
        IDestrPlatformService destroyedPlatform { get; set; }
        //void SetVelocity(Vector2 velocity);
        float GetSpeed();
        Vector2 GetVelocity();
        bool IsSpeedUpdate();
        bool IsVelocityUpdate();
    }
}