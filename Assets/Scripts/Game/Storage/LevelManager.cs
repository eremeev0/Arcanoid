using Assets.Scripts.Cross.StorageProvider;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Game.Storage
{
    public class LevelManager
    {
        private readonly FileStorageManager _storageManager;

        public LevelManager()
        {
            _storageManager = new FileStorageManager();
        }

        public string[] Load(string savename)
        {
            var values = _storageManager.Load(Application.dataPath + $"/saves/{savename}.save");
            return values;
        }

        public void Save(string savename,[NotNull]params string[] values)
        {
            _storageManager.Save(Application.dataPath + $"/saves/{savename}.save", values);
        }
    }
}