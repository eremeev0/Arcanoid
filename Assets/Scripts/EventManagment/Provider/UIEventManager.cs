﻿using System;
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
            ContainerDto.Menu.SetActive(false);
            ContainerDto.Score.SetActive(true);
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
            ContainerDto.RecordLabel.text = "Score ";
            ContainerDto.Failed.SetActive(false);
            //ResumeGame();
        }

        private void OpenMenu()
        {
            ContainerDto.Menu.SetActive(true);
            ContainerDto.Failed.SetActive(false);
            ContainerDto.Score.SetActive(false);
            ContainerDto.Settings.SetActive(false);
        }
        private void OpenOptions()
        {
            ContainerDto.Settings.SetActive(true);
            ContainerDto.Menu.SetActive(false);
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
            switch (index)
            {
                case 0:
                    Screen.SetResolution(640, 360, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 1:
                    Screen.SetResolution(800, 600, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 2:
                    Screen.SetResolution(1024, 768, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 3:
                    Screen.SetResolution(1280, 800, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 4:
                    Screen.SetResolution(1360, 768, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 5:
                    Screen.SetResolution(1440, 900, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 6:
                    Screen.SetResolution(1600, 900, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 7:
                    Screen.SetResolution(1920, 1080, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                case 8:
                    Screen.SetResolution(1920, 1200, true);
                    ContainerDto.ResolutionsList.value = index;
                    break;
                default:
                    break;
            }
        }

        private void UpdateColor(int value)
        {
            switch (value)
            {
                case 0:
                    SettingsDto.PlayerColor = Color.white;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 1:
                    SettingsDto.PlayerColor = Color.black;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 2:
                    SettingsDto.PlayerColor = Color.blue;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 3:
                    SettingsDto.PlayerColor = Color.cyan;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 4:
                    SettingsDto.PlayerColor = Color.gray;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 5:
                    SettingsDto.PlayerColor = Color.green;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 6:
                    SettingsDto.PlayerColor = Color.grey;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 7:
                    SettingsDto.PlayerColor = Color.magenta;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 8:
                    SettingsDto.PlayerColor = Color.red;
                    ContainerDto.ColorsList.value = value;
                    break;
                case 9:
                    SettingsDto.PlayerColor = Color.yellow;
                    ContainerDto.ColorsList.value = value;
                    break;
                default:
                    break;
            }
        }

        private void UpdateSpeed(float value)
        {
            ContainerDto.SpeedValue.text = value.ToString();
            ContainerDto.SpeedSlider.value = value;
            SettingsDto.PlayerSpeed = value;
        }

        private void UpdateScore(int value)
        {
            ContainerDto.ScoreLabel.text = value.ToString();
            SettingsDto.PlayerScore = value;
        }
    }
}