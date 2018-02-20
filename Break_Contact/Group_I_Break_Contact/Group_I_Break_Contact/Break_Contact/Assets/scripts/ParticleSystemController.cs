using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this ensures that the particle system is destroyed after finished playing
/// </summary>
public class ParticleSystemController : MonoBehaviour {

    ParticleSystem part;
	// Use this for initialization
	void Start () {
        part = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (part.isStopped)
        {
            Destroy(gameObject);
        }
	}
}
