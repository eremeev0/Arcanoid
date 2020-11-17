using Assets.Scripts.Models;
using Assets.Scripts.Models.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Initializers.UI
{
    public class MenuInitializer
    {
        public MenuInitializer(Menu uiMenu)
        {
            UIMenu = uiMenu;

            UIMenu.CommonLabel = 
                new ALabel(GameObject.Find("/UI/Menu/Panel/Text").GetComponent<Text>());

            UIMenu.StartButton = 
                new AButton(GameObject.Find("/UI/Menu/Panel/Start").GetComponent<Button>());
            
            UIMenu.SettingsButton = 
                new AButton(GameObject.Find("/UI/Menu/Panel/Settings").GetComponent<Button>());
            
            UIMenu.ExitButton = 
                new AButton(GameObject.Find("/UI/Menu/Panel/Exit").GetComponent<Button>());

            UIMenu.MainObject = GameObject.Find("/UI/Menu/Panel");
        }

        public Menu UIMenu { get; private set; }
    }
}