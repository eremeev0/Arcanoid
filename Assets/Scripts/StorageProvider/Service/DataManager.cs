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
        private readonly FileStorageManager _manager = new FileStorageManager();
        private readonly EventManager _eventManager = ContainerDto.Manager;

        /// <summary>
        /// Load user configuration from persistent data path to game settings
        /// </summary>
        public void Load()
        {
            Debug.Log(Application.dataPath);
            var values = _manager.Load(Application.persistentDataPath + "/user.config");
            if (values == null) return;
            _eventManager.SendEvent(UIEvents.SETTINGS_UPDATED, values);
        }
        /// <summary>
        /// Save all received game settings to persistent data path
        /// </summary>
        /// <param name="values">Game settings in string format</param>
        public void Save([NotNull]params string[] values)
        {
            _manager.Save(Application.persistentDataPath + "/user.config", values);
        }

        public void Reset()
        {
            _eventManager.SendEvent(UIEvents.RESET_CLICKED);
        }
    }
}