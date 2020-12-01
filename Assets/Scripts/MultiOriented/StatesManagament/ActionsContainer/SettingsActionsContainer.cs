using System;
using Assets.Scripts.GameScene.Storage;
using Assets.Scripts.MultiOriented.Contracts;
using UnityEngine;

namespace Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer
{
    public class SettingsActionsContainer
    {
        private DataManager _dataManager;

        public SettingsActionsContainer()
        {
            _dataManager = new DataManager();
        }

        public void SaveSettings()
        {
            _dataManager.Save(
                    $"[{nameof(SettingsSingleton.PlayerSpeed)}] = {SettingsSingleton.GetSettings().PlayerSpeed}",
                    $"[{nameof(SettingsSingleton.PlayerScore)}] = {SettingsSingleton.GetSettings().PlayerScore}",
                    $"[{nameof(SettingsSingleton.SoundsVolume)}] = {SettingsSingleton.GetSettings().SoundsVolume}",
                    $"[{nameof(SettingsSingleton.PlayerColor)}] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerColor)}",
                    $"[{nameof(SettingsSingleton.GameResolution)}] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().GameResolution)}"
            );
        }

        public void LoadSettings()
        {
            var settings = _dataManager.Load();
            if (settings == null) 
                return;

            string[] salt = new string[]
            {
                $"[{nameof(SettingsSingleton.PlayerSpeed)}] = ",
                $"[{nameof(SettingsSingleton.PlayerScore)}] = ",
                $"[{nameof(SettingsSingleton.SoundsVolume)}] = ",
                $"[{nameof(SettingsSingleton.PlayerColor)}] = ",
                $"[{nameof(SettingsSingleton.GameResolution)}] = ",
            };


            SettingsSingleton.GetSettings().PlayerSpeed = Convert.ToSingle(settings[0].Remove(0, salt[0].Length));
            SettingsSingleton.GetSettings().PlayerScore = Convert.ToInt32(settings[1].Remove(0, salt[1].Length));
            SettingsSingleton.GetSettings().SoundsVolume = Convert.ToInt32(settings[2].Remove(0, salt[2].Length));
            SettingsSingleton.GetSettings().PlayerColor = JsonUtility.FromJson<Color>(settings[3].Remove(0, salt[3].Length));
            SettingsSingleton.GetSettings().GameResolution = JsonUtility.FromJson<Vector2>(settings[4].Remove(0, salt[4].Length));
        }

        public void ResetSettings()
        {
            _dataManager.Save(
                $"[{nameof(SettingsSingleton.PlayerSpeed)}] = {DefaultSettingsDto.PlayerSpeed}",
                $"[{nameof(SettingsSingleton.PlayerScore)}] = {DefaultSettingsDto.PlayerScore}",
                $"[{nameof(SettingsSingleton.SoundsVolume)}] = {DefaultSettingsDto.SoundsVolume}",
                $"[{nameof(SettingsSingleton.PlayerColor)}] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerColor)}",
                $"[{nameof(SettingsSingleton.GameResolution)}] = {JsonUtility.ToJson(DefaultSettingsDto.GameResolution)}"
            );
        }
    }
}