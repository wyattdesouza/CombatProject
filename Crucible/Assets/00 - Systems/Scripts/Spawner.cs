using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnGap = 1f;
    [SerializeField] private float spawnCount = 10f;
    
    void Start()
    {
        StartCoroutine(SpawnBatch());
    }

    private IEnumerator SpawnBatch()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnGap);
        }
    }
}
