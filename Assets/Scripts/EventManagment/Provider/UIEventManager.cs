using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.EventManagment.Provider
{
    public class UIEventManager
    {
        public void SendEvent(UIEvents @event)
        {
            switch (@event)
            {
                case UIEvents.GAME_STARTED:
                    StartGame();
                    break;
                case UIEvents.GAME_CLOSED:
                    CloseApp();
                    break;
                case UIEvents.GAME_RESTARTED:
                    ReloadGame();
                    break;
                case UIEvents.GAME_BACK_TO_MENU:
                    OpenMenu();
                    break;
                case UIEvents.GAME_OPEN_OPTIONS:
                    OpenOptions();
                    break;
                case UIEvents.RESET_OPTIONS:
                    ResetOptions();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        public void SendEvent(UIEvents @event, params string[] value)
        {
            switch (@event)
            {
                case UIEvents.SAVE_OPTIONS:
                    SaveOptions(value);
                    break;
                case UIEvents.WIN_RESOLUTION_UPDATED:
                    UpdateResolution(Convert.ToInt32(value[0]));
                    break;
                case UIEvents.SPEED_UPDATED:
                    UpdateSpeed(Convert.ToSingle(value[0]));
                    break;
                case UIEvents.PLAYER_COLOR_UPDATED:
                    UpdateColor(Convert.ToInt32(value[0]));
                    break;
                case UIEvents.SCORE_UPDATED:
                    UpdateScore(Convert.ToInt32(value[0]));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
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
            SettingsDto.PlayerScore = 0;
            // reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            // unload old scene
            SceneManager.UnloadSceneAsync(1);
            // resume game
            // hide failed window
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text = "Score ";
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            //ResumeGame();
        }

        private void OpenMenu()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            GameObject.Find("/UI/Score/Panel").SetActive(false);
            GameObject.Find("/UI/Settings/Panel").SetActive(false);
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
            SaveOptions(DefaultSettingsDto.PlayerSpeed.ToString(), DefaultSettingsDto.PlayerColor.ToString(),
                DefaultSettingsDto.GameResolution.ToString(), DefaultSettingsDto.PlayerScore.ToString());
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
                    SettingsDto.PlayerColor = Color.white;
                    obj.value = value;
                    break;
                case 1:
                    SettingsDto.PlayerColor = Color.black;
                    obj.value = value;
                    break;
                case 2:
                    SettingsDto.PlayerColor = Color.blue;
                    obj.value = value;
                    break;
                case 3:
                    SettingsDto.PlayerColor = Color.cyan;
                    obj.value = value;
                    break;
                case 4:
                    SettingsDto.PlayerColor = Color.gray;
                    obj.value = value;
                    break;
                case 5:
                    SettingsDto.PlayerColor = Color.green;
                    obj.value = value;
                    break;
                case 6:
                    SettingsDto.PlayerColor = Color.grey;
                    obj.value = value;
                    break;
                case 7:
                    SettingsDto.PlayerColor = Color.magenta;
                    obj.value = value;
                    break;
                case 8:
                    SettingsDto.PlayerColor = Color.red;
                    obj.value = value;
                    break;
                case 9:
                    SettingsDto.PlayerColor = Color.yellow;
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
            SettingsDto.PlayerSpeed = value;
        }

        private void UpdateScore(int value)
        {
            GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>().text = value.ToString();
            SettingsDto.PlayerScore = value;
        }
    }
}