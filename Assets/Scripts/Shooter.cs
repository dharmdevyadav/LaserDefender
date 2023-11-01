using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject ProjectilePrefeb;
    [SerializeField] float ProjectileSpeed = 20f;
    [SerializeField] float ProjectiletimePeriod =5f;
    [SerializeField] float baseFiringRate = 0.2f;
    Coroutine Firecoroutine;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>(); 
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }

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
            float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVariance,
                                            baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayshootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);

        }

    }
}
