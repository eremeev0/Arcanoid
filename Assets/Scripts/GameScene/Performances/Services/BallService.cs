using Assets.Scripts.GameScene.Performances.Interfaces;
using Assets.Scripts.MultiOriented.Contracts;
using UnityEngine;

namespace Assets.Scripts.GameScene.Performances.Services
{
    public class BallService: MonoBehaviour, IBallService
    {
        private float _speed = BallSettingsDto.GetBallSettings().BallSpeed;
        private readonly float _maxSpeed = BallSettingsDto.GetBallSettings().BallMaxSpeed;
        private readonly float _speedMultiplier = BallSettingsDto.GetBallSettings().BallSpeedMultiplier;
        private Vector2 _velocity;
        private AudioSource _hitSound;

        //private IDestrPlatformService destroyedPlatform;
        public DestrPlatformService destroyedPlatform { get; set; }

        private bool _isSpeedUpdate;
        private bool _isVelocityUpdate;

        private void Start()
        {
            _isSpeedUpdate = false;
            _isVelocityUpdate = false;
            destroyedPlatform = DestrPlatformService.GetPlatformService();
            _hitSound = GetComponent<AudioSource>();
        }
        private void Update() {
            if (destroyedPlatform == null)
            {
                destroyedPlatform = DestrPlatformService.GetPlatformService();
            }
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
            SettingsSingleton.GetSettings().PlayerScore++;
            SettingsSingleton.GetSettings().IsScoreUpdate = true;
            //ScoreController.GetInstance().UpdateScore(1);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // if ball touch bottom trigger
            if (col.gameObject.name == "GameOver")
            {
                print("GameOver");
                //_hitSound.clip
                // hide ball and display failed window
                gameObject.SetActive(false);
                SettingsSingleton.GetSettings().IsLevelFailed = true;
                //ContainerDto.Manager.SendEvent(GameEvents.GAME_PAUSED);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            SpeedUp();
            _isVelocityUpdate = true;
            _hitSound.Play();
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
                    _velocity.y = -_velocity.y;
                    IncrementScore();
                    destroyedPlatform.Destroy(col.gameObject);
                    break;
            }
        }
    }
}