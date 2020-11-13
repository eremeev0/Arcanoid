using System;
using UnityEngine;
using UnityEngine.UI;
using UnityException = UnityEngine.UnityException;

namespace Assets.Scripts.Performances.Services
{
    public class ContainerService: MonoBehaviour
    {

        private GameObject _menu;
        private GameObject _failed;
        private GameObject _score;
        private GameObject _settings;

        public Button StartButton;
        public Button ExitButton;
        public Button RestartButton;
        public Button MenuButton;
        public Button SettingsButton;
        public Button BackToMenuButton;
        public Button SaveButton;
        public Button ResetButton;
        public Slider SpeedSlider;
        public Dropdown ColorsList;
        public Dropdown ResolutionsList;
        public Text ScoreLabel;
        public Text RecordLabel;


        private static ContainerService _instance;

        private ContainerService()
        {
            
        }

        public static ContainerService GetInstance()
        {
            if (_instance == null)
                _instance = new ContainerService();
            return _instance;
        }

        void Start()
        {
            var childs = gameObject.GetComponentsInChildren<GameObject>() ?? throw new MissingComponentException();
            foreach (var child in childs)
            {
                if (child.name == "Menu")
                    _menu = child.GetComponentInChildren<GameObject>() ?? throw new MissingComponentException();
                if (child.name == "Failed")
                    _failed = child.GetComponentInChildren<GameObject>() ?? throw new MissingComponentException();
                if (child.name == "Score")
                    _score = child.GetComponentInChildren<GameObject>()
                                 .GetComponentInChildren<GameObject>() ?? throw new MissingComponentException();
                if (child.name == "Settings")
                    _settings = child.GetComponentInChildren<GameObject>() ?? throw new MissingComponentException();
            }

            childs = _menu.GetComponentsInChildren<GameObject>() ?? throw new MissingComponentException();
            foreach (var child in childs)
            {
                if (child.name == "Start")
                    StartButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "Exit")
                    ExitButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "Settings")
                    SettingsButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
            }

            childs = _failed.GetComponentsInChildren<GameObject>() ?? throw new MissingComponentException();
            foreach (var child in childs)
            {
                if (child.name == "Restart")
                    RestartButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "OpenMenu")
                    MenuButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "Result")
                    RecordLabel = child.GetComponent<Text>() ?? throw new MissingComponentException();
                // other "failed" object here too
            }

            childs = _settings.GetComponentsInChildren<GameObject>() ?? throw new MissingComponentException();
            foreach (var child in childs)
            {
                if (child.name == "Exit")
                    BackToMenuButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "Save")
                    SaveButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "Reset")
                    ResetButton = child.GetComponent<Button>() ?? throw new MissingComponentException();
                if (child.name == "Slider")
                    SpeedSlider = child.GetComponent<Slider>() ?? throw new MissingComponentException();
                if (child.name == "Dropdown")
                    ColorsList = child.GetComponent<Dropdown>() ?? throw new MissingComponentException();
                if (child.name == "ResolutionDropdown")
                    ResolutionsList = child.GetComponent<Dropdown>() ?? throw new MissingComponentException();
            }
            childs = _score.GetComponentsInChildren<GameObject>() ?? throw new MissingComponentException();
            foreach (var child in childs)
            {
                if(child.name == "count")
                    ScoreLabel = child.GetComponent<Text>() ?? throw new MissingComponentException();
            }

        }


    }
}