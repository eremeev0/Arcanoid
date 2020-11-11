using System;
using Assets.Scripts.ConfigurationManagment;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.EventManagment.Provider
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
                    StartGame();
                    break;
                case GameEvents.GAME_CLOSED:
                    CloseApp();
                    break;
                case GameEvents.GAME_RESTARTED:
                    ReloadGame();
                    break;
                case GameEvents.GAME_BACK_TO_MENU:
                    OpenMenu();
                    break;
                case GameEvents.GAME_OPEN_OPTIONS:
                    OpenOptions();
                    break;
                case GameEvents.RESET_OPTIONS:
                    ResetOptions();
                    break;
                case GameEvents.GAME_PAUSED:
                    StopGame();
                    break;
                case GameEvents.GAME_RESUMED:
                    ResumeGame();
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
                case GameEvents.SAVE_OPTIONS:
                    SaveOptions(value);
                    break;
                case GameEvents.WIN_RESOLUTION_UPDATED:
                    UpdateResolution(Convert.ToInt32(value[0]));
                    break;
                case GameEvents.SPEED_UPDATED:
                    UpdateSpeed(Convert.ToSingle(value[0]));
                    break;
                case GameEvents.PLAYER_COLOR_UPDATED:
                    UpdateColor(Convert.ToInt32(value[0]));
                    break;
                case GameEvents.SCORE_UPDATED:
                    UpdateScore(Convert.ToInt32(value[0]));
                    break;
                case GameEvents.LEVEL_FAILED:
                    OpenFailedWindow(value[0]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }
        



        private void UpdateResolution(int index)
        {
            var obj = GameObject.Find("/UI/Settings/Panel/ResolutionDropdown").GetComponent<Dropdown>();
            switch (index)
            {
                case 0:
                    Screen.SetResolution(640, 360, true);
                    obj.value = index;
                    break;
                case 1:
                    Screen.SetResolution(800, 600, true);
                    obj.value = index;
                    break;
                case 2:
                    Screen.SetResolution(1024, 768, true);
                    obj.value = index;
                    break;
                case 3:
                    Screen.SetResolution(1280, 800, true);
                    obj.value = index;
                    break;
                case 4:
                    Screen.SetResolution(1360, 768, true);
                    obj.value = index;
                    break;
                case 5:
                    Screen.SetResolution(1440, 900, true);
                    obj.value = index;
                    break;
                case 6:
                    Screen.SetResolution(1600, 900, true);
                    obj.value = index;
                    break;
                case 7:
                    Screen.SetResolution(1920, 1080, true);
                    obj.value = index;
                    break;
                case 8:
                    Screen.SetResolution(1920, 1200, true);
                    obj.value = index;
                    break;
                default:
                    break;
            }
        }

        private void UpdateColor(int value)
        {
            var obj = GameObject.Find("/UI/Settings/Panel/Dropdown").GetComponent<Dropdown>();
            switch (value)
            {
                case 0:
                    Settings.PlayerColor = Color.white;
                    obj.value = value;
                    break;
                case 1:
                    Settings.PlayerColor = Color.black;
                    obj.value = value;
                    break;
                case 2:
                    Settings.PlayerColor = Color.blue;
                    obj.value = value;
                    break;
                case 3:
                    Settings.PlayerColor = Color.cyan;
                    obj.value = value;
                    break;
                case 4:
                    Settings.PlayerColor = Color.gray;
                    obj.value = value;
                    break;
                case 5:
                    Settings.PlayerColor = Color.green;
                    obj.value = value;
                    break;
                case 6:
                    Settings.PlayerColor = Color.grey;
                    obj.value = value;
                    break;
                case 7:
                    Settings.PlayerColor = Color.magenta;
                    obj.value = value;
                    break;
                case 8:
                    Settings.PlayerColor = Color.red;
                    obj.value = value;
                    break;
                case 9:
                    Settings.PlayerColor = Color.yellow;
                    obj.value = value;
                    break;
                default:
                    break;
            }
        }

        private void UpdateSpeed(float value)
        {
            GameObject.Find("/UI/Settings/Panel/Slider/value").GetComponent<Text>().text = value.ToString();
            GameObject.Find("/UI/Settings/Panel/Slider").GetComponent<Slider>().value = value;
            Settings.PlayerSpeed = value;
        }

        private void UpdateScore(int value)
        {
            GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>().text = value.ToString();
            Settings.PlayerScore = value;
        }

        private void CloseApp()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        private void StartGame()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(true);
            ReloadGame();
        }

        private void ReloadGame()
        {
            Settings.PlayerScore = 0;
            // reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            // unload old scene
            SceneManager.UnloadSceneAsync(1);
            // resume game
            ResumeGame();
            // hide failed window
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text = "Score ";
        }

        private void OpenMenu()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(false);
            GameObject.Find("/UI/Settings/Panel").SetActive(false);
        }

        private void OpenFailedWindow(string value)
        {
            Settings.PlayerScore = Convert.ToInt32(value);
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text += value;
            GameObject.Find("/UI/Failed/Panel").SetActive(true);
        }

        private void OpenOptions()
        {
            GameObject.Find("/UI/Settings/Panel").SetActive(true);
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
        }

        private void SaveOptions(params string[] value)
        {
            DataManager manager = new DataManager();
            // save user settings
            manager.Save(value);
        }

        private void ResetOptions()
        {
            DataManager manager = new DataManager();
            manager.Reset();
            SaveOptions(DefaultSettings.PlayerSpeed.ToString(), DefaultSettings.PlayerColor.ToString(),
                DefaultSettings.GameResolution.ToString(), DefaultSettings.PlayerScore.ToString());
        }

        private void StopGame()
        {
            Settings.IsGameStopped = true;
        }

        private void ResumeGame()
        {
            Settings.IsGameStopped = false;
        }
    }
}