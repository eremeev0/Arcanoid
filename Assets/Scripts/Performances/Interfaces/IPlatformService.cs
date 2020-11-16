using UnityEngine;

namespace Assets.Scripts.Performances.Interfaces
{
    /// <summary>
    /// Player logic interface class
    /// </summary>
    public interface IPlatformService
    {
        float GetSpeed();
        bool IsSpeedUpdate();

        void SetPosition(Vector component, float value);
        void SetPosition(Vector3 pos);
    }
}