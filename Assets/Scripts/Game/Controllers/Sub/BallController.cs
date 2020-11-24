using Assets.Scripts.Game.Performances.Interfaces;
using Assets.Scripts.Game.Performances.Services;
using UnityEngine;
using Rigidbody2D = UnityEngine.Rigidbody2D;

namespace Assets.Scripts.Game.Controllers.Sub
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
            
            _velocity = _ballService.GetVelocity();
            
            _speed = _ballService.GetSpeed();
        }

        // Update is called once per frame
        void Update()
        { 
            if (_ballService.IsSpeedUpdate()) 
                _speed = _ballService.GetSpeed();
           
            if (_ballService.IsVelocityUpdate())
                _velocity = _ballService.GetVelocity();
            
            GetComponent<Rigidbody2D>()
                .MovePosition(GetComponent<Rigidbody2D>().position + _velocity * Time.fixedDeltaTime * _speed);
        }
    }
}
