using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject ExplosionPrefab;
    public GameObject FlyingSaucer; // Lets player know who is the flying Saucer

    private Rigidbody rb;
    private Rigidbody rigid;
    private Vector3 startPos;

    

    // Use this for initialization
    void Start () {
        startPos = transform.position;
        rigid = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow)) // Makes player move
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -10);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "FlyingSaucer")
        {
            Die();
            transform.position = startPos;
            rigid.velocity = Vector3.zero;
        }

    }
    void Die()
    {
        PlayExplosion();
    }
    void PlayExplosion()
    {
        GameObject clone = Instantiate(ExplosionPrefab);
        clone.transform.position = transform.position;
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
        explosion.Play();
    }
}

