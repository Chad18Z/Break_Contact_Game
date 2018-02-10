using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb; // rigidbody for collision
    float moveUnits = 5;
    float speed = 10.0f; // speed of rotation
    Vector3 lastMousePosition;
   

	// Use this for initialization
	void Start () {
        rb = GetComponent < Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
 
    }

    // Gets user input and moves the player character
    void FixedUpdate()
    {
        bool move = false;
        Vector2 newPosition = Vector2.zero;

        // this will rotate the character
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
        }

        // move player character to the right
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            newPosition = new Vector2(transform.position.x + .1f, transform.position.y);
            move = true;
        }
        // move player character to the right
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            newPosition = new Vector2(transform.position.x - .1f, transform.position.y);
            move = true;
        }

        // move player character to the right
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            newPosition = new Vector2(transform.position.x , transform.position.y + .1f);
            move = true;
        }
        // move player character to the right
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            newPosition = new Vector2(transform.position.x, transform.position.y - .1f);
            move = true;
        }
        if (move)
        {
            rb.MovePosition(newPosition);
            move = false;
        }


    }
}
