using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will control when and where new enemies will spawn
/// </summary>
public class EnemyAIController : MonoBehaviour {

    [SerializeField]
    GameObject badGuyPrefab;

    bool readyToSpawn = true;
    GameObject[] waypoints = new GameObject[20];
    GameObject[] spawnPoint = new GameObject[4]; // this array will hold the spawn points. Spawn points are the waypoints outside each of the exits from the level
	// Use this for initialization
	void Start () {
        waypoints = GetWaypoints();
        InitializeSpawnpoints();
	}
	
	// Update is called once per frame
	void Update () {

		if (readyToSpawn)
        {
            Spawn();
            readyToSpawn = false;
        }
	}

    public GameObject[] ShareWaypoints
    {
        get { return waypoints; }
    }
    /// <summary>
    /// returns an array of all waypoints in the level
    /// </summary>
    /// <returns></returns>
    GameObject[] GetWaypoints()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        return waypoints;
    }
    /// <summary>
    /// this method will load the waypoints at exits into an array
    /// </summary>
    /// <returns></returns>
    void InitializeSpawnpoints()
    {
        spawnPoint[0] = waypoints[17]; // top left spawnpoint
        spawnPoint[1] = waypoints[18]; // bottom left spawnpoint
        spawnPoint[2] = waypoints[19]; // top right spawnpoint
        spawnPoint[3] = waypoints[15]; // bottom right spawnpoint
    }
    /// <summary>
    /// this method will spawn a new enemy.
    /// </summary>
    void Spawn()
    {
        Instantiate(badGuyPrefab, new Vector3(1,1,0), Quaternion.identity);
        Vector3 spawnPosition = spawnPoint[DetermineBestSpawnPoint()].transform.position;
        Instantiate(badGuyPrefab, spawnPosition , Quaternion.identity);
    }
    int DetermineBestSpawnPoint()  // based on player's location
    {
        int farthest = 0;
        Vector2 playerLocation = GameObject.FindGameObjectWithTag("player").transform.position;

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if (Vector2.Distance(playerLocation, spawnPoint[i].transform.position) > 
                Vector2.Distance(playerLocation, spawnPoint[farthest].transform.position))
            {
                farthest = i;
            }
        }
        return farthest;
    }

}
