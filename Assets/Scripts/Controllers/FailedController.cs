using Assets.Scripts.Performances.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class FailedController : MonoBehaviour, ICallBack
    {

        public bool IsShowMenu;
        public bool IsRestartGame;

        public Button RestartButton;
        public Button MenuButton;
        public Text ScoreLabel;

        private UnityAction _action;
        private void Start()
        {
            IsShowMenu = false;
            IsRestartGame = false;
            RestartButton.onClick.AddListener(RestartGame);
            MenuButton.onClick.AddListener(ShowMenu);
        }

        private void Update()
        {

        }

        void RestartGame(){IsRestartGame = true; _action.Invoke();}
        void ShowMenu(){IsShowMenu = true; _action.Invoke();}
        public void AddListener(UnityAction action)
        {
            _action = action;
        }
    }
}