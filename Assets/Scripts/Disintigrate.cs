using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disintigrate : MonoBehaviour {

    public float lifeTime = 5f; //How long the bullet lasts on screen

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
