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
        private void ReloadGame()
        {
            SettingsDto.PlayerScore = 0;
            // reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            // unload old scene
            SceneManager.UnloadSceneAsync(1);
            // resume game
            // hide failed window
            /*ContainerDto.RecordLabel.text = "Score ";
            ContainerDto.Failed.SetActive(false);*/
            //ResumeGame();
        }
        private void UpdateSettings(string[] values)
        {
            UpdateSpeed(Convert.ToSingle(values[0].Remove(0,
                Convert.ToString($"[{nameof(SettingsDto.PlayerSpeed)}] = ").Length)));
            UpdateColor(Convert.ToInt32(values[1].Remove(0,
                Convert.ToString($"[{nameof(SettingsDto.PlayerColor)}] = ").Length)));
            UpdateResolution(Convert.ToInt32(values[2].Remove(0,
                Convert.ToString($"[{nameof(SettingsDto.GameResolution)}] = ").Length)));
            UpdateScore(Convert.ToInt32(values[3].Remove(0,
                Convert.ToString($"[{nameof(SettingsDto.PlayerScore)}] = ").Length)));
        }

        private void UpdateResolution(int index)
        {
            switch (index)
            {
                case 0:
                    Screen.SetResolution(640, 360, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 1:
                    Screen.SetResolution(800, 600, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 2:
                    Screen.SetResolution(1024, 768, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 3:
                    Screen.SetResolution(1280, 800, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 4:
                    Screen.SetResolution(1360, 768, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 5:
                    Screen.SetResolution(1440, 900, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 6:
                    Screen.SetResolution(1600, 900, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 7:
                    Screen.SetResolution(1920, 1080, true);
                    //ContainerDto.ResolutionsList.value = index;
                    break;
                case 8:
                    Screen.SetResolution(1920, 1200, true);
                    //ContainerDto.ResolutionsList.value = index;
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
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 1:
                    SettingsDto.PlayerColor = Color.black;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 2:
                    SettingsDto.PlayerColor = Color.blue;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 3:
                    SettingsDto.PlayerColor = Color.cyan;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 4:
                    SettingsDto.PlayerColor = Color.gray;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 5:
                    SettingsDto.PlayerColor = Color.green;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 6:
                    SettingsDto.PlayerColor = Color.grey;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 7:
                    SettingsDto.PlayerColor = Color.magenta;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 8:
                    SettingsDto.PlayerColor = Color.red;
                    //ContainerDto.ColorsList.value = value;
                    break;
                case 9:
                    SettingsDto.PlayerColor = Color.yellow;
                    //ContainerDto.ColorsList.value = value;
                    break;
                default:
                    break;
            }
        }

        private void UpdateSpeed(float value)
        {
            //ContainerDto.SpeedValue.text = value.ToString();
            //ContainerDto.SpeedSlider.value = value;
            SettingsDto.PlayerSpeed = value;
        }

        private void UpdateScore(int value)
        {
            //ContainerDto.ScoreLabel.text = value.ToString();
            SettingsDto.PlayerScore = value;
        }
    }
}