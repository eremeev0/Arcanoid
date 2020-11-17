using System;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Models.Game
{
    /// <summary>
    /// This class will be update in future (or not)
    /// </summary>
    public class Level
    {
        /// <summary>
        /// name of the level
        /// </summary>
        [Obsolete("Property Name has been deprecated. Use Number instead. ", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; set; }
        /// <summary>
        /// level number in level's hierarchy (like a level 1, level 2 etc.)
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// color of the destroyed platform's
        /// </summary>
        public Color PlatformsColor { get; set; }
        /// <summary>
        /// Offsets collection for spawner logic
        /// <para>
        ///     Spawner use offsets when set new position relative original game object
        /// </para>
        /// </summary>
        public Vector2[] OffsetsForSpawner { get; set; }
    }
}