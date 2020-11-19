﻿using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.Models.Game;
using Assets.Scripts.Performances.Services;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.EventManagment.Provider
{
    public class GlobalEventManager
    {
        private readonly DataManager _settings;
        private readonly LevelHelperService _levelHelper;
        public GlobalEventManager()
        {
            _settings = new DataManager();
            _levelHelper = new LevelHelperService();
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

        public LevelN GenerateLevel(LevelN level)
        {
            Debug.Log(level.Number++);
            Debug.Log(level.Platform = _levelHelper.GetGameObjectFromResources("Prefabs/ActiveObjects/Platform"));
            Debug.Log(level.BallPosition = _levelHelper.GetStaticBallPosition());
            Debug.Log(level.PlayerPosition = _levelHelper.GetStaticPlayerPosition());
            Debug.Log(level.PlatformsColor = _levelHelper.GetPlatformsColor(level.Number));
            Debug.Log(level.PlatformsPosition = _levelHelper.GetPlatformsRelativePosition(level.Number, level.Platform.transform.localPosition));
            Debug.Log(level.ToString());
            return level;
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