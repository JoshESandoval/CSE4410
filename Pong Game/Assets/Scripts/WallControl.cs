using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallControl : MonoBehaviour
{
    public float Speed = 2;
    public Rigidbody2D Body;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(name == "Left Wall"){
            if(Input.GetKey(KeyCode.W )){
                Body.AddForce( new Vector2(0,Speed), ForceMode2D.Force);
            }
            if(Input.GetKey(KeyCode.S)){
                Body.AddForce( new Vector2(0,-Speed), ForceMode2D.Force);
            }
            if( !( Input.anyKey)){
               Body.velocity = Body.velocity * new Vector2(0.8f,0.8f);
            }
        }
        if(name == "Right Wall"){
            if(Input.GetKey(KeyCode.UpArrow )){
                Body.AddForce( new Vector2(0,Speed), ForceMode2D.Force);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                Body.AddForce( new Vector2(0,-Speed), ForceMode2D.Force);
            }
            if( !( Input.anyKey)){
               Body.velocity = Body.velocity * new Vector2(0.8f,0.8f);
            }
        }
    }
}
