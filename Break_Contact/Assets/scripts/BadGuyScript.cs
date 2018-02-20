using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour {


    [SerializeField]
    ParticleSystem part;

    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    Bullet bullet;

    Rigidbody2D brb;
    float bulletSpeed = 4.0f;

    float speed;

    Timer timer;

    int[] pathToFollow;

    int waypoint = 0;
    float spawnTimer = 5.0f;

    void Start () {

        speed = Random.Range(1.5f, 3.0f);
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = spawnTimer; // how long between spawns in seconds
        timer.Run();
    }
    public int[] SetPathToFollow
    {       
        set {pathToFollow = value; }
    }
    // Update is called once per frame
    void Update () {

        if (pathToFollow.Length > 0)
        { 

            float distance = Vector2.Distance(gameObject.transform.position, waypoints[pathToFollow[waypoint]].transform.position);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoints[pathToFollow[waypoint]].transform.position, Time.deltaTime * speed);
            if (distance <= .1f)
            {
                waypoint++;
                if (waypoint >= (pathToFollow.Length))
                {
                    Destroy(gameObject);
                }
            }
        }

        if (timer.Finished)
        {
            FireWeapon();
            timer.Run();
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
    /// fires a bullet
    /// </summary>
    void FireWeapon()
    {
        // Create new bullet which originates from the character's weapon muzzle
        Bullet firedBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        brb = firedBullet.GetComponent<Rigidbody2D>();
        Vector2 forceToAdd = (GameObject.FindGameObjectWithTag("player").transform.position - gameObject.transform.position).normalized;
        brb.AddForce(forceToAdd * bulletSpeed, ForceMode2D.Impulse);
    }
}
