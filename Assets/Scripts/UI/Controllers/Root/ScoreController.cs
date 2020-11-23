using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Root
{
    public class ScoreController: MonoBehaviour, ICallBack
    {
        public Text ScoreLabel;
        private int _score;
        private UnityAction _action;
        private void Start()
        {
            _score = SettingsSingleton.GetSettings().PlayerScore;
        }


        /// <summary>
        /// plus the received score value to the current
        /// </summary>
        public void UpdateScore()
        {
            _score = SettingsSingleton.GetSettings().PlayerScore;
            SettingsSingleton.GetSettings().IsScoreUpdate = false;
            ScoreLabel.text = _score.ToString();
            _action.Invoke();
            //ContainerDto.ScoreLabel.text = _score.ToString();
        }

        public int GetScore(){return _score;}
        public void AddListener(UnityAction action)
        {
            _action = action;
        }
    }
}