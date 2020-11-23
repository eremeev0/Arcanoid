using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.EventManagment.States;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.UI.Contracts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Root
{
    public class SettingsController : MonoBehaviour, ICallBack
    {
        public Button SaveButton, ResetButton, MenuButton;
        public Dropdown ColorDropdown, ResolutionDropdown;
        public Slider PlayerSpeedSlider;
        public Text SpeedValueLabel;
        public bool IsShowMenu;
        public bool IsResetSettings;
        public bool IsSaveSettings;
        private UnityAction _action;
        void Start()
        {
            SaveButton.onClick.AddListener(SaveSettings);
            ResetButton.onClick.AddListener(ResetSettings);
            MenuButton.onClick.AddListener(ShowMenu);

            /*ColorDropdown.onValueChanged.AddListener();
            ResolutionDropdown.onValueChanged.AddListener();*/
            PlayerSpeedSlider.onValueChanged.AddListener(DisplaySpeedValue);
            ColorDropdown = UIDataInit.InitDropdown(ColorDropdown, UIStates.INIT_COLOR_LIST);
            ResolutionDropdown = UIDataInit.InitDropdown(ResolutionDropdown, UIStates.INIT_RESOLUTION_LIST);
            IsShowMenu = false;
            IsResetSettings = false;
            IsSaveSettings = false;
        }

        private void Update()
        {

        }

        void SaveSettings()
        {
            SettingsSingleton.GetSettings().PlayerSpeed = PlayerSpeedSlider.value;
            SettingsSingleton.GetSettings().PlayerColor = IdConverter.ToColor(ColorDropdown.value);
            SettingsSingleton.GetSettings().GameResolution = IdConverter.ToVector2(ResolutionDropdown.value);
            IsSaveSettings = true;
            _action.Invoke();
        }
        void ResetSettings(){IsResetSettings = true; _action.Invoke();}
        void ShowMenu(){IsShowMenu = true; _action.Invoke();}
        void DisplaySpeedValue(float value){SpeedValueLabel.text = value.ToString(); _action.Invoke();}

        public void AddListener(UnityAction action)
        {
            _action = action;
        }
    }
}