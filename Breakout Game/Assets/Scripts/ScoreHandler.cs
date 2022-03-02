using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public int Lives = 3;
    public Text text,
                endText;
    public bool GameOver;
    public BlockBuilder blockBuilder;
    public GameObject[] bricks;

    

    private void Update()
    {
        bricks = GameObject.FindGameObjectsWithTag("Bricks");
        text.text = "Lives: " + Lives;
        endText.text = "";
       
        if (bricks.Length == 0)
        {
            GameOver = true;  
        }
        
        if(Lives <= 0)
        {
            GameOver = true;
            endText.text = "Press Space to try again";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                blockBuilder.checkWallToLoad();
                Lives = 3;
            }
        }

        if (GameOver && Lives > 0)
        {
            if (blockBuilder.level < 2)
            {
                endText.text = "Press Space to Play Next Level";
            }
            else
            {
                endText.text = "Press Space to start back at level 1";
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameOver = false;
                switch (blockBuilder.level)
                {
                    case 2:
                        blockBuilder.level = 0;
                        break;
                    default:
                        blockBuilder.level++;
                        break;

                }
                blockBuilder.checkWallToLoad();
                Lives = 3;
            }

        }
    }

}
