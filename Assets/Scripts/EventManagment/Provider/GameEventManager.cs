using System;
using System.Collections.Generic;
using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Assets.Scripts.EventManagment.Provider
{
    public class GameEventManager
    {
        private void OpenFailedWindow(string value)
        {
            SettingsDto.PlayerScore = Convert.ToInt32(value);
            /*ContainerDto.Failed.SetActive(true);
            ContainerDto.RecordLabel.text += value;*/
        }

        private void Spawn(GameObject spawnedObject, (float, int)[] pos)
        {
            GameObject newObject;
            Vector3 originalPos = spawnedObject.transform.position;
            for (int i = 0; i < pos.Length; i++)
            {
                // Clone object and set new position
                newObject = Object.Instantiate(spawnedObject, new Vector3(originalPos.x + pos[i].Item1, originalPos.y + pos[i].Item2, originalPos.z), Quaternion.identity);
                newObject.name = "Platform";
                // Set parent for new object
                //newObject.transform.parent = ContainerDto.PlatformsList.transform;
            }
        }
    }
}