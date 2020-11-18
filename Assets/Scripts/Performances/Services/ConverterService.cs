using System;
using Assets.Scripts.Contracts;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class ConverterService
    {
        public static Color ToColor(int colorId)
        {
            Color color = default;
            if (colorId == 0)
                color = Color.white;
            if (colorId == 1)
                color = Color.black;
            if (colorId == 2)
                color = Color.blue;
            if (colorId == 3)
                color = Color.cyan;
            if (colorId == 4)
                color = Color.gray;
            if (colorId == 5)
                color = Color.green;
            if (colorId == 6)
                color = Color.grey;
            if (colorId == 7)
                color = Color.magenta;
            if (colorId == 8)
                color = Color.red;
            if (colorId == 9)
                color = Color.yellow;
            return color;
        }
        public static Vector2 ToVector2(int resolutionId)
        {
            Vector2 color = default;
            if (resolutionId == 0)
                color = new Vector2(640, 360);
            if (resolutionId == 1)
                color = new Vector2(800, 600);
            if (resolutionId == 2)
                color = new Vector2(1024, 768);
            if (resolutionId == 3)
                color = new Vector2(1280, 800);
            if (resolutionId == 4)
                color = new Vector2(1360, 768);
            if (resolutionId == 5)
                color = new Vector2(1440, 900);
            if (resolutionId == 6)
                color = new Vector2(1600, 900);
            if (resolutionId == 7)
                color = new Vector2(1920, 1080);
            if (resolutionId == 8)
                color = new Vector2(1920, 1200);
            return color;
           
  
           
        
      
        }
    }
}