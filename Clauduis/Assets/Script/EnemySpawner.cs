using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]WaveConfig waveConfig;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
	}
	
    IEnumerator SpawnEnemy()
    {
        for (float num = 0; num < waveConfig.GetNumberOfEnemy(); num++)
        {
            var spawnEnemy=Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoint()[0].transform.position, 
                Quaternion.identity);
            spawnEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
        }
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());

    }

}
