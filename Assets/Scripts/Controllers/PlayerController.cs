using System.Collections.Generic;
using Assets.Scripts.Performances;
using Assets.Scripts.Performances.Interfaces;
using Assets.Scripts.Performances.Services;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// this class contains player movement logic
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 0f;

        // player interface
        private IPlatformService _platform;
        
        //Start is called before the first frame update
        void Start()
        {
            _platform = gameObject.AddComponent<PlatformService>();
            _platform.SetPosition(transform.position);
        }

        //Update is called once per frame
        void Update()
        {
            if (_platform.IsSpeedUpdate())
                Speed = _platform.GetSpeed();

            if (Input.GetKey(KeyCode.UpArrow))
                _platform.SetPosition(Vector.Y, transform.position.y + Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.DownArrow))
                _platform.SetPosition(Vector.Y, transform.position.y - Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.LeftArrow))
                _platform.SetPosition(Vector.X, transform.position.x - Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.RightArrow))
                _platform.SetPosition(Vector.X, transform.position.x + Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.W))
                _platform.SetPosition(Vector.Y, transform.position.y + Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.S))
                _platform.SetPosition(Vector.Y, transform.position.y - Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.A))
                _platform.SetPosition(Vector.X, transform.position.x - Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.D))
                _platform.SetPosition(Vector.X, transform.position.x + Time.deltaTime * Speed);
        }
    }
}
