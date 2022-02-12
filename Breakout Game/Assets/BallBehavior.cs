using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{   
    ScoreHandler ScoreHandler;
    GameObject Player;
    float y = 0,
          maxSpeed;
    bool hasShot;

    // Start is called before the first frame update
    void Start()
    {
        ScoreHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreHandler>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < 0){
            ScoreHandler.Lives--;
            gameObject.transform.position = Player.transform.position + new Vector3(0, y, 0);  
        }

        if (!hasShot)
        {
            gameObject.transform.position = Player.transform.position + new Vector3(0, y, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
           // Vector2 velocity = Player.GetComponent<Rigidbody2D>().velocity;
            //gameObject.GetComponent<Rigidbody2D>().velocity = 
        }
    }
}
