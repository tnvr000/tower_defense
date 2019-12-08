using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    public GameManager gameManager;
    public Transform SpawnPoint;
    public float timeBewwenWaves = 5f;
    public Wave[] waves;
    public Text waveCountdownText;
    public static int enemiesAlive = 0;

    private int waveIndex = 0;
    private float waveCountdown = 2f;
    void Update()
    {
        if(enemiesAlive > 0) {
            return;
        } else if(enemiesAlive == 0 && waveIndex == waves.Length) {
            gameManager.LevelComplete();
            this.enabled = false;
            return;
        }

        if(waveCountdown <= 0)
        {
            StartCoroutine(SpawnWave());
            waveCountdown = timeBewwenWaves;
            return;
        }

        waveCountdown -= Time.deltaTime;
        waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", waveCountdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
