using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class BallController : MonoBehaviour
    {

        public Collider2D[] Collider2Ds;
        private Collider2D _collider;

        private GameObject _gameObject;
        private MessageManager msgManager;
        private Score score;
        public float offsetX;
        public float offsetY;

        // Start is called before the first frame update
        void Start()
        {
            // init score label text
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text = "Score ";
            // get ball collider
            _collider = GetComponent<Collider2D>();
            // set pseudo-random ball direction
            offsetX = Random.Range(-1f, 1f) * 2;
            offsetY = Random.Range(-1f, 1f) * 2;
            // get and hide failed window
            _gameObject = GameObject.Find("/UI/Failed/Panel");
            _gameObject.SetActive(false);
            // get score class for counting
            score = gameObject.AddComponent<Score>();
        }

        public float speed = 2f;
    
        public float speedLimit = 14f;

        public float speedMultiplier = .01f;

        // Update is called once per frame
        void Update()
        {
            var transformPosition = transform.position;
            transformPosition.x += Time.deltaTime * offsetX * speed;
            transformPosition.y += Time.deltaTime * offsetY * speed;
            transform.position = transformPosition;
            foreach (var collider2D1 in Collider2Ds)
            {
                if (_collider.bounds.Intersects(collider2D1.bounds))
                {
                    print(speed);
                    switch (collider2D1.name)
                    {
                        case "playerPillar":
                            offsetY = 1f;
                            if (speed < speedLimit)
                                speed+= speedMultiplier;
                            break;
                        case "topPillar":
                            offsetY = -1f;
                            if (speed < speedLimit)
                                speed += speedMultiplier;
                            break;
                        case "leftPillar":
                            offsetX = 1f;
                            if (speed < speedLimit)
                                speed += speedMultiplier;
                            break;
                        case "rightPillar":
                            offsetX = -1f;
                            if (speed < speedLimit)
                                speed += speedMultiplier;
                            break;
                        case "bottomSide":
                            offsetY = -1f;
                            if (speed < speedLimit)
                                speed += speedMultiplier;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            // if ball touch player invert direction of move
            if (col.gameObject.name == "playerPillar")
            {
                offsetY = 3f;
            }
            // if ball touch platforms
            if (col.gameObject.layer == 11)
            {
                // destroy current touched platform
                Destroy(col.gameObject);
                // invert direction move
                offsetY = -offsetY;
                // speed up
                speed += speedMultiplier;
                // increment score
                score.UpdateScore(1);
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            // if ball touch bottom trigger
            if (col.gameObject.name == "GameOver")
            {
                print("GameOver");
                // hide ball and display failed window
                gameObject.SetActive(false);
                _gameObject.SetActive(true);
                // stop game
                Time.timeScale = 0;
                // get last score for save record
                Settings.PlayerScore = score.GetScore();
                // displayed reached score
                GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text += score.GetScore();
            }
        }
    }
}
