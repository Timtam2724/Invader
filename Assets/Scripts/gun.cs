using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gun : MonoBehaviour
{
    public AudioClip shootSound;

    private AudioSource source; // plays 8-bit invader like sound clip, sounf varies on lower variable
    private float volLowRange = .5f; // minimum Range
    private float volHighRange = 1.0f; // Maximum Range
    private float lowPitchRange = .75F; // Minimum Pitch
    private float highPitchRange = 1.5F; // Maximum Pitch


    public GameObject LaserBeam;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Creates Laser beam from player's gun
        {
            Instantiate(LaserBeam, transform.position, transform.rotation);

            float vol = Random.Range(volLowRange, volHighRange);
            source.pitch = Random.Range(lowPitchRange, highPitchRange);
            source.PlayOneShot(shootSound, vol);
        }
        RaycastHit hitRef;
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, transform.forward, out hitRef))
        {
            hitRef.transform.GetComponent<Rigidbody>().AddForce((hitRef.transform.position - hitRef.point) * 10);
        }
    }
}
