using System;
using System.ComponentModel;
using Assets.Scripts.Contracts;
using Assets.Scripts.Performances.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Performances.Services
{
    /// <summary>
    /// Player logic implementation class
    /// </summary>
    public class PlatformService: MonoBehaviour, IPlatformService
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private float _speed = SettingsDto.PlayerSpeed;
        [SerializeField] private Color _color = SettingsDto.PlayerColor;
        private bool _isSpeedUpdate = true;
        private bool _isColorUpdate = true;

        //Start if player touch "invisible wall". Ball ignore it.
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "TerritoryLimiter")
                transform.position = new Vector3(transform.position.x, transform.position.y - .2f * (_speed / 4), transform.position.z);

            if (col.name == "GameOver")
                transform.position = new Vector3(transform.position.x, transform.position.y + .2f * (_speed / 4), transform.position.z);
        }

        //Start if player touch walls
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "leftPillar")
                transform.position = new Vector3(transform.position.x + .2f * (_speed / 4), transform.position.y, transform.position.z);
            if (col.gameObject.name == "rightPillar")
                transform.position = new Vector3(transform.position.x - .2f * (_speed / 4), transform.position.y, transform.position.z);

            // Ball can't push player
            if (col.gameObject.name == "gameBall")
            {
                gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
        }

        void Start()
        {
            _position.z = -1f;
        }

        void Update()
        {
            var transformRotation = transform.rotation;
            transformRotation.z = 0;
            transform.rotation = transformRotation;
            if (_isColorUpdate)
                gameObject.GetComponent<SpriteRenderer>().color = _color;
        }

        public bool IsSpeedUpdate()
        {
            return _isSpeedUpdate;
        }

        public bool IsColorUpdate()
        {
            return _isColorUpdate;
        }

        public float GetSpeed()
        {
            _isSpeedUpdate = false;
            return _speed;
        }

        public Color GetColor()
        {
            _isColorUpdate = false;
            return _color;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public void SetPosition(Vector component, float value)
        {
            if (!Enum.IsDefined(typeof(Vector), component))
                throw new InvalidEnumArgumentException(nameof(component), (int) component, typeof(Vector));

            switch (component)
            {
                case Vector.X:
                    _position.x = value;
                    break;
                case Vector.Y:
                    _position.y = value;
                    break;
                case Vector.Z:
                    _position.z = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(component), component, null);
            }

            transform.position = _position;
        }

        public void SetPosition(Vector3 pos)
        {
            _position = pos;
        }
    }
}