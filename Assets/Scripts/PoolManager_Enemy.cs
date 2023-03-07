using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager_Enemy : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string parentName;
        public GameObject prefab;
        public int size;
        public List<GameObject> pooledObjects;
    }

    public List<Pool> poolsList;


    public static PoolManager_Enemy Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameObject obj;
        foreach (Pool pool in poolsList)
        {
            GameObject parent = new GameObject(pool.parentName);

            for (int i = 0; i < pool.size; i++)
            {
                obj = Instantiate(pool.prefab);
                obj.transform.SetParent(parent.transform);
                obj.SetActive(false);
                pool.pooledObjects.Add(obj);
            }
        }

    }

    public void ResetEnemy(GameObject enemy)
    {
        enemy.transform.position = Vector3.zero;
        enemy.transform.rotation = Quaternion.identity;
        enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemy.SetActive(true);
    }


    public GameObject GetPooledObjects(int bulletType, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < poolsList[bulletType].size; i++)
        {
            if (!poolsList[bulletType].pooledObjects[i].activeInHierarchy)
            {
                GameObject objectToSpawn = poolsList[bulletType].pooledObjects[i];
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                objectToSpawn.SetActive(true); 
                return objectToSpawn;
            }
        }
        return null;
    }


}
