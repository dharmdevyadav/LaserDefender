using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New wave Config")]
public class WavesConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefebs;
    [SerializeField] Transform pathPrefeb;
    [SerializeField] float WaveSpeed=3f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float minimumTimeSpawn = 0.2f;
    [SerializeField] float spawnTimeVariance = 0f;


    public int GetEnemyCount()
    {
        return enemyPrefebs.Count;
    }
    public GameObject GetEnemyPrefebs(int index)
    {
        return enemyPrefebs[index];
    }


    public Transform GetStartingWayPoint()
    {
        return pathPrefeb.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform Child in pathPrefeb)
        {
            wayPoints.Add(Child);
        }
            
        return wayPoints;
    }
    public float GetMoveSpeed()
    {
        return WaveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float SpawnTime=Random.Range(timeBetweenEnemySpawn-spawnTimeVariance,timeBetweenEnemySpawn+spawnTimeVariance);

        return Mathf.Clamp(SpawnTime,minimumTimeSpawn,float.MaxValue);
    }
}
