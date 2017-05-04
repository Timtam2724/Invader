using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colourchanger : MonoBehaviour {

    bool glowing = true;
    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>(); // Remember to place the renderer before the coroutine to get renderer to function while the coroutine is functioning 
        StartCoroutine(Glow());
       
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Glow()
    {

        while (glowing) // What to do when glowing
        {            
            rend.material.SetColor("_Color", Color.green); // Use "_Color" for changing color in this script
            yield return new WaitForSeconds(1);
            rend.material.SetColor("_Color", Color.magenta);
            yield return new WaitForSeconds(1);
        }
    }
}
