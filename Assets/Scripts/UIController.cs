using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
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
        private Slider speedSlider;
        private Dropdown colorsList;
        private Dropdown resolutions;

        private EventProvider _eventProvider = new EventProvider();
        void Start()
        {
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

            start.onClick.AddListener(_Start);
            exit.onClick.AddListener(Close);
            restart.onClick.AddListener(Restart);
            menu.onClick.AddListener(Menu);
            settings.onClick.AddListener(Options);
            backToMenu.onClick.AddListener(BackToMenu);
            speedSlider.onValueChanged.AddListener(SpeedUpdated);
            
            colorsList = InitDropdown(colorsList);
            colorsList.onValueChanged.AddListener(ColorUpdated);
            resolutions = InitResolutions(resolutions);
            resolutions.onValueChanged.AddListener(SetNewResolution);
            // stop game
            Time.timeScale = 0;
        }

        void Update()
        {
            // after scene reload try select game scene
            if (SceneManager.sceneCountInBuildSettings == 2)
            { 
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
            }
        }
        
        public void _Start()
        {
            _eventProvider.SendEvent(GameEvents.GAME_STARTED);
        }

        public void Close()
        {
            _eventProvider.SendEvent(GameEvents.GAME_CLOSED);
        }

        public void Restart()
        {
            Settings.PlayerScore = 0;
            _eventProvider.SendEvent(GameEvents.GAME_RESTARTED);
        }

        public void Menu()
        {
            _eventProvider.SendEvent(GameEvents.GAME_BACK_TO_MENU_2);
        }

        public void Options()
        {
            _eventProvider.SendEvent(GameEvents.GAME_OPEN_OPTIONS);
        }

        public void BackToMenu()
        {
            _eventProvider.SendEvent(GameEvents.GAME_BACK_TO_MENU, speedSlider.value.ToString(),
                colorsList.value.ToString(), resolutions.value.ToString(), Settings.PlayerScore.ToString());
        }

        public void SpeedUpdated(float value)
        {
            _eventProvider.SendEvent(GameEvents.SPEED_UPDATED, value.ToString());
        }

        public void ColorUpdated(int value)
        {
            _eventProvider.SendEvent(GameEvents.PLAYER_COLOR_UPDATED, value.ToString());
        }

        public void SetNewResolution(int index)
        {
            _eventProvider.SendEvent(GameEvents.WIN_RESOLUTION_UPDATED, index.ToString());
        }
        public Dropdown InitDropdown(Dropdown obj)
        {
            obj.ClearOptions();
            obj.captionText.text = "Choose from list";
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.white) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.black) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.blue) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.cyan) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.gray) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.green) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.grey) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.magenta) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.red) });
            obj.options.Add(new Dropdown.OptionData { text = nameof(Color.yellow) });
            return obj;
        }

        public Dropdown InitResolutions(Dropdown res)
        {
            print(1);
            res.ClearOptions();
            res.captionText.text = "Game Resolutions";
            res.options.Add(new Dropdown.OptionData { text = "640 x 360" });
            res.options.Add(new Dropdown.OptionData { text = "800 x 600" });
            res.options.Add(new Dropdown.OptionData { text = "1024 x 768" });
            res.options.Add(new Dropdown.OptionData { text = "1280 x 800" });
            res.options.Add(new Dropdown.OptionData { text = "1360 x 768" });
            res.options.Add(new Dropdown.OptionData { text = "1440 x 900" });
            res.options.Add(new Dropdown.OptionData { text = "1600 x 900" });
            res.options.Add(new Dropdown.OptionData { text = "1920 x 1080" });
            res.options.Add(new Dropdown.OptionData { text = "1920 x 1200" });
            return res;
        }
    }
}