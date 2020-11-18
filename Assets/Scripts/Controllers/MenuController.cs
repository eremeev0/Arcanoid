using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        public Button StartButton;
        public Button SettingsButton;
        public Button ExitButton;

        public bool IsShowScore = false;

        public bool IsShowSettings = false;

        public bool IsCloseGame = false;
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

        void ShowScore(){IsShowScore = true;}

        void ShowSettings(){IsShowSettings = true;}

        void CloseGame(){IsCloseGame = true;}
    }
}