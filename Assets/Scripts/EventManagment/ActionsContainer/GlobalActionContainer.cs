using System.IO;
using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.Models.Game;
using Assets.Scripts.Performances.Services;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.EventManagment.ActionsContainer
{
    public class GlobalActionContainer
    {
        private const string _boundleName = "Boundles\\platform";
        private const string _assetName = "Platform";
        private AssetBundle _localAssetBundle;

        private readonly DataManager _settings;
        private readonly LevelHelperService _levelHelper;
        public GlobalActionContainer()
        {
            _settings = new DataManager();
            _levelHelper = new LevelHelperService();
        }

        public void StartGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = false;
        }


        public void ResumeGame(GameObject player, GameObject ball)
        {
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Rigidbody2D>().simulated = true;
            ball.GetComponent<BallController>().enabled = true;
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

        public void PauseGame(GameObject player, GameObject ball)
        {
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            ball.GetComponent<BallController>().enabled = false;
            SettingsSingleton.GetSettings().IsGameStopped = true;
        }

        public LevelN GenerateLevel(LevelN level)
        {
            _localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, _boundleName));
            if (_localAssetBundle == null)
            {
                Debug.LogError("Failed to load AssetBoundle");
                return null;
            }
            level.Number++;
            level.Platform = _localAssetBundle.LoadAsset<GameObject>(_assetName);//_levelHelper.GetGameObjectFromResources("Prefabs/ActiveObjects/Platform"); // remove
            level.BallPosition = _levelHelper.GetInitialBallPosition();
            level.PlayerPosition = _levelHelper.GetInitialPlayerPosition();
            level.PlatformsColor = _levelHelper.GetPlatformsColor(level.Number);
            level.PlatformsPosition = _levelHelper.GetPlatformsRelativePosition(level.Number, level.Platform.transform.localPosition);
            return level;
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