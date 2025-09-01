using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling SharedInstance;
    public List<GameObject> pooledLaser;
    public GameObject laserToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        LaserPooling();
    }

    private void LaserPooling()
    {
        pooledLaser = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(laserToPool);
            tmp.SetActive(false);
            pooledLaser.Add(tmp);
        }
    }

    public GameObject GetPooledLaser()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledLaser[i].activeInHierarchy)
            {
                return pooledLaser[i];
            }
        }
        return null;
    }
}