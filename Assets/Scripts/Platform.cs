using System;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Player logic implementation class
    /// </summary>
    public class Platform: MonoBehaviour, IPlatform
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private float Speed;
        [SerializeField] private Color color;
        void Start()
        {
            _position.z = -1f;
            Speed = Settings.PlayerSpeed;
            color = Settings.PlayerColor;
        }

        void Update()
        {

        }

        public float GetPlayerSpeed()
        {
            return Speed;
        }

        public Color GetPlayerColor()
        {
            return color;
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
    }
}