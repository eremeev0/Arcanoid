using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.Models.Game;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.EventManagment.Provider
{
    public class GlobalEventManager
    {
        private readonly DataManager _settings;
        
        public GlobalEventManager()
        {
            _settings = new DataManager();
        }

        public void StartGame()
        {
            SettingsDto.IsGameStopped = false;
        }

        public void ResumeGame(GameObject player, GameObject ball)
        {
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Rigidbody2D>().simulated = true;
            ball.GetComponent<BallController>().enabled = true;

        }

        public void CloseGame()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void PauseGame(GameObject player, GameObject ball)
        {
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            ball.GetComponent<BallController>().enabled = false;
        }

        public void SetNextLevel(LevelN level)
        {
            level.Number++;
            level.BallPosition = default;
            level.PlayerPosition = default;
            level.PlatformsColor = default;
            level.PlatformsPosition = default;
        }

        public void SaveSettings()
        {
            _settings.Save(
                $"[{nameof(SettingsDto.PlayerSpeed)}] = {SettingsDto.PlayerSpeed}",
                           $"[{nameof(SettingsDto.PlayerColor)}] = {JsonUtility.ToJson(SettingsDto.PlayerColor)}",
                           $"[{nameof(SettingsDto.GameResolution)}] = {JsonUtility.ToJson(SettingsDto.GameResolution)}",
                           $"[{nameof(SettingsDto.PlayerScore)}] = {SettingsDto.PlayerScore}");
        }

        public void ResetSettings()
        {
            _settings.Save(
                $"[{nameof(SettingsDto.PlayerSpeed)}] = {DefaultSettingsDto.PlayerSpeed}",
                $"[{nameof(SettingsDto.PlayerColor)}] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerColor)}",
                $"[{nameof(SettingsDto.GameResolution)}] = {JsonUtility.ToJson(DefaultSettingsDto.GameResolution)}",
                $"[{nameof(SettingsDto.PlayerScore)}] = {DefaultSettingsDto.PlayerScore}");
        }
    }
}