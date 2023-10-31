using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float ShakeMagnitude;
    [SerializeField]float ShakeDuration;

    Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
        
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < ShakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * ShakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
       
    }
    
}
