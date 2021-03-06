﻿using UnityEngine;

namespace Assets.Scripts.GameScene.Performances.Interfaces
{
    /// <summary>
    /// Player logic interface class
    /// </summary>
    public interface IPlayerService
    {
        bool IsFreezable();
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