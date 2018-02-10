using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb; // rigidbody for collision
    float moveUnits = 5;
    float speed = 2.0f; // speed of rotation
    Vector3 startPosition;

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
        float moveX = 0; 
        float moveY = 0;

        // check for horizontal input
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }
        // check for vertical input
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }
        Vector2 position = rb.position;
        position.x += moveX * moveUnits * Time.deltaTime;
        position.y += moveY * moveUnits * Time.deltaTime;
        rb.MovePosition(position);

    }
}
