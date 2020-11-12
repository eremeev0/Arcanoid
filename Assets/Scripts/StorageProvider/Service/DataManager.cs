using System;
using System.IO;
using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using JetBrains.Annotations;
using UnityEngine;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;

namespace Assets.Scripts.StorageProvider.Service
{
    /// <summary>
    /// class that working with user configuration file
    /// </summary>
    public class DataManager: FileStorageManager
    {
        /// <summary>
        /// Load user configuration from persistent data path to game settings
        /// </summary>
        public void Load()
        {
            var values = Load("user.config");
            EventProvider eProvider = new EventProvider();
            eProvider.SendEvent(GameEvents.SPEED_UPDATED,
                values[0].Remove(0, Convert.ToString($"[{nameof(SettingsDto.PlayerSpeed)}] = ").Length));
            eProvider.SendEvent(GameEvents.PLAYER_COLOR_UPDATED,
                values[1].Remove(0, Convert.ToString($"[{nameof(SettingsDto.PlayerColor)}] = ").Length));
            eProvider.SendEvent(GameEvents.WIN_RESOLUTION_UPDATED,
                values[2].Remove(0, Convert.ToString($"[{nameof(SettingsDto.GameResolution)}] = ").Length));
            eProvider.SendEvent(GameEvents.SCORE_UPDATED,
                values[3].Remove(0, Convert.ToString($"[{nameof(SettingsDto.PlayerScore)}] = ").Length));
        }
        /// <summary>
        /// Save all received game settings to persistent data path
        /// </summary>
        /// <param name="values">Game settings in string format</param>
        public void Save([NotNull]params string[] values)
        {
            Save("user.config", values);
        }

        public void Reset()
        {
            EventProvider eProvider = new EventProvider();
            eProvider.SendEvent(GameEvents.SPEED_UPDATED, DefaultSettingsDto.PlayerSpeed.ToString());
            eProvider.SendEvent(GameEvents.PLAYER_COLOR_UPDATED, DefaultSettingsDto.PlayerColor.ToString());
            eProvider.SendEvent(GameEvents.WIN_RESOLUTION_UPDATED, DefaultSettingsDto.GameResolution.ToString());
            eProvider.SendEvent(GameEvents.SCORE_UPDATED, DefaultSettingsDto.PlayerScore.ToString());
        }
    }
}