using Assets.Scripts.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ScoreController: MonoBehaviour
    {
        public Text ScoreLabel;
        public bool IsScoreUpdate;
        
        private int _score;

        private void Start()
        {
            _score = SettingsDto.PlayerScore;
            IsScoreUpdate = true;
        }


        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        /// <param name="val">score</param>
        public void UpdateScore(int val)
        {
            _score += val;
            SettingsDto.PlayerScore = _score;
            IsScoreUpdate = true;
            //ContainerDto.ScoreLabel.text = _score.ToString();
        }

        public int GetScore(){return _score;}
    }
}