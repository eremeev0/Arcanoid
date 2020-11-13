﻿using System;
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
            GameObject player = GameObject.Find("/Character/playerPillar");
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            GameObject.Find("/ActiveObjects/gameBall").GetComponent<BallController>().enabled = false;
            //SettingsDto.IsGameStopped = true;
        }

        private void ResumeGame()
        {
            GameObject player = GameObject.Find("/Character/playerPillar");
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Rigidbody2D>().simulated = true;
            GameObject.Find("/ActiveObjects/gameBall").GetComponent<BallController>().enabled = true;
            //SettingsDto.IsGameStopped = false;
        }
        private void OpenFailedWindow(string value)
        {
            SettingsDto.PlayerScore = Convert.ToInt32(value);
            GameObject.Find("/UI/Failed/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text += value;
        }
    }
}