using Assets.Scripts.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ScoreController: MonoBehaviour
    {
        public Text ScoreLabel;
        private int _score;

        private void Start()
        {
            _score = SettingsDto.PlayerScore;
        }


        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        public void UpdateScore()
        {
            _score = SettingsDto.PlayerScore;
            SettingsDto.IsScoreUpdate = false;
            ScoreLabel.text = _score.ToString();
            //ContainerDto.ScoreLabel.text = _score.ToString();
        }

        public int GetScore(){return _score;}
    }
}