using System.IO;
using Assets.Scripts.EventManagment.Events;
using JetBrains.Annotations;
using UnityEngine;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;

namespace Assets.Scripts.StorageProvider
{
    public class FileStorageManager
    {
        public void Save(string filename,[NotNull] params string[] data)
        {
            var path = Application.persistentDataPath + "/" + filename;
            Debug.Log(Application.persistentDataPath);
            if (!File.Exists(path))
                File.Create(path);
            File.WriteAllLines(path, data);
        }
        public string[] Load(string filename)
        {
            var path = Application.persistentDataPath + "/" + filename;
            if (File.Exists(path))
            {
                var props = File.ReadAllLines(path);
                return props;
            }

            return null;
        }
    }
}