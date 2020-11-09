using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataManager
    {
        public void Load()
        {
            UIController controller = new UIController();
            var props = File.ReadAllLines(Application.persistentDataPath + "/user.config");
            Settings.PlayerSpeed = (float)Convert.ToDouble(props[0]);
            controller.ColorUpdated(Convert.ToInt32(props[1]));
            controller.SetNewResolution(Convert.ToInt32(props[2]));
            Settings.PlayerScore = Convert.ToInt32(props[3]);
            Debug.Log(Settings.PlayerSpeed);
            Debug.Log(Settings.PlayerScore);
            Debug.Log(Settings.PlayerColor);
        }

        public void Save([NotNull]params string[] values)
        {
            Debug.Log(Application.persistentDataPath);
            using (FileStream fs = new FileStream(Application.persistentDataPath + "/user.config", FileMode.OpenOrCreate))
            {
                foreach (var value in values)
                {
                    if (fs.CanWrite)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(value + "\n");
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}