using UnityEngine;

namespace Assets.Scripts.Performances.Interfaces
{
    /// <summary>
    /// Player logic interface class
    /// </summary>
    public interface IPlatform
    {
        Vector3 GetPosition();
        float GetSpeed();
        Color GetColor();
        bool IsSpeedUpdate();
        bool IsColorUpdate();

        void SetPosition(Vector component, float value);
        void SetPosition(Vector3 pos);
    }
}