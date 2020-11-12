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


        void Start()
        {
            _position.z = -1f;
        }

        void Update()
        {

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component">coordinate</param>
        /// <param name="value">new coordinate value</param>
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