using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject ExplosionPrefab;
    public float movementSpeed = 20f; // Adjusts how fast the spawner moves
    public Transform[] patrolPoints; // The points where the Spawner moves back and forwards

    private int currentPoint = 0;
    private Rigidbody rigid;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Movement(); // Makes the Spawner follow the Movement script to function continously 
    }
    void Movement() // Moves the Spawner between the patrol points
    {
        if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }

        Vector3 movePos = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, movementSpeed * Time.deltaTime);
        transform.position = movePos;
    }

}
