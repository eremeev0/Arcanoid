using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.EventManagment.States;
using Assets.Scripts.UI.Contracts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controllers.Sub
{
    public class SettingsController : MonoBehaviour
    {
        public Button SaveButton, ResetButton, MenuButton;
        public Dropdown ColorDropdown, ResolutionDropdown;
        public Slider PlayerSpeedSlider;
        public Text SpeedValueLabel;
        private UnityAction<SettingsEvents> _action;
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
        }

        private void Update()
        {

        }

        void SaveSettings()
        {
            SettingsSingleton.GetSettings().PlayerSpeed = PlayerSpeedSlider.value;
            SettingsSingleton.GetSettings().PlayerColor = IdConverter.ToColor(ColorDropdown.value);
            SettingsSingleton.GetSettings().GameResolution = IdConverter.ToVector2(ResolutionDropdown.value);
            _action.Invoke(SettingsEvents.SaveClicked);
        }
        void ResetSettings(){_action.Invoke(SettingsEvents.ResetClicked);}
        void ShowMenu(){_action.Invoke(SettingsEvents.BackToMenuClicked);}
        void DisplaySpeedValue(float value){SpeedValueLabel.text = value.ToString();}

        public void AddListener(UnityAction<SettingsEvents> action)
        {
            _action = action;
        }
    }
}