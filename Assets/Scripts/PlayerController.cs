using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// this class contains player movement logic
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        
        public float Speed = 0f;

        //private Vector3 lastPos;
        private IPlatform platform;
        private MessageManager msgManager;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(0.3f, -5.8f, -1.0f);
            //lastPos = transform.position;
            //fixedDeltaTime
            platform = gameObject.AddComponent<Platform>();
            platform.SetPosition(transform.position);
            msgManager = new MessageManager(transform);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "TerritoryLimiter")
                platform.SetPosition(new Vector3(transform.position.x, transform.position.y - .2f * (Speed / 4), -1));
            if (col.name == "GameOver")
                platform.SetPosition(new Vector3(transform.position.x, transform.position.y + .2f * (Speed / 4), -1));
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "leftPillar")
                platform.SetPosition(new Vector3(transform.position.x + .2f * (Speed / 4), transform.position.y, -1));
            if (col.gameObject.name == "rightPillar")
                platform.SetPosition(new Vector3(transform.position.x - .2f * (Speed / 4), transform.position.y, -1));
        }
        // Update is called once per frame
        void Update()
        {
            /*if (transform.position == new Vector3(0, 0, -1))
            {
                transform.position = lastPos;
            }*/
            transform.position = platform.GetPosition();
            Speed = platform.GetPlayerSpeed(); 
            gameObject.GetComponent<SpriteRenderer>().color = platform.GetPlayerColor();
            var transformRotation = transform.rotation;
            transformRotation.z = 0f;
            transform.rotation = transformRotation;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                platform.SetPosition(Vector.Y, transform.position.y + Time.deltaTime * Speed);
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
