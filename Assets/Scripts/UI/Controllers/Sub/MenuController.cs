using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Sub
{
    public class MenuController : MonoBehaviour
    {
        public Button StartButton;
        public Button SettingsButton;
        public Button ExitButton;
        public Button LoadButton;

        private UnityAction<MenuEvents> _action;

        private void Start()
        {

            StartButton.onClick.AddListener(ShowScore);
            SettingsButton.onClick.AddListener(ShowSettings);
            ExitButton.onClick.AddListener(CloseGame);
            LoadButton.onClick.AddListener(ShowSaves);
        }

        public void AddListener(UnityAction<MenuEvents> action)
        {
            _action = action;
        }


        void ShowScore() { _action.Invoke(MenuEvents.StartClicked);}

        void ShowSettings() { _action.Invoke(MenuEvents.SettingsClicked); }

        void CloseGame() { _action.Invoke(MenuEvents.ExitClicked); }

        void ShowSaves() { _action.Invoke(MenuEvents.SavesClicked);}
    }
}