using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    public bool GameOver = false;
    public Rigidbody2D ball;
    public float SpeedX = 0,
                 SpeedY = 0,
                 MaxSpeedY = 3;

    // Update is called once per frame
    void Start() {
        ball = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if(ball.velocity == Vector2.zero && !GameOver){
            ball.velocity = new Vector2(SpeedX, 0);
        }
        if(GameOver){
            if(Input.GetKey(KeyCode.Space)){
                GameOver = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collider) {
        Vector2 velocity;
        velocity.x = ball.velocity.x;
        velocity.y = (ball.velocity.y/2) + (collider.gameObject.GetComponent<Rigidbody2D>().velocity.y /2);
        ball.velocity = velocity;     
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        ball.velocity = ball.velocity * new Vector2( 1,-1);
        SpeedY = -SpeedY;        
    }

}
