using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Game.Performances.Interfaces
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