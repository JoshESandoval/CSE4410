using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D player;
    public ScoreHandler scoreHandler;
    [SerializeField]
    float Speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreHandler.GameOver)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                player.AddForce(new Vector2(Speed * Time.deltaTime, 0));
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                player.AddForce(new Vector2(-Speed * Time.deltaTime, 0));
            }

            if (!Input.anyKey)
            {
                player.velocity = new Vector2(0, 0);
            }
        }
    }
}
