using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] List<WavesConfigSO> waveConfigs;
    [SerializeField] float waveChangetime=0f;
    [SerializeField]bool isLooping;
    WavesConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WavesConfigSO  GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WavesConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefebs(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0, 0, 180), transform);
                               

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(waveChangetime);
            }
        }
        while (isLooping);
        
        
    }
}
