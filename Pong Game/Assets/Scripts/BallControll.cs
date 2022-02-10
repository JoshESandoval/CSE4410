using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallControll : MonoBehaviour
{
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
        ball.AddForce( new Vector2(SpeedX, SpeedY) , ForceMode2D.Force) ;
        if(Input.GetKey(KeyCode.Space))
            ball.AddForce( new Vector2(SpeedX, SpeedY) , ForceMode2D.Force) ;
        if(Input.GetKey(KeyCode.A)){
            gameObject.transform.position = new Vector3(0,0,0);
            ball.velocity = Vector2.zero;
        }

    }

    private void OnCollisionEnter2D(Collision2D collider) {
        SpeedX *= -1;
        //print("it");
        float Position = gameObject.transform.position.y - collider.gameObject.transform.position.y;
        if(Position > 2){
            SpeedY = MaxSpeedY;
        }
        else if(Position <= 0){
            SpeedY = 0;
        }
        else{
            SpeedY =  (SpeedY + (MaxSpeedY * Position))/2; 
            print(SpeedY);
        }
    
        //print(Position);
        
    }
 
    private void OnTriggerEnter2D(Collider2D other) {
        //print("Speed: " + SpeedY);
        ball.velocity = ball.velocity * new Vector2( 1,-1);
        //SpeedY *= -1;

    }
}
