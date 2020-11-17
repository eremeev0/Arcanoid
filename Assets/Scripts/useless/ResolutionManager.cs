using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class ResolutionManager: MonoBehaviour
    {

        private List<Vector2> resList = new List<Vector2>();


        private void Init()
        {

            resList.Add(new Vector2(640, 360));
            resList.Add(new Vector2(800, 600));
            resList.Add(new Vector2(1024, 768));
            resList.Add(new Vector2(1280, 800));
            resList.Add(new Vector2(1360, 768));
            resList.Add(new Vector2(1440, 900));
            resList.Add(new Vector2(1600, 900));
            resList.Add(new Vector2(1920, 1080));
            resList.Add(new Vector2(1920, 1200));

        }

        public void SetNewResolution(int index)
        {
            Vector2 resolution = new Vector2();

            resolution = resList[0];

            Screen.SetResolution((int)resolution.x, (int)resolution.y, false);

        }

        public List<Vector2> GetResolutionList()
        {
            return resList;
        }
    }
}