using System;
using System.IO;
using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.StorageProvider.Service
{
    /// <summary>
    /// class that working with user configuration file
    /// </summary>
    public class DataManager
    {
        private EventManager eProvider;
        private readonly FileStorageManager manager = new FileStorageManager();

        
        /// <summary>
        /// Load user configuration from persistent data path to game settings
        /// </summary>
        public void Load()
        {
            var values = manager.Load(Application.persistentDataPath + "/user.config");
            eProvider = GameObject.Find("EventSystem2").GetComponent<EventManager>();
            eProvider.SendEvent(UIEvents.SPEED_UPDATED,
                values[0].Remove(0, Convert.ToString($"[{nameof(SettingsDto.PlayerSpeed)}] = ").Length));
            eProvider.SendEvent(UIEvents.PLAYER_COLOR_UPDATED,
                values[1].Remove(0, Convert.ToString($"[{nameof(SettingsDto.PlayerColor)}] = ").Length));
            eProvider.SendEvent(UIEvents.WIN_RESOLUTION_UPDATED,
                values[2].Remove(0, Convert.ToString($"[{nameof(SettingsDto.GameResolution)}] = ").Length));
            eProvider.SendEvent(UIEvents.SCORE_UPDATED,
                values[3].Remove(0, Convert.ToString($"[{nameof(SettingsDto.PlayerScore)}] = ").Length));
        }
        /// <summary>
        /// Save all received game settings to persistent data path
        /// </summary>
        /// <param name="values">Game settings in string format</param>
        public void Save([NotNull]params string[] values)
        {
            manager.Save(Application.persistentDataPath + "/user.config", values);
        }

        public void Reset()
        {
            eProvider = GameObject.Find("EventSystem2").GetComponent<EventManager>();
            eProvider.SendEvent(UIEvents.SPEED_UPDATED, DefaultSettingsDto.PlayerSpeed.ToString());
            eProvider.SendEvent(UIEvents.PLAYER_COLOR_UPDATED, DefaultSettingsDto.PlayerColor.ToString());
            eProvider.SendEvent(UIEvents.WIN_RESOLUTION_UPDATED, DefaultSettingsDto.GameResolution.ToString());
            eProvider.SendEvent(UIEvents.SCORE_UPDATED, DefaultSettingsDto.PlayerScore.ToString());
        }
    }
}