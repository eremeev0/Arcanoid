using System.Globalization;
using Assets.Scripts.MultiOriented.Contracts;
using Assets.Scripts.MultiOriented.StatesManagament.States;
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
        public Slider MusicVolumeSlider;
        public Text VolumeValueLabel;
        public Text SpeedValueLabel;
        private UnityAction<SettingsEvents> _action;
        void Start()
        {
            SaveButton.onClick.AddListener(SaveSettings);
            ResetButton.onClick.AddListener(ResetSettings);
            MenuButton.onClick.AddListener(ShowMenu);

            /*ColorDropdown.onValueChanged.AddListener();
            ResolutionDropdown.onValueChanged.AddListener();*/
            PlayerSpeedSlider.onValueChanged.AddListener(UpdateSpeedValue);
            MusicVolumeSlider.onValueChanged.AddListener(UpdateVolumeValue);
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
        void ResetSettings() { _action.Invoke(SettingsEvents.ResetClicked);}
        void ShowMenu() { _action.Invoke(SettingsEvents.BackToMenuClicked);}
        void UpdateSpeedValue(float value) { SpeedValueLabel.text = value.ToString(CultureInfo.CurrentCulture);}
        void UpdateVolumeValue(float value) { VolumeValueLabel.text = value.ToString(CultureInfo.CurrentCulture);}
        public void AddListener(UnityAction<SettingsEvents> action)
        {
            _action = action;
        }
    }
}