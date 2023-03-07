using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = PoolManager_Enemy.Instance.GetPooledObjects(0, spawnPoint.position, Quaternion.identity);

            if (enemy != null)
            {
                enemy.SetActive(true);
                enemy.transform.position = spawnPoint.position;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}




