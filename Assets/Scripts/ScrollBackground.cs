using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField]Vector2 moveSpeed;

    Vector2 Offset;
    Material material;
    // Start is called before the first frame update
    void Awake()
    {
        material=GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        Offset=moveSpeed*Time.deltaTime;
        material.mainTextureOffset+=Offset;
    }

}
