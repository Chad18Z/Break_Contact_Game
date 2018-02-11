using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
