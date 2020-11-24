using Assets.Scripts.GameScene.Performances.Interfaces;
using Assets.Scripts.GameScene.Performances.Services;
using UnityEngine;

namespace Assets.Scripts.GameScene.Controllers.Sub
{
    /// <summary>
    /// this class contains player movement logic
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 0f;

        // player interface
        private IPlayerService _platform;
        
        //Start is called before the first frame update
        void Start()
        {
            _platform = gameObject.AddComponent<PlayerService>();
            _platform.SetPosition(transform.position);
        }

        //Update is called once per frame
        void Update()
        {
            if (_platform.IsSpeedUpdate())
                Speed = _platform.GetSpeed();

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if (!_platform.IsFreezeRight())
                    _platform.SetPosition(Vector.X, transform.position.x + Time.deltaTime * Speed);
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if (!_platform.IsFreezeLeft())
                    _platform.SetPosition(Vector.X, transform.position.x - Time.deltaTime * Speed);

            }
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                if (!_platform.IsFreezeUp())
                    _platform.SetPosition(Vector.Y, transform.position.y + Time.deltaTime * Speed);
            }

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                if (!_platform.IsFreezeDown())
                    _platform.SetPosition(Vector.Y, transform.position.y - Time.deltaTime * Speed);
            }
        }
    }
}
