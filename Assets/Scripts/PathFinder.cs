using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    //GameObject gameObject;
    NewBehaviourScript enemySpawner;
    WavesConfigSO waveConfig;
    List<Transform> wayPoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<NewBehaviourScript>(); 
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < wayPoints.Count) 
        { 
            Vector3 targetPosition = wayPoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
