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
        /*
         * Code Sections:
         * * Private Fields
         * * Getters
         * * Setters
         * * Unity Messages
        */
        /////////////////////////////////////////////////////////////
        ///////////////////////Private Fields///////////////////////
        private Vector3 _position;
        private float _speed;
        private Color _color;
        private bool _isSpeedUpdate;
        private bool _isColorUpdate;


        private bool _freezeUp = false;
        private bool _freezeDown = false;
        private bool _freezeLeft = false;
        private bool _freezeRight = false;
        /////////////////////////////////////////////////////////////
        /////////////////////////Getters////////////////////////////
        public bool IsFreezeUp(){return _freezeUp;}
        public bool IsFreezeDown(){return _freezeDown;}
        public bool IsFreezeLeft(){return _freezeLeft;}
        public bool IsFreezeRight(){return _freezeRight;}
        public bool IsSpeedUpdate(){return _isSpeedUpdate;}
        public float GetSpeed()
        {
            _isSpeedUpdate = false;
            return _speed;
        }
        /////////////////////////////////////////////////////////////
        /////////////////////////Setters////////////////////////////
        public void SetPosition(Vector3 pos){transform.position = pos;}
        public void SetPosition(Vector coordinate, float value)
        {
            switch (coordinate)
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
                    throw new ArgumentOutOfRangeException(nameof(coordinate), coordinate, null);
            }

            transform.position = _position;
        }
        /////////////////////////////////////////////////////////////
        //////////////////////Unity Messages////////////////////////

        //Unity message, that is sent if the player has just started
        //to interact with a collider, that is designated as a trigger
        private void OnTriggerEnter2D(Collider2D col)
        {
            switch (col.name)
            {
                case "TerritoryLimiter":
                    _freezeUp = true;
                    break;
                case "GameOver":
                    _freezeDown = true;
                    break;
            }
        }
        //Unity message, that is sent if the player has stopped
        //interacting with the collider, that is designated as a trigger
        private void OnTriggerExit2D(Collider2D col)
        {
            switch (col.name)
            {
                case "TerritoryLimiter":
                    _freezeUp = false;
                    break;
                case "GameOver":
                    _freezeDown = false;
                    break;
            }
        }

        //Unity message, that is sent if the player has just started
        //to interact with a collider, that is not designated as a trigger
        private void OnCollisionEnter2D(Collision2D col)
        {
            switch (col.gameObject.name)
            {
                case "leftPillar":
                    _freezeLeft = true;
                    break;
                case "rightPillar":
                    _freezeRight = true;
                    break;
            }
        }
        //Unity message, that is sent if the player has stopped
        //interacting with the collider, that is not designated as a trigger
        private void OnCollisionExit2D(Collision2D col)
        {
            switch (col.gameObject.name)
            {
                case "leftPillar":
                    _freezeLeft = false;
                    break;
                case "rightPillar":
                    _freezeRight = false;
                    break;
            }
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
    }
}