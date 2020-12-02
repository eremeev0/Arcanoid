using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace Assets.Scripts.UI.Controllers.Sub
{
    public class CompleteController: MonoBehaviour
    {
        public Button NextLevel, MenuButton;
        public Text ScoreLabel;

        private UnityAction<CompleteEvents> _action;
        private float _waitForMilliseconds = 10000; // 10 seconds
        
        void Start(){
            NextLevel.onClick.AddListener(StartNextLevel);
            MenuButton.onClick.AddListener(BackToMenu);
        }

        void Update()
        {
            StartCoroutine(ForcedStartNextLevel(_waitForMilliseconds));
        }
        
        IEnumerator ForcedStartNextLevel(float waitForMilliseconds){
            yield return new WaitForSeconds(waitForMilliseconds/1000);
            _action.Invoke(CompleteEvents.StartNextLevel); // say that the next level forced started
        }
        
        void StartNextLevel() { _action.Invoke(CompleteEvents.StartNextLevel);}
        
        void BackToMenu() { _action.Invoke(CompleteEvents.BackToMenu);}
        
        public void AddListener(UnityAction<CompleteEvents> action) { _action = action;}
    }
}