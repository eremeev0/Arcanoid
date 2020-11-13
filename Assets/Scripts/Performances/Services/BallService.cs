using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Performances.Services
{
    public class BallService: MonoBehaviour, IBallService
    {
        private float _speed = SettingsDto.BallSpeed;
        private float _maxSpeed = SettingsDto.BallMaxSpeed;
        private float _speedMultiplier = SettingsDto.BallSpeedMultiplier;
        private Vector2 _velocity;
        private bool _isSpeedUpdate = false;

        void Start()
        {

        }


        public float GetSpeed()
        {
            _isSpeedUpdate = false;
            return _speed;
        }

        public Vector2 GetVelocity()
        {
            print(_velocity);
            return _velocity;
        }

        public bool IsSpeedUpdate()
        {
            return _isSpeedUpdate;
        }

        public void Failed()
        {
            ContainerDto.Manager.SendEvent(GameEvents.LEVEL_FAILED, new ScoreController().GetScore().ToString());
        }

        public void SpeedUp()
        {
            if (_speed < _maxSpeed)
                _speed += _speedMultiplier;
            _isSpeedUpdate = true;
        }

        public void IncrementScore()
        {
            new ScoreController().UpdateScore(1);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            // if ball touch bottom trigger
            if (col.gameObject.name == "GameOver")
            {
                print("GameOver");
                // hide ball and display failed window
                gameObject.SetActive(false);
                Failed();
                ContainerDto.Manager.SendEvent(GameEvents.GAME_PAUSED);
            }
        }
    }
}