using UnityEngine;

namespace Assets.Scripts.Contracts
{
    /// <summary>
    /// this class contain all game properties
    /// </summary>
    public class SettingsDto
    {
        // saved settings
        public static float PlayerSpeed { get; set; }
        public static Color PlayerColor { get; set; }
        public static int PlayerScore { get; set; }
        public static Vector2 GameResolution { get; set; }
        
        // unsaved properties
        public static bool IsGameStopped { get; set; } = false;
        public static float BallSpeed { get; set; } = 2f;
        public static float BallMaxSpeed { get; set; } = 14f;
        public static float BallSpeedMultiplier { get; set; } = .5f;

    }
}