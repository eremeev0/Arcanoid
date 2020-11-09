using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Score: MonoBehaviour
    {
        [SerializeField] private int score = 0;

        private Text _count;
        void Start()
        {
            _count = GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>();
            _count.text = "0";
        }

        public void UpdateScore(int val)
        {
            score += val;
            _count.text = score.ToString();
        }

        public int GetScore()
        {
            return score;
        }
    }
}