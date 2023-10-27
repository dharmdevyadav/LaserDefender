using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefeb;
    [SerializeField] float ProjectileSpeed = 20f;
    [SerializeField] float ProjectiletimePeriod =5f;
    [SerializeField] float FireRate = 0.3f;
    Coroutine Firecoroutine;
    public bool isFiring;
    
    void Start()
    {
        
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
            yield return new WaitForSeconds(FireRate);
        }
        
    }
}
