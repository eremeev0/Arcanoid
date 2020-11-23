using UnityEngine;

namespace Assets.Scripts.UI
{
    public class IdConverter
    {
        public static Color ToColor(int colorId)
        {
            if (colorId == 0)
                return Color.white;
            if (colorId == 1)
                return Color.black;
            if (colorId == 2)
                return Color.blue;
            if (colorId == 3)
                return Color.cyan;
            if (colorId == 4)
                return Color.gray;
            if (colorId == 5)
                return Color.green;
            if (colorId == 6)
                return Color.grey;
            if (colorId == 7)
                return Color.magenta;
            if (colorId == 8)
                return Color.red;
            if (colorId == 9)
                return Color.yellow;
            return default;
        }
        public static Vector2 ToVector2(int resolutionId)
        {
            if (resolutionId == 0)
                return new Vector2(640, 360);
            if (resolutionId == 1)
                return new Vector2(800, 600);
            if (resolutionId == 2)
                return new Vector2(1024, 768);
            if (resolutionId == 3)
                return new Vector2(1280, 800);
            if (resolutionId == 4)
                return new Vector2(1360, 768);
            if (resolutionId == 5)
                return new Vector2(1440, 900);
            if (resolutionId == 6)
                return new Vector2(1600, 900);
            if (resolutionId == 7)
                return new Vector2(1920, 1080);
            if (resolutionId == 8)
                return new Vector2(1920, 1200);
            return default;
        }

        public static Vector2 ToVector2((float, float) tuple)
        {
            return new Vector2(tuple.Item1, tuple.Item2);
        }
    }
}