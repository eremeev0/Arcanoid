using System.Globalization;
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

            IsShowMenu = false;
            IsResetSettings = false;
            IsSaveSettings = false;
        }

        private void Update()
        {

        }

        void SaveSettings(){IsSaveSettings = true;}
        void ResetSettings(){IsResetSettings = true;}
        void ShowMenu(){IsShowMenu = true;}
        void DisplaySpeedValue(float value){SpeedValueLabel.text = value.ToString(CultureInfo.CurrentCulture);}

    }
}