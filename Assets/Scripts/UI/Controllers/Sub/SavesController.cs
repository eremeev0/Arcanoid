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
            Build();
        }

        private void Load() { _isButtonClicked.Invoke(SavesEvents.Load);}
        private void BackToMenu() { _isButtonClicked.Invoke(SavesEvents.BackToMenu);}
        private void Delete() { _isButtonClicked.Invoke(SavesEvents.Delete);}

        public void AddListener(UnityAction<SavesEvents> action) { _isButtonClicked = action;}

        public void Build()
        {
            var saves = new List<Button>();
            var savesPath = Application.dataPath + "/Saves";
            if (!Directory.Exists(savesPath)){
                Directory.CreateDirectory(savesPath);
                return;
            }
            var files =  Directory.GetFiles(savesPath);
            if (files.Length == 0)
            {
                BuildButton("Debug", Rect.content.transform);
                return;
            }
            foreach (var file in files)
            {
                BuildButton(file, Rect.content.transform);
            }
        }

        void BuildButton(string name, Transform parent){
            
            GameObject button = new GameObject(name);
            button.AddComponent<RectTransform>();
            
            Button component = button.AddComponent<Button>();
            component.onClick.AddListener(() => {component.SendMessage(component.name);});
            
            GameObject capture = new GameObject();
            capture.AddComponent<Text>().text = name;
            capture.transform.parent = button.transform;

            button.transform.parent = parent;
        }
    }
}