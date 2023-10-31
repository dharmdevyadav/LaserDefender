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
<<<<<<< HEAD
                    Instantiate(currentWave.GetEnemyPrefebs(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
=======
                    Instantiate(currentWave.GetEnemyPrefebs(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0, 0, 180), transform);
                               

>>>>>>> e1d3feaebcfebf39a6785d161f217fa3552774e3
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(waveChangetime);
            }
        }
        while (isLooping);
        
        
    }
}
