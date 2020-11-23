using Assets.Scripts.Cross.StatesManagament.Provider;
using Assets.Scripts.Cross.StorageProvider;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Game.Storage
{
    /// <summary>
    /// class that working with user configuration file
    /// </summary>
    public class DataManager
    {
        private readonly FileStorageManager _manager = new FileStorageManager();
        private readonly EventManager _eventManager = null;

        /// <summary>
        /// Load user configuration from persistent data path to game settings
        /// </summary>
        public string[] Load()
        {
            Debug.Log(Application.dataPath);
            var values = _manager.Load(Application.dataPath + "/user.config");
            return values;
            //_eventManager.SendEvent(UIEvents.SETTINGS_UPDATED, values);
        }
        /// <summary>
        /// Save all received game settings to persistent data path
        /// </summary>
        /// <param name="values">Game settings in string format</param>
        public void Save([NotNull]params string[] values)
        {
            Debug.Log(Application.dataPath + "/user.config");
            _manager.Save(Application.dataPath + "/user.config", values);
        }
    }
}