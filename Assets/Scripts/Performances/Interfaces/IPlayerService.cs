﻿using UnityEngine;

namespace Assets.Scripts.Performances.Interfaces
{
    /// <summary>
    /// Player logic interface class
    /// </summary>
    public interface IPlayerService
    {
        float GetSpeed();
        bool IsSpeedUpdate();
        bool IsFreezeUp();
        bool IsFreezeDown();
        bool IsFreezeLeft();
        bool IsFreezeRight();
        void SetPosition(Vector component, float value);
        void SetPosition(Vector3 pos);
    }
}