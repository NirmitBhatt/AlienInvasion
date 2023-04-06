using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        while(canSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            int rand = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[rand], transform.position, Quaternion.identity);
        }
    }
}
