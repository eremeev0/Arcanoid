using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Sub
{
    public class SavesController: MonoBehaviour
    {
        public Button LoadButton, BackToMenuButton, DeleteButton;
        private UnityAction<SavesEvents> _isButtonClicked;
        void Start()
        {
            LoadButton.onClick.AddListener(Load);
            BackToMenuButton.onClick.AddListener(BackToMenu);
            DeleteButton.onClick.AddListener(Delete);
        }
        void Load() { _isButtonClicked.Invoke(SavesEvents.Load);}
        void BackToMenu() { _isButtonClicked.Invoke(SavesEvents.BackToMenu);}
        void Delete() { _isButtonClicked.Invoke(SavesEvents.Delete);}
        public void AddListener(UnityAction<SavesEvents> action) { _isButtonClicked = action;}
    }
}