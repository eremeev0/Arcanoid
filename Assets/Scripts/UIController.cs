using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIController: MonoBehaviour
    {

        // Em... i catch so weird bug => start = Exit, exit = Start. 
        private Button start;
        private Button exit;
        private Button restart;
        private Button menu;
        private Button settings;
        private Button backToMenu;
        private Slider speedSlider;
        private Dropdown colorsList;
        void Start()
        {
            
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

            start.onClick.AddListener(_Start);
            exit.onClick.AddListener(Close);
            restart.onClick.AddListener(Restart);
            menu.onClick.AddListener(Menu);
            settings.onClick.AddListener(Options);
            backToMenu.onClick.AddListener(BackToMenu);
            speedSlider.onValueChanged.AddListener(SpeedUpdated);

            colorsList = InitDropdown(colorsList);
            colorsList.onValueChanged.AddListener(ColorUpdated);
            Time.timeScale = 0;
        }

        void Update()
        {
            if (SceneManager.sceneCountInBuildSettings == 2)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
            }
        }



        public void _Start()
        {
            print("start");
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(true);
            Restart();
        }

        public void Close()
        {
            print("close");
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(1);
            Time.timeScale = 1;
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            print("restart");
        }

        public void Menu()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(false);
            print("show menu");
        }

        public void Options()
        {
            GameObject.Find("/UI/Settings/Panel").SetActive(true);
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
            print("open options");
        }

        public void BackToMenu()
        {
            GameObject.Find("/UI/Settings/Panel").SetActive(false);
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
        }

        public void SpeedUpdated(float value)
        {
            GameObject.Find("/UI/Settings/Panel/Slider/value").GetComponent<Text>().text = value.ToString();
            Settings.PlayerSpeed = value;
        }

        public void ColorUpdated(int value)
        {
            switch (value)
            {
                case 0:
                    Settings.PlayerColor = Color.white;
                    break;
                case 1:
                    Settings.PlayerColor = Color.black;
                    break;
                case 2:
                    Settings.PlayerColor = Color.blue;
                    break;
                case 3:
                    Settings.PlayerColor = Color.cyan;
                    break;
                case 4:
                    Settings.PlayerColor = Color.gray;
                    break;
                case 5:
                    Settings.PlayerColor = Color.green;
                    break;
                case 6:
                    Settings.PlayerColor = Color.grey;
                    break;
                case 7:
                    Settings.PlayerColor = Color.magenta;
                    break;
                case 8:
                    Settings.PlayerColor = Color.red;
                    break;
                case 9:
                    Settings.PlayerColor = Color.yellow;
                    break;
                default:
                    break;
            }
        }

        public Dropdown InitDropdown(Dropdown obj)
        {
            obj.ClearOptions();
            obj.captionText.text = "Choose from list";
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.white) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.black) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.blue) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.cyan) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.gray) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.green) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.grey) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.magenta) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.red) });
            obj.options.Add(new Dropdown.OptionData { image = null, text = nameof(Color.yellow) });
            return obj;
        }
    }
}