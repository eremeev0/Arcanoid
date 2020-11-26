using Assets.Scripts.GameScene;
using Assets.Scripts.GameScene.Storage;
using Assets.Scripts.MultiOriented.Contracts;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer
{
    public class GlobalActionContainer
    {

        private readonly DataManager _settings;
        private readonly LevelLoader _levelLoader;
        public GlobalActionContainer()
        {
            _settings = new DataManager();
            _levelLoader = LevelLoader.GetLoader();
        }

        public void StartGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = false;
            if (_levelLoader.Level == null)
            {
                _levelLoader.Run(LevelStates.InitializeLevel);
            }
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