using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Input.GetKey(KeyCode.W)){
            Body.AddForce( new Vector2(0,Speed), ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.S)){
            Body.AddForce( new Vector2(0,-Speed), ForceMode2D.Force);
        }
        if( ! Input.anyKey){
            Body.velocity = Body.velocity * new Vector2(0.8f,0.8f);
        }
    }
}
