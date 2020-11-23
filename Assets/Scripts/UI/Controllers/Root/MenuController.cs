using Assets.Scripts.Performances.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Root
{
    public class MenuController : MonoBehaviour, ICallBack
    {
        public Button StartButton;
        public Button SettingsButton;
        public Button ExitButton;

        public bool IsShowScore = false;

        public bool IsShowSettings = false;

        public bool IsCloseGame = false;

        private UnityAction _action;
        //private
        private void Start()
        {

            StartButton.onClick.AddListener(ShowScore);
            SettingsButton.onClick.AddListener(ShowSettings);
            ExitButton.onClick.AddListener(CloseGame);
        }

        private void Update()
        {
            
        }
        public void AddListener(UnityAction action)
        {
            _action = action;
        }


        void ShowScore(){IsShowScore = true; _action.Invoke();}

        void ShowSettings(){IsShowSettings = true; _action.Invoke(); }

        void CloseGame(){IsCloseGame = true; _action.Invoke(); }
    }
}