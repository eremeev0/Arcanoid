using System;
using System.ComponentModel;
using UnityEngine.UI;

namespace Assets.Scripts.Contracts.UI
{
    public class Settings
    {
        public AButton SaveButton;
        public AButton ResetButton;
        public AButton Menu;
        public ASlider PlayerSpeedSlider;
        [Obsolete("Property PlayerSpeedSliderValue has been deprecated. Use ASlider constructor instead. (Contracts.ASlider)", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Text PlayerSpeedSliderValue;
        public ADropdown PlayerColorDropdown;
        public ADropdown GameResolutionDropdown;
    }
}