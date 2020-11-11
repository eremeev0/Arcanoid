using Assets.Scripts.ConfigurationManagment;
using Assets.Scripts.EventManagment.Events;
using UnityEngine;
using UnityEngine.UI;
using EventProvider = Assets.Scripts.EventManagment.Provider.EventProvider;
using Random = UnityEngine.Random;
using Rigidbody2D = UnityEngine.Rigidbody2D;

namespace Assets.Scripts.Controllers
{
    public class BallController : MonoBehaviour
    {

        public Collider2D[] Collider2Ds;
        private Collider2D _collider;

        private GameObject _gameObject;
        private MessageManager msgManager;
        private ScoreController score;
        public float offsetX;
        public float offsetY;

        private Vector2 velocity;
        // Start is called before the first frame update
        void Start()
        {
            velocity = new Vector2(1f, 1f);
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
            score = gameObject.AddComponent<ScoreController>();
        }

        public float speed = 2f;
    
        public float speedLimit = 14f;

        public float speedMultiplier = .5f;

        // Update is called once per frame
        void Update()
        {
            if (!Settings.IsGameStopped)
            {
                GetComponent<Rigidbody2D>().inertia = 0;
                GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + velocity * Time.fixedDeltaTime * speed);
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            switch (col.gameObject.name)
            {
                case "playerPillar":
                    if (velocity.y < 0)
                        velocity.y = -velocity.y;
                    if (speed < speedLimit)
                        speed += speedMultiplier;
                    break;
                case "topPillar":
                    velocity.y = -velocity.y;
                    if (speed < speedLimit)
                        speed += speedMultiplier;
                    break;
                case "leftPillar":
                    velocity.x = -velocity.x;
                    if (speed < speedLimit)
                        speed += speedMultiplier;
                    break;
                case "rightPillar":
                    velocity.x = -velocity.x;
                    if (speed < speedLimit)
                        speed += speedMultiplier;
                    break;
                case "bottomSide":
                    if (velocity.y > 0)
                        velocity.y = -velocity.y;
                    if (speed < speedLimit)
                        speed += speedMultiplier;
                    break;
                default:
                    break;
            }
            // if ball touch platforms
            if (col.gameObject.layer == 11)
            {
                // destroy current touched platform
                Destroy(col.gameObject);
                // invert direction move
                velocity.y = -velocity.y - .3f;
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
                new EventProvider().SendEvent(GameEvents.GAME_PAUSED);
                // get last score for save record
                Settings.PlayerScore = score.GetScore();
                // displayed reached score
                GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text += score.GetScore();
            }
        }
    }
}
