using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject ProjectilePrefeb;
    [SerializeField] float ProjectileSpeed = 20f;
    [SerializeField] float ProjectiletimePeriod =5f;
<<<<<<< HEAD
    [SerializeField] float baseFireRate = 0.3f;
    Coroutine Firecoroutine;
    [HideInInspector]public bool isFiring;
    [Header("AI System")]
    [SerializeField] bool UseAI;
    [SerializeField] float FiringRateVariance = 0f;
    [SerializeField] float MinimumFireRate = 0.1f;
    void Start()
    {
        if (UseAI)
        {
            isFiring = true;
        }
=======
    [SerializeField] float baseFiringRate = 0.3f;
    Coroutine Firecoroutine;
    [HideInInspector]public bool isFiring;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;


    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }


>>>>>>> e1d3feaebcfebf39a6785d161f217fa3552774e3
    }


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && Firecoroutine ==null)
        {
            Firecoroutine = StartCoroutine(FireContinuously());
            
        }
        else if(!isFiring && Firecoroutine!=null)
        {
            StopCoroutine(Firecoroutine);
            Firecoroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(ProjectilePrefeb, transform.position, Quaternion.identity);
            Rigidbody2D rb=instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * ProjectileSpeed;
                
            }
            Destroy(instance, ProjectiletimePeriod);

<<<<<<< HEAD
            float timeTONextProjectile = UnityEngine.Random.Range(baseFireRate - FiringRateVariance, baseFireRate + FiringRateVariance);
            timeTONextProjectile = Mathf.Clamp(timeTONextProjectile,MinimumFireRate,float.MaxValue);

            yield return new WaitForSeconds(timeTONextProjectile);
=======
            float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVariance,
                                            baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);


           
>>>>>>> e1d3feaebcfebf39a6785d161f217fa3552774e3
        }
        
    }
}
