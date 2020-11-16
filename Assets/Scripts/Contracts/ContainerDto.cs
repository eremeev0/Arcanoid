using Assets.Scripts.EventManagment.Provider;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Contracts
{
    public class ContainerDto
    {
        public static GameObject Menu;
        public static GameObject Failed;
        public static GameObject Settings;
        public static GameObject Score;
        public static GameObject Player;
        public static GameObject Ball;
        public static GameObject PlatformsList;
        public static GameObject Platform;
        
        public static Button StartButton;
        public static Button RestartButton;
        public static Button MenuButton;
        public static Button SettingsButton;
        public static Button BackToMenuButton;
        public static Button SaveButton;
        public static Button ResetButton;
        public static Button ExitButton;

        public static Slider SpeedSlider;
        
        public static Dropdown ColorsList;
        public static Dropdown ResolutionsList;
        
        public static Text ScoreLabel;
        public static Text RecordLabel;
        public static Text SpeedValue;
        
        public static EventManager Manager;
    }
}