using System.IO;
using JetBrains.Annotations;

namespace Assets.Scripts.MultiOriented.StorageProvider
{
    public class FileStorageManager
    {
        public void Save(string path,[NotNull] params string[] data)
        {
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