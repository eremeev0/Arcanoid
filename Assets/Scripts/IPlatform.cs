using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Player logic interface class
    /// </summary>
    public interface IPlatform
    {
        Vector3 GetPosition();
        float GetPlayerSpeed();
        Color GetPlayerColor();
        void SetPosition(Vector component, float value);
    }
}