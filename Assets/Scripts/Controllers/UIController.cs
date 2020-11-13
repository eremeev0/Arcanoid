using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using Assets.Scripts.Performances;
using Assets.Scripts.Performances.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        private EventManager _eventProvider;
        void Start()
        {
            _eventProvider = ContainerDto.Manager;
            _eventProvider.SendEvent(GameEvents.GAME_PAUSED);

            ContainerDto.Failed.SetActive(false);
            ContainerDto.Score.SetActive(false);
            ContainerDto.Settings.SetActive(false);
            // UI first init 

            start = ContainerDto.StartButton;
            exit = ContainerDto.ExitButton;
            restart = ContainerDto.RestartButton;
            menu = ContainerDto.MenuButton;
            settings = ContainerDto.SettingsButton;
            backToMenu = ContainerDto.BackToMenuButton;
            speedSlider = ContainerDto.SpeedSlider;
            colorsList = ContainerDto.ColorsList;
            resolutions = ContainerDto.ResolutionsList;
            save = ContainerDto.SaveButton;
            reset = ContainerDto.ResetButton;

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
            //_eventProvider.SendEvent(GameEvents.GAME_PAUSED);
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
            _eventProvider.SendEvent(UIEvents.GAME_STARTED);
        }

        public void OnExitButton_Clicked()
        {
            _eventProvider.SendEvent(UIEvents.GAME_CLOSED);
        }

        public void OnRestartButton_Clicked()
        {
            _eventProvider.SendEvent(UIEvents.GAME_RESTARTED);
            _eventProvider.SendEvent(GameEvents.GAME_RESUMED);
        }

        public void OnMenuButton_Clicked()
        {
            _eventProvider.SendEvent(UIEvents.GAME_BACK_TO_MENU);
        }

        public void OnOptionsButton_Clicked()
        {
            _eventProvider.SendEvent(UIEvents.GAME_OPEN_OPTIONS);
        }

        public void OnSaveButton_Clicked()
        {
            _eventProvider.SendEvent(UIEvents.SAVE_OPTIONS,
                $"[{nameof(SettingsDto.PlayerSpeed)}] = {SettingsDto.PlayerSpeed}",
                $"[{nameof(SettingsDto.PlayerColor)}] = {colorsList.value}",
                $"[{nameof(SettingsDto.GameResolution)}] = {resolutions.value}",
                $"[{nameof(SettingsDto.PlayerScore)}] = {SettingsDto.PlayerScore}");
        }

        public void OnResetButton_Clicked()
        {
            _eventProvider.SendEvent(UIEvents.RESET_OPTIONS);
        }

        public void OnSpeed_Changed(float value)
        {
            _eventProvider.SendEvent(UIEvents.SPEED_UPDATED, value.ToString());
        }

        public void OnColor_Changed(int value)
        {
            _eventProvider.SendEvent(UIEvents.PLAYER_COLOR_UPDATED, value.ToString());
        }

        public void OnResolution_Changed(int index)
        {
            _eventProvider.SendEvent(UIEvents.WIN_RESOLUTION_UPDATED, index.ToString());
        }
        
    }
}