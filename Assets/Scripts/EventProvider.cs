using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class EventProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void SendEvent(GameEvents @event)
        {
            switch (@event)
            {
                case GameEvents.GAME_STARTED:
                    Start();
                    break;
                case GameEvents.GAME_CLOSED:
                    Close();
                    break;
                case GameEvents.GAME_RESTARTED:
                    Restart();
                    break;
                case GameEvents.LEVEL_FAILED:
                    break;
                case GameEvents.GAME_BACK_TO_MENU_2:
                    Menu();
                    break;
                case GameEvents.GAME_OPEN_OPTIONS:
                    Options();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="value"></param>
        public void SendEvent(GameEvents @event,params string[] value)
        {
            switch (@event)
            {
                case GameEvents.GAME_BACK_TO_MENU:
                    BackToMenu(Convert.ToString(value));
                    break;
                case GameEvents.WIN_RESOLUTION_UPDATED:
                    SetResolution(Convert.ToInt32(value[0]));
                    break;
                case GameEvents.SPEED_UPDATED:
                    SetPlayerSpeed(Convert.ToSingle(value[0]));
                    break;
                case GameEvents.PLAYER_COLOR_UPDATED:
                    SetColor(Convert.ToInt32(value[0]));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        private void SetResolution(int index)
        {
            switch (index)
            {
                case 0:
                    Screen.SetResolution(640, 360, true);
                    break;
                case 1:
                    Screen.SetResolution(800, 600, true);
                    break;
                case 2:
                    Screen.SetResolution(1024, 768, true);
                    break;
                case 3:
                    Screen.SetResolution(1280, 800, true);
                    break;
                case 4:
                    Screen.SetResolution(1360, 768, true);
                    break;
                case 5:
                    Screen.SetResolution(1440, 900, true);
                    break;
                case 6:
                    Screen.SetResolution(1600, 900, true);
                    break;
                case 7:
                    Screen.SetResolution(1920, 1080, true);
                    break;
                case 8:
                    Screen.SetResolution(1920, 1200, true);
                    break;
                default:
                    break;
            }
        }

        private void SetColor(int value)
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

        private void SetPlayerSpeed(float value)
        {
            GameObject.Find("/UI/Settings/Panel/Slider/value").GetComponent<Text>().text = value.ToString();
            Settings.PlayerSpeed = value;
        }

        private void Close()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        private void Start()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(true);
            Restart();
        }

        private void Restart()
        {
            //Settings.PlayerScore = 0;
            // reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            // unload old scene
            SceneManager.UnloadSceneAsync(1);
            // resume game
            Time.timeScale = 1;
            // hide failed window
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
        }

        private void Menu()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(false);
        }

        private void Options()
        {
            GameObject.Find("/UI/Settings/Panel").SetActive(true);
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
        }

        private void BackToMenu(params string[] value)
        {
            GameObject.Find("/UI/Settings/Panel").SetActive(false);
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
            DataManager manager = new DataManager();
            // save user settings
            manager.Save(value);
        }
    }
}