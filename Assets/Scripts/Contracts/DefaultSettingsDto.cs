using UnityEngine;

namespace Assets.Scripts.Contracts
{
    public class DefaultSettingsDto
    {
        public static float PlayerSpeed { get; set; } = 5f;
        public static Color PlayerColor { get; set; } = Color.white;
        public static int PlayerScore { get; set; } = 0;
        public static Vector2 GameResolution { get; set; } = new Vector2(800, 600);
    }
}