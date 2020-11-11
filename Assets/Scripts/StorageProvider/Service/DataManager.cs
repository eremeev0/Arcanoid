using System.IO;
using Assets.Scripts.ConfigurationManagment;
using Assets.Scripts.EventManagment.Events;
using JetBrains.Annotations;
using UnityEngine;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;

namespace Assets.Scripts.StorageProvider.Service
{
    /// <summary>
    /// class that working with user configuration file
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Load user configuration from persistent data path to game settings
        /// </summary>
        public void Load()
        {
            EventProvider eProvider = new EventProvider();
            var props = File.ReadAllLines(Application.persistentDataPath + "/user.config");
            eProvider.SendEvent(GameEvents.SPEED_UPDATED, props[0]);
            eProvider.SendEvent(GameEvents.PLAYER_COLOR_UPDATED, props[1]);
            eProvider.SendEvent(GameEvents.WIN_RESOLUTION_UPDATED, props[2]);
            eProvider.SendEvent(GameEvents.SCORE_UPDATED, props[3]);
        }
        /// <summary>
        /// Save all received game settings to persistent data path
        /// </summary>
        /// <param name="values">Game settings in string format</param>
        public void Save([NotNull]params string[] values)
        {
            Debug.Log(Application.persistentDataPath);
            File.WriteAllLines(Application.persistentDataPath + "/user.config", values);
        }

        public void Reset()
        {
            EventProvider eProvider = new EventProvider();
            eProvider.SendEvent(GameEvents.SPEED_UPDATED, DefaultSettings.PlayerSpeed.ToString());
            eProvider.SendEvent(GameEvents.PLAYER_COLOR_UPDATED, DefaultSettings.PlayerColor.ToString());
            eProvider.SendEvent(GameEvents.WIN_RESOLUTION_UPDATED, DefaultSettings.GameResolution.ToString());
            eProvider.SendEvent(GameEvents.SCORE_UPDATED, DefaultSettings.PlayerScore.ToString());
        }
    }
}