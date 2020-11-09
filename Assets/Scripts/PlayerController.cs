using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        // properties with the possibility of change from Unity editor
        public float Speed = 0f;

        private IPlatform platform;
        private MessageManager msgManager;
        // Start is called before the first frame update
        void Start()
        {
            platform = gameObject.AddComponent<Platform>();
            msgManager = new MessageManager(transform);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "TerritoryLimiter")
                transform.position = new Vector3(transform.position.x, transform.position.y - .2f, -1);
            if (col.name == "GameOver")
                transform.position = new Vector3(transform.position.x, transform.position.y + .2f, -1);
        }

        // Update is called once per frame
        void Update()
        {
            //transform.position = platform.GetPosition();
            Speed = platform.GetPlayerSpeed(); 
            gameObject.GetComponent<SpriteRenderer>().color = platform.GetPlayerColor();
            var transformRotation = transform.rotation;
            transformRotation.z = 0f;
            transform.rotation = transformRotation;
            // transform.position += Move()
            if (Input.GetKey(KeyCode.UpArrow))
            {
                platform.SetPosition(Vector.Y, transform.position.y + Time.deltaTime * Speed);
                //   platform.SetPosition(platform.GetPos() += Time.deltaTime * Speed;);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                platform.SetPosition(Vector.Y, transform.position.y - Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                platform.SetPosition(Vector.X, transform.position.x - Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                platform.SetPosition(Vector.X, transform.position.x + Time.deltaTime * Speed);
            }

            if (Input.GetKey(KeyCode.W))
            {
                platform.SetPosition(Vector.Y, transform.position.y + Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                platform.SetPosition(Vector.Y, transform.position.y - Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                platform.SetPosition(Vector.X, transform.position.x - Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                platform.SetPosition(Vector.X, transform.position.x + Time.deltaTime * Speed);
            }
        }
    }
}
