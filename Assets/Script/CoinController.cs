using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float timeSpawn;

    private GameObject spawnAreaCoin;
    private float timer;

    private void Start()
    {
        spawnAreaCoin = GameObject.FindGameObjectWithTag("SpawnAreaCoin");
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeSpawn)
        {
            spawnAreaCoin.GetComponent<SpawnCoinManager>().RemoveCoin(gameObject);
            timer -= timeSpawn;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            spawnAreaCoin.GetComponent<SpawnCoinManager>().RemoveCoin(gameObject);
        }
    }
}
