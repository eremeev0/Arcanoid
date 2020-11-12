using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.EventManagment.Provider
{
    public class GameEventProvider
    {
        public void SendEvent(GameEvents @event)
        {
            switch (@event)
            {
                case GameEvents.GAME_PAUSED:
                    break;
                case GameEvents.GAME_RESUMED:
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
            GameObject.Find("/Character/playerPillar").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("/ActiveObjects/gameBall").GetComponent<BallController>().enabled = false;
            SettingsDto.IsGameStopped = true;
        }

        private void ResumeGame()
        {
            GameObject.Find("/Character/playerPillar").GetComponent<PlayerController>().enabled = true;
            GameObject.Find("/ActiveObjects/gameBall").GetComponent<BallController>().enabled = true;
            SettingsDto.IsGameStopped = false;
        }
        private void OpenFailedWindow(string value)
        {
            SettingsDto.PlayerScore = Convert.ToInt32(value);
            GameObject.Find("/UI/Failed/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text += value;
        }
    }
}