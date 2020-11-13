using Assets.Scripts.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ScoreController
    {
        private int score = SettingsDto.PlayerScore;
        
        // displayed score
        private Text _count;

        /*void Start()
        {
            _count = GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>();
            _count.text = score.ToString();
        }*/
        
        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        /// <param name="val">score</param>
        public void UpdateScore(int val)
        {
            score += val;
            SettingsDto.PlayerScore = score;
            ContainerDto.ScoreLabel.text = score.ToString();
        }

        public int GetScore()
        {
            return score;
        }
    }
}