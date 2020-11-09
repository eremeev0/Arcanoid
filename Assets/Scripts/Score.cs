using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Score: MonoBehaviour
    {
        [SerializeField] private int score = Settings.PlayerScore;

        private Text _count;
        void Start()
        {
            _count = GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>();
            _count.text = score.ToString();
        }

        public void UpdateScore(int val)
        {
            score += val;
            Settings.PlayerScore = score;
            _count.text = score.ToString();
        }

        public int GetScore()
        {
            return score;
        }
    }
}