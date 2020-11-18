using System.Globalization;
using Assets.Scripts.Contracts;
using Assets.Scripts.Contracts.Service;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class SettingsController : MonoBehaviour
    {
        public Button SaveButton, ResetButton, MenuButton;
        public Dropdown ColorDropdown, ResolutionDropdown;
        public Slider PlayerSpeedSlider;
        public Text SpeedValueLabel;
        public bool IsShowMenu;
        public bool IsResetSettings;
        public bool IsSaveSettings;

        void Start()
        {
            SaveButton.onClick.AddListener(SaveSettings);
            ResetButton.onClick.AddListener(ResetSettings);
            MenuButton.onClick.AddListener(ShowMenu);

            /*ColorDropdown.onValueChanged.AddListener();
            ResolutionDropdown.onValueChanged.AddListener();*/
            PlayerSpeedSlider.onValueChanged.AddListener(DisplaySpeedValue);
            ColorDropdown = UIDataInit.InitDropdown(ColorDropdown, UIEvents.INIT_COLOR_LIST);
            ResolutionDropdown = UIDataInit.InitDropdown(ResolutionDropdown, UIEvents.INIT_RESOLUTION_LIST);
            IsShowMenu = false;
            IsResetSettings = false;
            IsSaveSettings = false;
        }

        private void Update()
        {

        }

        void SaveSettings()
        {
            SettingsDto.PlayerSpeed = PlayerSpeedSlider.value;
            SettingsDto.PlayerColor = ConverterService.ToColor(ColorDropdown.value);
            SettingsDto.GameResolution = ConverterService.ToVector2(ResolutionDropdown.value);
            IsSaveSettings = true;
        }
        void ResetSettings(){IsResetSettings = true;}
        void ShowMenu(){IsShowMenu = true;}
        void DisplaySpeedValue(float value){SpeedValueLabel.text = value.ToString();}

    }
}