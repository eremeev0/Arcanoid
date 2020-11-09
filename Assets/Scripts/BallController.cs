using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text = "Score ";
        _collider = GetComponent<Collider2D>();
        offsetX = Random.Range(-1f, 1f) * 2;
        offsetY = Random.Range(-1f, 1f) * 2;
        _gameObject = GameObject.Find("/UI/Failed/Panel");
        _gameObject.SetActive(false);
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
        if (col.gameObject.name == "playerPillar")
        {
            offsetY = 3f;
        }

        if (col.gameObject.layer == 11)
        {
            Destroy(col.gameObject); 
            offsetY = -offsetY;
            speed += speedMultiplier;
            score.UpdateScore(1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "GameOver")
        {
            print("GameOver");
            gameObject.SetActive(false);
            _gameObject.SetActive(true);
            Time.timeScale = 0;
            GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>().text += score.GetScore();
        }
    }
}
