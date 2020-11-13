using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using UnityEngine;
using UnityEngine.UI;

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

        public void SendEvent(GameEvents @event, params string[] value)
        {
            switch (@event)
            {
                case GameEvents.LEVEL_FAILED:
                    OpenFailedWindow(value[0]);
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
    }
}