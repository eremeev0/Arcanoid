using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        public Button StartButton;
        public Button SettingsButton;
        public Button ExitButton;

        public bool _showScore = false;
        //private
        private void Start()
        {

            StartButton.onClick.AddListener(ShowScore);
            //SettingsButton.onClick.AddListener();
            //ExitButton.onClick.AddListener();
        }

        private void Update()
        {

        }

        void ShowScore()
        {
            _showScore = true;
        }
    }
}