﻿using UnityEngine;

namespace Assets.Scripts.Cross.Contracts
{
    /// <summary>
    /// this class contain all game properties
    /// </summary>
    public class SettingsDto
    {
        // saved settings
        public static float PlayerSpeed { get; set; } = DefaultSettingsDto.PlayerSpeed;
        public static Color PlayerColor { get; set; } = DefaultSettingsDto.PlayerColor;
        public static int PlayerScore { get; set; } = DefaultSettingsDto.PlayerScore;
        public static Vector2 GameResolution { get; set; } = DefaultSettingsDto.GameResolution;
        
        // unsaved properties
        // Execution context scriptable objects
        public static bool IsGameStopped { get; set; } = false;
        public static bool IsLevelComplete { get; set; } = false;
        public static bool IsLevelFailed { get; set; } = false;
        public static bool IsScoreUpdate { get; set; } = true;
        public static float BallSpeed { get; set; } = 1f;
        public static float BallMaxSpeed { get; set; } = 14f;
        public static float BallSpeedMultiplier { get; set; } = .1f;

    }
}