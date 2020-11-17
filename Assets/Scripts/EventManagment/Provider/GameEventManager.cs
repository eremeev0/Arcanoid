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
        public void SendEvent(GameEvents @event)
        {
            switch (@event)
            {
                case GameEvents.GAME_PAUSED:
                    StopGame();
                    break;
                case GameEvents.GAME_RESUMED:
                    ResumeGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        public void SendEvent(GameEvents @event, string value)
        {
            switch (@event)
            {
                case GameEvents.LEVEL_FAILED:
                    OpenFailedWindow(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        public void SendEvent(GameEvents @event, GameObject @object, (float, int)[] pos)
        {
            Debug.Log("L-2");
            switch (@event)
            {
                case GameEvents.SPAWN_OBJECTS:
                    Debug.Log("L-3");
                    Spawn(@object, pos);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        private void StopGame()
        {
            /*ContainerDto.Player.GetComponent<PlayerController>().enabled = false;
            ContainerDto.Player.GetComponent<Rigidbody2D>().simulated = false;
            ContainerDto.Ball.GetComponent<BallController>().enabled = false;*/
            //SettingsDto.IsGameStopped = true;
        }

        private void ResumeGame()
        {
            /*ContainerDto.Player.GetComponent<PlayerController>().enabled = true;
            ContainerDto.Player.GetComponent<Rigidbody2D>().simulated = true;
            ContainerDto.Ball.GetComponent<BallController>().enabled = true;*/
            //SettingsDto.IsGameStopped = false;
        }
        private void OpenFailedWindow(string value)
        {
            SettingsDto.PlayerScore = Convert.ToInt32(value);
            /*ContainerDto.Failed.SetActive(true);
            ContainerDto.RecordLabel.text += value;*/
        }

        private void Spawn(GameObject spawnedObject, (float, int)[] pos)
        {
            Debug.Log("L-4");
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