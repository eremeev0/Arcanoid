using Assets.Scripts.Models;
using Assets.Scripts.Models.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Initializers.UI
{
    public class ScoreInitializer
    {
        public ScoreInitializer(Score uiScore)
        {
            UIScore = uiScore;

            UIScore.ScoreLabel = 
                new ALabel(GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>());

            UIScore.CommonLabel = 
                new ALabel(GameObject.Find("/UI/Score/Panel/Text").GetComponent<Text>());

            UIScore.MainObject = GameObject.Find("/UI/Score/Panel");
        }

        public Score UIScore { get; private set; }
    }
}