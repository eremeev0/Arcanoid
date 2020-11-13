using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Events;
using Assets.Scripts.EventManagment.Provider;
using Assets.Scripts.Performances;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.Performances.Services;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Rigidbody2D = UnityEngine.Rigidbody2D;

namespace Assets.Scripts.Controllers
{
    public class BallController : MonoBehaviour
    {
        private IBallService _ballService;
        
        private float _speed = 0f;
        private Vector2 _velocity;
        // Start is called before the first frame update
        void Start()
        {
            _ballService = gameObject.AddComponent<BallService>();
            _velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _ballService.SetVelocity(_velocity);
            _speed = _ballService.GetSpeed();
            // get score class for counting
            //score = gameObject.AddComponent<ScoreController>();
        }

        // Update is called once per frame
        void Update()
        { 
            if (_ballService.IsSpeedUpdate()) 
                _speed = _ballService.GetSpeed();
            if (_ballService.IsVelocityUpdate())
                _velocity = _ballService.GetVelocity();
            GetComponent<Rigidbody2D>().inertia = 0;
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + _velocity * Time.fixedDeltaTime * _speed);
        }
    }
}
