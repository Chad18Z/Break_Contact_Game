using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb; // rigidbody for collision
    float moveUnits = .07f; // move speed for the player character
    static Vector2 direction;
   


    [SerializeField]
    Bullet bullet;

	// Use this for initialization
	void Start () {
        
        rb = GetComponent <Rigidbody2D>();
    }
    /// <summary>
    /// This property returns the direction (aim) vector of the player's weapon
    /// </summary>
    public static Vector2 GetWeaponDirection
    {
        get { return direction.normalized; }
    }
	

    // Gets user input and moves the player character
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) { FireWeapon(); }
        bool move = false;
        Vector2 newPosition = Vector2.zero;

        // this will rotate the character
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
        }

        // move player character to the right
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            newPosition = new Vector2(transform.position.x + moveUnits, transform.position.y);
            move = true;
        }
        // move player character to the left
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            newPosition = new Vector2(transform.position.x - moveUnits, transform.position.y);
            move = true;
        }

        // move player character down
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            newPosition = new Vector2(transform.position.x , transform.position.y + moveUnits);
            move = true;
        }
        // move player character up
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            newPosition = new Vector2(transform.position.x, transform.position.y - moveUnits);
            move = true;
        }
        if (move) // if player has provided input, then move the character
        {
            rb.MovePosition(newPosition);
            move = false;
        }
    }
    /// <summary>
    /// fires a bullet
    /// </summary>
    void FireWeapon()
    {
        // Create new bullet which originates from the character's weapon muzzle
        Instantiate(bullet, CalculateBulletOrigin(), Quaternion.identity);           
    }
    /// <summary>
    /// calculates the origin of the bullet (location on the sprite from where the bullet will be fired)
    /// </summary>
    /// <returns></returns>
    Vector3 CalculateBulletOrigin()
    {
        GameObject spawn = GameObject.FindGameObjectWithTag("bulletSpawn");
        return spawn.transform.position;
    }
}
