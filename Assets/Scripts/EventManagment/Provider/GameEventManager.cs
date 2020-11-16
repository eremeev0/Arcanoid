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

        public void SendEvent(GameEvents @event, [NotNull] GameObject @object, (int, int)[] pos)
        {
            if (@object == null) throw new ArgumentNullException(nameof(@object));
            switch (@event)
            {
                case GameEvents.SPAWN_OBJECTS:
                    Spawn(@object, pos);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
        }

        private void StopGame()
        {
            ContainerDto.Player.GetComponent<PlayerController>().enabled = false;
            ContainerDto.Player.GetComponent<Rigidbody2D>().simulated = false;
            ContainerDto.Ball.GetComponent<BallController>().enabled = false;
            //SettingsDto.IsGameStopped = true;
        }

        private void ResumeGame()
        {
            ContainerDto.Player.GetComponent<PlayerController>().enabled = true;
            ContainerDto.Player.GetComponent<Rigidbody2D>().simulated = true;
            ContainerDto.Ball.GetComponent<BallController>().enabled = true;
            //SettingsDto.IsGameStopped = false;
        }
        private void OpenFailedWindow(string value)
        {
            SettingsDto.PlayerScore = Convert.ToInt32(value);
            ContainerDto.Failed.SetActive(true);
            ContainerDto.RecordLabel.text += value;
        }

        private void Spawn(GameObject spawnedObject, (int, int)[] pos)
        {
            GameObject newObject;
            Vector3 originalPos = spawnedObject.transform.position;
            for (int i = 0; i < pos.Length; i++)
            {
                // Clone object
                newObject = Object.Instantiate(spawnedObject);
                // Set new Pos
                newObject.transform.position = new Vector3(originalPos.x + pos[i].Item1, originalPos.y + pos[i].Item2, originalPos.z);
                // Set parent for new object
                newObject.transform.parent = spawnedObject.transform;
            }
        }
    }
}