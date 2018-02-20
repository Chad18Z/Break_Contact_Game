using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will control when and where new enemies will spawn
/// </summary>
public class EnemyAIController : MonoBehaviour
{

    [SerializeField]
    GameObject badGuyPrefab;

    float spawnTimer = .6f;
    GameObject[] spawnPoint = new GameObject[4]; // this array will hold the spawn points. Spawn points are the waypoints outside each of the exits from the level

    Timer timer;

    // Use this for initialization
    void Start()
    {

        InitializeSpawnpoints();

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = .00001f; // start spawning immediately
        timer.Run();

    }
    // Update is called once per frame
    void Update()
    {

        if (timer.Finished)
        {
            Spawn();
            timer.Duration = spawnTimer;
            timer.Run();
        }
    }
    /// <summary>
    /// returns an array of all waypoints in the level
    /// </summary>
    /// <returns></returns>

    /// <summary>
    /// this method will load the waypoints at exits into an array
    /// </summary>
    /// <returns></returns>
    void InitializeSpawnpoints()
    {
        spawnPoint[0] = GameObject.Find("spawnPointA"); // top left spawnpoint
        spawnPoint[1] = GameObject.Find("spawnPointB"); // bottom left spawnpoint
        spawnPoint[2] = GameObject.Find("spawnPointC"); // top right spawnpoint
        spawnPoint[3] = GameObject.Find("spawnPointD"); // bottom right spawnpoint
    }
    /// <summary>
    /// this method will spawn a new enemy.
    /// </summary>
    void Spawn()
    {
        int point = DetermineBestSpawnPoint();
        GameObject badGuy = Instantiate(badGuyPrefab, spawnPoint[point].transform.position, Quaternion.identity);

        switch (point)
        {
            case 0:
                badGuy.GetComponent<BadGuyScript>().SetPathToFollow = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                break;
            case 1:
                badGuy.GetComponent<BadGuyScript>().SetPathToFollow = new int[] { 0, 19, 14, 7, 6, 5, 4, 9, 10, 11, 12, 18 };
                break;
            case 2:
                badGuy.GetComponent<BadGuyScript>().SetPathToFollow = new int[] { 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                break;
            case 3:
                badGuy.GetComponent<BadGuyScript>().SetPathToFollow = new int[] { 18, 12, 11, 10, 9, 4, 5, 6, 7, 14, 19, 0 };
                break;
        }


    }
    int DetermineBestSpawnPoint()  // based on player's location
    {
        int closestToPlayer = 0;
        // chance that spawnpoint will be randomly selected
        if (Random.Range(0, 6) < 2)
        {
            closestToPlayer = Random.Range(0, 4);
        }
        else
        {
            // chance that spawnpoint will be selected based on its distance from the player
            Vector2 playerLocation = GameObject.FindGameObjectWithTag("player").transform.position;

            for (int i = 0; i < spawnPoint.Length; i++)
            {
                if (Vector2.Distance(playerLocation, spawnPoint[i].transform.position) <
                    Vector2.Distance(playerLocation, spawnPoint[closestToPlayer].transform.position))
                {
                    closestToPlayer = i;
                }
            }
        }
        return closestToPlayer;
    }

}
