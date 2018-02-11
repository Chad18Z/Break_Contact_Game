using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    float bulletSpeed = 8.0f;

    [SerializeField]
    GameObject part; // particle system for impact with wall

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        Vector2 forceToAdd = PlayerScript.GetWeaponDirection.normalized;
        rb.AddForce(forceToAdd * bulletSpeed, ForceMode2D.Impulse);

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
    }
}
