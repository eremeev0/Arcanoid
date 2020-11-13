using Assets.Scripts.Contracts;
using Assets.Scripts.Controllers;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class BallService: MonoBehaviour, IBallService
    {
        private float _speed = SettingsDto.BallSpeed;
        private float _maxSpeed = SettingsDto.BallMaxSpeed;
        private float _speedMultiplier = SettingsDto.BallSpeedMultiplier;
        private Vector2 _velocity;
        private bool _isSpeedUpdate = false;
        private bool _isVelocityUpdate = false;
        private IDestrPlatformService _destroyedPlatform;
        void Start()
        {
            _destroyedPlatform = gameObject.AddComponent<DestrPlatformService>();
        }


        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }
        
        public float GetSpeed()
        {
            _isSpeedUpdate = false;
            return _speed;
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }

        public bool IsSpeedUpdate()
        {
            return _isSpeedUpdate;
        }

        public bool IsVelocityUpdate()
        {
            return _isVelocityUpdate;
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
        void OnCollisionEnter2D(Collision2D col)
        {
            SpeedUp();
            _isVelocityUpdate = true;
            switch (col.gameObject.name)
            {
                case "playerPillar":
                    _velocity.y = -_velocity.y;
                    break;
                case "topPillar":
                    _velocity.y = -_velocity.y;
                    break;
                case "leftPillar":
                    _velocity.x = -_velocity.x;
                    break;
                case "rightPillar":
                    _velocity.x = -_velocity.x;
                    break;
                case "bottomSide":
                    _velocity.y = -_velocity.y;
                    break;
                case "Platform":
                    Destroy(col.gameObject);
                    _velocity.y = -_velocity.y;
                    IncrementScore();
                    _destroyedPlatform.Destroy();
                    if (_destroyedPlatform.IsAllDestroyed())
                    {
                        ContainerDto.Manager.SendEvent(GameEvents.GAME_PAUSED);
                        // and level 1 complete
                    }
                    break;
                default:
                    break;
            }
        }
    }
}