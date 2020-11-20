using UnityEngine;

namespace Assets.Scripts.Performances.Interfaces
{
    public interface IBallService
    {
        IDestrPlatformService destroyedPlatform { get; set; }
        //void SetVelocity(Vector2 velocity);
        float GetSpeed();
        Vector2 GetVelocity();
        bool IsSpeedUpdate();
        bool IsVelocityUpdate();
    }
}