using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI WaveCount;
    public Transform enemyPrefab;
    public Transform SpawnPoint;
    public float timeBetweenWaves = 5.5f;
    private float countDown = 2f;

    private int waveIndex = 0;
    private void Update()
    {
        if (GameManager.GameEnd)
        {
            this.enabled = false;
            return;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
       
        countDown -= Time.deltaTime;
        countDown=Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        WaveCount.text =string.Format("{0:00.00}",countDown) ;
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
