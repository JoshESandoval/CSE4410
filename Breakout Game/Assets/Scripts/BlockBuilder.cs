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
    public Material  material1, material2, material3,material4, material5;


    int[,] Level0 = new int[,] {
        {1,1,1,1,1,1,1,1,1,1},
        {2,2,2,2,2,2,2,2,2,2},
        {3,3,3,3,3,3,3,3,3,3},
        {2,2,2,2,2,2,2,2,2,2},
        {1,1,1,1,1,1,1,1,1,1},
        {2,2,2,2,2,2,2,2,2,2},
        {3,3,3,3,3,3,3,3,3,3},
        {2,2,2,2,2,2,2,2,2,2},
        {1,1,1,1,1,1,1,1,1,1}
    };

    int[,] Level1 = new int[,] {
        {2,2,2,2,2,2,2,2,2,2},
        {2,1,1,0,0,0,0,1,1,2},
        {2,1,0,3,3,3,3,0,1,2},
        {2,0,5,0,3,3,0,5,0,2},
        {2,0,5,0,3,3,0,5,0,2},
        {2,0,5,4,3,3,4,5,0,2},
        {2,3,0,2,0,0,2,0,3,2},
        {2,3,0,2,3,3,2,0,3,2},
        {2,3,0,2,3,3,2,0,3,2}
    };

    int[,] Level2 = new int[,] {
        {3,3,3,3,3,3,3,3,3,3},
        {3,5,0,2,2,2,2,0,5,3},
        {3,0,2,4,4,4,4,2,0,3},
        {3,2,4,4,4,4,4,4,2,3},
        {3,2,1,1,1,1,1,1,2,3},
        {3,2,5,5,5,5,5,5,2,3},
        {3,0,2,5,5,5,5,2,0,3},
        {3,5,0,2,2,2,2,0,5,3},
        {3,3,3,3,3,3,3,3,3,3}
    };

    public void buildWall(int[,] level_){ 
       

        for (int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if (level_[j,i] > 0) { 
                    GameObject temp = Instantiate(brick, new Vector3(startx + width * i, starty - height * j, 0), Quaternion.identity);
                    //Instantiate()
                    switch (level_[j, i])
                    {
                        
                        case 1:
                            temp.GetComponent<SpriteRenderer>().color = material1.color;
                            break;
                        case 2:
                            temp.GetComponent<SpriteRenderer>().color = material2.color;
                            break;                              
                        case 3:                                 
                            temp.GetComponent<SpriteRenderer>().color = material3.color;
                            break;
                        case 4:
                            temp.GetComponent<SpriteRenderer>().color = material4.color;
                            break;
                        case 5:
                            temp.GetComponent<SpriteRenderer>().color = material5.color;
                            break;
                        default:                                
                            temp.GetComponent<SpriteRenderer>().color = material1.color;
                            break;

                    }
                    
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
            case 0:
                buildWall(Level0);
                break;
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
            }
        }
      
    }

    // Update is called once per frame


}
