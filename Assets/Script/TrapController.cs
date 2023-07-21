using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float timeSpawn;

    private GameObject spawnAreaTrap;
    private GameObject spawnPoint;
    private GameObject ball;
    private float timer;

    private void Start()
    {
        spawnAreaTrap = GameObject.FindGameObjectWithTag("SpawnAreaTrap");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPointBall");
        ball = GameObject.FindGameObjectWithTag("Ball");
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeSpawn)
        {
            spawnAreaTrap.GetComponent<SpawnTrapManager>().RemoveTrap(gameObject);
            timer -= timeSpawn;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ball.transform.position = spawnPoint.transform.position;
            spawnAreaTrap.GetComponent<SpawnTrapManager>().RemoveTrap(gameObject);
        }
    }
}
