using UnityEngine;

namespace Assets.Scripts.Performances.Interfaces
{
    public interface IBallService
    {
        void IncrementScore();
        void Failed();
        void SpeedUp();

        float GetSpeed();
        Vector2 GetVelocity();
        bool IsSpeedUpdate();
    }
}