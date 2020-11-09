using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    public class MessageManager
    {
        private readonly Transform _transform;
        private float _offsetY;

        public MessageManager(Transform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public MessageManager(float offsetY)
        {
            _offsetY = offsetY;
        }


        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "TerritoryLimiter")
                _transform.position = new Vector3(_transform.position.x, _transform.position.y - .2f, -1);
            if (col.name == "GameOver")
                _transform.position = new Vector3(_transform.position.x, _transform.position.y + .2f, -1);
            if (col.gameObject.layer == 9)
                _transform.position = new Vector3(_transform.position.x - 100f, _transform.position.y - 200, -1);
        }

        public void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "playerPillar")
            {
                _offsetY = 3f;
            }

            if (col.gameObject.layer == 11)
            {
                Object.Destroy(col.gameObject);
                _offsetY = -_offsetY;
            }
        }
    }
}