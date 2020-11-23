using UnityEngine;

namespace Assets.Scripts.Cross.Models
{
    /// <summary>
    /// This class will be update in future (or not)
    /// </summary>
    public class LevelN
    {
        /// <summary>
        /// level number in level's hierarchy (like a level 1, level 2 etc.)
        /// </summary>
        public int Number { get; set; } = 0;
        /// <summary>
        /// Destroyed platform exemplar
        /// </summary>
        public GameObject Platform { get; set; }
        /// <summary>
        /// color of the destroyed platform's
        /// </summary>
        public Color PlatformsColor { get; set; }
        /// <summary>
        /// player start position on level
        /// </summary>
        public Vector3 PlayerPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vector3 BallPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vector3[] PlatformsPosition { get; set; }
    }
}