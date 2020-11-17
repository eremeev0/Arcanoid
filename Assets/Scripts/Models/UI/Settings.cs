using System;
using System.ComponentModel;
using UnityEngine.UI;

namespace Assets.Scripts.Models.UI
{
    public class Settings: Panel
    {
        public AButton SaveButton;
        public AButton ResetButton;
        public AButton MenuButton;
        public ASlider PlayerSpeedSlider;
        public ALabel SpeedValueLabel;
        [Obsolete("Property PlayerSpeedSliderValue has been deprecated. Use SpeedValueLabel instead. (Models.ALabel)", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Text PlayerSpeedSliderValue;
        public ADropdown PlayerColorDropdown;
        public ADropdown GameResolutionDropdown;
    }
}