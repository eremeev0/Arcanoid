using Assets.Scripts.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ScoreController
    {
        private ScoreController()
        {
            
        }

        private static ScoreController _instance;

        public static ScoreController GetInstance()
        {
            if (_instance == null)
                _instance = new ScoreController();
            return _instance;
        }
        private int _score = SettingsDto.PlayerScore;
        
        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        /// <param name="val">score</param>
        public void UpdateScore(int val)
        {
            _score += val;
            SettingsDto.PlayerScore = _score;
            ContainerDto.ScoreLabel.text = _score.ToString();
        }

        public int GetScore()
        {
            return _score;
        }
    }
}