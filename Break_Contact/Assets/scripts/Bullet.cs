using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    float bulletSpeed = 5.0f;

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
	// Update is called once per frame
	void Update () {
        
    }
}
