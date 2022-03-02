using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public ScoreHandler scoreHandler;
    GameObject Player;
    public float y = 0,
          maxSpeed;
    public bool hasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreHandler>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreHandler.GameOver)
        {
            if (gameObject.transform.position.y < 0)
            {
                scoreHandler.Lives--;
                hasShot = false;
                gameObject.transform.position = Player.transform.position + new Vector3(0, y, 0);
            }

            if (!hasShot)
            {
                gameObject.transform.position = Player.transform.position + new Vector3(0, y, 0);
                if (Input.GetKey(KeyCode.Space))
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value, maxSpeed);
                    hasShot = !hasShot;
                }

            }


        }
        if (scoreHandler.GameOver)
        {
            gameObject.transform.position = Player.transform.position + new Vector3(0, y, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            float velocity_ = Player.GetComponent<Rigidbody2D>().velocity.x;
            float velocity2_ = gameObject.GetComponent<Rigidbody2D>().velocity.x;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((velocity2_ + velocity_) / 2, maxSpeed);
        }
        if (collision.collider.CompareTag("Bricks"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(collision.gameObject);
        }
    }
}
