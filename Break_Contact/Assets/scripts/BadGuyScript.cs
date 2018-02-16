using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour {

    [SerializeField]
    ParticleSystem part;
    GameObject[] waypoints;
    int waypoint;
    Rigidbody2D rb;


	void Start () {
       
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); // make an array of all the waypoints in the level
        waypoint = 0;
   
    }	
	// Update is called once per frame
	void Update () {

        float distance = Vector2.Distance(gameObject.transform.position, waypoints[waypoint].transform.position);
        transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoints[waypoint].transform.position, Time.deltaTime * 2.0f);
        if (distance <= 1f)
        {
            waypoint++;
            if (waypoint > 19)
            {
                waypoint = 0;
            }
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
    //int FindNearestWaypoint()  // based on this enemy location
    //{
    //    int closest = 0;
    //    for (int i = 0; i < waypoints.Length; i++)
    //    {
    //        if (Vector2.Distance(gameObject.transform.position, waypoints[i].transform.position) <
    //            Vector2.Distance(gameObject.transform.position, waypoints[closest].transform.position) && Vector2.Distance(gameObject.transform.position, waypoints[waypoint].transform.position) > 50f)
    //        {
    //            closest = i;
    //        }
    //    }
    //    return closest;
    //}
}
