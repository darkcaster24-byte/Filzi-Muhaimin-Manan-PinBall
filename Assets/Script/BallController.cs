using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // set max speed nya di inspector
	public float maxSpeed;

    private Rigidbody rig;
    private GameObject spawnPoint;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPointBall");
    }

    private void Update()
    {
            // cek besaran (magnitude) kecepatannya
        if (rig.velocity.magnitude > maxSpeed)
        {
                // kalau melebihi buat vector velocity baru dengan besaran max speed
        rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
