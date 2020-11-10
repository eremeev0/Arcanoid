using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// class that working with user configuration file
    /// </summary>
    public class DataManager: MonoBehaviour
    {
        /// <summary>
        /// Load user configuration from persistent data path to game settings
        /// </summary>
        public void Load()
        {
            UIController controller = gameObject.AddComponent<UIController>();
            var props = File.ReadAllLines(Application.persistentDataPath + "/user.config");
            Settings.PlayerSpeed = (float)Convert.ToDouble(props[0]);
            controller.ColorUpdated(Convert.ToInt32(props[1]));
            controller.SetNewResolution(Convert.ToInt32(props[2]));
            Settings.PlayerScore = Convert.ToInt32(props[3]);
        }
        /// <summary>
        /// Save all received game settings to persistent data path
        /// </summary>
        /// <param name="values">Game settings in string format</param>
        public void Save([NotNull]params string[] values)
        {
            Debug.Log(Application.persistentDataPath);
            using (FileStream fs = new FileStream(Application.persistentDataPath + "/user.config", FileMode.OpenOrCreate))
            {
                fs.Flush();
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