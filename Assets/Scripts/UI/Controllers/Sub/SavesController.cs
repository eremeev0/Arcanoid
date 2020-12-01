using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Assets.Scripts.UI.Controllers.Sub
{
    public class SavesController: MonoBehaviour
    {
        public Button LoadButton, BackToMenuButton, DeleteButton;
        public Text TimeLabel, LevelLabel, ScoreLabel, PlatformsLabel;
        public ScrollRect Rect;
        private UnityAction<SavesEvents> _isButtonClicked;

        private void Start()
        {
            LoadButton.onClick.AddListener(Load);
            BackToMenuButton.onClick.AddListener(BackToMenu);
            DeleteButton.onClick.AddListener(Delete);
        }

        private void Load() { _isButtonClicked.Invoke(SavesEvents.Load);}
        private void BackToMenu() { _isButtonClicked.Invoke(SavesEvents.BackToMenu);}
        private void Delete() { _isButtonClicked.Invoke(SavesEvents.Delete);}

        public void AddListener(UnityAction<SavesEvents> action) { _isButtonClicked = action;}

        public void Build()
        {
            var saves = new List<Button>();
            var savesPath = Application.dataPath + "/Saves";
            var files =  Directory.GetFiles(savesPath);
            foreach (var file in files)
            {
                //SaveBuilder.SetData = File.ReadAllLines(file);
                //SaveBuilder.Build();
                //...
                //saves.Add(new Button{name = file});
            }
        }
    }
}