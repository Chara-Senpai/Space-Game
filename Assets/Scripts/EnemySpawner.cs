using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPreFabs;

    float spawnDistance = 20f;
    float timeBetweenWaves = 5f;
    float timeBetweenSpawns = 0.5f;
    public int minEnemiesPerWave = 3;
    public int maxEnemiesPerWave = 6;

    private int currentWave = 1;
    private List<GameObject> aliveEnemies = new List<GameObject>();

    void Start()
    {

        StartCoroutine(SpawnWaveLoop());

    }

    IEnumerator SpawnWaveLoop()
    {

        while (true)
        {

            int enemiesToSpawn = Random.Range(minEnemiesPerWave, maxEnemiesPerWave + 1) + (currentWave - 1);
            Debug.Log($"Wave {currentWave} - Spawning {enemiesToSpawn} enemies");

            yield return StartCoroutine(SpawnWave(enemiesToSpawn));

            yield return new WaitUntil(() => aliveEnemies.Count == 0);

            currentWave++;
        }

    }

    IEnumerator SpawnWave(int count)
    {

        for (int i = 0; i < count; i++)
        {

            SpawnRandomEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);

        }

    }

    void SpawnRandomEnemy()
    {

        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        offset = offset.normalized * spawnDistance;

        int randomIndex = Random.Range(0, enemyPreFabs.Length);
        GameObject selectedEnemy = enemyPreFabs[randomIndex];

        GameObject enemy = Instantiate(selectedEnemy, transform.position + offset, Quaternion.identity);
        aliveEnemies.Add(enemy);

        EnemyDeathTracker tracker = enemy.AddComponent<EnemyDeathTracker>();
        tracker.spawner = this;

    }

    public void ReportEnemyDeath(GameObject enemy)
    {

        if (aliveEnemies.Contains(enemy))

        {

            aliveEnemies.Remove(enemy);

        }
        
    }
}
