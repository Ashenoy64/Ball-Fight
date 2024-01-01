using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpawnManger : MonoBehaviour
{
    public GameObject prefab;
    public GameObject powerups;
    private float spawnRange = 9;

    public int enemyCount = 1;
    private int waveNumber = 1;
    public TextMeshProUGUI waveCount;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void SpawnEnemyWave(int number)
    {
        for(int i=0;i<number;++i)
        {
            Instantiate(prefab, GenerateSpawnPosition(), prefab.transform.rotation);
        }

        SpawnPowerUps(Mathf.CeilToInt(Random.Range(1,3)));
    }

    void SpawnPowerUps(int number)
    {
        for (int i = 0; i < number; ++i)
        {
            Instantiate(powerups, GenerateSpawnPosition(), powerups.transform.rotation);
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
            waveNumber++;
            waveCount.text = "Wave : " + waveNumber;
            SpawnEnemyWave(waveNumber);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
