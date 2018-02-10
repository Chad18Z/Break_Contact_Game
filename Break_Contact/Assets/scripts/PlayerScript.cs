using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb; // rigidbody for collision
    float moveUnits = 10;

	// Use this for initialization
	void Start () {
        rb = GetComponent < Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Vector2 position = rb.position;
            position.x += horizontalInput * moveUnits * Time.deltaTime;
            rb.MovePosition(position);
        }
    }
}
