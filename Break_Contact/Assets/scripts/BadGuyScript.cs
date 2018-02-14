using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour {

    bool isMoving = false;
    // Use this for initialization

    [SerializeField]
    ParticleSystem part;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Check for collision with bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bulletTag")
        {
            Instantiate(part, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
