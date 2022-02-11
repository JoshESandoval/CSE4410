using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public GameObject brick;
    public int level = 0; 

    public float height = 0,
                 width = 0,
                 startx = 0,
                 starty = 0;
    
    int[,] Level1 = new int[,] {
        {1,1,1,1,1,1,1,1,1,1},
        {1,1,1,0,0,0,0,1,1,1},
        {1,1,0,1,1,1,1,0,1,1},
        {1,0,1,0,1,1,0,1,0,1},
        {1,0,1,0,1,1,0,1,0,1},
        {1,0,1,1,1,1,1,1,0,1},
        {1,1,0,1,0,0,1,0,1,1},
        {1,1,0,1,1,1,1,0,1,1},
        {1,1,0,1,1,1,1,0,1,1}
    };

    int[,] Level2 = new int[,] {
        {1,1,1,1,1,1,1,1,1,1},
        {1,1,0,1,1,1,1,0,1,1},
        {1,0,1,1,1,1,1,1,0,1},
        {1,1,1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1,1,1},
        {1,0,1,1,1,1,1,1,0,1},
        {1,1,0,1,1,1,1,0,1,1},
        {1,1,1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1,1,1}
    };

    public void buildWall(int[,] level_){ 
       

        for (int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if (level_[j,i] == 1) { 
                    Instantiate(brick, new Vector3(startx + width * i, starty - height * j, 0), Quaternion.identity);
                    //Instantiate()
                }
                else
                {

                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        checkWallToLoad();
    }

    public void checkWallToLoad()
    {
        switch (level) {
            case 1:
                buildWall(Level1);
                break;
            case 2:
                buildWall(Level2);
                break;
            default:
                buildWallManual();
                break;
        }
    }

    public void buildWallManual()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Instantiate(brick, new Vector3(startx + width * i, starty - height * j, 0), Quaternion.identity);
                //Instantiate()
            }
        }
      
    }

    public void clearWall()
    {
        GameObject[] toRemove = GameObject.FindGameObjectsWithTag("Bricks");
        foreach( GameObject block in toRemove)
        {
            Destroy(block);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) {
            clearWall();
        }
    }


}
