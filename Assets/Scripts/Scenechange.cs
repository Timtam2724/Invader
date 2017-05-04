using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenechange : MonoBehaviour {

    public float scrollSpeed = 0.5f; // Speed of scrolling
    public Renderer rend; // Helps assign what gets rended

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () { //Makes material on object scroll
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
