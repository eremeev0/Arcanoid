using Assets.Scripts.Contracts;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    public class BallService: MonoBehaviour, IBallService
    {
        private float _speed = SettingsDto.BallSpeed;
        private readonly float _maxSpeed = SettingsDto.BallMaxSpeed;
        private readonly float _speedMultiplier = SettingsDto.BallSpeedMultiplier;
        private Vector2 _velocity;
        
        private IDestrPlatformService _destroyedPlatform;
       
        private bool _isSpeedUpdate;
        private bool _isVelocityUpdate;

        private void Start()
        {
            _isSpeedUpdate = false;
            _isVelocityUpdate = false;
            _destroyedPlatform = new DestrPlatformService();
        }


        //public void SetVelocity(Vector2 velocity){_velocity = velocity;}
        
        public float GetSpeed()
        {
            _isSpeedUpdate = false;
            return _speed;
        }

        public Vector2 GetVelocity()
        {
            if (_velocity == default)
            {
                int x = 0, y = 0;
                while (x == 0)
                {
                    x = Random.Range(-1, 1);
                }

                while (y == 0)
                {
                    y = Random.Range(-1, 1);
                }
                _velocity = new Vector2(x, y);
            }

            _isVelocityUpdate = false;
            return _velocity;
        }

        public bool IsSpeedUpdate(){return _isSpeedUpdate;}

        public bool IsVelocityUpdate(){return _isVelocityUpdate;}

        public void SpeedUp()
        {
            if (!(_speed < _maxSpeed)) return;
            _speed += _speedMultiplier;
            _isSpeedUpdate = true;
        }

        public void IncrementScore()
        {
            SettingsDto.PlayerScore++;
            SettingsDto.IsScoreUpdate = true;
            //ScoreController.GetInstance().UpdateScore(1);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // if ball touch bottom trigger
            if (col.gameObject.name == "GameOver")
            {
                print("GameOver");
                // hide ball and display failed window
                gameObject.SetActive(false);
                SettingsDto.IsLevelFailed = true;
                //ContainerDto.Manager.SendEvent(GameEvents.GAME_PAUSED);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            SpeedUp();
            _isVelocityUpdate = true;
            switch (col.gameObject.name)
            {
                case "Player":
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
                        SettingsDto.IsLevelComplete = true;
                        //ContainerDto.Manager.SendEvent(GameEvents.GAME_PAUSED);
                        // and level 1 complete
                    }
                    break;
            }
        }
    }
}