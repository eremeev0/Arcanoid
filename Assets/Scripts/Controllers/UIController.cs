using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// class responsible for the logic of the game's user interface
    /// </summary>
    public class UIController: MonoBehaviour
    {

         
        private Button start;
        private Button exit;
        private Button restart;
        private Button menu;
        private Button settings;
        private Button backToMenu;
        private Button save;
        private Button reset;
        private Slider speedSlider;
        private Dropdown colorsList;
        private Dropdown resolutions;

        private readonly EventProvider _eventProvider = new EventProvider();
        void Start()
        {
            new EventProvider().SendEvent(GameEvents.GAME_PAUSED);
            //resManager = gameObject.AddComponent<ResolutionManager>();

            // UI first init 
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(false);
            GameObject.Find("/UI/Settings/Panel").SetActive(false);

            start = GameObject.Find("/UI/Menu/Panel/Start").GetComponent<Button>();
            exit = GameObject.Find("/UI/Menu/Panel/Exit").GetComponent<Button>();
            restart = GameObject.Find("/UI/Failed/Panel/Restart").GetComponent<Button>();
            menu = GameObject.Find("/UI/Failed/Panel/OpenMenu").GetComponent<Button>();
            settings = GameObject.Find("/UI/Menu/Panel/Settings").GetComponent<Button>();
            backToMenu = GameObject.Find("/UI/Settings/Panel/Exit").GetComponent<Button>();
            speedSlider = GameObject.Find("/UI/Settings/Panel/Slider").GetComponent<Slider>();
            colorsList = GameObject.Find("/UI/Settings/Panel/Dropdown").GetComponent<Dropdown>();
            resolutions = GameObject.Find("/UI/Settings/Panel/ResolutionDropdown").GetComponent<Dropdown>();
            save = GameObject.Find("/UI/Settings/Panel/Save").GetComponent<Button>();
            reset = GameObject.Find("UI/Settings/Panel/Reset").GetComponent<Button>();

            start.onClick.AddListener(OnStartButton_Clicked);
            exit.onClick.AddListener(OnExitButton_Clicked);
            restart.onClick.AddListener(OnRestartButton_Clicked);
            menu.onClick.AddListener(OnMenuButton_Clicked);
            settings.onClick.AddListener(OnOptionsButton_Clicked);
            backToMenu.onClick.AddListener(OnMenuButton_Clicked);
            save.onClick.AddListener(OnSaveButton_Clicked);
            reset.onClick.AddListener(OnResetButton_Clicked);
            
            colorsList = UIDataInit.InitDropdown(colorsList, UIEvents.INIT_COLOR_LIST);
            resolutions = UIDataInit.InitDropdown(resolutions, UIEvents.INIT_RESOLUTION_LIST);
            colorsList.onValueChanged.AddListener(OnColor_Changed);
            resolutions.onValueChanged.AddListener(OnResolution_Changed);
            speedSlider.onValueChanged.AddListener(OnSpeed_Changed);
            // stop game
            new EventProvider().SendEvent(GameEvents.GAME_PAUSED);
        }

        void Update()
        {
            // after scene reload try select game scene
            if (SceneManager.sceneCountInBuildSettings == 2)
            { 
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
            }
        }
        
        public void OnStartButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.GAME_STARTED);
        }

        public void OnExitButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.GAME_CLOSED);
        }

        public void OnRestartButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.GAME_RESTARTED);
        }

        public void OnMenuButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.GAME_BACK_TO_MENU);
        }

        public void OnOptionsButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.GAME_OPEN_OPTIONS);
        }

        public void OnSaveButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.SAVE_OPTIONS,
                $"[{nameof(SettingsDto.PlayerSpeed)}] = {SettingsDto.PlayerSpeed}",
                $"[{nameof(SettingsDto.PlayerColor)}] = {colorsList.value}",
                $"[{nameof(SettingsDto.GameResolution)}] = {resolutions.value}",
                $"[{nameof(SettingsDto.PlayerScore)}] = {SettingsDto.PlayerScore}");
        }

        public void OnResetButton_Clicked()
        {
            _eventProvider.SendEvent(GameEvents.RESET_OPTIONS);
        }

        public void OnSpeed_Changed(float value)
        {
            _eventProvider.SendEvent(GameEvents.SPEED_UPDATED, value.ToString());
        }

        public void OnColor_Changed(int value)
        {
            _eventProvider.SendEvent(GameEvents.PLAYER_COLOR_UPDATED, value.ToString());
        }

        public void OnResolution_Changed(int index)
        {
            _eventProvider.SendEvent(GameEvents.WIN_RESOLUTION_UPDATED, index.ToString());
        }
        
    }
}