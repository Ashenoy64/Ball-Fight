using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject prefab;
    public GameObject powerups;
    private float spawnRange = 9;

    public int enemyCount = 1;
    private int waveNumber = 1;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerups, GenerateSpawnPosition(), powerups.transform.rotation);
    }

    void SpawnEnemyWave(int number)
    {
        for(int i=0;i<number;++i)
        {
            Instantiate(prefab, GenerateSpawnPosition(), prefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosx, 0, spawnPosZ);
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0 )
        {
            Instantiate(powerups, GenerateSpawnPosition(), powerups.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
}
