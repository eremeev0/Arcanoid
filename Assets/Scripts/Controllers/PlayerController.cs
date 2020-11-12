using System.Collections.Generic;
using Assets.Scripts.ConfigurationManagment;
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
        //bug(for select) ********* operators init. start

        public float Speed = 0f;

        // player data storage interface
        private IPlatformService _platform;

        //bug(for select) ********* operators init. end


        //bug(for select) Start is called before the first frame update
        void Start()
        {
            _platform = gameObject.AddComponent<PlatformService>();
            _platform.SetPosition(transform.position);
        }

        //bug(for select) Start if player touch "invisible wall". Ball ignore it.
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "TerritoryLimiter")
                _platform.SetPosition(Vector.Y, transform.position.y - .2f * (Speed / 4));

            if (col.name == "GameOver")
                _platform.SetPosition(Vector.Y, transform.position.y + .2f * (Speed / 4));
        }

        //bug(for select) Start if player touch walls
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "leftPillar")
                _platform.SetPosition(Vector.X, transform.position.x + .2f * (Speed / 4));

            if (col.gameObject.name == "rightPillar")
                _platform.SetPosition(Vector.X, transform.position.x - .2f * (Speed / 4));
            
            // Ball can't push player
            if (col.gameObject.name == "gameBall")
            {
                gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
        }

        //bug(for select) Update is called once per frame
        void Update()
        { 
            var transformRotation = transform.rotation;
            transformRotation.z = 0;
            transform.rotation = transformRotation;
            if (_platform.IsColorUpdate())
                gameObject.GetComponent<SpriteRenderer>().color = _platform.GetColor();

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
