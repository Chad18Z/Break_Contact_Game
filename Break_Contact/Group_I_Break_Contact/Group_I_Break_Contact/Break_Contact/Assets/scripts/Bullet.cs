using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;


    [SerializeField]
    GameObject part; // particle system for impact with wall

    [SerializeField]
    GameObject bullPart;

    // Use this for initialization
    void Start () {


    }
	void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// handle collisions with other objects
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Instantiate(part, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "bulletTag" || collision.gameObject.tag == "badguyBullet")
        {
            Instantiate(bullPart, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
