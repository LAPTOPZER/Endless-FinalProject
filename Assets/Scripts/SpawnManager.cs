using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject obstaclePrefab;
    public List<GameObject> obstaclePrefab;
    public Vector3 spawnPos = new(25, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         //Instantiate(obstaclePrefab, new Vector3(25, 0, 0), obstaclePrefab.transform.rotation);

        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);

        GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        int prop = Random.Range(0, 3);
        Instantiate(obstaclePrefab[prop], spawnPos, obstaclePrefab[prop].transform.rotation);
    }
}
