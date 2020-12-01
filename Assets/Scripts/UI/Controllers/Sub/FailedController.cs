using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Sub
{
    public class FailedController : MonoBehaviour
    {

        public bool IsShowMenu;
        public bool IsRestartGame;

        public Button RestartButton;
        public Button MenuButton;
        public Text ScoreLabel;

        private UnityAction<FailedEvent> _action;
        private void Start()
        {
            IsShowMenu = false;
            IsRestartGame = false;
            RestartButton.onClick.AddListener(RestartGame);
            MenuButton.onClick.AddListener(ShowMenu);
        }

        void RestartGame(){_action.Invoke(FailedEvent.RestartClicked);}
        void ShowMenu(){_action.Invoke(FailedEvent.BackToMenuClicked);}
        public void AddListener(UnityAction<FailedEvent> action)
        {
            _action = action;
        }
    }
}