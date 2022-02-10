using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Transform ball;
    Rigidbody2D move;
    public BallControll ballControll;
    public Text scoreBoard;
    public int player1 = 0, 
               player2 = 0,
               winRange = 7,
               winCount = 4;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject.GetComponent<Transform>();
        move = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.position.x < -winRange){
            player2++;
            ball.position= Vector3.zero;
            move.velocity = Vector2.zero;
        }
        else if(ball.position.x > winRange){
            player1++;
            ball.position= Vector3.zero;
            move.velocity= Vector2.zero;
        }

        updateScoreDisplay();
    } 
  
    public void updateScoreDisplay(){
        if(player1 >= winCount || player2 > winCount){
            ballControll.GameOver = true;
        }
        if(!ballControll.GameOver){
            scoreBoard.text = "Score\n" + player1 + " : " + player2;
        }
        if(ballControll.GameOver){
            if(player1 > player2){
                scoreBoard.text = "Player 1 Wins!\nPress Space To Play Again";
            }
            if(player2 > player1){
                scoreBoard.text = "Player 2 Wins!\nPress Space To Play Again";
            }
            player1 = player2 = 0;
        }
    }

}
