using Assets.Scripts.Models;
using Assets.Scripts.Models.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Initializers.UI
{
    public class SettingsInitializer
    {
        public SettingsInitializer(Settings uiSettings)
        {
            UISettings = uiSettings;
            
            UISettings.SaveButton = 
                new AButton(GameObject.Find("/UI/Settings/Panel/Save").GetComponent<Button>());
            
            UISettings.ResetButton = 
                new AButton(GameObject.Find("/UI/Settings/Panel/Reset").GetComponent<Button>());
            
            UISettings.MenuButton = 
                new AButton(GameObject.Find("/UI/Settings/Panel/Exit").GetComponent<Button>());
            
            UISettings.PlayerSpeedSlider = 
                new ASlider(GameObject.Find("/UI/Settings/Panel/Slider").GetComponent<Slider>());

            UISettings.SpeedValueLabel = 
                new ALabel(GameObject.Find("/UI/Settings/Panel/Slider/value").GetComponent<Text>());

            UISettings.PlayerColorDropdown = 
                new ADropdown(GameObject.Find("/UI/Settings/Panel/Color").GetComponent<Dropdown>());
            
            UISettings.GameResolutionDropdown = 
                new ADropdown(GameObject.Find("/UI/Settings/Panel/Resolution").GetComponent<Dropdown>());

            UISettings.MainObject = GameObject.Find("/UI/Settings/Panel");
        }
        public Settings UISettings { get; private set; }
    }
}