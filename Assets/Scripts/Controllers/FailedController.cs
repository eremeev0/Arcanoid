using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class FailedController : MonoBehaviour
    {
        public bool IsShowMenu;
        public bool IsRestartGame;

        public Button RestartButton;
        public Button MenuButton;
        public Text ScoreLabel;

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

        void RestartGame(){IsRestartGame = true;}
        void ShowMenu(){IsShowMenu = true;}
    }
}