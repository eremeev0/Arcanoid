using System.IO;
using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.Cross.Models;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Controllers.Sub;
using Assets.Scripts.Game.Storage;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Cross.StatesManagament.ActionsContainer
{
    public class GlobalActionContainer
    {

        private readonly DataManager _settings;
        public GlobalActionContainer()
        {
            _settings = new DataManager();
        }

        public void StartGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = false;
        }


        public void ResumeGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = false;

        }

        public void CloseGame()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void PauseGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = true;
        }

        public void SaveSettings()
        {
            _settings.Save(
                $"[{nameof(SettingsDto.PlayerSpeed)}] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerSpeed)}",
                           $"[{nameof(SettingsDto.PlayerColor)}] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerColor)}",
                           $"[{nameof(SettingsDto.GameResolution)}] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().GameResolution)}",
                           $"[{nameof(SettingsDto.PlayerScore)}] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerScore)}");
        }

        public void ResetSettings()
        {
            _settings.Save(
                $"[{nameof(SettingsDto.PlayerSpeed)}] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerSpeed)}",
                $"[{nameof(SettingsDto.PlayerColor)}] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerColor)}",
                $"[{nameof(SettingsDto.GameResolution)}] = {JsonUtility.ToJson(DefaultSettingsDto.GameResolution)}",
                $"[{nameof(SettingsDto.PlayerScore)}] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerScore)}");
        }
    }
}