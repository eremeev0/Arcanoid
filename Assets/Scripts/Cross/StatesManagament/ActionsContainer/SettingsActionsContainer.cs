using Assets.Scripts.Cross.Contracts;
using Assets.Scripts.Game.Storage;
using UnityEngine;

namespace Assets.Scripts.Cross.StatesManagament.ActionsContainer
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
                $"[PlayerSpeed] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerSpeed)}",
                $"[PlayerColor] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerColor)}",
                $"[GameResolution] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().GameResolution)}",
                $"[PlayerScore] = {JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerScore)}"
                );
        }

        public void LoadSettings()
        {
            var settings = _dataManager.Load();
            if (settings == null) 
                return;
            string value = string.Empty;
            
            value = $"[PlayerSpeed] = ";
            SettingsSingleton.GetSettings().PlayerSpeed =
                JsonUtility.FromJson<float>(settings[0].Remove(0, value.Length));

            value = $"[PlayerColor] = ";
            SettingsSingleton.GetSettings().PlayerColor =
                JsonUtility.FromJson<Color>(settings[1].Remove(0, value.Length));

            value = $"[GameResolution] = ";
            SettingsSingleton.GetSettings().GameResolution =
                JsonUtility.FromJson<Vector2>(settings[2].Remove(0, value.Length));
            
            value = $"[PlayerScore] = ";
            SettingsSingleton.GetSettings().PlayerScore =
                JsonUtility.FromJson<int>(settings[3].Remove(0, value.Length));
        }

        public void ResetSettings()
        {
            _dataManager.Save(
                $"[PlayerSpeed] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerSpeed)}",
                $"[PlayerColor] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerColor)}",
                $"[GameResolution] = {JsonUtility.ToJson(DefaultSettingsDto.GameResolution)}",
                $"[PlayerScore] = {JsonUtility.ToJson(DefaultSettingsDto.PlayerScore)}"
            );
        }
    }
}