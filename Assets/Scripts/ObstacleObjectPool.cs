using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public Vector3 spawnPos = new(25, 0, 0);
    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerController;

    private List<Queue<GameObject>> obstaclePools = new();

    public int poolSizePerType = 2;

    void Start()
    {

        foreach (var prefab in obstaclePrefabs)
        {
            Queue<GameObject> pool = new Queue<GameObject>();

            for (int i = 0; i < poolSizePerType; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }

            obstaclePools.Add(pool);
        }

        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Count);
        var pool = obstaclePools[index];

        GameObject objToSpawn = null;

        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                objToSpawn = obj;
                break;
            }
        }

        if (objToSpawn == null)
        {
            objToSpawn = Instantiate(obstaclePrefabs[index]);
            objToSpawn.SetActive(false);
            pool.Enqueue(objToSpawn);
        }

        objToSpawn.transform.position = spawnPos;
        objToSpawn.transform.rotation = obstaclePrefabs[index].transform.rotation;
        objToSpawn.SetActive(true);
    }

}
