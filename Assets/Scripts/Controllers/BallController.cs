using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.Performances;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.Performances.Services;
using UnityEngine;
using UnityEngine.UI;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;
using Random = UnityEngine.Random;
using Rigidbody2D = UnityEngine.Rigidbody2D;

namespace Assets.Scripts.Controllers
{
    public class BallController : MonoBehaviour
    {
        private IBallService _ballService;
        private IDestrPlatformService _destroyedPlatform;
            
        private float _speed = 0f;
        private Vector2 _velocity;
        // Start is called before the first frame update
        void Start()
        {
            _destroyedPlatform = gameObject.AddComponent<DestrPlatformService>();
            _ballService = gameObject.AddComponent<BallService>();
            _velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _speed = _ballService.GetSpeed();
            // get score class for counting
            //score = gameObject.AddComponent<ScoreController>();
        }

        // Update is called once per frame
        void Update()
        { 
            if (_ballService.IsSpeedUpdate()) 
                _speed = _ballService.GetSpeed();
            GetComponent<Rigidbody2D>().inertia = 0;
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + _velocity * Time.fixedDeltaTime * _speed);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            _ballService.SpeedUp();
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
                    _ballService.IncrementScore();
                    _destroyedPlatform.Destroy();
                    break;
                default:
                    break;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            // if ball touch bottom trigger
            if (col.gameObject.name == "GameOver")
            {
                print("GameOver");
                // hide ball and display failed window
                gameObject.SetActive(false);
                _ballService.Failed();
                new EventProvider().SendEvent(GameEvents.GAME_PAUSED);
                // displayed reached score
            }
        }
    }
}
