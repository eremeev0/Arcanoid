using System.Collections.Generic;
using Assets.Scripts.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.GameScene
{
    public class LevelHelper
    {
        private readonly (float, float)[] _platformOffsetsAtLevel1 =
        {
            (-.2f, 0), (1.6f, 0), (3.4f, 0), (5.2f, 0), (7f, 0), (8.8f, 0),
            (-.2f, 1), (1.6f, 1), (3.4f, 1), (5.2f, 1), (7f, 1), (8.8f, 1),
            (-.2f, 2), (1.6f, 2), (3.4f, 2), (5.2f, 2), (7f, 2), (8.8f, 2),
            (-.2f, 3), (1.6f, 3), (3.4f, 3), (5.2f, 3), (7f, 3), (8.8f, 3)
        };

        private readonly (float, float)[] _platformsOffsetsAtLevel2 =
        {
            (-.2f, 0), (1.6f, 0), (3.4f, 0), (5.2f, 0), (7f, 0), (8.8f, 0),
            (-.2f, 1), (1.6f, 1), (3.4f, 1), (5.2f, 1), (7f, 1), (8.8f, 1),
            (-.2f, 2), (1.6f, 2), (3.4f, 2), (5.2f, 2), (7f, 2), (8.8f, 2),
            (-.2f, 3), (1.6f, 3), (3.4f, 3), (5.2f, 3), (7f, 3), (8.8f, 3)
        };
        
        private readonly Color _platformsColorAtLevel1 = new Color(185, 85, 85, 255);
        private readonly Color _platformsColorAtLevel2 = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 255);
        private readonly Vector3 _initialPlayerPosition = new Vector3(0.2929382f, -5.564697f, -1f);
        private readonly Vector3 _initialBallPosition = new Vector3(0.34f, -3.75f, -1f);
        /// <summary>
        /// Returns an array of positions relative to the position of the actual game object
        /// </summary>
        /// <param name="levelNumber">number of the current level</param>
        /// <param name="originalPosition">the position of the real object relative to the playing field</param>
        /// <returns>UnityEngine Vector2 array</returns>
        public Vector3[] GetPlatformsRelativePosition(int levelNumber,Vector2 originalPosition)
        {
            List<Vector3> clonedObjectsPosition = new List<Vector3>();
            Vector2 offsetVector;
            if (levelNumber == 1)
                foreach (var lvl1Offset in _platformOffsetsAtLevel1)
                {
                    offsetVector = IdConverter.ToVector2(lvl1Offset);
                    clonedObjectsPosition.Add(new Vector3(offsetVector.x + originalPosition.x,
                        offsetVector.y + originalPosition.y, -1f));
                }

            if (levelNumber == 2)
            {
                foreach (var lvl2Offset in _platformsOffsetsAtLevel2)
                {
                    offsetVector = IdConverter.ToVector2(lvl2Offset);
                    clonedObjectsPosition.Add(new Vector3(offsetVector.x + originalPosition.x,
                        offsetVector.y + originalPosition.y, -1f));
                }
                
            }
            return clonedObjectsPosition.ToArray();
        }
        /// <summary>
        /// Get static player position
        /// </summary>
        /// <returns>UnityEngine Vector3</returns>
        public Vector3 GetInitialPlayerPosition()
        {
            return _initialPlayerPosition;
        }
        /// <summary>
        /// Get static ball position
        /// </summary>
        /// <returns>UnityEngine Vector3</returns>
        public Vector3 GetInitialBallPosition()
        {
            return _initialBallPosition;
        }
        /// <summary>
        /// depending on the level number, returns the color for destructible platforms
        /// </summary>
        /// <param name="levelNumber">number of the current level</param>
        /// <returns>UnityEngine Color</returns>
        public Color GetPlatformsColor(int levelNumber)
        {
            if (levelNumber == 1)
                return _platformsColorAtLevel1;
            if (levelNumber == 2)
                return _platformsColorAtLevel2;
            return default;
        }
    }
}