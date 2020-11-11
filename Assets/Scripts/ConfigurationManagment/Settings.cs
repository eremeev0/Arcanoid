using UnityEngine;

namespace Assets.Scripts.ConfigurationManagment
{
    /// <summary>
    /// this class contain all game properties
    /// </summary>
    public class Settings
    {
        public static float PlayerSpeed { get; set; } = 5f;
        public static Color PlayerColor { get; set; } = Color.white;
        public static int PlayerScore { get; set; } = 0;

        public static bool IsGameStopped { get; set; } = false;
    }
}