using System;
using Assets.Scripts.GameScene;
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
        /// List of the game object "Platform".
        /// </summary>
        public ConcretePlatform[] Platforms { get; set; }
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