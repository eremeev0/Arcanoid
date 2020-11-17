using Assets.Scripts.Contracts;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ScoreController: MonoBehaviour
    {
        private int _score = SettingsDto.PlayerScore;
        
        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        /// <param name="val">score</param>
        public void UpdateScore(int val)
        {
            _score += val;
            SettingsDto.PlayerScore = _score;
            //ContainerDto.ScoreLabel.text = _score.ToString();
        }

        public int GetScore()
        {
            return _score;
        }
    }
}