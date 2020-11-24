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
                JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerSpeed),
                JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerColor),
                JsonUtility.ToJson(SettingsSingleton.GetSettings().GameResolution),
                JsonUtility.ToJson(SettingsSingleton.GetSettings().PlayerScore)
                );
        }

        public void LoadSettings()
        {
            var settings = _dataManager.Load();
            if (settings == null) 
                return;

            SettingsSingleton.GetSettings().PlayerSpeed = JsonUtility.FromJson<float>(settings[0]);
            SettingsSingleton.GetSettings().PlayerColor = JsonUtility.FromJson<Color>(settings[1]);
            SettingsSingleton.GetSettings().GameResolution = JsonUtility.FromJson<Vector2>(settings[2]);
            SettingsSingleton.GetSettings().PlayerScore = JsonUtility.FromJson<int>(settings[3]);
        }

        public void ResetSettings()
        {
            _dataManager.Save(
                JsonUtility.ToJson(DefaultSettingsDto.PlayerSpeed),
                JsonUtility.ToJson(DefaultSettingsDto.PlayerColor),
                JsonUtility.ToJson(DefaultSettingsDto.GameResolution),
                JsonUtility.ToJson(DefaultSettingsDto.PlayerScore)
            );
        }
    }
}