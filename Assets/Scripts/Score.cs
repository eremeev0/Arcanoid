﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Score: MonoBehaviour
    {
        [SerializeField] private int score = Settings.PlayerScore;
        
        // displayed score
        private Text _count;

        void Start()
        {
            _count = GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>();
            _count.text = score.ToString();
        }
        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        /// <param name="val">score</param>
        public void UpdateScore(int val)
        {
            score += val;
            Settings.PlayerScore = score;
            // check that Settings get value from class
            Debug.LogWarning(Settings.PlayerScore);
            // display current score
            _count.text = score.ToString();
        }

        public int GetScore()
        {
            return score;
        }
    }
}