using UnityEngine;

namespace Assets.Scripts
{
    public interface IPlatform
    {
        Vector3 GetPosition();
        float GetPlayerSpeed();
        void SetPosition(Vector component, float value);
    }
}