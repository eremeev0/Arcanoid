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
    public class PlayerService: MonoBehaviour, IPlayerService
    {
        private Vector3 _position;
        private float _speed;
        private Color _color;
        private bool _isSpeedUpdate;
        private bool _isColorUpdate;

        //Start if player touch "invisible wall". Ball ignore it.
        private void OnTriggerEnter2D(Collider2D col)
        {
            /*if (col.name == "TerritoryLimiter")
                transform.position = new Vector3(transform.position.x, transform.position.y - .2f * (_speed / 4), transform.position.z);

            if (col.name == "GameOver")
                transform.position = new Vector3(transform.position.x, transform.position.y + .2f * (_speed / 4), transform.position.z);
            */
        }

        //Start if player touch walls
        private void OnCollisionEnter2D(Collision2D col)
        {
            /*switch (col.gameObject.name)
            {
                case "leftPillar":
                    transform.position = new Vector3(transform.position.x + .2f * (_speed / 4), transform.position.y, transform.position.z);
                    break;
                case "rightPillar":
                    transform.position = new Vector3(transform.position.x - .2f * (_speed / 4), transform.position.y, transform.position.z);
                    break;
            }*/
        }

        private void Start()
        {
            _speed = SettingsDto.PlayerSpeed;
            _color = SettingsDto.PlayerColor;
            _isSpeedUpdate = true;
            _isColorUpdate = true;
            _position.z = -1f;
        }

        private void Update()
        {
            var transformRotation = transform.rotation;
            transformRotation.z = 0;
            transform.rotation = transformRotation;
            if (_isColorUpdate)
            {
                gameObject.GetComponent<SpriteRenderer>().color = _color;
                _isColorUpdate = false;
            }
        }

        public bool IsSpeedUpdate()
        {
            return _isSpeedUpdate;
        }

        public float GetSpeed()
        {
            _isSpeedUpdate = false;
            return _speed;
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