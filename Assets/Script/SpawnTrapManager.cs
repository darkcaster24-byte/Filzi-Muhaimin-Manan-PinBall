using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapManager : MonoBehaviour
{
    public GameObject trapTemplate;
    public Vector3 spawnAreaTrapMin;
    public Vector3 spawnAreaTrapMax;
    public int maxTrap;
    public float spawnInterval;

    private List<GameObject> trapList;
    private float timer;

    private void Start()
    {
        trapList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomTrap();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomTrap()
    {
        GenerateTrap(new Vector3(Random.Range(spawnAreaTrapMin.x, spawnAreaTrapMax.x), transform.position.y, Random.Range(spawnAreaTrapMin.z, spawnAreaTrapMax.z)));
    }

    public void GenerateTrap(Vector3 position)
    {
        if (trapList.Count >= maxTrap)
        {
            return;
        }

        if (position.x < spawnAreaTrapMin.x ||
            position.x > spawnAreaTrapMax.x ||
            position.z < spawnAreaTrapMin.z ||
            position.z > spawnAreaTrapMax.z)
        {
            return;
        }

        GameObject trap = Instantiate(trapTemplate, new Vector3(position.x, transform.position.y, position.z), Quaternion.identity, transform);
        trapList.Add(trap);
    }

    public void RemoveTrap(GameObject trap)
    {
        trapList.Remove(trap);
        Destroy(trap);
    }
}
