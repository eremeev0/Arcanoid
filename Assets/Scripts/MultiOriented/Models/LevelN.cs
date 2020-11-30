using System;
using Assets.Scripts.GameScene.Performances.Services;
using UnityEngine;

namespace Assets.Scripts.MultiOriented.Models
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
        /// color of the destroyed platform's
        /// </summary>
        [Obsolete("Property PlatformsColor deprecated. Use property Platform instead (PlatformService).", true)]
        public Color PlatformsColor { get; set; }
        /// <summary>
        /// player start position on level
        /// </summary>
        //[Obsolete("Property PlayerPosition deprecated. Use property Player instead (PlayerService).", true)]
        public Vector3 PlayerPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Obsolete("Property BallPosition deprecated. Use property Ball instead (BallService).", true)]
        public Vector3 BallPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        // save object
        [Obsolete("Property PlatformsPosition deprecated. Use property Platform instead (PlatformService).", true)]
        public Vector3[] PlatformsPosition { get; set; }

        /// <summary>
        /// List of the domain of game object "Platform". Contain all logic and data about destroyed platforms.
        /// </summary>
        public PlatformService[] Platforms { get; set; }
        /// <summary>
        /// The domain of game object "Player". Contain all logic and data about player character.
        /// </summary>
        public PlayerService Player { get; set; }
        /// <summary>
        /// The domain of game object "Ball". Contain all logic and data about active object -> ball.
        /// </summary>
        public BallService Ball { get; set; }
    }
}