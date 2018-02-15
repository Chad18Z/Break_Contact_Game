using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour {

    bool isMoving = true;
    // Use this for initialization

    [SerializeField]
    ParticleSystem part;
    GameObject[] waypoints;
    int waypoint;
    Rigidbody2D rb;


	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); // make an array of all the waypoints in the level
        waypoint = FindNearestWaypoint();
   
    }	
	// Update is called once per frame
	void Update () {

        if (isMoving && Vector2.Distance(gameObject.transform.position, waypoints[waypoint].transform.position) > .7f)
        {
            Vector2 moveDir = waypoints[waypoint].transform.position - gameObject.transform.position;
            moveDir = moveDir.normalized;
            rb.velocity = moveDir * 2.0f;
        }
        else
        {
            rb.velocity = Vector2.down;
        }
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
    /// <summary>
    /// Finds the nearest waypoint to the object this script is attached to
    /// </summary>
    /// <returns></returns>
    int FindNearestWaypoint()  // based on this enemy location
    {
        int closest = 0;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (Vector2.Distance(gameObject.transform.position, waypoints[i].transform.position) <
                Vector2.Distance(gameObject.transform.position, waypoints[closest].transform.position) && Vector2.Distance(gameObject.transform.position, waypoints[waypoint].transform.position) > 50f)
            {
                closest = i;
            }
        }
        return closest;
    }
}
