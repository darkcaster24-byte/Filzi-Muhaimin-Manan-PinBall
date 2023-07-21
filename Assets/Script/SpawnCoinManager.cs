using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinManager : MonoBehaviour
{
    public GameObject coinTemplate;
    public Vector3 spawnAreaCoinMin;
    public Vector3 spawnAreaCoinMax;
    public int maxCoin;
    public float spawnInterval;

    private List<GameObject> coinList;
    private float timer;

    private void Start()
    {
        coinList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomCoin();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomCoin()
    {
        GenerateCoin(new Vector3(Random.Range(spawnAreaCoinMin.x, spawnAreaCoinMax.x), transform.position.y, Random.Range(spawnAreaCoinMin.z, spawnAreaCoinMax.z)));
    }

    public void GenerateCoin(Vector3 position)
    {
        if (coinList.Count >= maxCoin)
        {
            return;
        }

        if (position.x < spawnAreaCoinMin.x ||
            position.x > spawnAreaCoinMax.x ||
            position.z < spawnAreaCoinMin.z ||
            position.z > spawnAreaCoinMax.z)
        {
            return;
        }

        GameObject coin = Instantiate(coinTemplate, new Vector3(position.x, transform.position.y, position.z), Quaternion.identity, transform);
        coinList.Add(coin);
    }

    public void RemoveCoin(GameObject coin)
    {
        coinList.Remove(coin);
        Destroy(coin);
    }
}
