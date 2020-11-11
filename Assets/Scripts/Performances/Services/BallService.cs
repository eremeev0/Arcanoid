using System;
using Assets.Scripts.ConfigurationManagment;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Performances.Services
{
    public class BallService: MonoBehaviour, IBallService
    {
        private float _speed = Settings.BallSpeed;
        private float _maxSpeed = Settings.BallMaxSpeed;
        private float _speedMultiplier = Settings.BallSpeedMultiplier;
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
            new EventProvider().SendEvent(GameEvents.LEVEL_FAILED, gameObject.AddComponent<ScoreController>().GetScore().ToString());
        }

        public void SpeedUp()
        {
            if (_speed < _maxSpeed)
                _speed += _speedMultiplier;
            _isSpeedUpdate = true;
        }

        public void IncrementScore()
        {
            gameObject.AddComponent<ScoreController>().UpdateScore(1);
        }
    }
}