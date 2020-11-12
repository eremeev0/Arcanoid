using System.IO;
using Assets.Scripts.EventManagment.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.StorageProvider
{
    public class FileStorageManager
    {
        public void Save(string path,[NotNull] params string[] data)
        {
            Debug.Log(path);
            if (!File.Exists(path))
                File.Create(path);
            File.WriteAllLines(path, data);
        }
        public string[] Load(string path)
        {
            if (File.Exists(path))
            {
                var props = File.ReadAllLines(path);
                return props;
            }

            return null;
        }
    }
}