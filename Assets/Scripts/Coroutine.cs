using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour {

    bool ticking = true;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Clock());
	}

    IEnumerator Clock()
    {
        if (ticking) // Instructions on what to do if ticking is true
        {
            print("Tick");
            yield return new WaitForSeconds(1); // Tells the script to wait for 1 second
            transform.Translate(transform.forward / 5);
            print("Tock");
            yield return new WaitForSeconds(3);
            transform.Translate(transform.forward / 5);
        }
    }
}
